Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Public Class ScheduleTimePeriod

    <Key>
    Public Property dayID As String

    Public Property startDayTime As String

    Public Property startDayDate As String

    Public Property startGameTime As String

    Public Property startGameDate As String

    Public Property endDayTime As String

    Public Property endDayDate As String

End Class

Public Class ScheduleTimePeriodMemory

    Public Property dayID As String

    Public Property startDayTime As Int32

    Public Property startDayDate As Int32

    Public Property startGameTime As Int32

    Public Property startGameDate As Int32

    Public Property endDayTime As Int32

    Public Property endDayDate As Int32


End Class
