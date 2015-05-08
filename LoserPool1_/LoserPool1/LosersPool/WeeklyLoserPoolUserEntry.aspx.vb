Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.ModelBinding
Imports System.Data
Imports System.Threading

Imports LoserPool1.LosersPool.Models
Public Class WeeklyLoserPoolUserEntry
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("userId") Is Nothing Then
            Response.Redirect("~/Account/Login.aspx")
        End If

        Dim _dbLoserPool As New LosersPoolContext

        Dim EName = CStr(Session("userId"))
        Dim dayNumber = CStr(Session("dayNumber"))

        Dim mpl = LoserPool1.MyPickList.UserPickList(EName, dayNumber)

        Dim currentDateTime = Date.Now

        Dim minStartTime = currentDateTime.AddYears(1)

        Try

            Dim queryScheduleStartTime = (From game1 In _dbLoserPool.ScheduleEntities
                                          Where game1.DayId = dayNumber
                                          Select game1).ToList

            ' Find Minimum start time for week
            For Each game1 In queryScheduleStartTime

                Dim gameStartDateTime = DateTime.Parse(CDate(game1.StartDate + " " + game1.StartTime))
                If gameStartDateTime < minStartTime Then
                    minStartTime = gameStartDateTime
                End If

            Next

            ' Is current time < min Start Time

            If currentDateTime > minStartTime Then
                Response.Redirect("~/LosersPool/Default.aspx")
            End If

            If mpl Is Nothing Then
                Button1.Visible = False
                Button2.Visible = True
                loser1.Visible = True
                Exit Try
            Else
                Button1.Visible = True
                Button2.Visible = False
                loser1.Visible = False
                If mpl.Washington = True Or mpl.PossibleUserPicks.Contains("Washington") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Washington"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Miami = True Or mpl.PossibleUserPicks.Contains("Miami") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Miami"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Colorado = True Or mpl.PossibleUserPicks.Contains("Colorado") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Colorado"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Arizona = True Or mpl.PossibleUserPicks.Contains("Arizona") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Arizona"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.SanFrancisco = True Or mpl.PossibleUserPicks.Contains("San Francisco") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "San Francisco"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.SanDiego = True Or mpl.PossibleUserPicks.Contains("San Diego") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "San Diego"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Pittsburg = True Or mpl.PossibleUserPicks.Contains("Pittsburg") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Pittsburg"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Cincinnati = True Or mpl.PossibleUserPicks.Contains("Cincinnati") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Cincinnati"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Toronto = True Or mpl.PossibleUserPicks.Contains("Toronto") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Toronto"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.NYYankees = True Or mpl.PossibleUserPicks.Contains("NY Yankees") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "NY Yankees"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Boston = True Or mpl.PossibleUserPicks.Contains("Boston") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Boston"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.TampaBay = True Or mpl.PossibleUserPicks.Contains("Tampa Bay") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Tampa Bay"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Atlanta = True Or mpl.PossibleUserPicks.Contains("Atlanta") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Atlanta"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Philadelphia = True Or mpl.PossibleUserPicks.Contains("Philadelphia") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Philadelphia"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.ChicagoWhiteSox = True Or mpl.PossibleUserPicks.Contains("Chicago White Sox") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Chicago White Sox"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Detroit = True Or mpl.PossibleUserPicks.Contains("Detroit") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Detroit"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.KansasCity = True Or mpl.PossibleUserPicks.Contains("Kansas City") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Kansas City"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Cleveland = True Or mpl.PossibleUserPicks.Contains("Cleveland") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Cleveland"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Milwaukee = True Or mpl.PossibleUserPicks.Contains("Milwaukee") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Panthers"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.LADodgers = True Or mpl.PossibleUserPicks.Contains("LA Dodgers") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "LA Dodgers"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Minnesota = True Or mpl.PossibleUserPicks.Contains("Minnesota") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Minnesota"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Oakland = True Or mpl.PossibleUserPicks.Contains("Oakland") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Oakland"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Houston = True Or mpl.PossibleUserPicks.Contains("Houston") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Houston"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Texas = True Or mpl.PossibleUserPicks.Contains("Texas") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Texas"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.STLouis = True Or mpl.PossibleUserPicks.Contains("St. Louis") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "St. Louis"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.ChicagoCubs = True Or mpl.PossibleUserPicks.Contains("Chicago Cubs") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Chicago Cubs"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.LAAngels = True Or mpl.PossibleUserPicks.Contains("LA Angels") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "LA Angels"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Seattle = True Or mpl.PossibleUserPicks.Contains("Seattle") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Cowboys"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.NYMets = True Or mpl.PossibleUserPicks.Contains("NY Mets") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "NY Mets"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                If mpl.Baltimore = True Or mpl.PossibleUserPicks.Contains("Baltimore") Then
                    Dim MyPick1 As New MyPick
                    MyPick1.ListId = _dbLoserPool.MyPicks.Count + 1
                    MyPick1.PossibleTeam = "Baltimore"
                    _dbLoserPool.MyPicks.Add(MyPick1)
                End If

                _dbLoserPool.SaveChanges()

            End If

            Dim queryByeTeams = (From team1 In _dbLoserPool.ByeTeamsList
                                 Where team1.DayId = dayNumber).ToList
            For Each team1 In queryByeTeams

                Dim queryMyPicks = (From pick1 In _dbLoserPool.MyPicks
                                    Where pick1.PossibleTeam = team1.TeamName).ToList

                If queryMyPicks.Count > 0 Then
                    _dbLoserPool.MyPicks.Remove(queryMyPicks(0))
                End If
            Next
            _dbLoserPool.SaveChanges()

        Catch ex As Exception

        End Try

    End Sub

    ' The return type can be changed to IEnumerable, however to support
    ' paging and sorting, the following parameters must be added:
    '     ByVal maximumRows as Integer
    '     ByVal startRowIndex as Integer
    '     ByRef totalRowCount as Integer
    '     ByVal sortByExpression as String
    'Public Function GridView1_GetData() As IQueryable(Of MyPick)

    'End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim EName = CStr(Session("userId"))
        Dim dayNumber = CStr(Session("dayNumber"))

        'day increment = 2 due to betting every other day
        Dim I2 = 2
        Dim lastDay = "day" + CStr(CInt(Mid(dayNumber, 4)) - I2)
        If lastDay = "day-1" Then
            lastDay = "day0"
        End If

        Dim _DbLoserPool As New LosersPoolContext
        Using (_DbLoserPool)
            Try

                Dim lastDayChoice As New UserChoices
                lastDayChoice = _DbLoserPool.UserChoicesList.SingleOrDefault(Function(lWC) lWC.UserID = EName And lWC.DayId = lastDay)
                lastDayChoice = SetContendersPickToFalse(lastDayChoice)
                lastDayChoice.DayId = dayNumber
                lastDayChoice.UserPick = ""

                Dim userChoice1 = New UserChoices
                userChoice1 = _DbLoserPool.UserChoicesList.SingleOrDefault(Function(uC1) uC1.UserID = EName And uC1.DayId = dayNumber)
                _DbLoserPool.UserChoicesList.Remove(userChoice1)
                _DbLoserPool.UserChoicesList.Add(lastDayChoice)

                _DbLoserPool.SaveChanges()

                userChoice1 = New UserChoices
                userChoice1 = _DbLoserPool.UserChoicesList.SingleOrDefault(Function(uC1) uC1.UserID = EName And uC1.DayId = dayNumber)


                If RadioButtonList1.SelectedIndex > -1 Then
                    Dim userPick1 = RadioButtonList1.SelectedItem.Text

                    If userPick1 = "Washington" Then
                        userChoice1.Washington = False
                        userChoice1.UserPick = "Washington"
                    End If

                    If userPick1 = "Miami" Then
                        userChoice1.Miami = False
                        userChoice1.UserPick = "Miami"
                    End If

                    If userPick1 = "Colorado" Then
                        userChoice1.Colorado = False
                        userChoice1.UserPick = "Colorado"
                    End If

                    If userPick1 = "Arizona" Then
                        userChoice1.Arizona = False
                        userChoice1.UserPick = "Arizona"
                    End If

                    If userPick1 = "San Francisco" Then
                        userChoice1.SanFrancisco = False
                        userChoice1.UserPick = "San Francisco"
                    End If

                    If userPick1 = "San Diego" Then
                        userChoice1.SanDiego = False
                        userChoice1.UserPick = "San Diego"
                    End If

                    If userPick1 = "Pittsburg" Then
                        userChoice1.Pittsburg = False
                        userChoice1.UserPick = "Pittsburg"
                    End If

                    If userPick1 = "Cincinnati" Then
                        userChoice1.Cincinnati = False
                        userChoice1.UserPick = "Cincinnati"
                    End If

                    If userPick1 = "Toronto" Then
                        userChoice1.Toronto = False
                        userChoice1.UserPick = "Toronto"
                    End If

                    If userPick1 = "NY Yankees" Then
                        userChoice1.NYYankees = False
                        userChoice1.UserPick = "NY Yankees"
                    End If

                    If userPick1 = "Boston" Then
                        userChoice1.Boston = False
                        userChoice1.UserPick = "Boston"
                    End If

                    If userPick1 = "Tampa Bay" Then
                        userChoice1.TampaBay = False
                        userChoice1.UserPick = "Tampa Bay"
                    End If

                    If userPick1 = "Atlanta" Then
                        userChoice1.Atlanta = False
                        userChoice1.UserPick = "Atlanta"
                    End If

                    If userPick1 = "Philadelphia" Then
                        userChoice1.Philadelphia = False
                        userChoice1.UserPick = "Philadelphia"
                    End If

                    If userPick1 = "Chicago White Sox" Then
                        userChoice1.ChicagoWhiteSox = False
                        userChoice1.UserPick = "Chicago White Sox"
                    End If

                    If userPick1 = "Detroit" Then
                        userChoice1.Detroit = False
                        userChoice1.UserPick = "Detroit"
                    End If

                    If userPick1 = "Kansas City" Then
                        userChoice1.KansasCity = False
                        userChoice1.UserPick = "Kansas City"
                    End If

                    If userPick1 = "Cleveland" Then
                        userChoice1.Cleveland = False
                        userChoice1.UserPick = "Cleveland"
                    End If

                    If userPick1 = "Milwaukee" Then
                        userChoice1.Milwaukee = False
                        userChoice1.UserPick = "Milwaukee"
                    End If

                    If userPick1 = "LA Dodgers" Then
                        userChoice1.LADodgers = False
                        userChoice1.UserPick = "LA Dodgers"
                    End If

                    If userPick1 = "Minnesota" Then
                        userChoice1.Minnesota = False
                        userChoice1.UserPick = "Minnesota"
                    End If

                    If userPick1 = "Oakland" Then
                        userChoice1.Oakland = False
                        userChoice1.UserPick = "Oakland"
                    End If

                    If userPick1 = "Houston" Then
                        userChoice1.Houston = False
                        userChoice1.UserPick = "Houston"
                    End If

                    If userPick1 = "Texas" Then
                        userChoice1.Texas = False
                        userChoice1.UserPick = "Texas"
                    End If

                    If userPick1 = "St. Louis" Then
                        userChoice1.STLouis = False
                        userChoice1.UserPick = "St. Louis"
                    End If

                    If userPick1 = "Chicago Cubs" Then
                        userChoice1.ChicagoCubs = False
                        userChoice1.UserPick = "Chicago Cubs"
                    End If

                    If userPick1 = "LA Angels" Then
                        userChoice1.LAAngels = False
                        userChoice1.UserPick = "LAAngels"
                    End If


                    If userPick1 = "Seattle" Then
                        userChoice1.Seattle = False
                        userChoice1.UserPick = "Seattle"
                    End If

                    If userPick1 = "NY Mets" Then
                        userChoice1.NYMets = False
                        userChoice1.UserPick = "NY Mets"
                    End If

                    If userPick1 = "Baltimore" Then
                        userChoice1.Baltimore = False
                        userChoice1.UserPick = "Baltimore"
                    End If

                    userChoice1.ConfirmationNumber = userChoice1.ListId

                    _DbLoserPool.SaveChanges()

                    Session("confirmationNumber") = userChoice1.ListId

                End If

            Catch ex As Exception

            End Try
        End Using

        Response.Redirect("~/LosersPool/ContenderConfirmation.aspx")

    End Sub

    Private Shared Function SetContendersPickToFalse(user1 As UserChoices) As UserChoices
        If user1.UserPick = "Washington" Then
            user1.Washington = False
        ElseIf user1.UserPick = "Miami" Then
            user1.Miami = False
        ElseIf user1.UserPick = "Colorado" Then
            user1.Colorado = False
        ElseIf user1.UserPick = "Arizona" Then
            user1.Arizona = False
        ElseIf user1.UserPick = "San Francisco" Then
            user1.SanFrancisco = False
        ElseIf user1.UserPick = "San Diego" Then
            user1.SanDiego = False
        ElseIf user1.UserPick = "Pittsburg" Then
            user1.Pittsburg = False
        ElseIf user1.UserPick = "Cincinnati" Then
            user1.Cincinnati = False
        ElseIf user1.UserPick = "Toronto" Then
            user1.Toronto = False
        ElseIf user1.UserPick = "NY Yankees" Then
            user1.NYYankees = False
        ElseIf user1.UserPick = "Boston" Then
            user1.Boston = False
        ElseIf user1.UserPick = "Tampa Bay" Then
            user1.TampaBay = False
        ElseIf user1.UserPick = "Atlanta" Then
            user1.Atlanta = False
        ElseIf user1.UserPick = "Philadelphia" Then
            user1.Philadelphia = False
        ElseIf user1.UserPick = "Chicago White Sox" Then
            user1.ChicagoWhiteSox = False
        ElseIf user1.UserPick = "Detroit" Then
            user1.Detroit = False
        ElseIf user1.UserPick = "KansasCity" Then
            user1.KansasCity = False
        ElseIf user1.UserPick = "Cleveland" Then
            user1.Cleveland = False
        ElseIf user1.UserPick = "Milwaukee" Then
            user1.Milwaukee = False
        ElseIf user1.UserPick = "LA Dodgers" Then
            user1.LADodgers = False
        ElseIf user1.UserPick = "Minnesota" Then
            user1.Minnesota = False
        ElseIf user1.UserPick = "Oakland" Then
            user1.Oakland = False
        ElseIf user1.UserPick = "Houston" Then
            user1.Houston = False
        ElseIf user1.UserPick = "Texas" Then
            user1.Texas = False
        ElseIf user1.UserPick = "St. Louis" Then
            user1.STLouis = False
        ElseIf user1.UserPick = "ChicagoCubs" Then
            user1.ChicagoCubs = False
        ElseIf user1.UserPick = "LA Angels" Then
            user1.LAAngels = False
        ElseIf user1.UserPick = "Seattle" Then
            user1.Seattle = False
        ElseIf user1.UserPick = "NY Mets" Then
            user1.NYMets = False
        ElseIf user1.UserPick = "Baltimore" Then
            user1.Baltimore = False

        End If
        Return user1
    End Function

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/LosersPool/Default.aspx")
    End Sub
