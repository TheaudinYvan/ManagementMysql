Public Class UserDroitDbModele

    Public IdGroupAws As String

    Private Sub UserDroitDbModele_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim rd As DataSetData.DroitsRow = ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Select("IdGroupAws='" & IdGroupAws.ToString & "' AND TypeServer='Mariadb' AND TypeDroit='User'").FirstOrDefault
        Dim arrdr As List(Of String) = Nothing

        If rd IsNot Nothing Then

            arrdr = New List(Of String)(rd.DroitCSV.Split(";"c))
        End If


        For Each MariadUser In ManagementMysql.ManagementMysqlApp.ManagementMysqlApplication.MariadbUser

            Dim ch As New DevExpress.XtraEditors.Controls.CheckedListBoxItem
            ch.Value = MariadUser
            If arrdr IsNot Nothing Then
                If arrdr.Contains(MariadUser) Then
                    ch.CheckState = CheckState.Checked
                End If
            End If


            CheckedListUserMariadb.Items.Add(ch)
        Next

        rd = ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Select("IdGroupAws='" & IdGroupAws.ToString & "' AND TypeServer='Mariadb' AND TypeDroit='Db'").FirstOrDefault

        If rd IsNot Nothing Then

            arrdr = New List(Of String)(rd.DroitCSV.Split(";"c))
        End If

        For Each MariadDB In ManagementMysql.ManagementMysqlApp.ManagementMysqlApplication.MariadbDb
            Dim ch As New DevExpress.XtraEditors.Controls.CheckedListBoxItem
            ch.Value = MariadDB
            If arrdr IsNot Nothing Then
                If arrdr.Contains(MariadDB) Then
                    ch.CheckState = CheckState.Checked
                End If
            End If
            CheckedListDbMariadb.Items.Add(ch)
        Next



        rd = ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Select("IdGroupAws='" & IdGroupAws.ToString & "' AND TypeServer='MySQL' AND TypeDroit='User'").FirstOrDefault

        If rd IsNot Nothing Then

            arrdr = New List(Of String)(rd.DroitCSV.Split(";"c))
        End If

        For Each MySQLUser In ManagementMysql.ManagementMysqlApp.ManagementMysqlApplication.MysqlUser

            Dim ch As New DevExpress.XtraEditors.Controls.CheckedListBoxItem
            ch.Value = MySQLUser
            If arrdr IsNot Nothing Then
                If arrdr.Contains(MySQLUser) Then
                    ch.CheckState = CheckState.Checked
                End If
            End If

            CheckedListUserMySQL.Items.Add(ch)
        Next

        rd = ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Select("IdGroupAws='" & IdGroupAws.ToString & "' AND TypeServer='MySQL' AND TypeDroit='Db'").FirstOrDefault

        If rd IsNot Nothing Then

            arrdr = New List(Of String)(rd.DroitCSV.Split(";"c))
        End If

        For Each MySQLDB In ManagementMysql.ManagementMysqlApp.ManagementMysqlApplication.MysqlDb

            Dim ch As New DevExpress.XtraEditors.Controls.CheckedListBoxItem
            ch.Value = MySQLDB
            If arrdr IsNot Nothing Then
                If arrdr.Contains(MySQLDB) Then
                    ch.CheckState = CheckState.Checked
                End If
            End If
            CheckedListDbMySQL.Items.Add(ch)
        Next









    End Sub
    Private currentlistbox As DevExpress.XtraEditors.CheckedListBoxControl
    Private Sub CheckedListUserMariadb_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckedListUserMariadb.MouseClick
        If e.Button = MouseButtons.Right Then
            'Dim p As Point = New Point(e.X, e.Y)
            currentlistbox = CheckedListUserMariadb
            PopupMenu1.ShowPopup(Control.MousePosition)

            'CType(PopupMenu1, DevExpress.Utils.Menu.IDXDropDownControl).Show(New DevExpress.Utils.Menu.SkinMenuManager(DevExpress.LookAndFeel.Design.UserLookAndFeelDefault.Default), Me, e.Location)
        End If
    End Sub




    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If currentlistbox IsNot Nothing Then
            currentlistbox.CheckAll()
            currentlistbox = Nothing

        End If

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If currentlistbox IsNot Nothing Then
            currentlistbox.UnCheckAll()
            currentlistbox = Nothing

        End If
    End Sub

    Private Sub CheckedListDbMariadb_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckedListDbMariadb.MouseClick
        If e.Button = MouseButtons.Right Then
            'Dim p As Point = New Point(e.X, e.Y)
            currentlistbox = CheckedListDbMariadb
            PopupMenu1.ShowPopup(Control.MousePosition)
        End If
    End Sub

    Private Sub CheckedListUserMySQL_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckedListUserMySQL.MouseClick
        If e.Button = MouseButtons.Right Then
            'Dim p As Point = New Point(e.X, e.Y)
            currentlistbox = CheckedListUserMySQL
            PopupMenu1.ShowPopup(Control.MousePosition)
        End If
    End Sub

    Private Sub CheckedListDbMySQL_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckedListDbMySQL.MouseClick
        If e.Button = MouseButtons.Right Then
            'Dim p As Point = New Point(e.X, e.Y)
            currentlistbox = CheckedListDbMySQL
            PopupMenu1.ShowPopup(Control.MousePosition)
        End If
    End Sub

    Private Sub XtraTabControl1_CustomHeaderButtonClick(sender As Object, e As DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs) Handles XtraTabControl1.CustomHeaderButtonClick


        For Each rd As DataRow In ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Select("IdGroupAws='" & IdGroupAws.ToString & "'")
            rd.Delete()
        Next



        Dim r As DataSetData.DroitsRow = ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.NewDroitsRow

        r.IdGroupAws = IdGroupAws
        r.id = Guid.NewGuid
        r.TypeServer = "Mariadb"
        r.TypeDroit = "User"
        Dim arrdroit As New ArrayList
        For Each c As DevExpress.XtraEditors.Controls.CheckedListBoxItem In CheckedListUserMariadb.Items
            If c.CheckState = CheckState.Checked Then
                arrdroit.Add(c.Value)
            End If
        Next
        r.DroitCSV = String.Join(";", arrdroit.ToArray)
        ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Rows.Add(r)

        r = ManagementMysql.ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.NewDroitsRow

        r.IdGroupAws = IdGroupAws
        r.id = Guid.NewGuid
        r.TypeServer = "Mariadb"
        r.TypeDroit = "Db"
        arrdroit = New ArrayList
        For Each c As DevExpress.XtraEditors.Controls.CheckedListBoxItem In CheckedListDbMariadb.Items
            If c.CheckState = CheckState.Checked Then
                arrdroit.Add(c.Value)
            End If
        Next
        r.DroitCSV = String.Join(";", arrdroit.ToArray)
        ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Rows.Add(r)


        r = ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.NewDroitsRow

        r.IdGroupAws = IdGroupAws
        r.id = Guid.NewGuid
        r.TypeServer = "MySQL"
        r.TypeDroit = "User"
        arrdroit = New ArrayList
        For Each c As DevExpress.XtraEditors.Controls.CheckedListBoxItem In CheckedListUserMySQL.Items
            If c.CheckState = CheckState.Checked Then
                arrdroit.Add(c.Value)
            End If
        Next
        r.DroitCSV = String.Join(";", arrdroit.ToArray)
        ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Rows.Add(r)

        r = ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.NewDroitsRow

        r.IdGroupAws = IdGroupAws
        r.id = Guid.NewGuid
        r.TypeServer = "MySQL"
        r.TypeDroit = "Db"
        arrdroit = New ArrayList
        For Each c As DevExpress.XtraEditors.Controls.CheckedListBoxItem In CheckedListDbMySQL.Items
            If c.CheckState = CheckState.Checked Then
                arrdroit.Add(c.Value)
            End If
        Next
        r.DroitCSV = String.Join(";", arrdroit.ToArray)
        ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Rows.Add(r)


    End Sub
End Class
