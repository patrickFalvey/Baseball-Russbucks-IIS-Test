Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Linq
Imports System.Data

Imports LoserPool1.LosersPool.Models

Imports LoserPool1.JoinPools
Imports LoserPool1.JoinPools.Models

Public Class CreateSchedulePeriod

    Private _dbLoserPool As New LosersPoolContext

    Public Sub New()

        If _dbLoserPool.ScheduleTimePeriods.Count >= 1 Then
            Exit Sub
        End If


        Try
            Using (_dbLoserPool)

                Dim games = New List(Of ScheduleEntity)
                games = _dbLoserPool.ScheduleEntities.ToList

                Dim days = New Dictionary(Of String, String)
                For Each game In games

                    Dim day1 = game.DayId
                    If Not (days.ContainsKey(day1)) Then
                        days.Add(day1, day1)
                    End If
                Next

                For Each day2 In days

                    Dim dailygames = New List(Of ScheduleEntity)
                    dailygames = _dbLoserPool.ScheduleEntities.Where(Function(wg) wg.DayId = day2.Key).ToList

                    Dim minStartDate As String
                    minStartDate = dailygames(0).StartDate
                    For gamenum = 1 To dailygames.Count - 1
                        If dailygames(gamenum).StartDate < minStartDate Then
                            minStartDate = dailygames(gamenum).StartDate
                        End If
                    Next

                    Dim dailygames1 = New List(Of ScheduleEntity)
                    dailygames1 = _dbLoserPool.ScheduleEntities.Where(Function(wg) wg.DayId = day2.Key And wg.StartDate = minStartDate).ToList

                    Dim minStartTime As String
                    minStartTime = dailygames1(0).StartTime
                    For gamenum = 1 To dailygames1.Count - 1
                        If dailygames1(gamenum).StartTime < minStartTime Then
                            minStartTime = dailygames1(gamenum).StartTime
                        End If
                    Next

                    Dim scheduleTimePeriod = New ScheduleTimePeriod
                    scheduleTimePeriod.dayID = day2.Key

                    If day2.Key = "day1" Then
                        scheduleTimePeriod.startDayDate = "3/15/15"
                        scheduleTimePeriod.startDayTime = "12:01 AM"
                    End If

                    scheduleTimePeriod.startGameDate = minStartTime
                    scheduleTimePeriod.startGameTime = minStartDate

                    _dbLoserPool.ScheduleTimePeriods.Add(scheduleTimePeriod)
                    _dbLoserPool.SaveChanges()

                    Dim dummy = "dummy"

                Next




            End Using
        Catch ex As Exception

        End Try


    End Sub

    Private Shared Function ClearExistingScheduleTimePeriodList(_dbLoserPool As LosersPoolContext) As LosersPoolContext

        Try

            Dim queryScheduleTimePeriod = (From game In _dbLoserPool.ScheduleTimePeriods).ToList

            For Each timePeriod In queryScheduleTimePeriod
                _dbLoserPool.ScheduleTimePeriods.Remove(timePeriod)
            Next

            _dbLoserPool.SaveChanges()
            Return _dbLoserPool


        Catch ex As Exception

        End Try

        Return Nothing

    End Function

End Class
