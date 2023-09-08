Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.MG
Imports CSI.Codes

<IDOExtensionClass("SLTaxparms")> _
Public Class SLTaxparms
    Inherits ExtensionClassBase
    ' this one takes the name of the parm to retrieve
    <IDOMethod(MethodFlags.None)> _
    Public Function GetSystemParm(ByRef strParmValue As Object, ByVal strParmName As String) As Integer


        Dim ResultSet As IDataReader = Nothing
        Dim strParmNameWithQuote As String
        strParmNameWithQuote = strParmName.Replace("]", "]]")
        strParmNameWithQuote = "[" + strParmNameWithQuote + "]"

        Try
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Using cmd As IDbCommand = db.CreateCommand()
                    cmd.CommandText = "SELECT " & strParmNameWithQuote & " FROM taxparms"

                    ResultSet = db.ExecuteReader(cmd)

                    If ResultSet.Read() Then
                        strParmValue = ResultSet.Item(strParmName)
                    Else
                        If ResultSet IsNot Nothing AndAlso Not ResultSet.IsClosed Then
                            ResultSet.Close()
                        End If
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist1", "@!Parameters", "@taxparms", strParmName))
                    End If
                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                End Using
            End Using

            Return 0
        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetTaxParmsTaxRegNumSp(ByRef TaxRegNum As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetTaxParmsTaxRegNumExt As IGetTaxParmsTaxRegNum = New GetTaxParmsTaxRegNumFactory().Create(appDb)

            Dim Severity As Integer = iGetTaxParmsTaxRegNumExt.GetTaxParmsTaxRegNumSp(TaxRegNum)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetTaxRegNumReturnSubmissionSiteSp(ByVal Site As String, ByRef TaxRegNumReturnSubmissionSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetTaxRegNumReturnSubmissionSiteExt As IGetTaxRegNumReturnSubmissionSite = New GetTaxRegNumReturnSubmissionSiteFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TaxRegNumReturnSubmissionSite As String) = iGetTaxRegNumReturnSubmissionSiteExt.GetTaxRegNumReturnSubmissionSiteSp(Site, TaxRegNumReturnSubmissionSite)
            Dim Severity As Integer = result.ReturnCode.Value
            TaxRegNumReturnSubmissionSite = result.TaxRegNumReturnSubmissionSite
            Return Severity
        End Using
    End Function
End Class

