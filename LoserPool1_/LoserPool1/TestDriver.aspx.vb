Imports System
Imports System.Data
Imports System.Linq
Imports System.Xml.Linq
Imports System.Globalization

Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.IO
Imports System.IO.Path

Imports System.Threading
Imports System.Threading.Tasks


Public Class TestDriver
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("userId") Is Nothing Then
            Response.Redirect("~/Account/Login.aspx")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim currentDateTime As New Date
        Dim cDT As String
        Dim sp As String
        Dim currentDate As String
        Dim currentTime As String

        Dim newDateTime As New Date
        Dim nDT As String
        Dim newDate As String
        Dim newTime As String

        Dim myUpdate As XDocument
        Dim mySchedule As XDocument

        Dim rootDirectory1 = GetPathRoot(GetFullPath("scoringUpdate.xml"))
        Dim fileDirectory1 = "Users\Larry\Documents\GitHub\Russbucks-IIS-Test\LoserPool1_\LoserPool1\TestFiles\"

        Dim filePath1 = rootDirectory1 + fileDirectory1

        Dim t1 = 3
        Dim t2 = 3
        Dim t3 = 1

        Button1.Visible = False

        currentDateTime = DateTime.Now

        cDT = currentDateTime.ToString("g")

        sp = cDT.IndexOf(" ")

        currentDate = cDT.Substring(0, sp)
        currentTime = cDT.Substring(sp + 1)

        ' Create Schedule Files for Week1-3 using new times
        newDateTime = currentDateTime.AddMinutes(t1)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        mySchedule = XDocument.Load(filePath1 + "ScheduleFileWeek1.xml")

        For Each game In mySchedule.Descendants("schedule").Descendants("day").Descendants("game")

            game.Element("startDate").Value = newDate
            game.Element("startTime").Value = newTime

        Next

        mySchedule.Save(filePath1 + "ScheduleFileWeek1.xml")

        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        mySchedule = XDocument.Load(filePath1 + "ScheduleFileWeek2.xml")

        For Each game In mySchedule.Descendants("schedule").Descendants("day").Descendants("game")

            game.Element("startDate").Value = newDate
            game.Element("startTime").Value = newTime

        Next

        mySchedule.Save(filePath1 + "ScheduleFileWeek2.xml")

        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2 + 3 * t3 + t2)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        mySchedule = XDocument.Load(filePath1 + "ScheduleFileWeek3.xml")

        For Each game In mySchedule.Descendants("schedule").Descendants("day").Descendants("game")

            game.Element("startDate").Value = newDate
            game.Element("startTime").Value = newTime

        Next

        mySchedule.Save(filePath1 + "ScheduleFileWeek3.xml")

        'Create Scoring update files using new times

        newDateTime = currentDateTime.AddMinutes(t1)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek1Update0.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek1Update0.xml")

        newDateTime = currentDateTime.AddMinutes(t1 + t3)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek1Update1.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek1Update1.xml")


        newDateTime = currentDateTime.AddMinutes(t1 + 2 * t3)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek1Update2.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek1Update2.xml")

        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek1Update3.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek1Update3.xml")

        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek2Update0.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek2Update0.xml")


        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2 + t3)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek2Update1.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek2Update1.xml")

        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2 + 2 * t3)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek2Update2.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek2Update2.xml")

        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2 + 3 * t3)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek2Update3.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek2Update3.xml")


        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2 + 3 * t3 + t2)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek3Update0.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek3Update0.xml")



        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2 + 3 * t3 + t2 + t3)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek3Update1.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek3Update1.xml")

        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2 + 3 * t3 + t2 + 2 * t3)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek3Update2.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek3Update2.xml")

        newDateTime = currentDateTime.AddMinutes(t1 + 3 * t3 + t2 + 3 * t3 + t2 + 3 * t3)

        nDT = newDateTime.ToString("g")

        sp = nDT.IndexOf(" ")

        newDate = nDT.Substring(0, sp)
        newTime = nDT.Substring(sp + 1)

        myUpdate = XDocument.Load(filePath1 + "scoringUpdateWeek3Update3.xml")

        myUpdate.Element("scores").Attribute("filetime").Value = newTime
        myUpdate.Element("scores").Attribute("filedate").Value = newDate

        myUpdate.Save(filePath1 + "scoringUpdateWeek3Update3.xml")


        myUpdate = XDocument.Load(filePath1 + "scoringUpdatePreseason.xml")

        Dim queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
                 Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                               .homescore = CInt(game.Elements("homescore").Value),
                                               .awayteam = game.Attribute("awayteam").Value,
                                               .awayscore = CInt(game.Elements("awayscore").Value),
                                               .gametime = game.Elements("gametime").Value}).ToList

        Dim allGamesAreFinal As Boolean = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(filePath1 + "scoringUpdateFinalWeek0.xml")
        End If

        myUpdate.Save(filePath1 + "scoringUpdate.xml")


        Dim sT As New SleepyThread()

        sT.TD1 = t1
        sT.TD2 = t2
        sT.TD3 = t3
        sT.FP = filePath1

        Dim updateFileThread As New Thread(AddressOf sT.ToSleep)
        updateFileThread.Start()

    End Sub
