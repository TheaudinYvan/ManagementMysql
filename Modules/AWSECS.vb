Imports Amazon
Imports Amazon.ECR
Imports Amazon.ECR.Model
Imports Amazon.ECS
Imports Amazon.ECS.Model
Imports DevComponents.AdvTree
Imports DevExpress.XtraSplashScreen

Module AWSECS
    Public Sub GetListCluster(ByVal Node As DevComponents.AdvTree.Node, ByVal Profile As String, ByVal Form As Form)

        Try



            SplashScreenManager.ShowForm(Form, GetType(WaitForm1), True, True, False)
            For Each n As Node In Node.Nodes
                Dim Region As RegionEndpoint = GetRegion(n.Text)
                Dim AmazonECSClient As AmazonECSClient = New AmazonECSClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(Profile, "", False), Region)
                Dim ListClustersRequest As ListClustersRequest = New ListClustersRequest
                Dim ListClustersResponse As ListClustersResponse = AmazonECSClient.ListClusters(ListClustersRequest)
                For Each v In ListClustersResponse.ClusterArns
                    SplashScreenManager.Default.SetWaitFormDescription("Loading " & v)
                    Dim c As New Node
                    c.Text = v.Split("/")(1)
                    c.Tag = v
                    n.Nodes.Add(c)
                    n.Text = "<b>" & n.Text & "</b>"
                    GetListContainer(c, v, Region, Profile)
                Next

            Next
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub GetListContainer(ByVal Node As DevComponents.AdvTree.Node, ByVal ClusterArn As String, ByVal Region As RegionEndpoint, ByVal Profile As String)
        Try
            Dim AmazonECSClient As AmazonECSClient = New AmazonECSClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(Profile, "", False), Region)
            Dim response As ListContainerInstancesResponse = AmazonECSClient.ListContainerInstances(New ListContainerInstancesRequest With {.Cluster = ClusterArn})

            For Each v In response.ContainerInstanceArns
                Dim c As New Node
                c.Text = v.Split("/")(1)
                c.Tag = v
                Node.Nodes.Add(c)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub GetListRepositories(ByVal Node As DevComponents.AdvTree.Node, ByVal Profile As String, ByVal Form As Form)
        Try
            SplashScreenManager.ShowForm(Form, GetType(WaitForm1), True, True, False)
            For Each n As Node In Node.Nodes

                Dim Region As RegionEndpoint = GetRegion(n.Text)
                Dim AmazonECRClient As AmazonECRClient = New AmazonECRClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(Profile, "", False), Region)
                Dim DescribeRepositoriesRequest As DescribeRepositoriesRequest = New DescribeRepositoriesRequest
                Dim response As DescribeRepositoriesResponse = AmazonECRClient.DescribeRepositories(DescribeRepositoriesRequest)
                For Each v In response.Repositories
                    SplashScreenManager.Default.SetWaitFormDescription("Loading " & v.RepositoryName)
                    Dim c As New Node
                    c.Text = v.RepositoryName
                    c.Tag = v
                    n.Nodes.Add(c)
                    n.Text = "<b>" & n.Text & "</b>"
                    GetListContainerImages(c, v.RepositoryName, Region, Profile)
                Next
            Next
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub GetListContainerImages(ByVal Node As DevComponents.AdvTree.Node, ByVal RepositoryName As String, ByVal Region As RegionEndpoint, ByVal Profile As String)
        Try
            Dim AmazonECRClient As AmazonECRClient = New AmazonECRClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(Profile, "", False), Region)
            Dim response As ListImagesResponse = AmazonECRClient.ListImages(New ListImagesRequest With {.RepositoryName = RepositoryName})

            For Each v In response.ImageIds
                Dim c As New Node
                c.Text = v.ImageTag
                c.Tag = v
                Node.Nodes.Add(c)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Module
