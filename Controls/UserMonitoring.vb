Public Class UserMonitoring
    Public Sub LoadMeteo(ByVal Region As String, ByVal Ko As String, ByVal Ok As String)
        Dim UserMeteo As New UserMeteo
        UserMeteo.Region = Region
        UserMeteo.KO = Ko
        UserMeteo.OK = Ok


        UserMeteo.Dock = DockStyle.Left
        'Dim InfoServer = WidgetView1.AddDocument(UserMeteo)
        Me.Controls.Add(UserMeteo)
        'WindowsUIView1.Controller.Select(CType(InfoServer, DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document))
    End Sub
End Class
