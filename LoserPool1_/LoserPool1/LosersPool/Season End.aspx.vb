Imports System
Imports System.Linq
Imports System.Xml.Linq
Imports System.Globalization
Imports System.Threading

Imports LoserPool1.JoinPools.Models
Imports LoserPool1.LosersPool.Models


Public Class Season_End
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userId") Is Nothing Then
            Response.Redirect("~/Account/Login.aspx")
        End If

    End Sub

    Public Function ContendersTable_GetData() As List(Of UserResult)

        Dim _dbLoserPool As New LosersPoolContext

        Try
            Using (_dbLoserPool)
                Dim UserResults = _dbLoserPool.UserResultList.ToList

                For Each userResult1 In UserResults
                    _dbLoserPool.UserResultList.Remove(userResult1)
                Next

                _dbLoserPool.SaveChanges()

                Dim I2 = 2 'Number of Days in Increment

                Dim dayNumber = CStr(Session("dayNumber"))
                Dim dayId = "day" + CStr(CInt(Mid(dayNumber, 4)) - I2)

                If CStr(Session("optionState")) = "SeasonEnd" Then
                    dayId = "day" + CStr(CInt(Mid(dayNumber, 4)))
                End If

                Dim DailyUserChoices As New List(Of UserChoices)

                DailyUserChoices = (From user1 In _dbLoserPool.UserChoicesList
                                        Where user1.Contender = True And user1.DayId = dayId
                                        Select user1).ToList()

                For Each user1 In DailyUserChoices

                    Dim user2 = New UserResult
                    user2.ListId = user1.ListId
                    user2.UserID = user1.UserID
                    user2.UserName = user1.UserName
                    user2.DayId = dayId

                    If user1.UserPick = "Washington" Then
                        user2.Washington = False
                    Else
                        user2.Washington = user1.Washington
                    End If

                    If user1.UserPick = "Miami" Then
                        user2.Miami = False
                    Else
                        user2.Miami = user1.Miami
                    End If

                    If user1.UserPick = "Colorado" Then
                        user2.Colorado = False
                    Else
                        user2.Colorado = user1.Colorado
                    End If

                    If user1.UserPick = "Arizona" Then
                        user2.Arizona = False
                    Else
                        user2.Arizona = user1.Arizona
                    End If

                    If user1.UserPick = "San Francisco" Then
                        user2.SanFrancisco = False
                    Else
                        user2.SanFrancisco = user1.SanFrancisco
                    End If

                    If user1.UserPick = "San Diego" Then
                        user2.SanDiego = False
                    Else
                        user2.SanDiego = user1.SanDiego
                    End If

                    If user1.UserPick = "Pittsburg" Then
                        user2.Pittsburg = False
                    Else
                        user2.Pittsburg = user1.Pittsburg
                    End If

                    If user1.UserPick = "Cincinnati" Then
                        user2.Cincinnati = False
                    Else
                        user2.Cincinnati = user1.Cincinnati
                    End If

                    If user1.UserPick = "Toronto" Then
                        user2.Toronto = False
                    Else
                        user2.Toronto = user1.Toronto
                    End If

                    If user1.UserPick = "NY Yankees" Then
                        user2.NYYankees = False
                    Else
                        user2.NYYankees = user1.NYYankees
                    End If

                    If user1.UserPick = "Boston" Then
                        user2.Boston = False
                    Else
                        user2.Boston = user1.Boston
                    End If

                    If user1.UserPick = "Tampa Bay" Then
                        user2.TampaBay = False
                    Else
                        user2.TampaBay = user1.TampaBay
                    End If

                    If user1.UserPick = "Atlanta" Then
                        user2.Atlanta = False
                    Else
                        user2.Atlanta = user1.Atlanta
                    End If

                    If user1.UserPick = "Philadelphia" Then
                        user2.Philadelphia = False
                    Else
                        user2.Philadelphia = user1.Philadelphia
                    End If

                    If user1.UserPick = "Chicago White Sox" Then
                        user2.ChicagoWhiteSox = False
                    Else
                        user2.ChicagoWhiteSox = user1.ChicagoWhiteSox
                    End If

                    If user1.UserPick = "Detroit" Then
                        user2.Detroit = False
                    Else
                        user2.Detroit = user1.Detroit
                    End If

                    If user1.UserPick = "Kansas City" Then
                        user2.KansasCity = False
                    Else
                        user2.KansasCity = user1.KansasCity
                    End If

                    If user1.UserPick = "Cleveland" Then
                        user2.Cleveland = False
                    Else
                        user2.Cleveland = user1.Cleveland
                    End If

                    If user1.UserPick = "Milwaukee" Then
                        user2.Milwaukee = False
                    Else
                        user2.Milwaukee = user1.Milwaukee
                    End If

                    If user1.UserPick = "LA Dodgers" Then
                        user2.LADodgers = False
                    Else
                        user2.LADodgers = user1.LADodgers
                    End If

                    If user1.UserPick = "Minnesota" Then
                        user2.Minnesota = False
                    Else
                        user2.Minnesota = user1.Minnesota
                    End If

                    If user1.UserPick = "Oakland" Then
                        user2.Oakland = False
                    Else
                        user2.Oakland = user1.Oakland
                    End If

                    If user1.UserPick = "Houston" Then
                        user2.Houston = False
                    Else
                        user2.Houston = user1.Houston
                    End If

                    If user1.UserPick = "Texas" Then
                        user2.Texas = False
                    Else
                        user2.Texas = user1.Texas
                    End If

                    If user1.UserPick = "St. Louis" Then
                        user2.STLouis = False
                    Else
                        user2.STLouis = user1.STLouis
                    End If

                    If user1.UserPick = "Chicago Cubs" Then
                        user2.ChicagoCubs = False
                    Else
                        user2.ChicagoCubs = user1.ChicagoCubs
                    End If

                    If user1.UserPick = "LA Angels" Then
                        user2.LAAngels = False
                    Else
                        user2.LAAngels = user1.LAAngels
                    End If

                    If user1.UserPick = "Seattle" Then
                        user2.Seattle = False
                    Else
                        user2.Seattle = user1.Seattle
                    End If

                    If user1.UserPick = "NY Mets" Then
                        user2.NYMets = False
                    Else
                        user2.NYMets = user1.NYMets
                    End If

                    If user1.UserPick = "Baltimore" Then
                        user2.Baltimore = False
                    Else
                        user2.Baltimore = user1.Baltimore
                    End If



                    _dbLoserPool.UserResultList.Add(user2)
                    _dbLoserPool.SaveChanges()
                Next


                Dim DailyUserResults = (From user1 In _dbLoserPool.UserResultList
                                        Where user1.DayId = dayId
                                        Select user1).ToList()

                ViewState("dayNumber") = dayId
                Return DailyUserResults
            End Using
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function LosersTable_GetData() As List(Of Loser)
        Dim _dbLoserPool As New LosersPoolContext
        Try
            Using (_dbLoserPool)
                Dim losers1 = _dbLoserPool.LoserList.ToList
                Return losers1
            End Using
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("~/JoinPool/MyPools.aspx")
    End Sub


End Class