Imports System.Linq
Imports System.Xml.Linq

Imports LoserPool1.LosersPool.Models
Imports LoserPool1.JoinPools.Models

Public Class ReadScheduleFile


    Public Sub New(filecontrol As String)

        Dim _dbLoserPool As New LosersPoolContext

        System.IO.Directory.SetCurrentDirectory("C:\Users\Larry\Documents\GitHub\Baseball-Russbucks-IIS-Test\LoserPool1_\LoserPool1")

        Using (_dbLoserPool)
            If _dbLoserPool.ScheduleEntities.Count >= 1 Then
                Exit Sub
            End If
        End Using

        If filecontrol = "onefile" Then

            Dim pathname = ".\TestFiles\scheduleDataDay3.xml"
            ReadScheduleXMLFileAndWriteToScheduleEntities(pathname)

        ElseIf filecontrol = "manyfiles" Then

            Dim schedulefile = XDocument.Load(".\TestFiles\scheduleDataFileList.xml")

            Dim dayFileList = (From dayFile In schedulefile.Descendants("schedulefiles").Descendants("file")
                                Select New dailyFileXML With {.dayFilePath = dayFile.Elements("filepath").Value}).ToList

            For Each day1 In dayFileList
                Dim pathname = day1.dayFilePath
                ReadScheduleXMLFileAndWriteToScheduleEntities(pathname)
            Next

        End If



        Dim dummy = "dummy"

    End Sub

    Private Shared Sub ReadScheduleXMLFileAndWriteToScheduleEntities(pathname As String)

        Dim _dbLoserPool = New LosersPoolContext
        Dim _dbPools As New PoolDbContext

        Try
            Using (_dbLoserPool)
                Using (_dbPools)

                    Dim myschedule = XDocument.Load(pathname)

                    Dim queryDay = (From dayElement In myschedule.Descendants("day")
                                    Select New dayXML With {.dayNumber = dayElement.Attribute("dayNumber")}).ToList

                    Dim queryGame = (From gameElement In myschedule.Descendants("day").Descendants("game")
                    Select New gameXML With {.startDate = gameElement.Elements("startDate").Value,
                        .startTime = gameElement.Elements("startTime").Value,
                        .homeTeam = gameElement.Elements("homeTeam").Value,
                        .awayTeam = gameElement.Elements("awayTeam").Value}).ToList

                    Dim queryTeams = (From team1 In _dbPools.Teams).ToList

                    For gameNum = 1 To queryGame.Count

                        Dim gameNumber = New ScheduleEntity

                        gameNumber.GameId = CreateGameId(_dbLoserPool)
                        gameNumber.DayId = queryDay(0).dayNumber
                        gameNumber.StartDate = queryGame(gameNum - 1).startDate
                        gameNumber.StartTime = queryGame(gameNum - 1).startTime
                        gameNumber.HomeTeam = queryGame(gameNum - 1).homeTeam
                        gameNumber.AwayTeam = queryGame(gameNum - 1).awayTeam

                        _dbLoserPool.ScheduleEntities.Add(gameNumber)
                        _dbLoserPool.SaveChanges()

                    Next


                    Dim thisDay = CStr(queryDay(0).dayNumber)
                    Dim querySchedule = (From day1 In _dbLoserPool.ScheduleEntities
                                         Where day1.DayId = thisDay
                                         Select day1)

                    For Each team1 In queryTeams

                        Dim byeTeam1 = (From daySchedule1 In querySchedule
                                          Where daySchedule1.HomeTeam = team1.TeamName Or daySchedule1.AwayTeam = team1.TeamName).ToList

                        If byeTeam1.Count > 0 Then

                        Else
                            Dim byeTeam2 As New ByeTeam
                            byeTeam2.DayId = thisDay
                            byeTeam2.TeamName = team1.TeamName

                            _dbLoserPool.ByeTeamsList.Add(byeTeam2)
                        End If
                    Next

                    _dbLoserPool.SaveChanges()

                End Using
            End Using
        Catch ex As Exception

        End Try

        Dim dummy = "dummy"

    End Sub

    Private Shared Function CreateGameId(_dbLoserPool As LosersPoolContext) As String

        Dim gameId1 As String

        If _dbLoserPool.ScheduleEntities Is Nothing Then
            gameId1 = "game" + Convert.ToString(1)
        Else
            gameId1 = "game" + Convert.ToString(_dbLoserPool.ScheduleEntities.Count + 1)
        End If

        Return gameId1

    End Function

    Private Shared Function ClearExistingSchedule(_dbLoserPool As LosersPoolContext) As LosersPoolContext

        Try
            Using (_dbLoserPool)

                Dim querySchedule = (From game In _dbLoserPool.ScheduleEntities).ToList

                For Each game In querySchedule
                    _dbLoserPool.ScheduleEntities.Remove(game)
                Next

                _dbLoserPool.SaveChanges()
                Return _dbLoserPool

            End Using
        Catch ex As Exception

        End Try

        Return Nothing

    End Function

End Class

