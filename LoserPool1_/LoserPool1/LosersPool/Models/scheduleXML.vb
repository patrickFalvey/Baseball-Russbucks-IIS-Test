
Namespace LosersPool.Models
    Public Class gameXML
        Public Property startTime As String
        Public Property startDate As String
        Public Property homeTeam As String
        Public Property awayTeam As String
    End Class

    Public Class dayXML
        Public Property dayNumber As String
    End Class

    Public Class dailyFileXML
        Public Property dayFilePath As String
    End Class

    Public Class scheduleTimePeriodXML

        Public Property dayId As String
        Public Property startDayTime As String
        Public Property startDayDate As String
        Public Property startGameTime As String
        Public Property startGameDate As String
        Public Property endDayTime As String
        Public Property endDayDate As String

    End Class


End Namespace
