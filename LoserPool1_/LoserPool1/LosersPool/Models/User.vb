Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace LosersPool.Models
    Public Class User
        <Key>
        Public Property UserId As String

        <Required>
        Public Property UserName As String

        Public Property Administrator As Boolean

        Public Property OptionState As String

    End Class

    Public Class UserXML

        Public Property UserId As String

        Public Property UserName As String

        Public Property Administrator As Boolean

        Public Property OptionState As String

    End Class

    Public Class UserChoices

        <Key>
        Public Property ListId As Int32

        Public Property UserID As String

        Public Property UserName As String

        Public Property DayId As String

        Public Property ConfirmationNumber As Int32

        Public Property UserPick As String

        Public Property Contender As Boolean

        Public Property Washington As Boolean
        Public Property Miami As Boolean
        Public Property Colorado As Boolean
        Public Property Arizona As Boolean
        Public Property SanFrancisco As Boolean
        Public Property SanDiego As Boolean
        Public Property Pittsburg As Boolean
        Public Property Cincinnati As Boolean
        Public Property Toronto As Boolean
        Public Property NYYankees As Boolean
        Public Property Boston As Boolean
        Public Property TampaBay As Boolean
        Public Property Atlanta As Boolean
        Public Property Philadelphia As Boolean
        Public Property ChicagoWhiteSox As Boolean
        Public Property Detroit As Boolean
        Public Property KansasCity As Boolean
        Public Property Cleveland As Boolean
        Public Property Milwaukee As Boolean
        Public Property LADodgers As Boolean
        Public Property Minnesota As Boolean
        Public Property Oakland As Boolean
        Public Property Houston As Boolean
        Public Property Texas As Boolean
        Public Property STLouis As Boolean
        Public Property ChicagoCubs As Boolean
        Public Property LAAngels As Boolean
        Public Property Seattle As Boolean
        Public Property NYMets As Boolean
        Public Property Baltimore As Boolean

        Public Overridable Property PossibleUserPicks As New List(Of String)

        Public Overridable Property RadioButtonsForUserPicks As List(Of String)

        'Function WeekId() As String
        'Throw New NotImplementedException
        'End Function

        Function WeekId() As String
            Throw New NotImplementedException
        End Function



    End Class

    Public Class userChoicesXML

        Public Property UserID As String
        Public Property UserName As String
        Public Property DayId As String
        Public Property ConfirmationNumber As Int32
        Public Property UserPick As String

        Public Property Washington As Boolean
        Public Property Miami As Boolean
        Public Property Colorado As Boolean
        Public Property Arizona As Boolean
        Public Property SanFrancisco As Boolean
        Public Property SanDiego As Boolean
        Public Property Pittsburg As Boolean
        Public Property Cincinnati As Boolean
        Public Property Toronto As Boolean
        Public Property NYYankees As Boolean
        Public Property Boston As Boolean
        Public Property TampaBay As Boolean
        Public Property Atlanta As Boolean
        Public Property Philadelphia As Boolean
        Public Property ChicagoWhiteSox As Boolean
        Public Property Detroit As Boolean
        Public Property KansasCity As Boolean
        Public Property Cleveland As Boolean
        Public Property Milwaukee As Boolean
        Public Property LADodgers As Boolean
        Public Property Minnesota As Boolean
        Public Property Oakland As Boolean
        Public Property Houston As Boolean
        Public Property Texas As Boolean
        Public Property STLouis As Boolean
        Public Property ChicagoCubs As Boolean
        Public Property LAAngels As Boolean
        Public Property Seattle As Boolean
        Public Property NYMets As Boolean
        Public Property Baltimore As Boolean

        Public Property Contender As Boolean

    End Class


    Public Class UserResult

        <Key>
        Public Property ListId As Int32

        Public Property UserID As String

        Public Property UserName As String

        Public Property DayId As String

        Public Property Washington As Boolean
        Public Property Miami As Boolean
        Public Property Colorado As Boolean
        Public Property Arizona As Boolean
        Public Property SanFrancisco As Boolean
        Public Property SanDiego As Boolean
        Public Property Pittsburg As Boolean
        Public Property Cincinnati As Boolean
        Public Property Toronto As Boolean
        Public Property NYYankees As Boolean
        Public Property Boston As Boolean
        Public Property TampaBay As Boolean
        Public Property Atlanta As Boolean
        Public Property Philadelphia As Boolean
        Public Property ChicagoWhiteSox As Boolean
        Public Property Detroit As Boolean
        Public Property KansasCity As Boolean
        Public Property Cleveland As Boolean
        Public Property Milwaukee As Boolean
        Public Property LADodgers As Boolean
        Public Property Minnesota As Boolean
        Public Property Oakland As Boolean
        Public Property Houston As Boolean
        Public Property Texas As Boolean
        Public Property STLouis As Boolean
        Public Property ChicagoCubs As Boolean
        Public Property LAAngels As Boolean
        Public Property Seattle As Boolean
        Public Property NYMets As Boolean
        Public Property Baltimore As Boolean


    End Class
End Namespace
