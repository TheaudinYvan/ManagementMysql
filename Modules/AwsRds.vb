Imports Amazon
Imports Amazon.RDS
Imports Amazon.RDS.Model

Module AwsRds
    Public Function GetSnapShotPercentProgress(ByVal MeDBInstance As DBInstance, ByVal RegionEndpoint As RegionEndpoint, ByVal DBSnapshot As DBSnapshot, ByVal Profile As String) As Integer
        'AWSConfigs.AWSRegion = RegionEndpoint.SystemName
        Dim requestSnapp = New Amazon.RDS.Model.DescribeDBSnapshotsRequest
        Dim AmazonRDSClient = New AmazonRDSClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(Profile, "", False), RegionEndpoint)
        Dim response = AmazonRDSClient.DescribeDBSnapshots(requestSnapp)
        For Each v As DBSnapshot In response.DBSnapshots
            If v.DBSnapshotArn = DBSnapshot.DBSnapshotArn Then
                'Console.WriteLine(v.PercentProgress)

                Return v.PercentProgress
            End If
        Next

        If response.DBSnapshots.Count = 0 Then
            Return 100
        End If
        Return 0
    End Function

    Public Function CreateSnapShot(ByVal Node As DevComponents.AdvTree.Node, ByVal RegionEndpoint As RegionEndpoint, ByVal Profile As String) As DBSnapshot
        Try
            Dim AmazonRDSClient = New AmazonRDSClient(ManagementMysqlApp.ManagementMysqlApplication.CreateAwsCredential(Profile, "", False), RegionEndpoint)
            Dim dbInstance As DBInstance = CType(Node.Tag, DBInstance)
            Dim nGuid As String = "ManuelBackup" & DateTime.Now.Day & DateTime.Now.Month & DateTime.Now.Year & "-" & DateTime.Now.Second
            Dim createsnap As New CreateDBSnapshotRequest(nGuid, dbInstance.DBInstanceIdentifier)
            Dim snapShotresponse As CreateDBSnapshotResponse = AmazonRDSClient.CreateDBSnapshot(createsnap)
            If snapShotresponse.HttpStatusCode = Net.HttpStatusCode.OK Then
                Return snapShotresponse.DBSnapshot
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
        'XPanel.Controls.Add(newProgress)
    End Function
End Module
