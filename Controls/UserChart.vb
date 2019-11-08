Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports Amazon.CloudWatch
Imports System.Windows
Imports Amazon.CloudWatch.Model
Imports DevExpress.XtraCharts
Imports AwsGestion.Chart.Annotations
Imports DevExpress.Data
Imports System.Threading

Public Class UserChart
    'Implements INotifyPropertyChanged
    Public id As String
    Private chtr As ChangeThread
    Private tr As Thread
    Private realTimeSource As RealTimeSource
    'Public ConfiChart As AwsGestionApp.ConfiChart
    Public ConcatChart As New List(Of ManagementMysqlApp.ConfiChart)
    'Private mQuotaInfo As ObjectModel.ObservableCollection(Of LineData)
    Private StatsDataTable As New DataSetTmp.StatsDataTable
    Private Const interval As Integer = 20
    Private TimeInterval As Integer = 10
    Private CountMod As Integer = 0
    Public StopBackGroundWorker As Boolean = True
    Private Sub LoadData()

        For Each ConfiChart As ManagementMysqlApp.ConfiChart In ConcatChart

            Dim client = New AmazonCloudWatchClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(ConfiChart.profile, "", False), ConfiChart.RegionEndpoint)
            ConfiChart.Request.StartTimeUtc = DateTime.UtcNow.Subtract(New TimeSpan(0, 30, 0))
            ConfiChart.Request.EndTimeUtc = DateTime.UtcNow
            'ConfiChart.dimension = Nothing
            Dim response As GetMetricStatisticsResponse = client.GetMetricStatistics(ConfiChart.Request)
            Try

                CountMod += response.Datapoints.Count
                For Each metric In response.Datapoints

                    Dim r As DataSetTmp.StatsRow = StatsDataTable.NewStatsRow
                    r.DateInfo = metric.Timestamp
                    r.Value = metric.Average
                    r.InstancesAndRegion = ConfiChart.dimension.Value & ConfiChart.RegionEndpoint.SystemName
                    StatsDataTable.AddStatsRow(r)
                Next
                'ChartControl1.RefreshData()

                ' Console.WriteLine(StatsDataTable.Count)
                'If CountMod Mod 60 = 0 Then

                'End If

                For Each c In ConcatChart

                    Dim StatPurge As Integer = StatsDataTable.Select(" InstancesAndRegion ='" & c.dimension.Value & c.RegionEndpoint.SystemName & "'").Count - 1000
                    If StatPurge > 30 Then
                        Dim Rows = StatsDataTable.Select(" InstancesAndRegion ='" & c.dimension.Value & c.RegionEndpoint.SystemName & "'", "id ASC")

                        For z As Integer = 0 To 30
                            StatsDataTable.RemoveStatsRow(CType(Rows(z), DataSetTmp.StatsRow))
                        Next
                    End If

                    'Console.WriteLine(StatsDataTable.Select(" InstancesAndRegion ='" & c.dimension.Value & c.RegionEndpoint.SystemName & "'").Count)
                Next


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Next
        'ChartControl1.Series(0).Points.Add(SeriesPointCollection)
    End Sub




    Public Sub StartStatLoad()
        BackgroundWorker1.RunWorkerAsync()
        'DataGridView1.DataSource = StatsDataTable
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub
    Public Sub MaxIS()
        ChartPrintExportBar1.Visible = Not ChartPrintExportBar1.Visible
        ChartTypeBar1.Visible = Not ChartTypeBar1.Visible
        ChartWizardBar1.Visible = Not ChartWizardBar1.Visible
        ChartTypeBar1.Visible = Not ChartTypeBar1.Visible
        ChartAppearanceBar1.Visible = Not ChartAppearanceBar1.Visible
        RangeControl1.Visible = Not RangeControl1.Visible
        'DataGridView1.Visible = Not DataGridView1.Visible
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork




        'ChartControl1.DataSource = StatsDataTable


        'ChartControl1.Series(0).ArgumentDataMember = "Sample"
        While StopBackGroundWorker = True
            System.Threading.Thread.Sleep(1000)
            BackgroundWorker1.ReportProgress(1)
            System.Threading.Thread.Sleep(1000)
            BackgroundWorker1.ReportProgress(1)
            System.Threading.Thread.Sleep(1000)
            BackgroundWorker1.ReportProgress(1)
            System.Threading.Thread.Sleep(1000)
            BackgroundWorker1.ReportProgress(1)
            System.Threading.Thread.Sleep(1000)
            BackgroundWorker1.ReportProgress(1)
            LoadData()
        End While



    End Sub
    'Public Event PropertyChanged As PropertyChangedEventHandler
    'Private Event INotifyPropertyChanged_PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    '<NotifyPropertyChangedInvocator>
    'Protected Overridable Sub OnPropertyChanged(
    '<CallerMemberName> ByVal Optional propertyName As String = Nothing)
    'End Sub
    'Public Property QuotaInfo As ObservableCollection(Of LineData)
    '    Get
    '        Return mQuotaInfo
    '    End Get
    '    Set(ByVal value As ObservableCollection(Of LineData))
    '        If Equals(value, mQuotaInfo) Then Return
    '        mQuotaInfo = value
    '        OnPropertyChanged()
    '    End Set
    'End Property


    Private Sub UserChart_Load(sender As Object, e As EventArgs) Handles Me.Load
        'QuotaInfo = New ObservableCollection(Of LineData)()
        'DataContext = Me
        realTimeSource = New RealTimeSource() With {.DataSource = StatsDataTable}
        Dim i As Integer = 0
        For Each serie As Series In ChartControl1.Series
            serie.DataSource = realTimeSource
            If i = 1 Then
                ChartControl1.Titles(i).Visibility = DevExpress.Utils.DefaultBoolean.False
            End If
            i += 1
        Next
        GridControl1.DataSource = realTimeSource
    End Sub



    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If CType(BarEditItem2.EditValue, Integer) = 5 Then
            BarEditItem2.EditValue = 0
        End If

        BarEditItem2.EditValue = CType(BarEditItem2.EditValue, Integer) + e.ProgressPercentage
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        MaxIS()
    End Sub
End Class
'Public Class QuotaData
'    Public Property QuotaName As String
'    Public Property SampleCount As Integer
'    Public Property HighRange As Integer
'    Public Property LowRange As Integer
'    Public Property Completed As Integer
'    Public Property Range As String
'    Public Property MaxRange As Double
'    Public Property ChartData As Dictionary(Of Integer, String)
'    Public Property Message As String

'    Public Sub New(ByVal name As String, ByVal sampleCount As Integer, ByVal highRange As Integer, ByVal lowRange As Integer, ByVal completed As Integer, ByVal range As String, ByVal message As String)
'        QuotaName = name
'        sampleCount = sampleCount
'        highRange = highRange
'        lowRange = lowRange
'        completed = completed
'        MaxRange = highRange * 1.2
'        range = range
'        message = message
'        ChartData = New Dictionary(Of Integer, String) From {
'            {sampleCount, "Sample"},
'            {completed, "Completed"}
'        }
'    End Sub
'End Class
'Public Class LineData
'    Public Property QuotaDate As DateTime
'    Public Property SampleCount As Double

'    Public Property ChartData As Dictionary(Of Double, String)


'    Public Sub New(ByVal QuotaDate As DateTime, ByVal sampleCount As Double, ByVal completed As Integer)
'        QuotaDate = QuotaDate
'        sampleCount = sampleCount
'        'If ChartData.ContainsKey(sampleCount) Then

'        'End If
'        ChartData = New Dictionary(Of Double, String) From {
'            {sampleCount, "Sample"}
'        }
'    End Sub
'End Class
