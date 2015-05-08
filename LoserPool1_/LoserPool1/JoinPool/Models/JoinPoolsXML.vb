﻿Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Linq
Imports System.Data

Imports LoserPool1.LosersPool.Models

Imports LoserPool1.JoinPools
Imports LoserPool1.JoinPools.Models


Public Class PoolList
    Public Sub New(filepath As String)
        Dim _dbPools As New PoolDbContext

        Try
            Using (_dbPools)

                Dim queryPool1 = (From pool1 In _dbPools.Pools).ToList

                If queryPool1.Count >= 1 Then
                    Exit Sub
                End If

                Dim poolsXDocument = XDocument.Load(filepath)

                Dim allPools = (From pool1 In poolsXDocument.Descendants("PoolList").Descendants("Pool")
                                Select New PoolXML With {.PoolId = pool1.Attribute("PoolId").Value,
                                                         .PoolName = pool1.Elements("PoolName").Value})

                For Each pool1 In allPools
                    Dim pool2 As New Pool
                    pool2.PoolId = pool1.PoolId
                    pool2.PoolName = pool1.PoolName
                    _dbPools.Pools.Add(pool2)
                Next

                _dbPools.SaveChanges()

            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class TeamList
    Public Sub New(filepath As String)
        Dim _dbPools As New PoolDbContext

        Try
            Using (_dbPools)

                Dim queryTeam1 = (From team1 In _dbPools.Teams).ToList

                If queryTeam1.Count >= 1 Then
                    Exit Sub
                End If

                Dim teamsXDocument = XDocument.Load(filepath)

                Dim allteams = (From team1 In teamsXDocument.Descendants("TeamList").Descendants("Team")
                                Select New TeamXML With {.TeamId = team1.Attribute("TeamId").Value,
                                                         .TeamName = team1.Elements("TeamName").Value})

                For Each team1 In allteams
                    Dim team2 As New Team
                    team2.TeamId = team1.TeamId
                    team2.TeamName = team1.TeamName
                    _dbPools.Teams.Add(team2)
                Next

                _dbPools.SaveChanges()

            End Using
        Catch ex As Exception

        End Try
    End Sub

End Class
Public Class MyPoolListAlso
    Public Sub New(filepath As String)
        Dim _dbPools As New PoolDbContext

        Try
            Using (_dbPools)

                Dim queryMypool1 = (From user1 In _dbPools.MyPools).ToList

                If queryMypool1.Count >= 1 Then
                    Exit Sub
                End If

                Dim poolsXDocument = XDocument.Load(filepath)

                Dim queryAllMypools = (From user1 In poolsXDocument.Descendants("MyPoolList").Descendants("User")
                                       Select New MyPoolXML With {.UserId = user1.Attribute("UserId").Value,
                                                                   .EName = user1.Elements("EName").Value,
                                                                   .Loser = user1.Elements("Loser").Value,
                                                                   .Playoff = user1.Elements("Playoff").Value}).ToList

                For Each user1 In queryAllMypools
                    Dim user2 = New MyPool
                    user2.UserId = user1.UserId
                    user2.EName = user1.EName

                    If user1.Loser = "" Then
                        user2.Loser = Nothing
                    Else
                        user2.Loser = user1.Loser
                    End If

                    If user1.Playoff = "" Then
                        user2.Playoff = Nothing
                    Else
                        user2.Playoff = user1.Playoff
                    End If



                    _dbPools.MyPools.Add(user2)
                Next

                _dbPools.SaveChanges()

            End Using
        Catch ex As Exception

        End Try

    End Sub

End Class

Public Class SeedPools
    Public Sub New()
        Dim _dbPools2 As New PoolDbContext


        Try

            Using (_dbPools2)

                Dim querypool1 = (From user1 In _dbPools2.Pools).ToList

                If querypool1.Count >= 1 Then
                    Exit Sub
                End If

                Dim pool1 As New Pool
                pool1.PoolId = "pool1"
                pool1.PoolName = "LoserPool"

                _dbPools2.Pools.Add(pool1)

                Dim pool2 As New Pool
                pool2.PoolId = "pool2"
                pool2.PoolName = "PlayoffPool"

                _dbPools2.Pools.Add(pool2)

                _dbPools2.SaveChanges()
            End Using
        Catch ex As Exception

        End Try

    End Sub

