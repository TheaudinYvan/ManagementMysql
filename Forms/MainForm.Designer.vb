<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.DocumentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.SkinDropDownButtonItem1 = New DevExpress.XtraBars.SkinDropDownButtonItem()
        Me.BarEditCredentials = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryCredentials = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.AdvTree1 = New DevComponents.AdvTree.AdvTree()
        Me.NodeServers = New DevComponents.AdvTree.Node()
        Me.NodeUsers = New DevComponents.AdvTree.Node()
        Me.UserGroups = New DevComponents.AdvTree.Node()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.NodeGrantsSql = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.DockPanel2 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel2_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.TabbedView1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonContext = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonRegion = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonRefresh = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonMetrics = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonCreateSnapShot = New DevComponents.DotNetBar.ButtonItem()
        Me.Flyout1 = New DevComponents.DotNetBar.Controls.Flyout(Me.components)
        Me.UserGridSnapShot1 = New ManagementMysql.UserGridSnapShot()
        Me.FlyoutPanel1 = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.adornerUIManager1 = New DevExpress.Utils.VisualEffects.AdornerUIManager(Me.components)
        Me.dashMainBadge = New DevExpress.Utils.VisualEffects.Badge()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCredentials, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel2.SuspendLayout()
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlyoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanel1.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        CType(Me.adornerUIManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DocumentManager1
        '
        Me.DocumentManager1.ContainerControl = Me
        Me.DocumentManager1.MenuManager = Me.BarManager1
        Me.DocumentManager1.View = Me.TabbedView1
        Me.DocumentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.TabbedView1})
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockManager = Me.DockManager1
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarEditCredentials, Me.BarButtonItem1, Me.SkinDropDownButtonItem1})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 5
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryCredentials})
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Save"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SkinDropDownButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEditCredentials)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'SkinDropDownButtonItem1
        '
        Me.SkinDropDownButtonItem1.Id = 3
        Me.SkinDropDownButtonItem1.Name = "SkinDropDownButtonItem1"
        '
        'BarEditCredentials
        '
        Me.BarEditCredentials.Caption = "BarEditItem1"
        Me.BarEditCredentials.Edit = Me.RepositoryCredentials
        Me.BarEditCredentials.EditWidth = 100
        Me.BarEditCredentials.Id = 0
        Me.BarEditCredentials.Name = "BarEditCredentials"
        '
        'RepositoryCredentials
        '
        Me.RepositoryCredentials.AutoHeight = False
        Me.RepositoryCredentials.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryCredentials.Name = "RepositoryCredentials"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1047, 24)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 626)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1047, 27)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 24)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 602)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1047, 24)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 602)
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.MenuManager = Me.BarManager1
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1, Me.DockPanel2})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("81ae15e5-1165-4c37-9e57-4f7ce6246e37")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 24)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(224, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(224, 602)
        Me.DockPanel1.Text = "List of servers"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.AdvTree1)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 23)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(215, 575)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'AdvTree1
        '
        Me.AdvTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.AdvTree1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.AdvTree1.BackgroundStyle.Class = "TreeBorderKey"
        Me.AdvTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ContextMenuBar1.SetContextMenuEx(Me.AdvTree1, Me.ButtonContext)
        Me.AdvTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.AdvTree1.Location = New System.Drawing.Point(0, 0)
        Me.AdvTree1.Name = "AdvTree1"
        Me.AdvTree1.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.NodeServers, Me.NodeUsers, Me.UserGroups, Me.Node1, Me.NodeGrantsSql})
        Me.AdvTree1.NodesConnector = Me.NodeConnector1
        Me.AdvTree1.NodeStyle = Me.ElementStyle1
        Me.AdvTree1.PathSeparator = ";"
        Me.AdvTree1.Size = New System.Drawing.Size(215, 575)
        Me.AdvTree1.Styles.Add(Me.ElementStyle1)
        Me.AdvTree1.TabIndex = 2
        Me.AdvTree1.Text = "AdvTree1"
        '
        'NodeServers
        '
        Me.NodeServers.DataKeyString = "Servers"
        Me.NodeServers.Expanded = True
        Me.NodeServers.Image = Global.ManagementMysql.My.Resources.Resources.iconfinder_Server_858733
        Me.NodeServers.Name = "NodeServers"
        Me.NodeServers.Text = "Servers"
        '
        'NodeUsers
        '
        Me.NodeUsers.Expanded = True
        Me.NodeUsers.Image = Global.ManagementMysql.My.Resources.Resources.iconfinder_User_4737448
        Me.NodeUsers.Name = "NodeUsers"
        Me.NodeUsers.Text = "Users"
        '
        'UserGroups
        '
        Me.UserGroups.Expanded = True
        Me.UserGroups.Image = Global.ManagementMysql.My.Resources.Resources.iconfinder_user_group_team_duo_partner_3209200
        Me.UserGroups.Name = "UserGroups"
        Me.UserGroups.Text = "Groups"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.Image = Global.ManagementMysql.My.Resources.Resources.iconfinder_165_Infrastructure_monitoring_surveillance_vision_eye_network_cloud_smart_computing_4178958
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "Monitoring"
        '
        'NodeGrantsSql
        '
        Me.NodeGrantsSql.Expanded = True
        Me.NodeGrantsSql.Image = Global.ManagementMysql.My.Resources.Resources.login
        Me.NodeGrantsSql.Name = "NodeGrantsSql"
        Me.NodeGrantsSql.Text = "GrantSql"
        Me.NodeGrantsSql.Tooltip = "MariaDb | MySQL"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'DockPanel2
        '
        Me.DockPanel2.Controls.Add(Me.DockPanel2_Container)
        Me.DockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top
        Me.DockPanel2.ID = New System.Guid("59a6786a-6283-4410-be1d-1d3f2e00af03")
        Me.DockPanel2.Location = New System.Drawing.Point(224, 24)
        Me.DockPanel2.Name = "DockPanel2"
        Me.DockPanel2.OriginalSize = New System.Drawing.Size(200, 200)
        Me.DockPanel2.Size = New System.Drawing.Size(823, 200)
        Me.DockPanel2.Text = "The weather"
        '
        'DockPanel2_Container
        '
        Me.DockPanel2_Container.Location = New System.Drawing.Point(4, 23)
        Me.DockPanel2_Container.Name = "DockPanel2_Container"
        Me.DockPanel2_Container.Size = New System.Drawing.Size(815, 172)
        Me.DockPanel2_Container.TabIndex = 0
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.IsMaximized = False
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonContext})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(355, 612)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(75, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 6
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'ButtonContext
        '
        Me.ButtonContext.AutoExpandOnClick = True
        Me.ButtonContext.Name = "ButtonContext"
        Me.ButtonContext.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonRegion, Me.ButtonRefresh, Me.ButtonMetrics, Me.ButtonCreateSnapShot})
        Me.ButtonContext.Text = "ButtonItem1"
        '
        'ButtonRegion
        '
        Me.ButtonRegion.Name = "ButtonRegion"
        Me.ButtonRegion.Symbol = ""
        Me.ButtonRegion.SymbolSize = 12.0!
        Me.ButtonRegion.Text = "Add Region"
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Symbol = ""
        Me.ButtonRefresh.SymbolSize = 12.0!
        Me.ButtonRefresh.Text = "Refresh"
        '
        'ButtonMetrics
        '
        Me.ButtonMetrics.Name = "ButtonMetrics"
        Me.ButtonMetrics.Symbol = ""
        Me.ButtonMetrics.SymbolSize = 12.0!
        Me.ButtonMetrics.Text = "Metrics"
        '
        'ButtonCreateSnapShot
        '
        Me.ButtonCreateSnapShot.Name = "ButtonCreateSnapShot"
        Me.ButtonCreateSnapShot.Symbol = ""
        Me.ButtonCreateSnapShot.SymbolSize = 12.0!
        Me.ButtonCreateSnapShot.Text = "Create SnapShot"
        '
        'Flyout1
        '
        Me.Flyout1.Content = Me.UserGridSnapShot1
        Me.Flyout1.DropShadow = False
        Me.Flyout1.Parent = Me
        '
        'UserGridSnapShot1
        '
        Me.UserGridSnapShot1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserGridSnapShot1.Location = New System.Drawing.Point(2, 2)
        Me.UserGridSnapShot1.Name = "UserGridSnapShot1"
        Me.UserGridSnapShot1.Size = New System.Drawing.Size(580, 150)
        Me.UserGridSnapShot1.TabIndex = 12
        '
        'FlyoutPanel1
        '
        Me.FlyoutPanel1.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanel1.Location = New System.Drawing.Point(423, 499)
        Me.FlyoutPanel1.Name = "FlyoutPanel1"
        Me.FlyoutPanel1.Size = New System.Drawing.Size(584, 154)
        Me.FlyoutPanel1.TabIndex = 13
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.UserGridSnapShot1)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanel1
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(584, 154)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'adornerUIManager1
        '
        Me.adornerUIManager1.Elements.Add(Me.dashMainBadge)
        Me.adornerUIManager1.Owner = Me.DockPanel1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 653)
        Me.Controls.Add(Me.FlyoutPanel1)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.DockPanel2)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MainForm"
        Me.Text = "ManagementMySQL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCredentials, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel2.ResumeLayout(False)
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlyoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanel1.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        CType(Me.adornerUIManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DocumentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents TabbedView1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents AdvTree1 As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeServers As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents UserGroups As DevComponents.AdvTree.Node
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents BarEditCredentials As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryCredentials As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents NodeUsers As DevComponents.AdvTree.Node
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonContext As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonRegion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ButtonRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Flyout1 As DevComponents.DotNetBar.Controls.Flyout
    Friend WithEvents UserGridSnapShot1 As UserGridSnapShot
    Friend WithEvents FlyoutPanel1 As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Private WithEvents adornerUIManager1 As DevExpress.Utils.VisualEffects.AdornerUIManager
    Friend WithEvents dashMainBadge As DevExpress.Utils.VisualEffects.Badge
    Friend WithEvents DockPanel2 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel2_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents ButtonMetrics As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents SkinDropDownButtonItem1 As DevExpress.XtraBars.SkinDropDownButtonItem
    Friend WithEvents NodeGrantsSql As DevComponents.AdvTree.Node
    Friend WithEvents ButtonCreateSnapShot As DevComponents.DotNetBar.ButtonItem
End Class
