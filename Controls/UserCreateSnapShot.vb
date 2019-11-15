Public Class UserCreateSnapShot
    Private _Node As DevComponents.AdvTree.Node
    Public Property Node As DevComponents.AdvTree.Node
        Get
            Return _Node
        End Get
        Set(value As DevComponents.AdvTree.Node)
            _Node = value
        End Set
    End Property
    Private _RegionEndpoint As Amazon.RegionEndpoint
    Public Property RegionEndpoint As Amazon.RegionEndpoint
        Get
            Return _RegionEndpoint
        End Get
        Set(value As Amazon.RegionEndpoint)
            _RegionEndpoint = value
        End Set
    End Property
    Private _Profile As String
    Public Property Profile As String
        Get
            Return _Profile
        End Get
        Set(value As String)
            _Profile = value
        End Set
    End Property
    Private _TypeAction As String
    Public Property TypeAction As String
        Get
            Return _TypeAction

        End Get
        Set(value As String)
            _TypeAction = value
        End Set
    End Property
    Private etat As Integer = 0
    Private _DbSnapShot As Amazon.RDS.Model.DBSnapshot
    Public Sub StartSnapShop()
        circularGauge14.Labels(0).Text = ""
        circularGauge14.RangeBars(0).Value = 0
        _TypeAction = "GetSnapShotPercentProgress"
        _DbSnapShot = CreateSnapShot(_Node, _RegionEndpoint, _Profile)
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Do While etat = 0
            Dim etat2 As Integer = 0
            Select Case _TypeAction
                Case "GetSnapShotPercentProgress"
                    etat2 = GetSnapShotPercentProgress(_Node.Tag, _RegionEndpoint, _DbSnapShot, _Profile)
            End Select


            If etat2 = 100 Then
                etat = 100

            End If

            BackgroundWorker1.ReportProgress(etat2)
            System.Threading.Thread.Sleep(5000)
        Loop


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Select Case _TypeAction
            Case "GetSnapShotPercentProgress"
                DevComponents.DotNetBar.Controls.DesktopAlert.Show("SnapShot Finish : ", DevComponents.DotNetBar.Controls.eDesktopAlertColor.Green, DevComponents.DotNetBar.Controls.eAlertPosition.BottomRight)
                Me.Dispose()
        End Select
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        circularGauge14.Labels(0).Text = e.ProgressPercentage
        circularGauge14.RangeBars(0).Value = e.ProgressPercentage
    End Sub
End Class
