﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace LosersPool.Models
    Public Class Loser

        <Key>
        Public Property ListId As Int32

        Public Property UserId As String

        Public Property UserName As String

        Public Property DayId As String

        Public Property DayIdInt As Int32

        Public Property LosingPick As String



    End Class
End Namespace