End Class

Public Class SeedTeams
    Public Sub New()

        Dim _dbPools2 As New PoolDbContext

        Try
            Using (_dbPools2)

                Dim queryTeam1 = (From team1 In _dbPools2.Teams).ToList

                If queryTeam1.Count >= 1 Then
                    Exit Sub
                End If

                Dim teams As New List(Of Team)
                teams = GetTeams()
                For Each team1 In teams
                    _dbPools2.Teams.Add(team1)
                Next

                _dbPools2.SaveChanges()

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function GetTeams() As List(Of Team)

        Dim teams As New List(Of Team)
        Dim t As New Team

        t.TeamId = "team1"
        t.TeamName = "Washington"
        teams.Add(t)

        t = New Team
        t.TeamId = "team2"
        t.TeamName = "Miami"
        teams.Add(t)

        t = New Team
        t.TeamId = "team3"
        t.TeamName = "Colorado"
        teams.Add(t)

        t = New Team
        t.TeamId = "team4"
        t.TeamName = "Arizona"
        teams.Add(t)

        t = New Team
        t.TeamId = "team5"
        t.TeamName = "San Francisco"
        teams.Add(t)

        t = New Team
        t.TeamId = "team6"
        t.TeamName = "San Diego"
        teams.Add(t)

        t = New Team
        t.TeamId = "team7"
        t.TeamName = "Pittsburg"
        teams.Add(t)

        t = New Team
        t.TeamId = "team8"
        t.TeamName = "Cincinnati"
        teams.Add(t)

        t = New Team
        t.TeamId = "team9"
        t.TeamName = "Toronto"
        teams.Add(t)

        t = New Team
        t.TeamId = "team10"
        t.TeamName = "NY Yankees"
        teams.Add(t)

        t = New Team
        t.TeamId = "team11"
        t.TeamName = "Boston"
        teams.Add(t)

        t = New Team
        t.TeamId = "team12"
        t.TeamName = "Tampa Bay"
        teams.Add(t)

        t = New Team
        t.TeamId = "team13"
        t.TeamName = "Atlanta"
        teams.Add(t)

        t = New Team
        t.TeamId = "team14"
        t.TeamName = "Philadelphia"
        teams.Add(t)

        t = New Team
        t.TeamId = "team15"
        t.TeamName = "Chicago White Sox"
        teams.Add(t)

        t = New Team
        t.TeamId = "team16"
        t.TeamName = "Detroit"
        teams.Add(t)

        t = New Team
        t.TeamId = "team17"
        t.TeamName = "Kansas City"
        teams.Add(t)

        t = New Team
        t.TeamId = "team18"
        t.TeamName = "Cleveland"
        teams.Add(t)

        t = New Team
        t.TeamId = "team19"
        t.TeamName = "Milwaukee"
        teams.Add(t)

        t = New Team
        t.TeamId = "team20"
        t.TeamName = "LA Dodgers"
        teams.Add(t)

        t = New Team
        t.TeamId = "team21"
        t.TeamName = "Minnesota"
        teams.Add(t)

        t = New Team
        t.TeamId = "team22"
        t.TeamName = "Oakland"
        teams.Add(t)

        t = New Team
        t.TeamId = "team23"
        t.TeamName = "Houston"
        teams.Add(t)

        t = New Team
        t.TeamId = "team24"
        t.TeamName = "Texas"
        teams.Add(t)

        t = New Team
        t.TeamId = "team25"
        t.TeamName = "St. Louis"
        teams.Add(t)

        t = New Team
        t.TeamId = "team26"
        t.TeamName = "Chicago Cubs"
        teams.Add(t)

        t = New Team
        t.TeamId = "team27"
        t.TeamName = "LA Angels"
        teams.Add(t)

        t = New Team
        t.TeamId = "team28"
        t.TeamName = "Seattle"
        teams.Add(t)

        t = New Team
        t.TeamId = "team29"
        t.TeamName = "NY Mets"
        teams.Add(t)

        t = New Team
        t.TeamId = "team30"
        t.TeamName = "Baltimore"
        teams.Add(t)

        Return teams

    End Function

End Class