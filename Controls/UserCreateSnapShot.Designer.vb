<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserCreateSnapShot
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserCreateSnapShot))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelNameServer = New DevExpress.XtraEditors.LabelControl()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GaugeControl1 = New DevExpress.XtraGauges.Win.GaugeControl()
        Me.circularGauge14 = New DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge()
        Me.LabelComponent1 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
        Me.ImageIndicatorComponent1 = New DevExpress.XtraGauges.Win.Base.ImageIndicatorComponent()
        Me.ArcScaleComponent1 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent()
        Me.ArcScaleRangeBarComponent1 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.circularGauge14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageIndicatorComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArcScaleComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArcScaleRangeBarComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl1.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl1.AppearanceCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisWord
        Me.GroupControl1.AutoSize = True
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl1.Controls.Add(Me.GaugeControl1)
        Me.GroupControl1.Controls.Add(Me.LabelNameServer)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(112, 157)
        Me.GroupControl1.TabIndex = 4
        Me.GroupControl1.Text = "Please Wait"
        '
        'LabelNameServer
        '
        Me.LabelNameServer.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNameServer.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelNameServer.Appearance.Options.UseFont = True
        Me.LabelNameServer.Appearance.Options.UseForeColor = True
        Me.LabelNameServer.Appearance.Options.UseTextOptions = True
        Me.LabelNameServer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelNameServer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelNameServer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LabelNameServer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelNameServer.Location = New System.Drawing.Point(2, 139)
        Me.LabelNameServer.Name = "LabelNameServer"
        Me.LabelNameServer.Size = New System.Drawing.Size(108, 16)
        Me.LabelNameServer.TabIndex = 0
        Me.LabelNameServer.Text = "Please Wait"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'GaugeControl1
        '
        Me.GaugeControl1.ColorScheme.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GaugeControl1.ColorScheme.TargetElements = CType(((DevExpress.XtraGauges.Core.Base.TargetElement.RangeBar Or DevExpress.XtraGauges.Core.Base.TargetElement.ImageIndicator) _
            Or DevExpress.XtraGauges.Core.Base.TargetElement.Label), DevExpress.XtraGauges.Core.Base.TargetElement)
        Me.GaugeControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GaugeControl1.Gauges.AddRange(New DevExpress.XtraGauges.Base.IGauge() {Me.circularGauge14})
        Me.GaugeControl1.Location = New System.Drawing.Point(2, 25)
        Me.GaugeControl1.Name = "GaugeControl1"
        Me.GaugeControl1.Size = New System.Drawing.Size(108, 114)
        Me.GaugeControl1.TabIndex = 2
        '
        'circularGauge14
        '
        Me.circularGauge14.Bounds = New System.Drawing.Rectangle(6, 6, 96, 102)
        Me.circularGauge14.Images.AddRange(New DevExpress.XtraGauges.Win.Base.ImageIndicatorComponent() {Me.ImageIndicatorComponent1})
        Me.circularGauge14.Labels.AddRange(New DevExpress.XtraGauges.Win.Base.LabelComponent() {Me.LabelComponent1})
        Me.circularGauge14.Name = "circularGauge14"
        Me.circularGauge14.RangeBars.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent() {Me.ArcScaleRangeBarComponent1})
        Me.circularGauge14.Scales.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent() {Me.ArcScaleComponent1})
        '
        'LabelComponent1
        '
        Me.LabelComponent1.AppearanceText.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.LabelComponent1.Name = "circularGauge3_Label1"
        Me.LabelComponent1.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(205.0!, 93.0!)
        Me.LabelComponent1.Size = New System.Drawing.SizeF(50.0!, 40.0!)
        Me.LabelComponent1.Text = "95"
        Me.LabelComponent1.ZOrder = -1001
        '
        'ImageIndicatorComponent1
        '
        Me.ImageIndicatorComponent1.Image = CType(resources.GetObject("ImageIndicatorComponent1.Image"), System.Drawing.Image)
        Me.ImageIndicatorComponent1.Name = "circularGauge1_ImageIndicator1"
        Me.ImageIndicatorComponent1.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(123.0!, 125.0!)
        Me.ImageIndicatorComponent1.ZOrder = -1001
        '
        'ArcScaleComponent1
        '
        Me.ArcScaleComponent1.AppearanceMajorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
        Me.ArcScaleComponent1.AppearanceMajorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
        Me.ArcScaleComponent1.AppearanceMinorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
        Me.ArcScaleComponent1.AppearanceMinorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
        Me.ArcScaleComponent1.AppearanceTickmarkText.Font = New System.Drawing.Font("Tahoma", 8.5!)
        Me.ArcScaleComponent1.AppearanceTickmarkText.TextBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A")
        Me.ArcScaleComponent1.Center = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 125.0!)
        Me.ArcScaleComponent1.EndAngle = -45.0!
        Me.ArcScaleComponent1.MajorTickCount = 0
        Me.ArcScaleComponent1.MajorTickmark.FormatString = "{0:F0}"
        Me.ArcScaleComponent1.MajorTickmark.ShapeOffset = -14.0!
        Me.ArcScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1
        Me.ArcScaleComponent1.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight
        Me.ArcScaleComponent1.MaxValue = 100.0!
        Me.ArcScaleComponent1.MinorTickCount = 0
        Me.ArcScaleComponent1.MinorTickmark.ShapeOffset = -7.0!
        Me.ArcScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2
        Me.ArcScaleComponent1.Name = "scale1"
        Me.ArcScaleComponent1.StartAngle = -270.0!
        Me.ArcScaleComponent1.Value = 40.0!
        '
        'ArcScaleRangeBarComponent1
        '
        Me.ArcScaleRangeBarComponent1.ArcScale = Me.ArcScaleComponent1
        Me.ArcScaleRangeBarComponent1.Name = "circularGauge3_RangeBar2"
        Me.ArcScaleRangeBarComponent1.RoundedCaps = True
        Me.ArcScaleRangeBarComponent1.ShowBackground = True
        Me.ArcScaleRangeBarComponent1.StartOffset = 79.0!
        Me.ArcScaleRangeBarComponent1.ZOrder = -10
        '
        'UserCreateSnapShot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "UserCreateSnapShot"
        Me.Size = New System.Drawing.Size(112, 157)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.circularGauge14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelComponent1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageIndicatorComponent1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArcScaleComponent1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArcScaleRangeBarComponent1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelNameServer As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GaugeControl1 As DevExpress.XtraGauges.Win.GaugeControl
    Friend WithEvents circularGauge14 As DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge
    Private WithEvents ImageIndicatorComponent1 As DevExpress.XtraGauges.Win.Base.ImageIndicatorComponent
    Private WithEvents LabelComponent1 As DevExpress.XtraGauges.Win.Base.LabelComponent
    Private WithEvents ArcScaleRangeBarComponent1 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent
    Private WithEvents ArcScaleComponent1 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent
End Class
