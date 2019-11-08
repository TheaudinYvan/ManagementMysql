<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMeteo
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
        Me.components = New System.ComponentModel.Container()
        Me.SvgImageCollection1 = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.labelError = New DevExpress.XtraEditors.LabelControl()
        Me.LabelSuccess = New DevExpress.XtraEditors.LabelControl()
        Me.labelControlRegion = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.SvgImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SvgImageCollection1
        '
        Me.SvgImageCollection1.Add("weather_rainheavy", "image://svgimages/icon builder/weather_rainheavy.svg")
        Me.SvgImageCollection1.Add("weather_sunny", "image://svgimages/icon builder/weather_sunny.svg")
        Me.SvgImageCollection1.Add("weather_storm", "image://svgimages/icon builder/weather_storm.svg")
        '
        'labelError
        '
        Me.labelError.Appearance.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelError.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelError.Appearance.Options.UseFont = True
        Me.labelError.Appearance.Options.UseForeColor = True
        Me.labelError.Appearance.Options.UseTextOptions = True
        Me.labelError.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.labelError.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labelError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labelError.Location = New System.Drawing.Point(0, 54)
        Me.labelError.Name = "labelError"
        Me.labelError.Size = New System.Drawing.Size(116, 46)
        Me.labelError.TabIndex = 15
        Me.labelError.Text = "37F (3C)"
        '
        'LabelSuccess
        '
        Me.LabelSuccess.Appearance.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelSuccess.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelSuccess.Appearance.Options.UseFont = True
        Me.LabelSuccess.Appearance.Options.UseForeColor = True
        Me.LabelSuccess.Appearance.Options.UseTextOptions = True
        Me.LabelSuccess.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelSuccess.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelSuccess.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelSuccess.Location = New System.Drawing.Point(0, 100)
        Me.LabelSuccess.Name = "LabelSuccess"
        Me.LabelSuccess.Size = New System.Drawing.Size(116, 46)
        Me.LabelSuccess.TabIndex = 16
        Me.LabelSuccess.Text = "37F (3C)"
        '
        'labelControlRegion
        '
        Me.labelControlRegion.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelControlRegion.Appearance.Options.UseFont = True
        Me.labelControlRegion.Appearance.Options.UseTextOptions = True
        Me.labelControlRegion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.labelControlRegion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.labelControlRegion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.labelControlRegion.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelControlRegion.Location = New System.Drawing.Point(0, 0)
        Me.labelControlRegion.Name = "labelControlRegion"
        Me.labelControlRegion.Size = New System.Drawing.Size(116, 21)
        Me.labelControlRegion.TabIndex = 13
        Me.labelControlRegion.Text = "SnapShot"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 21)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Size = New System.Drawing.Size(116, 33)
        Me.PictureEdit1.TabIndex = 17
        '
        'UserMeteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.labelError)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.LabelSuccess)
        Me.Controls.Add(Me.labelControlRegion)
        Me.Name = "UserMeteo"
        Me.Size = New System.Drawing.Size(116, 146)
        CType(Me.SvgImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SvgImageCollection1 As DevExpress.Utils.SvgImageCollection
    Private WithEvents labelError As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelSuccess As DevExpress.XtraEditors.LabelControl
    Private WithEvents labelControlRegion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
End Class
