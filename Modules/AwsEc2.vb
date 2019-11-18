Imports Amazon
Imports Amazon.EC2
Imports Amazon.EC2.Model
Imports DevComponents.AdvTree
Imports DevExpress.XtraSplashScreen

Module AwsEc2
    Public Sub GetInstanceEc2(ByVal Node As Node, ByVal Profile As String, ByVal Form As Form)

        Try

            SplashScreenManager.ShowForm(Form, GetType(WaitForm1), True, True, False)
            For Each n As Node In Node.Nodes
                Dim Region As RegionEndpoint = GetRegion(n.Text)

                Dim AmazonEC2Client As AmazonEC2Client = New AmazonEC2Client(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(Profile, "", False), Region)
                Dim DescribeInstancesRequest As DescribeInstancesRequest = New DescribeInstancesRequest
                Dim DescribeInstancesResponse As DescribeInstancesResponse = AmazonEC2Client.DescribeInstances(DescribeInstancesRequest)
                For Each v As Reservation In DescribeInstancesResponse.Reservations
                    For Each i As Instance In v.Instances
                        SplashScreenManager.Default.SetWaitFormDescription("Loading " & i.KeyName)
                        Dim c As New Node
                        c.Text = i.KeyName
                        c.Tag = i
                        n.Nodes.Add(c)
                        n.Text = "<b>" & n.Text & "</b>"

                    Next


                Next

            Next
            SplashScreenManager.CloseForm()

        Catch EC2Exception As AmazonEC2Exception
            MsgBox(EC2Exception.Message)
        End Try

    End Sub

    Public Function GetTag(ByVal AmazonEC2Client As AmazonEC2Client, ByVal Typeid As String, ByVal id As String, ByVal KeyName As String) As String

        Dim DescribeTagsRequest As DescribeTagsRequest = New DescribeTagsRequest
        Dim filter As New Filter
        filter.Name = Typeid
        filter.Values.Add(id)
        DescribeTagsRequest.Filters.Add(filter)
        Dim DescribeTagsResponse As DescribeTagsResponse = AmazonEC2Client.DescribeTags(DescribeTagsRequest)
        For Each t In DescribeTagsResponse.Tags
            If t.Key = KeyName Then
                Return t.Value
            End If
        Next
        Return Nothing

    End Function
End Module
