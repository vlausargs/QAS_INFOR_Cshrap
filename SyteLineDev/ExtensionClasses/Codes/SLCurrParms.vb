Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.MG
Imports CSI.Codes
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLCurrParms")> _
Public Class SLCurrParms
    Inherits ExtensionClassBase

    Public Function GetSystemParm(ByRef strParmValue As String, ByVal strParmName As String) As Integer

        Dim ResultSet As IDataReader

        GetSystemParm = 0
        Dim strParmNameWithQuote As String
        strParmNameWithQuote = strParmName.Replace("]", "]]")
        strParmNameWithQuote = "[" + strParmNameWithQuote + "]"

        Try
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Using cmd As IDbCommand = db.CreateCommand()
                    cmd.CommandText = "SELECT " & strParmNameWithQuote & " FROM currparms"
                    ResultSet = db.ExecuteReader(cmd)

                    If ResultSet.Read() Then
                        strParmValue = ResultSet.Item(strParmName).ToString()
                    Else
                        If ResultSet IsNot Nothing AndAlso Not ResultSet.IsClosed Then
                            ResultSet.Close()
                        End If
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@currparms", strParmName))
                    End If
                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                End Using
            End Using
            Exit Function
        Catch ex As Exception
            GetSystemParm = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EuroInfoSp(ByVal DispMsg As Integer?, ByRef PEuroUser As Integer?, ByRef PEuroExists As Integer?, ByRef PBaseEuro As Integer?, ByRef PEuroCurr As String, ByRef InfoBar As String,
        <[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEuroInfoExt As IEuroInfo = New EuroInfoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PEuroUser As Integer?, PEuroExists As Integer?, PBaseEuro As Integer?, PEuroCurr As String, InfoBar As String) = iEuroInfoExt.EuroInfoSp(DispMsg, PEuroUser, PEuroExists, PBaseEuro, PEuroCurr, InfoBar, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            PEuroUser = result.PEuroUser
            PEuroExists = result.PEuroExists
            PBaseEuro = result.PBaseEuro
            PEuroCurr = result.PEuroCurr
            InfoBar = result.InfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EuroPartSp(ByVal PCurrCode As String, ByRef PPartOfEuro As Integer?,
<[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEuroPartExt As IEuroPart = New EuroPartFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PPartOfEuro As Integer?) = iEuroPartExt.EuroPartSp(PCurrCode, PPartOfEuro, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            PPartOfEuro = result.PPartOfEuro
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InsertCurrencySp(ByVal CurrCode As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iInsertCurrencyExt As IInsertCurrency = New InsertCurrencyFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iInsertCurrencyExt.InsertCurrencySp(CurrCode)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateEuroParmsSp(ByVal CurrParmsParmKey As Byte?, ByVal EuroParmsCurrCode As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateEuroParmsExt As IUpdateEuroParms = New UpdateEuroParmsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUpdateEuroParmsExt.UpdateEuroParmsSp(CurrParmsParmKey, EuroParmsCurrCode, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class


