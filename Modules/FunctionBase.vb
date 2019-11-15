Module FunctionBase
    Function StripTags(ByVal html As String) As String
        ' Remove HTML tags.
        Return System.Text.RegularExpressions.Regex.Replace(html, "<.*?>", "")
    End Function
End Module
