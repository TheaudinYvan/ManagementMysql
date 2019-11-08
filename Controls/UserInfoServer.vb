Public Class UserInfoServer
    Public Sub InsertInfoServer(ByVal NameServer As String, ByVal DbInstance As Amazon.RDS.Model.DBInstance, ByVal TableSnapshot As DataTable)

        Dim DeleteDoc As DevExpress.XtraBars.Docking2010.Views.BaseDocument = Nothing

        For Each z As DevExpress.XtraBars.Docking2010.Views.BaseDocument In WidgetView1.Documents
            If z.Caption = NameServer Then
                DeleteDoc = z
            End If
        Next

        If DeleteDoc IsNot Nothing Then
            DeleteDoc.Dispose()
        End If

        Dim UserInfoServerDetail As New UserInfoServerDetail
        UserInfoServerDetail.PropertyGridControl1.SelectedObject = DbInstance
        UserInfoServerDetail.VGridControl1.DataSource = TableSnapshot



        'PropertyGridControl.
        Dim pRDS As DevExpress.XtraBars.Docking2010.Views.BaseDocument = WidgetView1.AddDocument(UserInfoServerDetail)
        pRDS.Caption = NameServer
    End Sub


End Class
