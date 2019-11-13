Partial Class ManagementMysqlApp
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Requis pour la prise en charge du Concepteur de composition de classes Windows.Forms
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur de composants.
        InitializeComponent()

    End Sub

    'Component remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur de composants
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur de composants
    'Elle peut être modifiée à l'aide du Concepteur de composants.
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManagementMysqlApp))
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.DataSetData1 = New ManagementMysql.DataSetData()
        Me.DataSetStat1 = New ManagementMysql.DataSetStat()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetData1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetStat1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "iconfinder_Storage__Content_Delivery_Amazon_EBS_Snapshot_259258.png")
        Me.ImageCollection1.Images.SetKeyName(1, "australia-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(2, "australia-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(3, "Bahrain-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(4, "Bahrain-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(5, "Brazil-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(6, "Brazil-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(7, "California-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(8, "California-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(9, "Canada-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(10, "Canada-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(11, "China-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(12, "China-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(13, "France-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(14, "France-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(15, "Germany-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(16, "Germany-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(17, "Hong-Kong-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(18, "Hong-Kong-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(19, "Indonesia-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(20, "Indonesia-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(21, "Ireland-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(22, "Ireland-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(23, "Japan-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(24, "Japan-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(25, "Ohio-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(26, "Ohio-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(27, "Oregon-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(28, "Oregon-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(29, "Singapore-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(30, "Singapore-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(31, "South-Korea.png")
        Me.ImageCollection1.Images.SetKeyName(32, "South-Korea32.png")
        Me.ImageCollection1.Images.SetKeyName(33, "Sweden-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(34, "Sweden-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(35, "United-Kingdom-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(36, "United-Kingdom-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(37, "Virginia-Flag.png")
        Me.ImageCollection1.Images.SetKeyName(38, "Virginia-Flag32.png")
        Me.ImageCollection1.Images.SetKeyName(39, "mysql.png")
        Me.ImageCollection1.Images.SetKeyName(40, "mariadb.png")
        Me.ImageCollection1.InsertImage(Global.ManagementMysql.My.Resources.Resources.tag_16x16, "tag_16x16", GetType(Global.ManagementMysql.My.Resources.Resources), 41)
        Me.ImageCollection1.Images.SetKeyName(41, "tag_16x16")
        Me.ImageCollection1.Images.SetKeyName(42, "login.png")
        '
        'DataSetData1
        '
        Me.DataSetData1.DataSetName = "DataSetData"
        Me.DataSetData1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataSetStat1
        '
        Me.DataSetStat1.DataSetName = "DataSetStat"
        Me.DataSetStat1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetData1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetStat1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents DataSetData1 As DataSetData
    Friend WithEvents DataSetStat1 As DataSetStat
End Class
