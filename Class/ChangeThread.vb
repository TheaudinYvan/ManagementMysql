Imports System.ComponentModel
Imports System.Threading

Public Class ChangeThread
    Private ReadOnly collection As New BindingList(Of MarketData)()
    Public ReadOnly Property List() As IList
        Get
            Return Me.collection
        End Get
    End Property
    Public InterEventDelay As Integer = 1024000
    Private needStop As Boolean
    Private ReadOnly context As SynchronizationContext
    Private ReadOnly changesWatch As Stopwatch = Stopwatch.StartNew()
    Private changes As Integer
    Public Function GetRate() As Double?
        Dim interval = changesWatch.Elapsed
        If interval = TimeSpan.Zero Then
            Return Nothing
        End If
        changesWatch.Restart()
        Dim currentChanges = CDbl(Interlocked.Exchange(changes, 0))
        Try
            Dim resultRate = currentChanges / interval.TotalSeconds
            If resultRate >= 0.0 AndAlso resultRate < Single.MaxValue Then
                Return resultRate
            End If
        Catch
        End Try
        Return Nothing
    End Function
    Public Sub New(ByVal context As SynchronizationContext)
        Dim data() As String = {"ANR", "FE", "GT", "PRGO", "APD", "PPL", "AES", "AVB", "IBM", "GAS", "EFX", "GPC", "ICE", "IVZ", "KO", "CCE", "SO", "STI", "BWA", "HRL", "WFM", "LM", "TROW", "K", "EXPE", "PCAR", "TRIP", "WHR", "WMT", "NU", "HST", "CVH", "LMT", "MAR", "CVC", "RF", "VMC", "PHM", "MU", "IRM", "AMT", "BXP", "STT", "PBCT", "FISV", "BLL", "MTB", "DIS", "LH", "AKAM", "CPB", "MYL", "LIFE", "LEG", "SCG", "CNX", "COL", "MCHP", "GR", "DUK", "BAC", "NUE", "UNM", "DLTR", "ABC", "TEG", "RRD", "EQR", "EXC", "BA", "CME", "NTRS", "VTR", "FITB", "PG", "KR", "M", "SNI", "ETN", "CLF", "PH", "KEY", "SHW", "HD", "AFL", "TSS", "CMI", "HBAN", "AEP", "BIG", "LTD", "ESRX", "GLW", "WPI", "MON", "AAPL", "DF", "T", "CMA", "THC", "LUV", "TXN", "TIE", "PX"}

        Me.context = context
        For Each name As String In data
            collection.Add(New MarketData(name))
        Next name
    End Sub
    Public Sub [Do]()
        Dim rndRow As New Random()
        Do
            Dim delayPerRow = Volatile.Read(InterEventDelay)
            If delayPerRow = 0 Then
                For i As Integer = 0 To 1023
                    UpdateRandomRow()
                Next i
            Else
                Dim rows As Integer = CInt(Math.Min(Math.Max(TimeSpan.TicksPerSecond / delayPerRow / 25, 1), 4096))
                For i As Integer = 0 To rows - 1
                    UpdateRandomRow()
                Next i
                Dim totalDelay = TimeSpan.FromTicks(rows * CLng((delayPerRow)))
                Dim watch As Stopwatch = Stopwatch.StartNew()
                Do
                    Dim elapsed = watch.Elapsed
                    If elapsed >= totalDelay Then
                        Exit Do
                    End If
                    Dim diffTicks = (totalDelay.Subtract(elapsed)).Ticks
                    If diffTicks > TimeSpan.TicksPerMillisecond \ 100 Then
                        Thread.Sleep(CInt(diffTicks \ TimeSpan.TicksPerMillisecond))
                    End If
                Loop
                watch.Stop()
            End If
        Loop While Not Volatile.Read(needStop)
    End Sub
    Private Sub UpdateRandomRow()
        Dim row = MarketData.Rnd.Next(0, collection.Count)
        collection(row).Update()
        collection.ResetItem(row)
        Interlocked.Increment(changes)
    End Sub
    Public Sub [Stop]()
        Volatile.Write(needStop, True)
    End Sub
End Class

Public Class MarketData
    Friend Shared ReadOnly Rnd As New Random()
    Private Const MAX As Double = 950
    Private Const MIN As Double = 350
    Private privateTicker As String
    Public Property Ticker() As String
        Get
            Return privateTicker
        End Get
        Private Set(ByVal value As String)
            privateTicker = value
        End Set
    End Property
    Private privateLast As Double
    Public Property Last() As Double
        Get
            Return privateLast
        End Get
        Private Set(ByVal value As Double)
            privateLast = value
        End Set
    End Property
    Private privateChgPercent As Double
    Public Property ChgPercent() As Double
        Get
            Return privateChgPercent
        End Get
        Private Set(ByVal value As Double)
            privateChgPercent = value
        End Set
    End Property
    Private privateChg As Double
    Public Property Chg() As Double
        Get
            Return privateChg
        End Get
        Private Set(ByVal value As Double)
            privateChg = value
        End Set
    End Property
    Private privateOpen As Double
    Public Property Open() As Double
        Get
            Return privateOpen
        End Get
        Private Set(ByVal value As Double)
            privateOpen = value
        End Set
    End Property
    Private privateHigh As Double
    Public Property High() As Double
        Get
            Return privateHigh
        End Get
        Private Set(ByVal value As Double)
            privateHigh = value
        End Set
    End Property
    Private privateLow As Double
    Public Property Low() As Double
        Get
            Return privateLow
        End Get
        Private Set(ByVal value As Double)
            privateLow = value
        End Set
    End Property
    Private dayValCore As Double
    Public Property DayVal() As Double
        Get
            Return Math.Round(dayValCore, 1)
        End Get
        Private Set(ByVal value As Double)
            dayValCore = value
        End Set
    End Property

    Public Sub New(ByVal name As String)
        Ticker = name
        Open = Math.Round((NextRnd() * (MAX - MIN)) + MIN, 1)
        DayVal = Open
        UpdateInternal(Open)
    End Sub
    Public Sub Update()
        Dim value As Double = Math.Round(DayVal - (MAX - MIN) * 0.05 + NextRnd() * (MAX - MIN) * 0.1, 1)
        If value <= MIN Then
            value = MIN
        End If
        If value >= MAX Then
            value = MAX
        End If
        UpdateInternal(value)
    End Sub
    Private Sub UpdateInternal(ByVal dayVal As Double)
        Last = Me.DayVal
        Me.DayVal = dayVal
        Chg = Me.DayVal - Last
        ChgPercent = Math.Round(Chg / Me.DayVal * 100, 2)
        High = Math.Max(Open, Math.Max(Me.DayVal, Last))
        Low = Math.Min(Open, Math.Min(Me.DayVal, Last))
    End Sub
    Private Function NextRnd() As Double
        Return (Rnd.NextDouble() + Rnd.NextDouble() + Rnd.NextDouble() + Rnd.NextDouble() + Rnd.NextDouble()) / 5
    End Function
End Class