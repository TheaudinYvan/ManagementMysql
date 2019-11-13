Imports Amazon
Imports Amazon.IdentityManagement
Imports Amazon.IdentityManagement.Model
Imports Amazon.RDS
Imports Amazon.RDS.Model
Imports DevComponents.AdvTree
Imports DevExpress.Utils.VisualEffects
Imports DevExpress.XtraSplashScreen

Public Class MainForm

    Private InfoServer As DevExpress.XtraBars.Docking2010.Views.BaseDocument
    Private UserInfoServer As UserInfoServer
    Private DictDataTaBleSnapShot As New Dictionary(Of String, DataTable)
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        ManagementMysqlApp.ManagementMysqlApplication.MainFormTabbedView = TabbedView1
        If IO.File.Exists("ConfiInstanceMetrics.xml") Then
            ManagementMysqlApp.ManagementMysqlApplication.DataSetStat1.ReadXml("ConfiInstanceMetrics.xml")
        End If

        NodeGrantsSql.Image = ManagementMysqlApp.ManagementMysqlApplication.ImageCollection1.Images("login.png")


        For Each z In ManagementMysqlApp.ManagementMysqlApplication.LoadCredentials()
            RepositoryCredentials.Items.Add(z)
        Next
        ManagementMysqlApp.ManagementMysqlApplication.AdvTree = Me.AdvTree1
        BarEditCredentials.EditValue = My.Settings.AwsProfile
        GetAvailabilityZone(ButtonRegion)
        GetCurrentRegionSelect()
        GetRdsInstances(NodeServers, Me)
        ListUserIam()

        'EtatSnapShot()
        EtatSnapShotByRegion()
        'InitBadge(dashMainBadge, 3, DockPanel1)
    End Sub

    Private Sub RepositoryCredentials_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepositoryCredentials.SelectedIndexChanged
        My.Settings.AwsProfile = BarEditCredentials.EditValue.ToString
        My.Settings.Save()
    End Sub
    Private dicGroup As New Dictionary(Of String, String)

    Private Sub ListUserIam()
        Dim iamClient As AmazonIdentityManagementServiceClient = New AmazonIdentityManagementServiceClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(BarEditCredentials.EditValue))
        Dim requestUsers = New ListUsersRequest()
        Dim responseUsers = iamClient.ListUsers(requestUsers)



        For Each user In responseUsers.Users
            'Console.WriteLine("For user {0}:", user.UserName)
            'Console.WriteLine("  In groups:")

            Dim UserNewNode As New Node
            UserNewNode.Text = user.UserName
            UserNewNode.Tag = user.UserId
            NodeUsers.Nodes.Add(UserNewNode)

            insertDataset(user.UserName, user.UserId, "Users")



            Dim requestGroups = New ListGroupsForUserRequest With {.UserName = user.UserName}
            Dim responseGroups = iamClient.ListGroupsForUser(requestGroups)

            For Each group In responseGroups.Groups
                Dim GroupNewNode As New Node
                GroupNewNode.Text = group.GroupName
                GroupNewNode.Tag = group.GroupId
                UserNewNode.Nodes.Add(GroupNewNode)
                insertDataset(group.GroupName, group.GroupId, "Groups")
                If Not dicGroup.ContainsKey(group.GroupName) Then
                    dicGroup.Add(group.GroupName, group.GroupId)
                End If
                'Console.WriteLine("    {0}", group.GroupName)
            Next group

            'Console.WriteLine("  Policies:")

            Dim requestPolicies = New ListUserPoliciesRequest With {.UserName = user.UserName}
            Dim responsePolicies = iamClient.ListUserPolicies(requestPolicies)

            For Each policy In responsePolicies.PolicyNames
                Console.WriteLine("    {0}", policy)

                Dim policyNewNode As New Node
                policyNewNode.Text = policy
                policyNewNode.Tag = policy
                UserNewNode.Nodes.Add(policyNewNode)

            Next policy

            'Dim requestAccessKeys = New ListAccessKeysRequest With {.UserName = user.UserName}
            'Dim responseAccessKeys = iamClient.ListAccessKeys(requestAccessKeys)

            'Console.WriteLine("  Access keys:")

            'For Each accessKey In responseAccessKeys.AccessKeyMetadata
            '    Console.WriteLine("    {0}", accessKey.AccessKeyId)
            'Next accessKey
        Next user

        For Each z In dicGroup

            Dim GroupNewNode As New Node
            GroupNewNode.Text = z.Key
            GroupNewNode.Tag = z.Value
            UserGroups.Nodes.Add(GroupNewNode)
            AddHandler GroupNewNode.NodeClick, AddressOf UserGroups_NodeClick

        Next




    End Sub
    Private Sub insertDataset(ByVal Name As String, ByVal Id As String, ByVal quoi As String)

        Dim r As DataRow = ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Tables(quoi).Select("IdAws='" & Id & "'").FirstOrDefault
        If r Is Nothing Then
            r = ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Tables(quoi).NewRow
            r.Item("id") = Guid.NewGuid
            r.Item("Name") = Name
            r.Item("IdAws") = Id
            ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Tables(quoi).Rows.Add(r)
        End If


    End Sub
    Private Sub UserGroups_NodeClick(sender As Object, e As EventArgs)
        Dim GroupNewNode As Node = sender
        Dim UserDroitDbModele As UserDroitDbModele = New UserDroitDbModele
        UserDroitDbModele.IdGroupAws = GroupNewNode.Tag
        Dim pRDS As DevExpress.XtraBars.Docking2010.Views.BaseDocument = TabbedView1.AddDocument(UserDroitDbModele)
        pRDS.Caption = GroupNewNode.Text

        TabbedView1.Controller.Select(CType(pRDS, DevExpress.XtraBars.Docking2010.Views.Tabbed.Document))
    End Sub

    Private AmazonRDSClient As AmazonRDSClient
    Public Sub GetRdsInstances(ByVal NodeAwsRDS As Node, ByVal Forms As Form)
        'AddHandler NodeAwsRDS.TreeControl.BeforeNodeDrop, AddressOf TreeControl_BeforeNodeDrop
        'AddHandler NodeAwsRDS.TreeControl.AfterNodeDrop, AddressOf TreeControl_AfterNodeDrop
        SplashScreenManager.ShowForm(Forms, GetType(WaitForm1), True, True, False)
        Try

            For Each n As Node In NodeAwsRDS.Nodes
                SplashScreenManager.Default.SetWaitFormDescription("Loading " & n.Text)
                Dim Region As RegionEndpoint = GetRegion(n.Text)
                AmazonRDSClient = New AmazonRDSClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(BarEditCredentials.EditValue, "For " & n.Text, False), Region)

                Dim request = New DescribeDBInstancesRequest()
                Dim response = AmazonRDSClient.DescribeDBInstances(request)

                For Each v As DBInstance In response.DBInstances
                    Dim cNewNodeDBInstance As New Node With {
                        .Tag = v,
                        .Text = v.DBInstanceIdentifier,
                        .Image = ManagementMysqlApp.ManagementMysqlApplication.ImageCollection1.Images(v.Engine.ToLower.ToString & ".png")
                    }
                    GetSnapShotList(v.DbiResourceId, Region)
                    GetTagRds(cNewNodeDBInstance, v.DBInstanceArn, Region)
                    GetListMetricTreeGx(cNewNodeDBInstance, Region, BarEditCredentials.EditValue)

                    n.Nodes.Add(cNewNodeDBInstance)
                    ' AddHandler cNewNodeDBInstance.NodeClick, AddressOf CNewNodeDBInstance_NodeClick
                    AddHandler cNewNodeDBInstance.NodeMouseDown, AddressOf CNewNodeDBInstance_NodeMouseDown
                    AddHandler cNewNodeDBInstance.NodeMouseEnter, AddressOf CNewNodeDBInstance_NodeMouseEnter
                Next

                If response.DBInstances.Count > 0 Then
                    n.Text = "<b>" & n.Text & "</b>"
                End If

            Next
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            DevComponents.DotNetBar.Controls.DesktopAlert.Show("Nothing instance For : ", DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red, DevComponents.DotNetBar.Controls.eAlertPosition.BottomRight)
        End Try

    End Sub

    Private Sub GetTagRds(ByVal Node As Node, ByVal DBInstanceArn As String, ByVal RegionEndpoint As RegionEndpoint)

        Dim ListTagsForResourceRequest = New Amazon.RDS.Model.ListTagsForResourceRequest
        'Dim lvalue As List(Of String) = New List(Of String)
        'lvalue.Add(DbiResourceId)
        'Dim Filter As New Filter With {
        '    .Name = "dbi-resource-id",
        '    .Values = lvalue
        '}
        'ListTagsForResourceRequest.Filters.Add(Filter)
        ListTagsForResourceRequest.ResourceName = DBInstanceArn
        'AmazonRDSClient = New AmazonRDSClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(BarEditCredentials.EditValue), RegionEndpoint)
        Dim response As Amazon.RDS.Model.ListTagsForResourceResponse = AmazonRDSClient.ListTagsForResource(ListTagsForResourceRequest)

        For Each RTag As RDS.Model.Tag In response.TagList
            If RTag.Key.ToString.Contains("Schema") Then
                Dim RTagNode As New Node With {
                        .Tag = RTag,
                        .Text = RTag.Value,
                        .Image = ManagementMysqlApp.ManagementMysqlApplication.ImageCollection1.Images("tag_16x16")
                    }
                Node.Nodes.Add(RTagNode)
            End If
        Next

        'For Each vSN As DBSnapshot In response.DBSnapshots

        'Next

    End Sub


    Private Sub CNewNodeDBInstance_NodeMouseDown(sender As Object, e As MouseEventArgs)
        Dim cNewNodeDBInstance As Node = sender
        If e.Button = MouseButtons.Left Then
            ' Dim cNewNodeDBInstance As Node = sender

            If InfoServer Is Nothing Then
                UserInfoServer = New UserInfoServer
                InfoServer = TabbedView1.AddDocument(UserInfoServer)
                InfoServer.Caption = "Server information"
                TabbedView1.Controller.Select(CType(InfoServer, DevExpress.XtraBars.Docking2010.Views.Tabbed.Document))
            End If
            Dim DBInstance As DBInstance = cNewNodeDBInstance.Tag
            'UserGridSnapShot1.VGridControl1.DataSource = DictDataTaBleSnapShot.Item(DBInstance.DbiResourceId)
            UserInfoServer.InsertInfoServer(cNewNodeDBInstance.Text, cNewNodeDBInstance.Tag, DictDataTaBleSnapShot.Item(DBInstance.DbiResourceId))
        ElseIf e.Button = MouseButtons.Right Then
            For Each z As ManagementMysqlApp.ConfigStat In ManagementMysqlApp.ManagementMysqlApplication.MetricByInstance.Item(cNewNodeDBInstance.Text)
                ButtonMetrics.SubItems.Add(z.CheckBoxItem)
            Next
        End If

    End Sub

    Private Sub CNewNodeDBInstance_NodeMouseEnter(sender As Object, e As EventArgs)
        'Flyout1.TargetControl = sender
        'FlyoutPanel1.Options.Location = New Point(Me.ClientSize.Width \ 2 - FlyoutPanel1.Width \ 2, Me.ClientSize.Height - FlyoutPanel1.Size.Height)
        'Dim cNewNodeDBInstance As Node = sender
        ' Dim DBInstance As DBInstance = cNewNodeDBInstance.Tag
        'UserGridSnapShot1.VGridControl1.DataSource = DictDataTaBleSnapShot.Item(DBInstance.DbiResourceId)
        ' FlyoutPanel1.ShowBeakForm(Control.MousePosition) '.OwnerControl = sender
    End Sub

    Private Sub InitBadge(ByVal badge As DevExpress.Utils.VisualEffects.Badge, ByVal text As String, ByVal target As Object)
        badge.Properties.BeginUpdate()

        'badge.Properties.Offset = New Point(target.l, trackBarControlY.Value)
        badge.Properties.PaintStyle = DevExpress.Utils.VisualEffects.BadgePaintStyle.Critical
        badge.Properties.Location = ContentAlignment.BottomLeft
        'badge.TargetElement = target
        badge.Properties.Text = text
        badge.Properties.EndUpdate()
    End Sub

    'Private Sub SetBadgeOffset(ByVal badge As DevExpress.Utils.VisualEffects.Badge, ByVal tile As Node, ByVal deltaX As Integer, ByVal deltaY As Integer)
    '    Dim delta As Integer = ScaleDPI.ScaleSize(tile.).Width \ 2
    '    Dim x As Integer = DirectCast(tile, ISupportAdornerElement).Bounds.Width \ 2 - delta
    '    Dim y As Integer = DirectCast(tile, ISupportAdornerElement).Bounds.Height \ 2 - delta
    '    badge.Properties.Offset = New Point(-x - deltaX, y - deltaY)
    'End Sub
    Private Sub CNewNodeDBInstance_NodeClick(sender As Object, e As EventArgs)



        Dim cNewNodeDBInstance As Node = sender

        If InfoServer Is Nothing Then
            UserInfoServer = New UserInfoServer
            InfoServer = TabbedView1.AddDocument(UserInfoServer)
            InfoServer.Caption = "Server information"
            TabbedView1.Controller.Select(CType(InfoServer, DevExpress.XtraBars.Docking2010.Views.Tabbed.Document))
        End If
        Dim DBInstance As DBInstance = cNewNodeDBInstance.Tag
        'UserGridSnapShot1.VGridControl1.DataSource = DictDataTaBleSnapShot.Item(DBInstance.DbiResourceId)
        UserInfoServer.InsertInfoServer(cNewNodeDBInstance.Text, cNewNodeDBInstance.Tag, DictDataTaBleSnapShot.Item(DBInstance.DbiResourceId))

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        ManagementMysqlApp.ManagementMysqlApplication.SaveData()
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click

        ManagementMysqlApp.ManagementMysqlApplication.AdvTree.FindNodeByDataKey("Servers").Nodes.Clear()
        UserGroups.Nodes.Clear()
        NodeUsers.Nodes.Clear()
        DictDataTaBleSnapShot.Clear()
        GetCurrentRegionSelect()
        GetRdsInstances(NodeServers, Me)
        ListUserIam()


    End Sub


    Private Sub GetSnapShotList(ByVal DbiResourceId As String, ByVal RegionEndpoint As RegionEndpoint)
        Dim DescribeDBSnapshotsRequest = New Amazon.RDS.Model.DescribeDBSnapshotsRequest
        Dim lvalue As List(Of String) = New List(Of String)
        lvalue.Add(DbiResourceId)
        Dim Filter As New Filter With {
            .Name = "dbi-resource-id",
            .Values = lvalue
        }
        DescribeDBSnapshotsRequest.Filters.Add(Filter)
        'AmazonRDSClient = New AmazonRDSClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(BarEditCredentials.EditValue), RegionEndpoint)
        Dim response = AmazonRDSClient.DescribeDBSnapshots(DescribeDBSnapshotsRequest)
        DictDataTaBleSnapShot.Add(DbiResourceId, CreateDataTable(response.DBSnapshots))

        'For Each vSN As DBSnapshot In response.DBSnapshots

        'Next
    End Sub



    Public Shared Function CreateDataTable(Of T)(ByVal list As IEnumerable(Of T)) As DataTable
        Dim type As Type = GetType(T)
        Dim properties = type.GetProperties()

        Dim dataTable As New DataTable()
        For Each info As Reflection.PropertyInfo In properties
            dataTable.Columns.Add(New DataColumn(info.Name, If(Nullable.GetUnderlyingType(info.PropertyType), info.PropertyType)))
        Next info

        For Each entity As T In list
            Dim values(properties.Length - 1) As Object
            For i As Integer = 0 To properties.Length - 1
                values(i) = properties(i).GetValue(entity)
            Next i

            dataTable.Rows.Add(values)
        Next entity

        Return dataTable
    End Function


    Private Sub EtatSnapShot()
        Dim counterreur As Integer = 0
        'Dim oDate As DateTime = Convert.ToDateTime(Now.Date.ToString)
        For Each d In DictDataTaBleSnapShot
            Dim r As DataRow = d.Value.Select("SnapshotCreateTime >= '" & Now.Date.ToString & "'").FirstOrDefault
            If r Is Nothing Then
                counterreur += 1
            End If
        Next
    End Sub


    Private Sub EtatSnapShotByRegion()

        Dim m As New UserMonitoring
        m.Dock = DockStyle.Fill
        DockPanel2.Controls.Add(m)
        Dim counterreur As Integer = 0
        Dim Serveur As Integer = 0
        'Dim oDate As DateTime = Convert.ToDateTime(Now.Date.ToString)
        For Each Region As Node In NodeServers.Nodes
            For Each Server As Node In Region.Nodes
                Dim s As DBInstance = Server.Tag
                Dim r As DataRow = DictDataTaBleSnapShot.Item(s.DbiResourceId).Select("SnapshotCreateTime >= '" & Now.Date.ToString & "'").FirstOrDefault
                If r Is Nothing Then
                    counterreur += 1
                End If
                Serveur += 1
            Next
            If Serveur > 0 Then
                m.LoadMeteo(Region.Text, counterreur, Serveur)
            End If
            counterreur = 0
            Serveur = 0
        Next


    End Sub

    Private Sub Node1_NodeClick(sender As Object, e As EventArgs) Handles Node1.NodeClick
        ManagementMysqlApp.ManagementMysqlApplication.ColorChart = New Dictionary(Of String, Color)
        ManagementMysqlApp.ManagementMysqlApplication.DictChart.Clear()
        GetListmetric(BarEditCredentials.EditValue.ToString)
    End Sub

    Private Sub CreateGrantsUser(ByVal Db As String, ByVal Serveur As String, ByVal TypeServeur As String, ByVal UserGrants As UserGrants)

        UserGrants.TextEditorControl1.AppendLine("# Server : " & Serveur)

        For Each nuser As Node In NodeUsers.Nodes

            For Each Ngroup As Node In nuser.Nodes
                For Each r As DataSetData.DroitsRow In ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.Droits.Select("IdGroupAws='" & Ngroup.Tag.ToString & "' AND TypeServer='" & TypeServeur & "'")
                    If r Is Nothing Then
                        DevComponents.DotNetBar.Controls.DesktopAlert.Show("no rights For : " & nuser.Text & "(Group: )" & Ngroup.Text, DevComponents.DotNetBar.Controls.eDesktopAlertColor.Green, DevComponents.DotNetBar.Controls.eAlertPosition.BottomRight)
                    Else
                        UserGrants.TextEditorControl1.AppendLine("#Type De droit : " & r.TypeDroit)
                        UserGrants.TextEditorControl1.AppendLine("GRANT " & r.DroitCSV.Replace(";", ",") & " ON " & "*." & Db & " TO " & nuser.Text & ".*")
                    End If
                Next




            Next

        Next



    End Sub

    Private Sub NodeGrantsSql_NodeClick(sender As Object, e As EventArgs) Handles NodeGrantsSql.NodeClick
        Dim UserGrants As New UserGrants

        For Each nRegion As Node In NodeServers.Nodes
            For Each nServeur As Node In nRegion.Nodes
                Dim DBInstance As DBInstance = nServeur.Tag
                For Each nTag As Node In nServeur.Nodes
                    CreateGrantsUser(nTag.Text, nServeur.Text, DBInstance.Engine, UserGrants)
                Next

            Next

        Next

        'GRANT SELECT, INSERT, UPDATE ON *.* TO u1;
        'REVOKE INSERT, Update ON db1.* FROM u1;
        ' GRANT ALL PRIVILEGES ON books.authors  TO 'tolkien'@'localhost';

        Dim pRDS As DevExpress.XtraBars.Docking2010.Views.BaseDocument = TabbedView1.AddDocument(UserGrants)
        pRDS.Caption = "Grants Servers"
    End Sub
End Class