End Class

Public Class MyPickList

    Public Property MyPicks As UserChoices

    Public Sub New(Ename As String, dayNumber As String)

        Dim user1 As UserChoices = UserPickList(Ename, dayNumber)
        Me.MyPicks = user1

    End Sub

    Public Shared Function UserPickList(EName As String, dayNumber As String) As UserChoices
        Dim _DbLoserPool = New LosersPoolContext

        Try
            Using (_DbLoserPool)

                ' Clear Previous Picks
                Dim users1 = New List(Of MyPick)
                users1 = _DbLoserPool.MyPicks.ToList

                For Each user2 In users1
                    _DbLoserPool.MyPicks.Remove(user2)
                Next

                _DbLoserPool.SaveChanges()

                ' Get New User

                Dim user1 = New UserChoices
                user1 = _DbLoserPool.UserChoicesList.SingleOrDefault(Function(u1) u1.UserID = EName And u1.DayId = dayNumber)

                If user1 Is Nothing Then
                    Return Nothing
                Else
                    If user1.Washington = True Or user1.UserPick = "Washington" Then
                        user1.PossibleUserPicks.Add("Washington")
                    End If

                    If user1.Miami = True Or user1.UserPick = "Miami" Then
                        user1.PossibleUserPicks.Add("Miami")
                    End If

                    If user1.Colorado = True Or user1.UserPick = "Colorado" Then
                        user1.PossibleUserPicks.Add("Colorado")
                    End If

                    If user1.Arizona = True Or user1.UserPick = "Arizona" Then
                        user1.PossibleUserPicks.Add("Arizona")
                    End If

                    If user1.SanFrancisco = True Or user1.UserPick = "San Francisco" Then
                        user1.PossibleUserPicks.Add("San Francisco")
                    End If

                    If user1.SanDiego = True Or user1.UserPick = "San Diego" Then
                        user1.PossibleUserPicks.Add("San Diego")
                    End If

                    If user1.Pittsburg = True Or user1.UserPick = "Pittsburg" Then
                        user1.PossibleUserPicks.Add("Pittsburg")
                    End If

                    If user1.Cincinnati = True Or user1.UserPick = "Cincinnati" Then
                        user1.PossibleUserPicks.Add("Cincinnati")
                    End If

                    If user1.Toronto = True Or user1.UserPick = "Toronto" Then
                        user1.PossibleUserPicks.Add("Toronto")
                    End If

                    If user1.NYYankees = True Or user1.UserPick = "NY Yankees" Then
                        user1.PossibleUserPicks.Add("NY Yankees")
                    End If

                    If user1.Boston = True Or user1.UserPick = "Boston" Then
                        user1.PossibleUserPicks.Add("Boston")
                    End If

                    If user1.TampaBay = True Or user1.UserPick = "Tampa Bay" Then
                        user1.PossibleUserPicks.Add("Tampa Bay")
                    End If

                    If user1.Atlanta = True Or user1.UserPick = "Atlanta" Then
                        user1.PossibleUserPicks.Add("Atlanta")
                    End If

                    If user1.Philadelphia = True Or user1.UserPick = "Philadelphia" Then
                        user1.PossibleUserPicks.Add("Philadelphia")
                    End If

                    If user1.ChicagoWhiteSox = True Or user1.UserPick = "Chicago White Sox" Then
                        user1.PossibleUserPicks.Add("Chicago White Sox")
                    End If

                    If user1.Detroit = True Or user1.UserPick = "Detroit" Then
                        user1.PossibleUserPicks.Add("Detroit")
                    End If

                    If user1.KansasCity = True Or user1.UserPick = "Kansas City" Then
                        user1.PossibleUserPicks.Add("Kansas City")
                    End If

                    If user1.Cleveland = True Or user1.UserPick = "Cleveland" Then
                        user1.PossibleUserPicks.Add("Cleveland")
                    End If

                    If user1.Milwaukee = True Or user1.UserPick = "Milwaukee" Then
                        user1.PossibleUserPicks.Add("Milwaukee")
                    End If

                    If user1.LADodgers = True Or user1.UserPick = "LA Dodgers" Then
                        user1.PossibleUserPicks.Add("LA Dodgers")
                    End If

                    If user1.Minnesota = True Or user1.UserPick = "Minnesota " Then
                        user1.PossibleUserPicks.Add("Minnesota ")
                    End If

                    If user1.Oakland = True Or user1.UserPick = "Oakland" Then
                        user1.PossibleUserPicks.Add("Oakland")
                    End If

                    If user1.Houston = True Or user1.UserPick = "Houston" Then
                        user1.PossibleUserPicks.Add("Houston")
                    End If

                    If user1.Texas = True Or user1.UserPick = "Texas" Then
                        user1.PossibleUserPicks.Add("Texas")
                    End If

                    If user1.STLouis = True Or user1.UserPick = "St. Louis" Then
                        user1.PossibleUserPicks.Add("St. Louis")
                    End If

                    If user1.ChicagoCubs = True Or user1.UserPick = "Chicago Cubs" Then
                        user1.PossibleUserPicks.Add("Chicago Cubs")
                    End If

                    If user1.LAAngels = True Or user1.UserPick = "LA Angels" Then
                        user1.PossibleUserPicks.Add("LA Angels")
                    End If

                    If user1.Seattle = True Or user1.UserPick = "Seattle" Then
                        user1.PossibleUserPicks.Add("Seattle")
                    End If

                    If user1.NYMets = True Or user1.UserPick = "NY Mets" Then
                        user1.PossibleUserPicks.Add("NY Mets")
                    End If

                    If user1.Baltimore = True Or user1.UserPick = "Baltimore" Then
                        user1.PossibleUserPicks.Add("Baltimore")
                    End If

                    Return user1

                End If

            End Using
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
End Class