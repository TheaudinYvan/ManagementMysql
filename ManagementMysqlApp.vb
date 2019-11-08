Imports Amazon
Imports Amazon.Runtime
Imports Amazon.Runtime.CredentialManagement
Imports DevComponents.AdvTree

Public Class ManagementMysqlApp
    Private Shared mApplication As ManagementMysqlApp
    Public MariadbDb As Array = {"Select_priv", "Insert_priv", "Update_priv", "Delete_priv", "Create_priv", "Drop_priv", "Grant_priv", "References_priv", "Index_priv", "Alter_priv", "Create_tmp_table_priv", "Lock_tables_priv", "Create_view_priv", "Show_view_priv", "Create_routine_priv", "Alter_routine_priv", "Execute_priv", "Event_priv", "Trigger_priv"}
    Public MariadbUser As Array = {"Select_priv", "Insert_priv", "Update_priv", "Delete_priv", "Create_priv", "Drop_priv", "Reload_priv", "Shutdown_priv", "Process_priv", "File_priv", "Grant_priv", "References_priv", "Index_priv", "Alter_priv", "Show_db_priv", "Super_priv", "Create_tmp_table_priv", "Lock_tables_priv", "Execute_priv", "Repl_slave_priv", "Repl_client_priv", "Create_view_priv", "Show_view_priv", "Create_routine_priv", "Alter_routine_priv", "Create_user_priv", "Event_priv", "Trigger_priv", "Create_tablespace_priv", "max_questions", "max_updates", "max_connections", "max_user_connections", "plugin", "password_expired", "max_statement_time"}
    Public MysqlDb As Array = {"Select_priv", "Insert_priv", "Update_priv", "Delete_priv", "Index_priv", "Alter_priv", "Create_priv", "Drop_priv", "Grant_priv", "Create_view_priv", "Show_view_priv", "Create_routine_priv", "Alter_routine_priv", "Execute_priv", "Trigger_priv", "Event_priv", "Create_tmp_table_priv", "Lock_tables_priv", "References_priv"}
    Public MysqlUser As Array = {"Select_priv", "Insert_priv", "Update_priv", "Delete_priv", "Index_priv", "Alter_priv", "Create_priv", "Drop_priv", "Grant_priv", "Create_view_priv", "Show_view_priv", "Create_routine_priv", "Alter_routine_priv", "Execute_priv", "Trigger_priv", "Event_priv", "Create_tmp_table_priv", "Lock_tables_priv", "References_priv", "Reload_priv", "Shutdown_priv", "Process_priv", "File_priv", "Show_db_priv", "Super_priv", "Repl_slave_priv", "Repl_client_priv", "Create_user_priv", "Create_tablespace_priv", "Create_role_priv", "Drop_role_priv", "max_questions", "max_updates", "max_connections", "max_user_connections"}

    Private _MetricByInstance As New Dictionary(Of String, List(Of ConfigStat))
    Public Property MetricByInstance As Dictionary(Of String, List(Of ConfigStat))
        Get
            Return _MetricByInstance
        End Get
        Set(value As Dictionary(Of String, List(Of ConfigStat)))
            _MetricByInstance = value
        End Set
    End Property

    Private _ColorChart As Dictionary(Of String, Color)
    Public Property ColorChart As Dictionary(Of String, Color)
        Get
            Return _ColorChart
        End Get
        Set(value As Dictionary(Of String, Color))
            _ColorChart = value
        End Set
    End Property

    Private _DictChart As New Dictionary(Of String, UserChart)
    Public Property DictChart As Dictionary(Of String, UserChart)
        Get
            Return _DictChart

        End Get
        Set(value As Dictionary(Of String, UserChart))
            _DictChart = value
        End Set
    End Property
    Public Structure ConfiChart
        Dim Id As String
        Dim NameInstance As String
        Dim ValueColInstance As String
        Dim dimension As Amazon.CloudWatch.Model.Dimension
        Dim StartTimeUtc As Date
        Dim EndTimeUtc As Date
        Dim Period As Integer
        Dim [Namespace] As String
        Dim Statistics As List(Of String)
        Dim Request As Amazon.CloudWatch.Model.GetMetricStatisticsRequest
        Dim RegionEndpoint As RegionEndpoint
        Dim profile As String
    End Structure

    Public Structure ConfigStat
        Dim instance As String
        Dim metrics As String
        Dim SystemNameRegion As String
        Dim CheckBoxItem As DevComponents.DotNetBar.CheckBoxItem
    End Structure
    Private _MainFormTabbedView As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Public Property MainFormTabbedView As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
        Get
            Return _MainFormTabbedView

        End Get
        Set(value As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView)
            _MainFormTabbedView = value
        End Set
    End Property
    Private _mMainForm As MainForm
    Public Property mMainForm As MainForm
        Get
            Return _mMainForm

        End Get
        Set(value As MainForm)
            _mMainForm = value
        End Set
    End Property

    Public Shared ReadOnly Property ManagementMysqlApplication() As ManagementMysqlApp
        Get
            Return mApplication
        End Get
    End Property
    Private _AWSCredentials As AWSCredentials
    Public Property AWSCredentials As AWSCredentials
        Get
            Return _AWSCredentials
        End Get
        Set(value As AWSCredentials)
            _AWSCredentials = value
        End Set
    End Property

    Private _AdvTree As AdvTree
    Public Property AdvTree As AdvTree
        Get
            Return _AdvTree
        End Get
        Set(value As AdvTree)
            _AdvTree = value
        End Set
    End Property
    Public Shared Sub Initialize()
        mApplication = New ManagementMysqlApp()
        mApplication.mMainForm = New MainForm
        Try

            'AwsGestionApp.AwsGestionApplication.ConstructDbStatus()
            If IO.File.Exists("datadroit.xml") Then
                ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.ReadXml("datadroit.xml")
            End If

            Application.Run(mApplication.mMainForm)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SaveData()
        ManagementMysqlApp.ManagementMysqlApplication.DataSetData1.WriteXml("datadroit.xml")
    End Sub
    Public Function CreateAwsCredential(ByVal NameCredential As String, Optional ByVal Comment As String = "", Optional ByVal ViewInfo As Boolean = True) As Amazon.Runtime.AWSCredentials

        Dim awsCredentials As AWSCredentials = Nothing

        If chain.TryGetAWSCredentials(NameCredential, awsCredentials) Then
            If ViewInfo = True Then
                DevComponents.DotNetBar.Controls.DesktopAlert.Show("AWSCredentials Create OK : " & Comment, DevComponents.DotNetBar.Controls.eDesktopAlertColor.Green, DevComponents.DotNetBar.Controls.eAlertPosition.BottomRight)
            End If

            Return awsCredentials
        Else
            DevComponents.DotNetBar.Controls.DesktopAlert.Show("AWSCredentials Create KO : " & Comment, DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red, DevComponents.DotNetBar.Controls.eAlertPosition.BottomRight)
            Return Nothing
        End If



    End Function

    Private chain As CredentialProfileStoreChain
    Public Function LoadCredentials() As List(Of String)
        Dim l As New List(Of String)
        chain = New CredentialProfileStoreChain(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\.aws\credentials")
        For Each z As CredentialProfile In chain.ListProfiles
            l.Add(z.Name)
        Next
        Return l
    End Function

    Public Function GetImageNodeFlag(ByVal namepurge As String, Optional ByVal s As String = "32") As Image

        Select Case namepurge

            Case "EU Central (Frankfurt)"
                namepurge = "Germany-Flag"
            Case "EU West (Ireland)"
                namepurge = "Ireland-Flag"
            Case "EU West (London)"
                namepurge = "United-Kingdom-Flag"
            Case "US East (Virginia)"
                namepurge = "Virginia-Flag"
            Case "US East (Ohio)"
                namepurge = "Ohio-Flag"
            Case "Asia Pacific (Hong Kong)"
                namepurge = "Hong-Kong-Flag"
            Case "Asia Pacific (Tokyo)"
                namepurge = "Japan-Flag"
            Case "Asia Pacific (Seoul)"
                namepurge = "South-Korea"
            Case "Asia Pacific (Mumbai)"
                namepurge = "Indonesia-Flag"
            Case "Asia Pacific (Singapore)"
                namepurge = "Singapore-Flag"
            Case "Canada (Central)"
                namepurge = "Canada-Flag"
            Case "Asia Pacific (Sydney)"
                namepurge = "australia-Flag"
            Case "EU Central (Frankfurt)"
                namepurge = "Germany-Flag"
            Case "EU North (Stockholm)"
                namepurge = "Sweden-Flag"
            Case "EU West (Ireland)"
                namepurge = "Ireland-Flag"
            Case "EU West (London)"
                namepurge = "United-Kingdom-Flag"
            Case "EU West (Paris)"
                namepurge = "France-Flag"
            Case "Middle East (Bahrain)"
                namepurge = "Bahrain-Flag"
            Case "South America (Sao Paulo)"
                namepurge = "Brazil-Flag"
            Case "US East (Virginia)"
                namepurge = "Virginia-Flag"
            Case "US East (Ohio)"
                namepurge = "Ohio-Flag"
            Case "US West (N.California)"
                namepurge = "California-Flag"
            Case "US West (Oregon)"
                namepurge = "Oregon-Flag"
            Case "China (Beijing)"
                namepurge = "China-Flag"
            Case "China (Ningxia)"
                namepurge = "China-Flag"
            Case "US GovCloud East (Virginia)"
                namepurge = "Virginia-Flag"
            Case "US GovCloud West (Oregon)"
                namepurge = "Oregon-Flag"


        End Select
        Return ImageCollection1.Images(namepurge & s & ".png")

        'For i As Integer = 0 To ImageCollection1.Images.InnerImages.Count - 1

        '    If ImageCollection1.Images.InnerImages.Item(i).Name.Contains(namepurge) Then

        '    End If

        'Next
        'For z As Integer = 0 To ImageCollection1.Images.Count
        '    If ImageCollection1.Images(z).Keys(0).ToString.Contains(namepurge) Then

        '    End If
        'Next
        Return Nothing
    End Function
End Class
