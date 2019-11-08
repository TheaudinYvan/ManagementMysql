Friend NotInheritable Class Program

    ''' <summary>
    ''' Mains this instance.	
    ''' </summary>
    ''' <remarks></remarks>
    <STAThread()>
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(True)
        Try
        Catch e As Exception
            Return
        End Try

        ManagementMysqlApp.Initialize()

    End Sub

End Class
