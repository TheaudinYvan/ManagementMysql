Public Class UserMeteo
    Private _Region As String
    Public Property Region As String
        Get
            Return _Region
        End Get
        Set(value As String)
            _Region = value
            labelControlRegion.Text = StripTags(_Region)
        End Set

    End Property


    Private _KO As String
    Public Property KO As String
        Get
            Return _KO
        End Get
        Set(value As String)
            _KO = value
            labelError.Text = _KO
            ChangeImage()
        End Set

    End Property
    Private _OK As String
    Public Property OK As String
        Get
            Return _OK
        End Get
        Set(value As String)
            _OK = value
            LabelSuccess.Text = _OK
        End Set

    End Property

    Private Sub ChangeImage()
        If KO > 0 Then
            PictureEdit1.SvgImage = SvgImageCollection1.Item("weather_storm")
            PictureEdit1.SvgImageSize = New Size(32, 32)
            labelError.ForeColor = Color.Red
        Else
            PictureEdit1.SvgImage = SvgImageCollection1.Item("weather_sunny")
            PictureEdit1.SvgImageSize = New Size(32, 32)
        End If
    End Sub
    Function StripTags(ByVal html As String) As String
        ' Remove HTML tags.
        Return System.Text.RegularExpressions.Regex.Replace(html, "<.*?>", "")
    End Function
End Class
