Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Linq

Imports LoserPool1.LosersPool.Models

Imports LoserPool1.JoinPools
Imports LoserPool1.JoinPools.Models

Public Class JoinLoserPool
    Inherits System.Web.UI.Page

    Private _dbLoserPool As New LosersPoolContext
    Private _dbMyPool As New PoolDbContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("userId") Is Nothing Then
            Response.Redirect("~/Account/Login.aspx")
        End If

        UserNameTextBox.Focus()
        'JoinError.Text = ""
    End Sub

    Public Sub JoinLoserPoolBtn_Click(sender As Object, e As EventArgs)

        Dim UserName1 As String = CStr(UserNameTextBox.Text)
        Dim EName As String = CStr(Session("userId"))

        If Not (UserName1 = "") Then

            Try
                Using (_dbLoserPool)

                    Dim notValid As New User
                    notValid = _dbLoserPool.Users.SingleOrDefault(Function(u1) u1.UserName = UserName1)

                    If (notValid Is Nothing) Then

                        Dim newUser As New User
                        newUser.UserId = EName
                        newUser.UserName = UserName1
                        newUser.Administrator = False

                        Dim newUser2 As New UserChoices
                        newUser2.UserID = EName
                        newUser2.UserName = UserName1
                        newUser2.DayId = "day0"
                        newUser2.Contender = True
                        newUser2.Washington = True
                        newUser2.Miami = True
                        newUser2.Colorado = True
                        newUser2.Arizona = True
                        newUser2.SanFrancisco = True
                        newUser2.SanDiego = True
                        newUser2.Pittsburg = True
                        newUser2.Cincinnati = True
                        newUser2.Toronto = True
                        newUser2.NYYankees = True
                        newUser2.Boston = True
                        newUser2.TampaBay = True
                        newUser2.Atlanta = True
                        newUser2.Philadelphia = True
                        newUser2.ChicagoWhiteSox = True
                        newUser2.Detroit = True
                        newUser2.KansasCity = True
                        newUser2.Cleveland = True
                        newUser2.Milwaukee = True
                        newUser2.LADodgers = True
                        newUser2.Minnesota = True
                        newUser2.Oakland = True
                        newUser2.Houston = True
                        newUser2.Texas = True
                        newUser2.STLouis = True
                        newUser2.ChicagoCubs = True
                        newUser2.LAAngels = True
                        newUser2.Seattle = True
                        newUser2.NYMets = True
                        newUser2.Baltimore = True

                        If _dbLoserPool.UserChoicesList.Count = 0 Then
                            newUser2.ListId = 1
                        Else
                            newUser2.ListId = _dbLoserPool.UserChoicesList.Count + 1
                        End If

                        _dbLoserPool.Users.Add(newUser)
                        _dbLoserPool.UserChoicesList.Add(newUser2)

                        Dim newUser3 As New UserChoices
                        newUser3.UserID = EName
                        newUser3.UserName = UserName1
                        newUser3.DayId = "day1"
                        newUser3.Contender = True
                        newUser3.Washington = True
                        newUser3.Miami = True
                        newUser3.Colorado = True
                        newUser3.Arizona = True
                        newUser3.SanFrancisco = True
                        newUser3.SanDiego = True
                        newUser3.Pittsburg = True
                        newUser3.Cincinnati = True
                        newUser3.Toronto = True
                        newUser3.NYYankees = True
                        newUser3.Boston = True
                        newUser3.TampaBay = True
                        newUser3.Atlanta = True
                        newUser3.Philadelphia = True
                        newUser3.ChicagoWhiteSox = True
                        newUser3.Detroit = True
                        newUser3.KansasCity = True
                        newUser3.Cleveland = True
                        newUser3.Milwaukee = True
                        newUser3.LADodgers = True
                        newUser3.Minnesota = True
                        newUser3.Oakland = True
                        newUser3.Houston = True
                        newUser3.Texas = True
                        newUser3.STLouis = True
                        newUser3.ChicagoCubs = True
                        newUser3.LAAngels = True
                        newUser3.Seattle = True
                        newUser3.NYMets = True
                        newUser3.Baltimore = True

                        _dbLoserPool.UserChoicesList.Add(newUser3)
                        _dbLoserPool.SaveChanges()

                        Try
                            Using (_dbMyPool)

                                Dim Ename1 As String = CStr(Session("userId"))

                                Dim newuser1 As New MyPool
                                newuser1 = _dbMyPool.MyPools.SingleOrDefault(Function(mp) mp.EName = Ename1)
                                newuser1.Loser = "LoserPool"

                                _dbMyPool.SaveChanges()

                            End Using

                        Catch ex As Exception

                        End Try

                        Response.Redirect("~/Default.aspx")
                    Else
                        UserNameTextBox.Text = ""
                        UserNameTextBox.Focus()
                        JoinError.Text = "ERROR: User name is already in use"
                        'Response.Redirect("~/LosersPool/JoinLoserPool.aspx")
                    End If

                End Using

            Catch ex As Exception

            End Try

        Else
            UserNameTextBox.Text = ""
            UserNameTextBox.Focus()
            JoinError.Text = "ERROR:  Invalid user name"
            'Response.Redirect("~/LosersPool/JoinLoserPool.aspx")
        End If


    End Sub

    Private Function CreateUserId() As String

        Dim userId1 As String

        If _dbLoserPool.Users Is Nothing Then
            userId1 = "user" + Convert.ToString(1)
        Else
            userId1 = "user" + Convert.ToString(_dbLoserPool.Users.Count + 1)
        End If

        Return userId1

    End Function


End Class