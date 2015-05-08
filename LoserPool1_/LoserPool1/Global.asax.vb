Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Optimization
Imports System.Web.Routing
Imports System.Web.Security
Imports System.Web.SessionState
Imports System.Data.Entity

Imports LoserPool1.JoinPools.Models
Imports LoserPool1.PlayoffPool.Models
Imports LoserPool1.PlayoffPool
Imports LoserPool1.LosersPool.Models

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

    End Sub

End Class