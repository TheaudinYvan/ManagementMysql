Imports Amazon
Imports Amazon.RDS

Module Regions
    'Private LoadFirst As Boolean = False
    Public Function Loadregions() As Dictionary(Of String, RegionEndpoint)
        Dim dicRegion As New Dictionary(Of String, RegionEndpoint)
        For Each v In RegionEndpoint.EnumerableAllRegions

            dicRegion.Add(v.DisplayName, v)

        Next
        Return dicRegion
    End Function

    Public Function GetRegion(ByVal Name As String) As RegionEndpoint

        Name = StripTags(Name)


        For Each v In RegionEndpoint.EnumerableAllRegions
            If v.DisplayName = Name Then
                Return v
            End If
        Next
        Return Nothing
    End Function

    'Private Sub MetroTileItem_CheckedChanged(sender As Object, e As EventArgs)
    '    Dim MetroTileItem1 As MetroTileItem = CType(sender, MetroTileItem)
    '    'My.Settings.MyRegion.Clear()
    '    If LoadFirst = True Then


    '        If MetroTileItem1.Checked = True AndAlso Not My.Settings.MyRegion.Contains(MetroTileItem1.Text) Then
    '            My.Settings.MyRegion.Add(MetroTileItem1.Text)
    '            MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
    '        Else
    '            If My.Settings.MyRegion.Contains(MetroTileItem1.Text) Then
    '                My.Settings.MyRegion.Remove(MetroTileItem1.Text)
    '                MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default
    '            End If
    '        End If
    '    End If

    '    My.Settings.Save()
    'End Sub
    Public Sub GetAvailabilityZone(ByVal NodeServers As DevComponents.DotNetBar.ButtonItem)


        For Each v In RegionEndpoint.EnumerableAllRegions


            Dim RegionNewNode As New DevComponents.DotNetBar.ButtonItem
            RegionNewNode.Text = v.DisplayName
            RegionNewNode.Tag = v
            NodeServers.SubItems.Add(RegionNewNode)
            AddHandler RegionNewNode.Click, AddressOf RegionNewNode_Click
        Next
    End Sub

    Public Sub GetCurrentRegionSelect(ByVal Name As String)
        For Each s In My.Settings.MyRegion
            Dim n As New DevComponents.AdvTree.Node
            n.Text = s
            n.Tag = GetRegion(s)
            n.Image = ManagementMysqlApp.ManagementMysqlApplication.GetImageNodeFlag(s)
            ManagementMysqlApp.ManagementMysqlApplication.AdvTree.FindNodeByDataKey(Name).Nodes.Add(n)
        Next
    End Sub


    Private Sub RegionNewNode_Click(sender As Object, e As EventArgs)
        Dim RegionNewNode As DevComponents.DotNetBar.ButtonItem = sender
        If Not My.Settings.MyRegion.Contains(RegionNewNode.Text) Then
            My.Settings.MyRegion.Add(RegionNewNode.Text)
            My.Settings.Save()
        End If


        Dim n As New DevComponents.AdvTree.Node
        n.Text = RegionNewNode.Text
        n.Tag = RegionNewNode.Tag
        n.Image = ManagementMysqlApp.ManagementMysqlApplication.GetImageNodeFlag(RegionNewNode.Text)
        ManagementMysqlApp.ManagementMysqlApplication.AdvTree.FindNodeByDataKey("Servers").Nodes.Add(n)

    End Sub
End Module

