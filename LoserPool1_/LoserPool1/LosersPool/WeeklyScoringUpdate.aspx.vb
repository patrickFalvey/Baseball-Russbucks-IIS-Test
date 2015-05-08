Imports System.Data

Imports System
Imports System.Collections.Specialized
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web

Imports System.Web.UI
Imports System.Web.UI.WebControls


Imports LoserPool1
Imports LoserPool1.LosersPool.Models
Imports LoserPool1.JoinPools.Models

Public Class WeeklyScoringUpdate
    Inherits System.Web.UI.Page

    Private GameUpdateCollection As New Dictionary(Of String, GameUpdate)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("userId") Is Nothing Then
            Response.Redirect("~/Account/Login.aspx")
        End If


        Dim thisDay = CStr(Session("dayNumber"))

        Dim _DbLoserPool As New LosersPoolContext
        Dim _DbPools2 As New PoolDbContext

        Try
            Using (_DbLoserPool)
                Using (_DbPools2)

                    System.IO.Directory.SetCurrentDirectory("C:\Users\Larry\Documents\GitHub\Baseball-Russbucks-IIS-Test\LoserPool1_\LoserPool1")

                    Dim myUpdate = XDocument.Load(".\TestFiles\scoringUpdate.xml")

                    Dim queryContenders As New List(Of UserChoices)

                    queryContenders = (From contender1 In _DbLoserPool.UserChoicesList
                                       Where contender1.DayId = thisDay And contender1.Contender = True
                                       Select contender1).ToList


                    Dim teams1 As New List(Of Team)

                    teams1 = (From teams2 In _DbPools2.Teams).ToList

                    Dim dailyGames As New List(Of ScheduleEntity)

                    dailyGames = (From scheduleEntity1 In _DbLoserPool.ScheduleEntities
                           Where scheduleEntity1.DayId = thisDay
                           Select scheduleEntity1).ToList

                    Dim cnt1 = 0
                    For Each game1 In dailyGames

                        cnt1 = cnt1 + 1
                        Dim gameupdate1 As New GameUpdate

                        gameupdate1.GameId = "game" + CStr(cnt1)
                        gameupdate1.HomeTeam = game1.HomeTeam
                        gameupdate1.AwayTeam = game1.AwayTeam

                        Dim queryUpdateGame1 = (From game In myUpdate.Descendants("scores").Descendants("game")
                                                Where game.Attribute("hometeam").Value = game1.HomeTeam Or game.Attribute("awayteam").Value = game1.AwayTeam)

                        If queryUpdateGame1.Count = 0 Then
                            Continue For
                        End If

                        Dim queryUpdateGame As New List(Of GameUpdateXML)

                        queryUpdateGame = (From game In myUpdate.Descendants("scores").Descendants("game")
                                              Where game.Attribute("hometeam").Value = game1.HomeTeam And game.Attribute("awayteam").Value = game1.AwayTeam
                                              Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                                                       .homescore = game.Elements("homescore").Value,
                                                                       .awayteam = game.Attribute("awayteam").Value,
                                                                       .awayscore = game.Elements("awayscore").Value,
                                                                       .gametime = game.Elements("gametime").Value}).ToList


                        gameupdate1.HomeScore = queryUpdateGame(0).homescore
                        gameupdate1.AwayScore = queryUpdateGame(0).awayscore
                        gameupdate1.GameTime = queryUpdateGame(0).gametime


                        For Each user1 In queryContenders


                            gameupdate1.UserHandles.Add(user1.UserName)

                            Dim teamAvailability As String

                            For Each team1 In teams1

                                If team1.TeamName = queryUpdateGame(0).hometeam Then
                                    If team1.TeamName = "Washington" Then
                                        teamAvailability = user1.Washington
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Miami" Then
                                        teamAvailability = user1.Miami
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Colorado" Then
                                        teamAvailability = user1.Colorado
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Arizona" Then
                                        teamAvailability = user1.Arizona
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "San Francisco" Then
                                        teamAvailability = user1.SanFrancisco
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "San Diego" Then
                                        teamAvailability = user1.SanDiego
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Pittsburg" Then
                                        teamAvailability = user1.Pittsburg
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Cincinnati" Then
                                        teamAvailability = user1.Cincinnati
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Toronto" Then
                                        teamAvailability = user1.Toronto
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "NY Yankees" Then
                                        teamAvailability = user1.NYYankees
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Boston" Then
                                        teamAvailability = user1.Boston
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Tampa Bay" Then
                                        teamAvailability = user1.TampaBay
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Atlanta" Then
                                        teamAvailability = user1.Atlanta
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Philadelphia" Then
                                        teamAvailability = user1.Philadelphia
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Chicago White Sox" Then
                                        teamAvailability = user1.ChicagoWhiteSox
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Detroit" Then
                                        teamAvailability = user1.Detroit
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Kansas City" Then
                                        teamAvailability = user1.KansasCity
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Cleveland" Then
                                        teamAvailability = user1.Cleveland
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Milwaukee" Then
                                        teamAvailability = user1.Milwaukee
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "LA Dodgers" Then
                                        teamAvailability = user1.LADodgers
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Minnesota" Then
                                        teamAvailability = user1.Minnesota
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Oakland" Then
                                        teamAvailability = user1.Oakland
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Houston" Then
                                        teamAvailability = user1.Houston
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Texas" Then
                                        teamAvailability = user1.Texas
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "St. Louis" Then
                                        teamAvailability = user1.STLouis
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Chicago Cubs" Then
                                        teamAvailability = user1.ChicagoCubs
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "LA Angels" Then
                                        teamAvailability = user1.LAAngels
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Seattle" Then
                                        teamAvailability = user1.Seattle
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "NY Mets" Then
                                        teamAvailability = user1.NYMets
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Baltimore" Then
                                        teamAvailability = user1.Baltimore
                                        gameupdate1 = SetHomeTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    End If

                                ElseIf team1.TeamName = queryUpdateGame(0).awayteam Then

                                    If team1.TeamName = "Washington" Then
                                        teamAvailability = user1.Washington
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Miami" Then
                                        teamAvailability = user1.Miami
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Colorado" Then
                                        teamAvailability = user1.Colorado
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Arizona" Then
                                        teamAvailability = user1.Arizona
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "San Francisco" Then
                                        teamAvailability = user1.SanFrancisco
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "San Diego" Then
                                        teamAvailability = user1.SanDiego
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Pittsburg" Then
                                        teamAvailability = user1.Pittsburg
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Cincinnati" Then
                                        teamAvailability = user1.Cincinnati
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Toronto" Then
                                        teamAvailability = user1.Toronto
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "NY Yankees" Then
                                        teamAvailability = user1.NYYankees
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Boston" Then
                                        teamAvailability = user1.Boston
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Tampa Bay" Then
                                        teamAvailability = user1.TampaBay
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Atlanta" Then
                                        teamAvailability = user1.Atlanta
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Philadelphia" Then
                                        teamAvailability = user1.Philadelphia
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Chicago White Sox" Then
                                        teamAvailability = user1.ChicagoWhiteSox
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Detroit" Then
                                        teamAvailability = user1.Detroit
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Kansas City" Then
                                        teamAvailability = user1.KansasCity
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Cleveland" Then
                                        teamAvailability = user1.Cleveland
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Milwaukee" Then
                                        teamAvailability = user1.Milwaukee
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "LA Dodgers" Then
                                        teamAvailability = user1.LADodgers
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Minnesota" Then
                                        teamAvailability = user1.Minnesota
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Oakland" Then
                                        teamAvailability = user1.Oakland
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Houston" Then
                                        teamAvailability = user1.Houston
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Texas" Then
                                        teamAvailability = user1.Texas
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "St. Louis" Then
                                        teamAvailability = user1.STLouis
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Chicago Cubs" Then
                                        teamAvailability = user1.ChicagoCubs
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "LA Angels" Then
                                        teamAvailability = user1.LAAngels
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Seattle" Then
                                        teamAvailability = user1.Seattle
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "NY Mets" Then
                                        teamAvailability = user1.NYMets
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    ElseIf team1.TeamName = "Baltimore" Then
                                        teamAvailability = user1.Baltimore
                                        gameupdate1 = SetAwayTeamAvailabilityState(gameupdate1, queryUpdateGame, team1.TeamName, teamAvailability, user1)
                                    End If

                                End If

                            Next
                        Next
                        GameUpdateCollection.Add(gameupdate1.GameId, gameupdate1)
                    Next


                    Dim queryGameUpdateCollection = (From gameUpdateCollection1 In GameUpdateCollection
                                               Where gameUpdateCollection1.Key = "game1" Or gameUpdateCollection1.Key = "game2" Or gameUpdateCollection1.Key = "game3" Or gameUpdateCollection1.Key = "game4").ToList

                    For Each game In queryGameUpdateCollection

                        If game.Key = "game1" Then
                            GameNumber1.Text = game.Key
                            HomeTeam1.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam1.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore1.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore1.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber1Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore1.Text) > CInt(AwayScore1.Text) Then
                                HomeTeam1.ForeColor = Drawing.Color.DarkGreen
                                HomeScore1.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam1.ForeColor = Drawing.Color.DarkRed
                                AwayScore1.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore1.Text) > CInt(HomeScore1.Text) Then
                                HomeTeam1.ForeColor = Drawing.Color.DarkRed
                                HomeScore1.ForeColor = Drawing.Color.DarkRed
                                AwayTeam1.ForeColor = Drawing.Color.DarkGreen
                                AwayScore1.ForeColor = Drawing.Color.DarkGreen
                            End If

                        ElseIf game.Key = "game2" Then
                            GameNumber2.Text = game.Key
                            HomeTeam2.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam2.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore2.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore2.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber2Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore2.Text) > CInt(AwayScore2.Text) Then
                                HomeTeam2.ForeColor = Drawing.Color.DarkGreen
                                HomeScore2.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam2.ForeColor = Drawing.Color.DarkRed
                                AwayScore2.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore2.Text) > CInt(HomeScore2.Text) Then
                                HomeTeam2.ForeColor = Drawing.Color.DarkRed
                                HomeScore2.ForeColor = Drawing.Color.DarkRed
                                AwayTeam2.ForeColor = Drawing.Color.DarkGreen
                                AwayScore2.ForeColor = Drawing.Color.DarkGreen
                            End If


                        ElseIf game.Key = "game3" Then
                            GameNumber3.Text = game.Key
                            HomeTeam3.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam3.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore3.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore3.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber3Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore3.Text) > CInt(AwayScore3.Text) Then
                                HomeTeam3.ForeColor = Drawing.Color.DarkGreen
                                HomeScore3.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam3.ForeColor = Drawing.Color.DarkRed
                                AwayScore3.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore3.Text) > CInt(HomeScore3.Text) Then
                                HomeTeam3.ForeColor = Drawing.Color.DarkRed
                                HomeScore3.ForeColor = Drawing.Color.DarkRed
                                AwayTeam3.ForeColor = Drawing.Color.DarkGreen
                                AwayScore3.ForeColor = Drawing.Color.DarkGreen
                            End If


                        ElseIf game.Key = "game4" Then
                            GameNumber4.Text = game.Key
                            HomeTeam4.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam4.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore4.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore4.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber4Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore4.Text) > CInt(AwayScore4.Text) Then
                                HomeTeam4.ForeColor = Drawing.Color.DarkGreen
                                HomeScore4.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam4.ForeColor = Drawing.Color.DarkRed
                                AwayScore4.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore4.Text) > CInt(HomeScore4.Text) Then
                                HomeTeam4.ForeColor = Drawing.Color.DarkRed
                                HomeScore4.ForeColor = Drawing.Color.DarkRed
                                AwayTeam4.ForeColor = Drawing.Color.DarkGreen
                                AwayScore4.ForeColor = Drawing.Color.DarkGreen
                            End If
                        End If
                    Next

                    Dim cnt = 0
                    For Each user1 In GameUpdateCollection("game1").UserHandles

                        Dim userColor As New System.Drawing.Color

                        For Each game In GameUpdateCollection
                            If game.Key = "game5" Then
                                Exit For
                            End If
                            If GameUpdateCollection.Count >= 1 Then
                                If GameUpdateCollection("game1").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore1.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore1.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game1").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore1.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore1.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                            End If

                            If GameUpdateCollection.Count >= 2 Then
                                If GameUpdateCollection("game2").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore2.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore2.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game2").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore2.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore2.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If
                            End If

                            If GameUpdateCollection.Count >= 3 Then
                                If GameUpdateCollection("game3").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore3.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore3.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game3").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore3.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore3.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If
                            End If

                            If GameUpdateCollection.Count >= 4 Then
                                If GameUpdateCollection("game4").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore4.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore4.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game4").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore4.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore4.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If

                                End If
                            End If
                        Next


                        Dim dRow As New TableRow

                        If GameUpdateCollection.Count >= 1 Then

                            Dim dCell1 As New TableCell
                            dCell1.Text = GameUpdateCollection("game1").UserHandles(cnt)
                            dCell1.Width = "80"
                            dCell1.ForeColor = userColor
                            dRow.Cells.Add(dCell1)


                            Dim dCell2 As New TableCell
                            dCell2.Text = GameUpdateCollection("game1").HomeTeamAvailability(user1)
                            dCell2.Width = "80"

                            If dCell2.Text = "L" Then
                                dCell2.ForeColor = userColor
                                dCell2.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell2)

                            Dim dCell3 As New TableCell
                            dCell3.Text = GameUpdateCollection("game1").AwayTeamAvailability(user1)
                            dCell3.Width = "80"

                            If dCell3.Text = "L" Then
                                dCell3.ForeColor = userColor
                                dCell3.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell3)

                        End If

                        If GameUpdateCollection.Count >= 2 Then
                            Dim dCell4 As New TableCell
                            dCell4.Text = GameUpdateCollection("game2").HomeTeamAvailability(user1)

                            If dCell4.Text = "L" Then
                                dCell4.ForeColor = userColor
                                dCell4.Font.Bold = True
                            End If


                            dCell4.Width = "80"
                            dRow.Cells.Add(dCell4)

                            Dim dCell5 As New TableCell
                            dCell5.Text = GameUpdateCollection("game2").AwayTeamAvailability(user1)
                            dCell5.Width = "80"

                            If dCell5.Text = "L" Then
                                dCell5.ForeColor = userColor
                                dCell5.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell5)

                        End If

                        If GameUpdateCollection.Count >= 3 Then

                            Dim dCell6 As New TableCell
                            dCell6.Text = GameUpdateCollection("game3").HomeTeamAvailability(user1)
                            dCell6.Width = "80"

                            If dCell6.Text = "L" Then
                                dCell6.ForeColor = userColor
                                dCell6.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell6)

                            Dim dCell7 As New TableCell
                            dCell7.Text = GameUpdateCollection("game3").AwayTeamAvailability(user1)
                            dCell7.Width = "80"

                            If dCell7.Text = "L" Then
                                dCell7.ForeColor = userColor
                                dCell7.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell7)

                        End If

                        If GameUpdateCollection.Count >= 4 Then
                            Dim dCell8 As New TableCell
                            dCell8.Text = GameUpdateCollection("game4").HomeTeamAvailability(user1)
                            dCell8.Width = "80"

                            If dCell8.Text = "L" Then
                                dCell8.ForeColor = userColor
                                dCell8.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell8)

                            Dim dCell9 As New TableCell
                            dCell9.Text = GameUpdateCollection("game4").AwayTeamAvailability(user1)
                            dCell9.Width = "80"

                            If dCell9.Text = "L" Then
                                dCell9.ForeColor = userColor
                                dCell9.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell9)

                        End If

                        If GameUpdateCollection.Count >= 1 Then
                            TeamsByGameTable1.Rows.Add(dRow)
                        End If

                        cnt = cnt + 1
                    Next

                    If GameUpdateCollection.Count >= 1 Then
                        TeamsByGameTable1.DataBind()
                    End If

                    If GameUpdateCollection.Count <= 4 Then
                        Exit Try
                    End If

                    queryGameUpdateCollection = (From gameUpdateCollection1 In GameUpdateCollection
                                               Where gameUpdateCollection1.Key = "game5" Or gameUpdateCollection1.Key = "game6" Or gameUpdateCollection1.Key = "game7" Or gameUpdateCollection1.Key = "game8").ToList

                    For Each game In queryGameUpdateCollection

                        If game.Key = "game5" Then
                            GameNumber5.Text = game.Key
                            HomeTeam5.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam5.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore5.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore5.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber5Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore5.Text) > CInt(AwayScore5.Text) Then
                                HomeTeam5.ForeColor = Drawing.Color.DarkGreen
                                HomeScore5.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam5.ForeColor = Drawing.Color.DarkRed
                                AwayScore5.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore5.Text) > CInt(HomeScore5.Text) Then
                                HomeTeam5.ForeColor = Drawing.Color.DarkRed
                                HomeScore5.ForeColor = Drawing.Color.DarkRed
                                AwayTeam5.ForeColor = Drawing.Color.DarkGreen
                                AwayScore5.ForeColor = Drawing.Color.DarkGreen
                            End If

                        ElseIf game.Key = "game6" Then
                            GameNumber6.Text = game.Key
                            HomeTeam6.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam6.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore6.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore6.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber6Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore6.Text) > CInt(AwayScore6.Text) Then
                                HomeTeam6.ForeColor = Drawing.Color.DarkGreen
                                HomeScore6.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam6.ForeColor = Drawing.Color.DarkRed
                                AwayScore6.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore6.Text) > CInt(HomeScore6.Text) Then
                                HomeTeam6.ForeColor = Drawing.Color.DarkRed
                                HomeScore6.ForeColor = Drawing.Color.DarkRed
                                AwayTeam6.ForeColor = Drawing.Color.DarkGreen
                                AwayScore6.ForeColor = Drawing.Color.DarkGreen
                            End If


                        ElseIf game.Key = "game7" Then
                            GameNumber7.Text = game.Key
                            HomeTeam7.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam7.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore7.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore7.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber7Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore7.Text) > CInt(AwayScore7.Text) Then
                                HomeTeam7.ForeColor = Drawing.Color.DarkGreen
                                HomeScore7.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam7.ForeColor = Drawing.Color.DarkRed
                                AwayScore7.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore7.Text) > CInt(HomeScore7.Text) Then
                                HomeTeam7.ForeColor = Drawing.Color.DarkRed
                                HomeScore7.ForeColor = Drawing.Color.DarkRed
                                AwayTeam7.ForeColor = Drawing.Color.DarkGreen
                                AwayScore7.ForeColor = Drawing.Color.DarkGreen
                            End If


                        ElseIf game.Key = "game8" Then
                            GameNumber8.Text = game.Key
                            HomeTeam8.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam8.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore8.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore8.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber8Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore8.Text) > CInt(AwayScore8.Text) Then
                                HomeTeam8.ForeColor = Drawing.Color.DarkGreen
                                HomeScore8.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam8.ForeColor = Drawing.Color.DarkRed
                                AwayScore8.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore8.Text) > CInt(HomeScore8.Text) Then
                                HomeTeam8.ForeColor = Drawing.Color.DarkRed
                                HomeScore8.ForeColor = Drawing.Color.DarkRed
                                AwayTeam8.ForeColor = Drawing.Color.DarkGreen
                                AwayScore8.ForeColor = Drawing.Color.DarkGreen
                            End If
                        End If
                    Next

                    cnt = 0
                    For Each user1 In GameUpdateCollection("game5").UserHandles

                        Dim userColor As New System.Drawing.Color

                        For Each game In GameUpdateCollection
                            If GameUpdateCollection.Count >= 5 Then
                                If GameUpdateCollection("game5").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore5.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore5.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game5").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore5.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore5.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                            End If

                            If GameUpdateCollection.Count >= 6 Then
                                If GameUpdateCollection("game6").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore6.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore6.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game6").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore6.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore6.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If
                            End If

                            If GameUpdateCollection.Count >= 7 Then
                                If GameUpdateCollection("game7").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore7.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore7.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game7").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore7.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore7.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If
                            End If

                            If GameUpdateCollection.Count >= 8 Then
                                If GameUpdateCollection("game8").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore8.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore8.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game8").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore8.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore8.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If

                                End If
                            End If
                        Next


                        Dim dRow As New TableRow

                        If GameUpdateCollection.Count >= 5 Then

                            Dim dCell1 As New TableCell
                            dCell1.Text = GameUpdateCollection("game5").UserHandles(cnt)
                            dCell1.Width = "80"
                            dCell1.ForeColor = userColor
                            dRow.Cells.Add(dCell1)


                            Dim dCell2 As New TableCell
                            dCell2.Text = GameUpdateCollection("game5").HomeTeamAvailability(user1)
                            dCell2.Width = "80"

                            If dCell2.Text = "L" Then
                                dCell2.ForeColor = userColor
                                dCell2.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell2)

                            Dim dCell3 As New TableCell
                            dCell3.Text = GameUpdateCollection("game5").AwayTeamAvailability(user1)
                            dCell3.Width = "80"

                            If dCell3.Text = "L" Then
                                dCell3.ForeColor = userColor
                                dCell3.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell3)

                        End If

                        If GameUpdateCollection.Count >= 6 Then
                            Dim dCell4 As New TableCell
                            dCell4.Text = GameUpdateCollection("game6").HomeTeamAvailability(user1)

                            If dCell4.Text = "L" Then
                                dCell4.ForeColor = userColor
                                dCell4.Font.Bold = True
                            End If


                            dCell4.Width = "80"
                            dRow.Cells.Add(dCell4)

                            Dim dCell5 As New TableCell
                            dCell5.Text = GameUpdateCollection("game6").AwayTeamAvailability(user1)
                            dCell5.Width = "80"

                            If dCell5.Text = "L" Then
                                dCell5.ForeColor = userColor
                                dCell5.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell5)

                        End If

                        If GameUpdateCollection.Count >= 7 Then

                            Dim dCell6 As New TableCell
                            dCell6.Text = GameUpdateCollection("game7").HomeTeamAvailability(user1)
                            dCell6.Width = "80"

                            If dCell6.Text = "L" Then
                                dCell6.ForeColor = userColor
                                dCell6.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell6)

                            Dim dCell7 As New TableCell
                            dCell7.Text = GameUpdateCollection("game7").AwayTeamAvailability(user1)
                            dCell7.Width = "80"

                            If dCell7.Text = "L" Then
                                dCell7.ForeColor = userColor
                                dCell7.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell7)

                        End If

                        If GameUpdateCollection.Count >= 8 Then
                            Dim dCell8 As New TableCell
                            dCell8.Text = GameUpdateCollection("game8").HomeTeamAvailability(user1)
                            dCell8.Width = "80"

                            If dCell8.Text = "L" Then
                                dCell8.ForeColor = userColor
                                dCell8.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell8)

                            Dim dCell9 As New TableCell
                            dCell9.Text = GameUpdateCollection("game8").AwayTeamAvailability(user1)
                            dCell9.Width = "80"

                            If dCell9.Text = "L" Then
                                dCell9.ForeColor = userColor
                                dCell9.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell9)

                        End If

                        If GameUpdateCollection.Count >= 5 Then
                            TeamsByGameTable2.Rows.Add(dRow)
                        End If

                        cnt = cnt + 1
                    Next

                    If GameUpdateCollection.Count >= 5 Then
                        TeamsByGameTable2.DataBind()
                    End If

                    If GameUpdateCollection.Count <= 8 Then
                        Exit Try
                    End If


                    queryGameUpdateCollection = (From gameUpdateCollection1 In GameUpdateCollection
                                               Where gameUpdateCollection1.Key = "game9" Or gameUpdateCollection1.Key = "game10" Or gameUpdateCollection1.Key = "game11" Or gameUpdateCollection1.Key = "game12").ToList

                    For Each game In queryGameUpdateCollection

                        If game.Key = "game9" Then
                            GameNumber9.Text = game.Key
                            HomeTeam9.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam9.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore9.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore9.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber9Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore9.Text) > CInt(AwayScore9.Text) Then
                                HomeTeam9.ForeColor = Drawing.Color.DarkGreen
                                HomeScore9.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam9.ForeColor = Drawing.Color.DarkRed
                                AwayScore9.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore9.Text) > CInt(HomeScore9.Text) Then
                                HomeTeam9.ForeColor = Drawing.Color.DarkRed
                                HomeScore9.ForeColor = Drawing.Color.DarkRed
                                AwayTeam9.ForeColor = Drawing.Color.DarkGreen
                                AwayScore9.ForeColor = Drawing.Color.DarkGreen
                            End If

                        ElseIf game.Key = "game10" Then
                            GameNumber10.Text = game.Key
                            HomeTeam10.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam10.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore10.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore10.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber10Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore10.Text) > CInt(AwayScore10.Text) Then
                                HomeTeam10.ForeColor = Drawing.Color.DarkGreen
                                HomeScore10.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam10.ForeColor = Drawing.Color.DarkRed
                                AwayScore10.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore10.Text) > CInt(HomeScore10.Text) Then
                                HomeTeam10.ForeColor = Drawing.Color.DarkRed
                                HomeScore10.ForeColor = Drawing.Color.DarkRed
                                AwayTeam10.ForeColor = Drawing.Color.DarkGreen
                                AwayScore10.ForeColor = Drawing.Color.DarkGreen
                            End If


                        ElseIf game.Key = "game11" Then
                            GameNumber11.Text = game.Key
                            HomeTeam11.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam11.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore11.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore11.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber11Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore11.Text) > CInt(AwayScore11.Text) Then
                                HomeTeam11.ForeColor = Drawing.Color.DarkGreen
                                HomeScore11.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam11.ForeColor = Drawing.Color.DarkRed
                                AwayScore11.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore11.Text) > CInt(HomeScore11.Text) Then
                                HomeTeam11.ForeColor = Drawing.Color.DarkRed
                                HomeScore11.ForeColor = Drawing.Color.DarkRed
                                AwayTeam11.ForeColor = Drawing.Color.DarkGreen
                                AwayScore11.ForeColor = Drawing.Color.DarkGreen
                            End If


                        ElseIf game.Key = "game12" Then
                            GameNumber12.Text = game.Key
                            HomeTeam12.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam12.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore12.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore12.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber12Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore12.Text) > CInt(AwayScore12.Text) Then
                                HomeTeam12.ForeColor = Drawing.Color.DarkGreen
                                HomeScore12.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam12.ForeColor = Drawing.Color.DarkRed
                                AwayScore12.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore12.Text) > CInt(HomeScore12.Text) Then
                                HomeTeam12.ForeColor = Drawing.Color.DarkRed
                                HomeScore12.ForeColor = Drawing.Color.DarkRed
                                AwayTeam12.ForeColor = Drawing.Color.DarkGreen
                                AwayScore12.ForeColor = Drawing.Color.DarkGreen
                            End If
                        End If
                    Next

                    cnt = 0
                    For Each user1 In GameUpdateCollection("game9").UserHandles

                        Dim userColor As New System.Drawing.Color

                        For Each game In GameUpdateCollection
                            If GameUpdateCollection.Count >= 9 Then
                                If GameUpdateCollection("game9").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore9.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore9.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game9").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore9.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore9.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                            End If

                            If GameUpdateCollection.Count >= 10 Then
                                If GameUpdateCollection("game10").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore10.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore10.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game10").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore10.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore10.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If
                            End If

                            If GameUpdateCollection.Count >= 11 Then
                                If GameUpdateCollection("game11").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore11.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore11.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game11").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore11.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore11.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If
                            End If

                            If GameUpdateCollection.Count >= 12 Then
                                If GameUpdateCollection("game12").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore12.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore12.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game12").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore12.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore12.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If

                                End If
                            End If
                        Next


                        Dim dRow As New TableRow

                        If GameUpdateCollection.Count >= 9 Then

                            Dim dCell1 As New TableCell
                            dCell1.Text = GameUpdateCollection("game9").UserHandles(cnt)
                            dCell1.Width = "80"
                            dCell1.ForeColor = userColor
                            dRow.Cells.Add(dCell1)


                            Dim dCell2 As New TableCell
                            dCell2.Text = GameUpdateCollection("game9").HomeTeamAvailability(user1)
                            dCell2.Width = "80"

                            If dCell2.Text = "L" Then
                                dCell2.ForeColor = userColor
                                dCell2.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell2)

                            Dim dCell3 As New TableCell
                            dCell3.Text = GameUpdateCollection("game9").AwayTeamAvailability(user1)
                            dCell3.Width = "80"

                            If dCell3.Text = "L" Then
                                dCell3.ForeColor = userColor
                                dCell3.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell3)

                        End If

                        If GameUpdateCollection.Count >= 10 Then
                            Dim dCell4 As New TableCell
                            dCell4.Text = GameUpdateCollection("game10").HomeTeamAvailability(user1)

                            If dCell4.Text = "L" Then
                                dCell4.ForeColor = userColor
                                dCell4.Font.Bold = True
                            End If


                            dCell4.Width = "80"
                            dRow.Cells.Add(dCell4)

                            Dim dCell5 As New TableCell
                            dCell5.Text = GameUpdateCollection("game10").AwayTeamAvailability(user1)
                            dCell5.Width = "80"

                            If dCell5.Text = "L" Then
                                dCell5.ForeColor = userColor
                                dCell5.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell5)

                        End If

                        If GameUpdateCollection.Count >= 11 Then

                            Dim dCell6 As New TableCell
                            dCell6.Text = GameUpdateCollection("game11").HomeTeamAvailability(user1)
                            dCell6.Width = "80"

                            If dCell6.Text = "L" Then
                                dCell6.ForeColor = userColor
                                dCell6.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell6)

                            Dim dCell7 As New TableCell
                            dCell7.Text = GameUpdateCollection("game11").AwayTeamAvailability(user1)
                            dCell7.Width = "80"

                            If dCell7.Text = "L" Then
                                dCell7.ForeColor = userColor
                                dCell7.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell7)

                        End If

                        If GameUpdateCollection.Count >= 12 Then
                            Dim dCell8 As New TableCell
                            dCell8.Text = GameUpdateCollection("game12").HomeTeamAvailability(user1)
                            dCell8.Width = "80"

                            If dCell8.Text = "L" Then
                                dCell8.ForeColor = userColor
                                dCell8.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell8)

                            Dim dCell9 As New TableCell
                            dCell9.Text = GameUpdateCollection("game12").AwayTeamAvailability(user1)
                            dCell9.Width = "80"

                            If dCell9.Text = "L" Then
                                dCell9.ForeColor = userColor
                                dCell9.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell9)

                        End If

                        If GameUpdateCollection.Count >= 9 Then
                            TeamsByGameTable3.Rows.Add(dRow)
                        End If

                        cnt = cnt + 1
                    Next

                    If GameUpdateCollection.Count >= 9 Then
                        TeamsByGameTable3.DataBind()
                    End If

                    If GameUpdateCollection.Count <= 12 Then
                        Exit Try
                    End If


                    queryGameUpdateCollection = (From gameUpdateCollection1 In GameUpdateCollection
                                               Where gameUpdateCollection1.Key = "game13" Or gameUpdateCollection1.Key = "game14" Or gameUpdateCollection1.Key = "game15" Or gameUpdateCollection1.Key = "game16").ToList

                    For Each game In queryGameUpdateCollection

                        If game.Key = "game13" Then
                            GameNumber13.Text = game.Key
                            HomeTeam13.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam13.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore13.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore13.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber13Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore13.Text) > CInt(AwayScore13.Text) Then
                                HomeTeam13.ForeColor = Drawing.Color.DarkGreen
                                HomeScore13.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam13.ForeColor = Drawing.Color.DarkRed
                                AwayScore13.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore13.Text) > CInt(HomeScore13.Text) Then
                                HomeTeam13.ForeColor = Drawing.Color.DarkRed
                                HomeScore13.ForeColor = Drawing.Color.DarkRed
                                AwayTeam13.ForeColor = Drawing.Color.DarkGreen
                                AwayScore13.ForeColor = Drawing.Color.DarkGreen
                            End If

                        ElseIf game.Key = "game14" Then
                            GameNumber14.Text = game.Key
                            HomeTeam14.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam14.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore14.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore14.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber14Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore14.Text) > CInt(AwayScore14.Text) Then
                                HomeTeam14.ForeColor = Drawing.Color.DarkGreen
                                HomeScore14.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam14.ForeColor = Drawing.Color.DarkRed
                                AwayScore14.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore14.Text) > CInt(HomeScore14.Text) Then
                                HomeTeam14.ForeColor = Drawing.Color.DarkRed
                                HomeScore14.ForeColor = Drawing.Color.DarkRed
                                AwayTeam14.ForeColor = Drawing.Color.DarkGreen
                                AwayScore14.ForeColor = Drawing.Color.DarkGreen
                            End If


                        ElseIf game.Key = "game15" Then
                            GameNumber15.Text = game.Key
                            HomeTeam15.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam15.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore15.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore15.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber15Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore15.Text) > CInt(AwayScore15.Text) Then
                                HomeTeam15.ForeColor = Drawing.Color.DarkGreen
                                HomeScore15.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam15.ForeColor = Drawing.Color.DarkRed
                                AwayScore15.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore15.Text) > CInt(HomeScore15.Text) Then
                                HomeTeam15.ForeColor = Drawing.Color.DarkRed
                                HomeScore15.ForeColor = Drawing.Color.DarkRed
                                AwayTeam15.ForeColor = Drawing.Color.DarkGreen
                                AwayScore15.ForeColor = Drawing.Color.DarkGreen
                            End If


                        ElseIf game.Key = "game16" Then
                            GameNumber16.Text = game.Key
                            HomeTeam16.Text = GameUpdateCollection(game.Key).HomeTeam
                            AwayTeam16.Text = GameUpdateCollection(game.Key).AwayTeam
                            HomeScore16.Text = GameUpdateCollection(game.Key).HomeScore
                            AwayScore16.Text = GameUpdateCollection(game.Key).AwayScore
                            GameNumber16Status.Text = GameUpdateCollection(game.Key).GameTime

                            If CInt(HomeScore16.Text) > CInt(AwayScore16.Text) Then
                                HomeTeam16.ForeColor = Drawing.Color.DarkGreen
                                HomeScore16.ForeColor = Drawing.Color.DarkGreen
                                AwayTeam16.ForeColor = Drawing.Color.DarkRed
                                AwayScore16.ForeColor = Drawing.Color.DarkRed
                            ElseIf CInt(AwayScore16.Text) > CInt(HomeScore16.Text) Then
                                HomeTeam16.ForeColor = Drawing.Color.DarkRed
                                HomeScore16.ForeColor = Drawing.Color.DarkRed
                                AwayTeam16.ForeColor = Drawing.Color.DarkGreen
                                AwayScore16.ForeColor = Drawing.Color.DarkGreen
                            End If
                        End If
                    Next

                    cnt = 0
                    For Each user1 In GameUpdateCollection("game13").UserHandles

                        Dim userColor As New System.Drawing.Color

                        For Each game In GameUpdateCollection
                            If GameUpdateCollection.Count >= 13 Then
                                If GameUpdateCollection("game13").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore13.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore13.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game13").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore13.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore13.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                            End If

                            If GameUpdateCollection.Count >= 14 Then
                                If GameUpdateCollection("game14").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore14.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore14.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game14").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore14.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore14.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If
                            End If

                            If GameUpdateCollection.Count >= 15 Then
                                If GameUpdateCollection("game15").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore15.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore15.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game15").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore15.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore15.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If
                            End If

                            If GameUpdateCollection.Count >= 16 Then
                                If GameUpdateCollection("game16").HomeTeamAvailability(user1) = "L" Then
                                    If HomeScore16.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf HomeScore16.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If
                                End If

                                If GameUpdateCollection("game16").AwayTeamAvailability(user1) = "L" Then
                                    If AwayScore16.ForeColor = Drawing.Color.DarkGreen Then
                                        userColor = Drawing.Color.DarkRed
                                        Exit For
                                    ElseIf AwayScore16.ForeColor = Drawing.Color.DarkRed Then
                                        userColor = Drawing.Color.DarkGreen
                                        Exit For
                                    End If

                                End If
                            End If
                        Next


                        Dim dRow As New TableRow

                        If GameUpdateCollection.Count >= 13 Then

                            Dim dCell1 As New TableCell
                            dCell1.Text = GameUpdateCollection("game13").UserHandles(cnt)
                            dCell1.Width = "80"
                            dCell1.ForeColor = userColor
                            dRow.Cells.Add(dCell1)


                            Dim dCell2 As New TableCell
                            dCell2.Text = GameUpdateCollection("game13").HomeTeamAvailability(user1)
                            dCell2.Width = "80"

                            If dCell2.Text = "L" Then
                                dCell2.ForeColor = userColor
                                dCell2.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell2)

                            Dim dCell3 As New TableCell
                            dCell3.Text = GameUpdateCollection("game13").AwayTeamAvailability(user1)
                            dCell3.Width = "80"

                            If dCell3.Text = "L" Then
                                dCell3.ForeColor = userColor
                                dCell3.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell3)

                        End If

                        If GameUpdateCollection.Count >= 14 Then
                            Dim dCell4 As New TableCell
                            dCell4.Text = GameUpdateCollection("game14").HomeTeamAvailability(user1)

                            If dCell4.Text = "L" Then
                                dCell4.ForeColor = userColor
                                dCell4.Font.Bold = True
                            End If


                            dCell4.Width = "80"
                            dRow.Cells.Add(dCell4)

                            Dim dCell5 As New TableCell
                            dCell5.Text = GameUpdateCollection("game14").AwayTeamAvailability(user1)
                            dCell5.Width = "80"

                            If dCell5.Text = "L" Then
                                dCell5.ForeColor = userColor
                                dCell5.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell5)

                        End If

                        If GameUpdateCollection.Count >= 15 Then

                            Dim dCell6 As New TableCell
                            dCell6.Text = GameUpdateCollection("game15").HomeTeamAvailability(user1)
                            dCell6.Width = "80"

                            If dCell6.Text = "L" Then
                                dCell6.ForeColor = userColor
                                dCell6.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell6)

                            Dim dCell7 As New TableCell
                            dCell7.Text = GameUpdateCollection("game15").AwayTeamAvailability(user1)
                            dCell7.Width = "80"

                            If dCell7.Text = "L" Then
                                dCell7.ForeColor = userColor
                                dCell7.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell7)

                        End If

                        If GameUpdateCollection.Count >= 16 Then
                            Dim dCell8 As New TableCell
                            dCell8.Text = GameUpdateCollection("game16").HomeTeamAvailability(user1)
                            dCell8.Width = "80"

                            If dCell8.Text = "L" Then
                                dCell8.ForeColor = userColor
                                dCell8.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell8)

                            Dim dCell9 As New TableCell
                            dCell9.Text = GameUpdateCollection("game16").AwayTeamAvailability(user1)
                            dCell9.Width = "80"

                            If dCell9.Text = "L" Then
                                dCell9.ForeColor = userColor
                                dCell9.Font.Bold = True
                            End If

                            dRow.Cells.Add(dCell9)

                        End If

                        If GameUpdateCollection.Count >= 13 Then
                            TeamsByGameTable4.Rows.Add(dRow)
                        End If

                        cnt = cnt + 1
                    Next

                    If GameUpdateCollection.Count >= 13 Then
                        TeamsByGameTable4.DataBind()
                    End If


                End Using
            End Using

        Catch ex As Exception

        End Try


    End Sub

    Private Shared Function SetHomeTeamAvailabilityState(gameUpdate1 As GameUpdate, queryUpdateGame As List(Of GameUpdateXML), team As String, teamAvailability As Boolean, user1 As UserChoices) As GameUpdate
        If queryUpdateGame(0).hometeam = team Then
            If user1.UserPick = team Then
                gameUpdate1.HomeTeamAvailability.Add(user1.UserName, "L")
            ElseIf teamAvailability = True Then
                gameUpdate1.HomeTeamAvailability.Add(user1.UserName, "A")
            Else
                gameUpdate1.HomeTeamAvailability.Add(user1.UserName, "NA")
            End If
        End If

        Return gameUpdate1
    End Function

    Private Shared Function SetAwayTeamAvailabilityState(gameUpdate1 As GameUpdate, queryUpdateGame As List(Of GameUpdateXML), team As String, teamAvailability As Boolean, user1 As UserChoices) As GameUpdate
        If queryUpdateGame(0).awayteam = team Then
            If user1.UserPick = team Then
                gameUpdate1.AwayTeamAvailability.Add(user1.UserName, "L")
            ElseIf teamAvailability = True Then
                gameUpdate1.AwayTeamAvailability.Add(user1.UserName, "A")
            Else
                gameUpdate1.AwayTeamAvailability.Add(user1.UserName, "NA")
            End If
        End If

        Return gameUpdate1
    End Function


    ' The return type can be changed to IEnumerable, however to support
    ' paging and sorting, the following parameters must be added:
    '     ByVal maximumRows as Integer
    '     ByVal startRowIndex as Integer
    '     ByRef totalRowCount as Integer
    '     ByVal sortByExpression as String

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect("~/LosersPool/Default.aspx")
    End Sub
End Class