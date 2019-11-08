Imports Amazon
Imports Amazon.CloudWatch
Imports Amazon.CloudWatch.Model
Imports DevComponents.Tree
Imports DevExpress.XtraCharts

Module AWSCloudWatch
    Private DicTLoadMetrics As New Dictionary(Of String, Dictionary(Of RegionEndpoint, List(Of String)))
    Public Sub GetListDataMetric()

    End Sub
    'Public Sub GetListMetricRDS(ByVal Node As Node)
    '    Dim id As String = "s" & System.Text.RegularExpressions.Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "").ToString.ToLower
    '    Dim RegionEndpoint As RegionEndpoint = CType(Node.Parent.Tag, RegionEndpoint)
    '    Dim client = New AmazonCloudWatchClient(AwsGestionApp.AwsGestionApplication.AWSCredentials, RegionEndpoint)
    '    Dim dimension = New DimensionFilter With {
    '        .Name = "DBInstanceIdentifier",
    '        .Value = Node.Text
    '        }
    '    Dim request = New ListMetricsRequest With {
    '        .[Namespace] = "AWS/RDS",
    '        .Dimensions = New List(Of DimensionFilter)() From {
    '            dimension
    '    }
    '    }
    '    Dim ctstat As New UserStatInstance

    '    Dim response As ListMetricsResponse = New ListMetricsResponse
    '    Dim MetricName As New List(Of String)

    '    Do
    '        response = client.ListMetrics(request)

    '        If response.Metrics.Count > 0 Then

    '            For Each metric In response.Metrics

    '                Dim Statistics As New List(Of String) From {
    '                    "Average"
    '                }
    '                'If metric.MetricName = "CPUUtilization" Then
    '                MetricName.Add(metric.MetricName)
    '                ctstat.LoadChartStart(id, dimension.Name, dimension.Value, metric.MetricName, metric.Namespace, DateTime.UtcNow, 60, Statistics, RegionEndpoint)
    '                'End If


    '            Next
    '        Else
    '            Console.WriteLine("No metrics found.")
    '        End If

    '        request.NextToken = response.NextToken
    '    Loop While Not String.IsNullOrEmpty(response.NextToken)

    '    Dim d As New Dictionary(Of RegionEndpoint, List(Of String)) From {
    '        {RegionEndpoint, MetricName}
    '    }
    '    DicTLoadMetrics.Add(id, d)
    '    LoadDataAll()
    'End Sub

    'Public Sub GetListmetric(ByVal Node As Node)
    '    Dim id As String = Guid.NewGuid.ToString
    '    Dim RegionEndpoint As RegionEndpoint = CType(Node.Parent.Tag, RegionEndpoint)
    '    Dim client = New AmazonCloudWatchClient(AwsGestionApp.AwsGestionApplication.AWSCredentials, RegionEndpoint)
    '    Dim dimension = New DimensionFilter With {
    '        .Name = "DBInstanceIdentifier",
    '        .Value = Node.Text
    '        }
    '    Dim request = New ListMetricsRequest With {
    '        .[Namespace] = "AWS/RDS",
    '        .Dimensions = New List(Of DimensionFilter)() From {
    '            dimension
    '    }
    '    }
    '    Dim ctstat As New UserStatInstance
    '    Dim response As ListMetricsResponse = New ListMetricsResponse
    '    If AwsGestionApp.AwsGestionApplication.ColorChart Is Nothing Then
    '        AwsGestionApp.AwsGestionApplication.ColorChart = New Dictionary(Of String, Color)
    '    End If
    '    If Not AwsGestionApp.AwsGestionApplication.ColorChart.ContainsKey(Node.Text) Then

    '        Dim rnd As New Random
    '        AwsGestionApp.AwsGestionApplication.ColorChart.Add(Node.Text, Color.FromArgb(255, rnd.Next(128, 255), rnd.Next(128, 255), rnd.Next(128, 255)))
    '    End If

    '    Do
    '        response = client.ListMetrics(request)

    '        If response.Metrics.Count > 0 Then

    '            For Each metric In response.Metrics

    '                Dim Statistics As New List(Of String) From {
    '                    "Average"
    '                }
    '                'If metric.MetricName = "CPUUtilization" Then
    '                ctstat.LoadChartStart(id, dimension.Name, dimension.Value, metric.MetricName, metric.Namespace, DateTime.UtcNow, 60, Statistics, RegionEndpoint)
    '                'End If


    '            Next
    '        Else
    '            Console.WriteLine("No metrics found.")
    '        End If

    '        request.NextToken = response.NextToken
    '    Loop While Not String.IsNullOrEmpty(response.NextToken)


    '    Dim pRDS As DevExpress.XtraBars.Docking2010.Views.BaseDocument = AwsGestionApp.AwsGestionApplication.MainFormTabbedView.AddDocument(ctstat)
    '    pRDS.Caption = Node.Text
    '    AwsGestionApp.AwsGestionApplication.MainFormTabbedView.Controller.Select(CType(pRDS, DevExpress.XtraBars.Docking2010.Views.Tabbed.Document))

    '    For Each z In AwsGestionApp.AwsGestionApplication.DictChart
    '        z.Value.StartStatLoad()

    '    Next
    'End Sub

    Public Sub GetListmetric(ByVal Profile As String)
        Dim RegionEndpoint As RegionEndpoint
        Dim ctstat As New UserStatInstance
        For Each r As DataSetStat.ConfiInstanceMetricsRow In ManagementMysqlApp.ManagementMysqlApplication.DataSetStat1.ConfiInstanceMetrics
            RegionEndpoint = RegionEndpoint.GetBySystemName(r.SystemNameRegion)

            Dim id As String = Guid.NewGuid.ToString

            'Dim client = New AmazonCloudWatchClient(AwsGestionApp.AwsGestionApplication.AWSCredentials, RegionEndpoint)
            Dim dimension = New DimensionFilter With {
                .Name = "DBInstanceIdentifier",
                .Value = r.instance
                }
            Dim request = New ListMetricsRequest With {
                .[Namespace] = "AWS/RDS",
                .Dimensions = New List(Of DimensionFilter)() From {
                    dimension
            }
            }

            If Not ManagementMysqlApp.ManagementMysqlApplication.ColorChart.ContainsKey(r.instance) Then

                Dim rnd As New Random
                ManagementMysqlApp.ManagementMysqlApplication.ColorChart.Add(r.instance, Color.FromArgb(255, rnd.Next(128, 255), rnd.Next(128, 255), rnd.Next(128, 255)))
            End If

            'Dim response As ListMetricsResponse = New ListMetricsResponse
            Dim Statistics As New List(Of String) From {
                "Average"
            }
            'If metric.MetricName = "CPUUtilization" Then
            ctstat.LoadChartStart(id, dimension.Name, dimension.Value, r.metrics, request.Namespace, DateTime.UtcNow, 60, Statistics, RegionEndpoint, Profile)

            'Do
            '    response = client.ListMetrics(request)

            '    If response.Metrics.Count > 0 Then

            '        For Each metric In response.Metrics


            '            'End If


            '        Next
            '    Else
            '        Console.WriteLine("No metrics found.")
            '    End If

            '    request.NextToken = response.NextToken
            'Loop While Not String.IsNullOrEmpty(response.NextToken)

        Next



        Dim pRDS As DevExpress.XtraBars.Docking2010.Views.BaseDocument = ManagementMysqlApp.ManagementMysqlApplication.MainFormTabbedView.AddDocument(ctstat)
        pRDS.Caption = "Monitoring"
        ManagementMysqlApp.ManagementMysqlApplication.MainFormTabbedView.Controller.Select(CType(pRDS, DevExpress.XtraBars.Docking2010.Views.Tabbed.Document))

        For Each z In ManagementMysqlApp.ManagementMysqlApplication.DictChart
            z.Value.StartStatLoad()

        Next

    End Sub
    'Public Sub MetricV3(ByVal Node As Node, ByVal PanelEx As DevComponents.DotNetBar.PanelEx)
    '    Dim RegionEndpoint As RegionEndpoint = CType(Node.Parent.Tag, RegionEndpoint)

    '    Dim client = New AmazonCloudWatchClient(AwsGestionApp.AwsGestionApplication.AWSCredentials, RegionEndpoint)

    '    Dim dimension = New Dimension With {
    '        .Name = "DBInstanceIdentifier",
    '        .Value = "database-1"
    '        }

    '    Dim request = New GetMetricStatisticsRequest With {.MetricName = "CPUUtilization",
    '        .[Namespace] = "AWS/RDS",
    '        .StartTimeUtc = Now.Subtract(New TimeSpan(0, 30, 0)),
    '        .EndTimeUtc = DateTime.UtcNow,
    '        .Period = 60,
    '        .Dimensions = New List(Of Dimension)() From {
    '            dimension
    '    }
    '        }
    '    request.Statistics.Add("Average")
    '    Dim response As GetMetricStatisticsResponse = client.GetMetricStatistics(request)

    '    Dim lineChart As New ChartControl()

    '    Dim series1 As New Series("Series 1", ViewType.Line)

    '    For Each metric In response.Datapoints
    '        Dim d As DateTime = metric.Timestamp
    '        series1.Points.Add(New SeriesPoint(d, metric.Average))

    '    Next

    '    lineChart.Series.Add(series1)
    '    'series1.ArgumentScaleType = ScaleType.DateTime
    '    Dim axisX As AxisX = CType(lineChart.Diagram, XYDiagram).AxisX
    '    axisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Second
    '    axisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Second
    '    axisX.WholeRange.SetMinMaxValues(DateTime.Now.Date, DateTime.Now.AddHours(1).Date)
    '    axisX.WholeRange.AutoSideMargins = False

    '    CType(series1.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
    '    CType(series1.View, LineSeriesView).LineMarkerOptions.Kind = MarkerKind.Triangle
    '    CType(series1.View, LineSeriesView).LineStyle.DashStyle = DashStyle.Dash
    '    CType(lineChart.Diagram, XYDiagram).EnableAxisXZooming = True

    '    lineChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
    '    lineChart.Titles.Add(New ChartTitle())
    '    lineChart.Titles(0).Text = "CPUUtilization"
    '    lineChart.Dock = DockStyle.Top
    '    PanelEx.Controls.Add(lineChart)
    '    ' Add the chart to the form. 
    '    'lineChart.Dock = DockStyle.Fill
    'End Sub


    '    Private Sub LoadDataAll()
    '        Dim RegionEndpoint As RegionEndpoint = Nothing
    '        Dim Id As String = Nothing
    '        Dim MetricNameS As New List(Of String)

    '        For Each MetricsInfo In DicTLoadMetrics

    '            Id = MetricsInfo.Key
    '            For Each MetricDetail In MetricsInfo.Value
    '                RegionEndpoint = MetricDetail.Key
    '                MetricNameS = MetricDetail.Value
    '            Next
    '        Next

    '        Dim client = New AmazonCloudWatchClient(AwsGestionApp.AwsGestionApplication.AWSCredentials, RegionEndpoint)
    '        'ConfiChart.Request.StartTimeUtc = DateTime.UtcNow.Subtract(New TimeSpan(0, 30, 0))
    '        'ConfiChart.Request.EndTimeUtc = DateTime.UtcNow
    '        'ConfiChart.dimension = Nothing
    '        'Dim request As GetMetricDataRequest = New GetMetricDataRequest With {
    '        '    .StartTimeUtc = DateTime.UtcNow.Subtract(New TimeSpan(0, 30, 0)),
    '        '    .EndTimeUtc = DateTime.UtcNow,
    '        '    .MetricDataQueries = New MetricDataQuery
    '        '}
    '        Dim z As New List(Of MetricDataQuery)
    '        Dim i As Integer = 0
    '        For Each MetricName As String In MetricNameS
    '            Dim a As New MetricDataQuery With {
    '                .Id = Id & "_" & i.ToString,
    '                .MetricStat = New MetricStat() With {
    '                .Metric = New Metric() With {
    '                     .[Namespace] = "AWS/RDS",
    '                     .MetricName = MetricName,
    '                     .Dimensions = New List(Of Dimension)() From {
    '                        New Dimension() With {
    '                            .Name = "DBInstanceIdentifier",
    '                            .Value = "Database-1"
    '                        }
    '                    }
    '                    },
    '                    .Period = 60,
    '                    .Stat = "Sum",
    '                    .Unit = "None"
    '                }
    '            }
    '            i += 1
    '            z.Add(a)
    '        Next


    '        Dim request As GetMetricDataRequest = New GetMetricDataRequest() With {
    '            .StartTimeUtc = DateTime.UtcNow.Subtract(New TimeSpan(0, 30, 0)),
    '            .EndTimeUtc = DateTime.UtcNow,
    '            .MetricDataQueries = z,
    '            .ScanBy = ScanBy.TimestampDescending,
    '            .MaxDatapoints = 1000
    '}
    '        Dim response As GetMetricDataResponse = New GetMetricDataResponse
    '        Do
    '            response = client.GetMetricData(request)
    '            If response.MetricDataResults.Count > 0 Then
    '                For Each metric As MetricDataResult In response.MetricDataResults
    '                    MsgBox(metric.Id & "--" & metric.Values.Count)

    '                    'Dim r As DataSetStat.StatsRow = StatsDataTable.NewStatsRow
    '                    'r.DateInfo = metric.Timestamp
    '                    'r.Value = metric.Average
    '                    'StatsDataTable.AddStatsRow(r)
    '                Next
    '            End If

    '            request.NextToken = response.NextToken
    '        Loop While Not String.IsNullOrEmpty(response.NextToken)


    '        Try



    '            'ChartControl1.RefreshData()

    '        Catch ex As Exception
    '            MsgBox("41")
    '        End Try
    '        'ChartControl1.Series(0).Points.Add(SeriesPointCollection)
    '    End Sub
End Module
