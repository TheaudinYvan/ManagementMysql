<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserGrants
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
        Me.TextEditorControl1 = New ICSharpCode.TextEditor.TextEditorControl()
        Me.SuspendLayout()
        '
        'TextEditorControl1
        '
        Me.TextEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextEditorControl1.Highlighting = "SQL"
        Me.TextEditorControl1.Location = New System.Drawing.Point(0, 0)
        Me.TextEditorControl1.Name = "TextEditorControl1"
        Me.TextEditorControl1.Size = New System.Drawing.Size(655, 208)
        Me.TextEditorControl1.TabIndex = 0
        '
        'UserGrants
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextEditorControl1)
        Me.Name = "UserGrants"
        Me.Size = New System.Drawing.Size(655, 208)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextEditorControl1 As ICSharpCode.TextEditor.TextEditorControl
End Class
