Imports Amazon
Imports Amazon.CloudWatch
Imports Amazon.CloudWatch.Model
Imports DevExpress.XtraBars.Docking2010.Views.Widget
Imports DevExpress.XtraCharts

Public Class UserStatInstance



    Public Sub LoadChartStart(ByVal id As String, ByVal DimentionName As String, ByVal DimentionValue As String, ByVal MetricName As String, ByVal [Namespace] As String, ByVal StartTimeUtc As Date, ByVal Period As Integer, ByVal Statistics As List(Of String), ByVal RegionEndpoint As RegionEndpoint, ByVal Profile As String)

        Dim UserChart As UserChart
        If ManagementMysqlApp.ManagementMysqlApplication.DictChart.ContainsKey(MetricName) Then
            UserChart = ManagementMysqlApp.ManagementMysqlApplication.DictChart.Item(MetricName)
        Else
            UserChart = New UserChart
            ManagementMysqlApp.ManagementMysqlApplication.DictChart.Add(MetricName, UserChart)
        End If


        UserChart.id = id
        Dim lineChart As ChartControl = UserChart.ChartControl1

        Dim ConfiChart As ManagementMysqlApp.ConfiChart = New ManagementMysqlApp.ConfiChart With {
            .NameInstance = DimentionName,
            .ValueColInstance = DimentionValue,
            .RegionEndpoint = RegionEndpoint,
            .profile = Profile,
            .dimension = New Dimension With {
            .Name = DimentionName,
            .Value = DimentionValue
            }
        }
        ConfiChart.Request = New GetMetricStatisticsRequest With {.MetricName = MetricName,
            .[Namespace] = [Namespace],
            .StartTimeUtc = StartTimeUtc.Subtract(New TimeSpan(0, 30, 0)),
            .EndTimeUtc = DateTime.UtcNow,
            .Period = Period,
            .Dimensions = New List(Of Dimension)() From {
                ConfiChart.dimension
        },
        .Statistics = Statistics
            }

        UserChart.ConcatChart.Add(ConfiChart)
        Dim Filter As String = DimentionValue & RegionEndpoint.SystemName
        'lineChart.Series.Add()
        CreateSerieChart(lineChart, MetricName, Filter, DimentionValue)





        Dim pRDS As DevExpress.XtraBars.Docking2010.Views.BaseDocument = WidgetView1.AddDocument(UserChart)

        'pRDS.Caption = MetricName & "(" & DimentionValue & ")"
        Dim CRDS = CType(pRDS, DevExpress.XtraBars.Docking2010.Views.Widget.Document)
        CRDS.AppearanceCaption.BackColor = ManagementMysqlApp.ManagementMysqlApplication.ColorChart.Item(DimentionValue)
        CRDS.AppearanceCaption.ForeColor = Color.Black
        'AddHandler CRDS.Maximized, AddressOf CRDS_Maximized
        'AddHandler CRDS.Restored, AddressOf CRDS_Restored

        pRDS.Caption = System.Text.RegularExpressions.Regex.Replace(MetricName, "(?<!^)((?<!\d)\d|(?(?<=[A-Z])[A-Z](?=[a-z])|[A-Z]))", " $1") & " (" & DimentionValue & ")"

    End Sub

    Private Function CreateSerieChart(ByVal lineChart As ChartControl, ByVal MetricName As String, ByVal Filter As String, ByVal SerieName As String) As Series

        Dim series1 As New Series(SerieName, ViewType.Line)
        lineChart.Series.Add(series1)
        series1.ArgumentDataMember = "DateInfo"
        series1.ValueDataMembers.AddRange("Value")
        series1.FilterString = "[InstancesAndRegion] = '" & Filter & "'"
        series1.DataSourceSorted = True
        Dim rnd As New Random
        series1.View.Color = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))
        Dim AxisX As AxisX = CType(lineChart.Diagram, XYDiagram).AxisX
        AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Minute
        AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Minute
        AxisX.WholeRange.SetMinMaxValues(DateTime.UtcNow.AddDays(-1).Date, DateTime.UtcNow.AddDays(1).Date)
        AxisX.WholeRange.AutoSideMargins = False
        AxisX.WholeRange.Auto = True
        AxisX.VisualRange.Auto = True

        CType(series1.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
        CType(series1.View, LineSeriesView).LineMarkerOptions.Kind = MarkerKind.Circle
        CType(series1.View, LineSeriesView).LineStyle.DashStyle = DashStyle.Dash

        CType(lineChart.Diagram, XYDiagram).EnableAxisXZooming = True

        lineChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True
        lineChart.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker
        lineChart.Titles.Add(New ChartTitle())
        lineChart.Titles(0).Text = System.Text.RegularExpressions.Regex.Replace(MetricName, "(?<!^)((?<!\d)\d|(?(?<=[A-Z])[A-Z](?=[a-z])|[A-Z]))", " $1")
        Return series1
    End Function

    Private Sub CRDS_Restored(sender As Object, e As EventArgs)
        Dim CRDS = CType(sender, DevExpress.XtraBars.Docking2010.Views.Widget.Document)
        Dim UserChart As UserChart = CType(CRDS.Control, UserChart)
        UserChart.MaxIS()
    End Sub

    Private Sub CRDS_Maximized(sender As Object, e As EventArgs)
        Dim CRDS = CType(sender, DevExpress.XtraBars.Docking2010.Views.Widget.Document)
        Dim UserChart As UserChart = CType(CRDS.Control, UserChart)
        UserChart.MaxIS()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        For Each z As DevExpress.XtraBars.Docking2010.Views.BaseDocument In WidgetView1.Documents
            Dim UserChart As UserChart = CType(z.Control, UserChart)
            UserChart.StopBackGroundWorker = False
        Next
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        For Each z As DevExpress.XtraBars.Docking2010.Views.BaseDocument In WidgetView1.Documents
            Dim UserChart As UserChart = CType(z.Control, UserChart)
            UserChart.StopBackGroundWorker = True
            UserChart.StartStatLoad()
        Next
    End Sub
    Private Sub ApplyLayoutMode(ByVal layoutMode As LayoutMode)
        WidgetView1.BeginUpdateAnimation()
        WidgetView1.LayoutMode = layoutMode
        Select Case layoutMode
            Case DevExpress.XtraBars.Docking2010.Views.Widget.LayoutMode.FlowLayout
                'InitFlowLayout()
            Case DevExpress.XtraBars.Docking2010.Views.Widget.LayoutMode.FreeLayout
                'InitFreeLayout()
            Case Else
                'pgMixAction.Visible = True
                'biItemMixer.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                'biDragMode.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
                'pgFlowDirection.Visible = False
        End Select
        WidgetView1.EndUpdateAnimation()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim BarButtonItem As DevExpress.XtraBars.BarButtonItem = CType(e.Item, DevExpress.XtraBars.BarButtonItem)
        ApplyLayoutMode(LayoutMode.StackLayout)
        StackLayoutMix()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim BarButtonItem As DevExpress.XtraBars.BarButtonItem = CType(e.Item, DevExpress.XtraBars.BarButtonItem)
        ApplyLayoutMode(LayoutMode.FlowLayout)
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        'Dim BarButtonItem As DevExpress.XtraBars.BarButtonItem = CType(e.Item, DevExpress.XtraBars.BarButtonItem)
        TableLayoutMix()
        ApplyLayoutMode(LayoutMode.TableLayout)

    End Sub
    Private random As New Random()
    Private Sub TableLayoutMix(Optional ByVal col As Integer = 3)
        Try
            WidgetView1.BeginUpdateAnimation()
            Dim nbDoc As Integer = WidgetView1.Documents.Count
            Dim z As String = Nothing
            Dim resultdiff As Integer = col - WidgetView1.Columns.Count
            If resultdiff > 0 Then
                For index As Integer = WidgetView1.Columns.Count To col
                    WidgetView1.Columns.Add(New ColumnDefinition)
                Next
            ElseIf resultdiff < 0 Then
                For index As Integer = 0 To (resultdiff * -1)
                    WidgetView1.Columns.Remove(WidgetView1.Columns(index))
                Next

            End If


            Dim crow As Integer = 0
            Dim ccol As Integer = 0
            For Each document As Document In WidgetView1.Documents
                If ccol = WidgetView1.Columns.Count Then
                    crow += 1
                    ccol = 0
                    WidgetView1.Rows.Add(New RowDefinition)
                End If
                document.RowIndex = crow
                document.ColumnIndex = ccol
                ccol += 1
            Next document
        Finally
            WidgetView1.EndUpdateAnimation()
        End Try
    End Sub
    Private Sub StackLayoutMix(Optional ByVal NbStack As Integer = 3)

        If NbStack > WidgetView1.StackGroups.Count Then

            For index As Integer = WidgetView1.StackGroups.Count To NbStack
                Dim st As New StackGroup
                WidgetView1.StackGroups.Add(st)
            Next

        End If

        Dim randomIndex As Integer = 0
        Try
            WidgetView1.BeginUpdateAnimation()
            For Each document As Document In WidgetView1.Documents
                Dim oldGroup As StackGroup = document.Parent
                If oldGroup IsNot Nothing Then
                    oldGroup.Items.Remove(document)
                End If
                WidgetView1.StackGroups(randomIndex).Items.Add(document)
                If randomIndex = NbStack - 1 Then
                    randomIndex = 0
                Else
                    randomIndex += 1
                End If
            Next document
        Finally
            WidgetView1.EndUpdateAnimation()
        End Try
    End Sub
End Class
