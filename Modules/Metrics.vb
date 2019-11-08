Imports DevComponents.DotNetBar

Module Metrics

    Private LoadFirst As Boolean = False

    Public Sub GetListMetricTreeGx(ByVal Node As DevComponents.AdvTree.Node, ByVal RegionEndpoint As Amazon.RegionEndpoint, ByVal Profile As String)


        Try



            If ManagementMysqlApp.ManagementMysqlApplication.MetricByInstance.Count > 0 AndAlso ManagementMysqlApp.ManagementMysqlApplication.MetricByInstance.ContainsKey(Node.Text) Then
                ManagementMysqlApp.ManagementMysqlApplication.MetricByInstance.Remove(Node.Text)

            End If

            If TypeOf Node.Tag IsNot Amazon.RDS.Model.DBInstance Then
                Exit Sub
            End If


            'Dim RegionEndpoint As Amazon.RegionEndpoint = CType(Node.Parent.Tag, Amazon.RegionEndpoint)
            Dim client = New Amazon.CloudWatch.AmazonCloudWatchClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(Profile, "For " & Node.Text, False), RegionEndpoint)
            Dim dimension = New Amazon.CloudWatch.Model.DimensionFilter With {
                .Name = "DBInstanceIdentifier",
                .Value = Node.Text
                }
            Dim request = New Amazon.CloudWatch.Model.ListMetricsRequest With {
                .[Namespace] = "AWS/RDS",
                .Dimensions = New List(Of Amazon.CloudWatch.Model.DimensionFilter)() From {
                    dimension
            }
            }
            ' Dim ctstat As New UserStatInstance
            'Listmetrics.SubItems.Clear()
            Dim response As Amazon.CloudWatch.Model.ListMetricsResponse = New Amazon.CloudWatch.Model.ListMetricsResponse
            Dim MetricName As New List(Of String)
            ManagementMysqlApp.ManagementMysqlApplication.MetricByInstance.Add(Node.Text, New List(Of ManagementMysqlApp.ConfigStat))
            Do
                response = client.ListMetrics(request)

                If response.Metrics.Count > 0 Then

                    For Each metric In response.Metrics
                        Dim r As DataSetStat.ConfiInstanceMetricsRow = CType(ManagementMysqlApp.ManagementMysqlApplication.DataSetStat1.ConfiInstanceMetrics.Select("region='" & RegionEndpoint.SystemName & "' AND instance='" & Node.Text & "' AND metrics='" & metric.MetricName & "'").FirstOrDefault, DataSetStat.ConfiInstanceMetricsRow)
                        Dim Etat As Boolean = False
                        Dim CheckBoxItem As New DevComponents.DotNetBar.CheckBoxItem
                        CheckBoxItem.Text = metric.MetricName
                        CheckBoxItem.Tag = Node
                        'MetroTileItem1.TileSize = New Size(90, 45)
                        If r IsNot Nothing Then
                            CheckBoxItem.Checked = True
                            ' MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                        End If
                        Dim ConfigStat As New ManagementMysqlApp.ConfigStat
                        ConfigStat.CheckBoxItem = CheckBoxItem
                        ConfigStat.SystemNameRegion = RegionEndpoint.SystemName
                        ConfigStat.instance = Node.Text
                        ConfigStat.metrics = metric.MetricName
                        CheckBoxItem.Tag = ConfigStat
                        ManagementMysqlApp.ManagementMysqlApplication.MetricByInstance.Item(Node.Text).Add(ConfigStat)
                        'Listmetrics.SubItems.Add(CheckBoxItem)
                        AddHandler CheckBoxItem.CheckedChanged, AddressOf CheckBoxItem_CheckedChanged
                    Next
                Else
                    Console.WriteLine("No metrics found.")
                End If

                request.NextToken = response.NextToken
            Loop While Not String.IsNullOrEmpty(response.NextToken)
            'Listmetrics.Refresh()

            LoadFirst = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CheckBoxItem_CheckedChanged(sender As Object, e As CheckBoxChangeEventArgs)
        Dim CheckBoxItem As CheckBoxItem = CType(sender, CheckBoxItem)
        Dim ConfigStat As ManagementMysqlApp.ConfigStat = CType(CheckBoxItem.Tag, ManagementMysqlApp.ConfigStat)

        If LoadFirst = True Then

            Dim r As DataSetStat.ConfiInstanceMetricsRow = CType(ManagementMysqlApp.ManagementMysqlApplication.DataSetStat1.ConfiInstanceMetrics.Select("region='" & ConfigStat.SystemNameRegion & "' AND instance='" & ConfigStat.instance & "' AND metrics='" & ConfigStat.metrics & "'").FirstOrDefault, DataSetStat.ConfiInstanceMetricsRow)


            If CheckBoxItem.Checked = True AndAlso r Is Nothing Then
                'My.Settings.MyRegion.Add(MetroTileItem1.Text)
                r = ManagementMysqlApp.ManagementMysqlApplication.DataSetStat1.ConfiInstanceMetrics.NewConfiInstanceMetricsRow
                r._region = ConfigStat.SystemNameRegion
                r.instance = ConfigStat.instance
                r.metrics = CheckBoxItem.Text
                r.SystemNameRegion = ConfigStat.SystemNameRegion
                ManagementMysqlApp.ManagementMysqlApplication.DataSetStat1.ConfiInstanceMetrics.AddConfiInstanceMetricsRow(r)
                Dim rconf As DataSetStat.ConfStatRow = ManagementMysqlApp.ManagementMysqlApplication.DataSetStat1.ConfStat.NewConfStatRow
                ManagementMysqlApp.ManagementMysqlApplication.DataSetStat1.ConfStat.AddConfStatRow(rconf)
                'MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
            Else
                r.Delete()
                'MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default

            End If
        End If
        ManagementMysqlApp.ManagementMysqlApplication.DataSetStat1.WriteXml("ConfiInstanceMetrics.xml")
    End Sub
End Module