End Class
Public Class SleepyThread

    Public Property TD1 As Int32
    Public Property TD2 As Int32
    Public Property TD3 As Int32

    Public Property FP As String

    Public Sub New()

    End Sub

    Public Sub ToSleep()

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD1))

        Dim myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek1Update0.xml")

        Dim queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
                 Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                               .homescore = CInt(game.Elements("homescore").Value),
                                               .awayteam = game.Attribute("awayteam").Value,
                                               .awayscore = CInt(game.Elements("awayscore").Value),
                                               .gametime = game.Elements("gametime").Value}).ToList

        Dim allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek1.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD3))


        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek1Update1.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
                 Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                               .homescore = CInt(game.Elements("homescore").Value),
                                               .awayteam = game.Attribute("awayteam").Value,
                                               .awayscore = CInt(game.Elements("awayscore").Value),
                                               .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek1.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD3))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek1Update2.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
         Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                       .homescore = CInt(game.Elements("homescore").Value),
                                       .awayteam = game.Attribute("awayteam").Value,
                                       .awayscore = CInt(game.Elements("awayscore").Value),
                                       .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek1.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD3))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek1Update3.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
         Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                       .homescore = CInt(game.Elements("homescore").Value),
                                       .awayteam = game.Attribute("awayteam").Value,
                                       .awayscore = CInt(game.Elements("awayscore").Value),
                                       .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek1.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD2))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek2Update0.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
         Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                       .homescore = CInt(game.Elements("homescore").Value),
                                       .awayteam = game.Attribute("awayteam").Value,
                                       .awayscore = CInt(game.Elements("awayscore").Value),
                                       .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek2.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD3))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek2Update1.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
         Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                       .homescore = CInt(game.Elements("homescore").Value),
                                       .awayteam = game.Attribute("awayteam").Value,
                                       .awayscore = CInt(game.Elements("awayscore").Value),
                                       .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek2.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD3))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek2Update2.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
 Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                               .homescore = CInt(game.Elements("homescore").Value),
                               .awayteam = game.Attribute("awayteam").Value,
                               .awayscore = CInt(game.Elements("awayscore").Value),
                               .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek2.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD3))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek2Update3.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
 Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                               .homescore = CInt(game.Elements("homescore").Value),
                               .awayteam = game.Attribute("awayteam").Value,
                               .awayscore = CInt(game.Elements("awayscore").Value),
                               .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek2.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD2))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek3Update0.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
         Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                       .homescore = CInt(game.Elements("homescore").Value),
                                       .awayteam = game.Attribute("awayteam").Value,
                                       .awayscore = CInt(game.Elements("awayscore").Value),
                                       .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek3.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD3))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek3Update1.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
         Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                               .homescore = CInt(game.Elements("homescore").Value),
                               .awayteam = game.Attribute("awayteam").Value,
                               .awayscore = CInt(game.Elements("awayscore").Value),
                               .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek3.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD3))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek3Update2.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
                    Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                               .homescore = CInt(game.Elements("homescore").Value),
                               .awayteam = game.Attribute("awayteam").Value,
                               .awayscore = CInt(game.Elements("awayscore").Value),
                               .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek3.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")

        Thread.Sleep(TimeSpan.FromMinutes(Me.TD3))

        myUpdate = XDocument.Load(Me.FP + "scoringUpdateWeek3Update3.xml")

        queryGame = (From game In myUpdate.Descendants("scores").Descendants("game")
         Select New GameUpdateXML With {.hometeam = game.Attribute("hometeam").Value,
                                       .homescore = CInt(game.Elements("homescore").Value),
                                       .awayteam = game.Attribute("awayteam").Value,
                                       .awayscore = CInt(game.Elements("awayscore").Value),
                                       .gametime = game.Elements("gametime").Value}).ToList

        allGamesAreFinal = True
        For Each game In queryGame
            If game.gametime <> "final" Then
                allGamesAreFinal = False
            End If
        Next

        If allGamesAreFinal = True Then
            myUpdate.Save(Me.FP + "scoringUpdateFinalWeek3.xml")
        End If


        myUpdate.Save(Me.FP + "scoringUpdate.xml")



    End Sub

End Class