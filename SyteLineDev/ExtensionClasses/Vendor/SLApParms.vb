Option Explicit On
Option Strict On

Imports System.Data.SqlClient
Imports Mongoose.IDO
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.DataAccess
Imports Mongoose.Core.Common
Imports CSI.Logistics.Vendor
Imports CSI.MG
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLApParms")> _
Public Class SLApParms
    Inherits ExtensionClassBase
    <IDOMethod(MethodFlags.None)>
    Public Function GetApParm(ByRef parmValue As String, ByVal parmName As String) As Integer
        Dim dr As IDataReader

        dr = Nothing

        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Using cmd As IDbCommand = appDB.CreateCommand()
                cmd.CommandText = String.Format("SELECT {0} FROM apparms", parmName)
                cmd.CommandType = CommandType.Text
                Try
                    dr = cmd.ExecuteReader()

                    Using reader As New MGDataReader(dr)
                        If reader.Read() Then
                            parmValue = TextUtil.FormatNormalizedString(reader.RawReader.GetValue(0))
                        Else
                            Throw New Exception(GetMessageProvider.GetMessage("E=NotOneExists", "@apparms"))
                        End If
                    End Using
                Catch ex As Exception
                    Throw New MGException(ex.Message)
                Finally
                    If dr IsNot Nothing AndAlso Not dr.IsClosed() Then
                        dr.Close()
                    End If
                End Try
            End Using
        End Using

        Return 0

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DetermineVoucherStatusForVatSp(ByRef stat As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iDetermineVoucherStatusForVatExt As IDetermineVoucherStatusForVat = New DetermineVoucherStatusForVatFactory().Create(appDb)

            Dim Severity As Integer = iDetermineVoucherStatusForVatExt.DetermineVoucherStatusForVatSp(stat, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetAccountsPayableParmsSp(ByRef APCheckFormType As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetAccountsPayableParmsExt As IGetAccountsPayableParms = New GetAccountsPayableParmsFactory().Create(appDb)

            Dim Severity As Integer = iGetAccountsPayableParmsExt.GetAccountsPayableParmsSp(APCheckFormType)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetAPAgeDaysSP(ByRef AgeDays1 As Short?, ByRef AgeDesc1 As String, ByRef AgeDays2 As Short?, ByRef AgeDesc2 As String, ByRef AgeDays3 As Short?, ByRef AgeDesc3 As String, ByRef AgeDays4 As Short?, ByRef AgeDesc4 As String, ByRef AgeDays5 As Short?, ByRef AgeDesc5 As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetAPAgeDaysExt As IGetAPAgeDays = New GetAPAgeDaysFactory().Create(appDb)

            Dim Severity As Integer = iGetAPAgeDaysExt.GetAPAgeDaysSP(AgeDays1, AgeDesc1, AgeDays2, AgeDesc2, AgeDays3, AgeDesc3, AgeDays4, AgeDesc4, AgeDays5, AgeDesc5)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetApParmsDraftsPayableAcctSp(ByRef Acct As String, ByRef UnitCode1 As String, ByRef UnitCode2 As String, ByRef UnitCode3 As String, ByRef UnitCode4 As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetApParmsDraftsPayableAcctExt As IGetApParmsDraftsPayableAcct = New GetApParmsDraftsPayableAcctFactory().Create(appDb)

            Dim Severity As Integer = iGetApParmsDraftsPayableAcctExt.GetApParmsDraftsPayableAcctSp(Acct, UnitCode1, UnitCode2, UnitCode3, UnitCode4)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetApParmsOffsetAcctInfoSp(ByRef Acct As String, ByRef UnitCode1 As String, ByRef UnitCode2 As String, ByRef UnitCode3 As String, ByRef UnitCode4 As String, ByRef AccessUnitCode1 As String, ByRef AccessUnitCode2 As String, ByRef AccessUnitCode3 As String, ByRef AccessUnitCode4 As String, ByRef AcctDescription As String, ByRef SiteGroup As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetApParmsOffsetAcctInfoExt As IGetApParmsOffsetAcctInfo = New GetApParmsOffsetAcctInfoFactory().Create(appDb)

            Dim Severity As Integer = iGetApParmsOffsetAcctInfoExt.GetApParmsOffsetAcctInfoSp(Acct, UnitCode1, UnitCode2, UnitCode3, UnitCode4, AccessUnitCode1, AccessUnitCode2, AccessUnitCode3, AccessUnitCode4, AcctDescription, SiteGroup)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VchPreRegisterVarSP(ByRef SuspenseAcct As String, ByRef SuspenseAcctDesc As String, ByRef SuspenseAcctUnit1 As String, ByRef SuspenseAcctUnit2 As String, ByRef SuspenseAcctUnit3 As String, ByRef SuspenseAcctUnit4 As String, ByRef UnMatchedAcct As String, ByRef UnMatchedAcctDesc As String, ByRef UnMatchedAcctUnit1 As String, ByRef UnMatchedAcctUnit2 As String, ByRef UnMatchedAcctUnit3 As String, ByRef UnMatchedAcctUnit4 As String, ByRef FreightAcct As String, ByRef FreightAcctDesc As String, ByRef FreightAcctUnit1 As String, ByRef FreightAcctUnit2 As String, ByRef FreightAcctUnit3 As String, ByRef FreightAcctUnit4 As String, ByRef MiscAcct As String, ByRef MiscAcctDesc As String, ByRef MiscAcctUnit1 As String, ByRef MiscAcctUnit2 As String, ByRef MiscAcctUnit3 As String, ByRef MiscAcctUnit4 As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iVchPreRegisterVarExt As IVchPreRegisterVar = New VchPreRegisterVarFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, SuspenseAcct As String, SuspenseAcctDesc As String, SuspenseAcctUnit1 As String, SuspenseAcctUnit2 As String, SuspenseAcctUnit3 As String, SuspenseAcctUnit4 As String, UnMatchedAcct As String, UnMatchedAcctDesc As String, UnMatchedAcctUnit1 As String, UnMatchedAcctUnit2 As String, UnMatchedAcctUnit3 As String, UnMatchedAcctUnit4 As String, FreightAcct As String, FreightAcctDesc As String, FreightAcctUnit1 As String, FreightAcctUnit2 As String, FreightAcctUnit3 As String, FreightAcctUnit4 As String, MiscAcct As String, MiscAcctDesc As String, MiscAcctUnit1 As String, MiscAcctUnit2 As String, MiscAcctUnit3 As String, MiscAcctUnit4 As String) = iVchPreRegisterVarExt.VchPreRegisterVarSP(SuspenseAcct, SuspenseAcctDesc, SuspenseAcctUnit1, SuspenseAcctUnit2, SuspenseAcctUnit3, SuspenseAcctUnit4, UnMatchedAcct, UnMatchedAcctDesc, UnMatchedAcctUnit1, UnMatchedAcctUnit2, UnMatchedAcctUnit3, UnMatchedAcctUnit4, FreightAcct, FreightAcctDesc, FreightAcctUnit1, FreightAcctUnit2, FreightAcctUnit3, FreightAcctUnit4, MiscAcct, MiscAcctDesc, MiscAcctUnit1, MiscAcctUnit2, MiscAcctUnit3, MiscAcctUnit4)
            Dim Severity As Integer = result.ReturnCode.Value
            SuspenseAcct = result.SuspenseAcct
            SuspenseAcctDesc = result.SuspenseAcctDesc
            SuspenseAcctUnit1 = result.SuspenseAcctUnit1
            SuspenseAcctUnit2 = result.SuspenseAcctUnit2
            SuspenseAcctUnit3 = result.SuspenseAcctUnit3
            SuspenseAcctUnit4 = result.SuspenseAcctUnit4
            UnMatchedAcct = result.UnMatchedAcct
            UnMatchedAcctDesc = result.UnMatchedAcctDesc
            UnMatchedAcctUnit1 = result.UnMatchedAcctUnit1
            UnMatchedAcctUnit2 = result.UnMatchedAcctUnit2
            UnMatchedAcctUnit3 = result.UnMatchedAcctUnit3
            UnMatchedAcctUnit4 = result.UnMatchedAcctUnit4
            FreightAcct = result.FreightAcct
            FreightAcctDesc = result.FreightAcctDesc
            FreightAcctUnit1 = result.FreightAcctUnit1
            FreightAcctUnit2 = result.FreightAcctUnit2
            FreightAcctUnit3 = result.FreightAcctUnit3
            FreightAcctUnit4 = result.FreightAcctUnit4
            MiscAcct = result.MiscAcct
            MiscAcctDesc = result.MiscAcctDesc
            MiscAcctUnit1 = result.MiscAcctUnit1
            MiscAcctUnit2 = result.MiscAcctUnit2
            MiscAcctUnit3 = result.MiscAcctUnit3
            MiscAcctUnit4 = result.MiscAcctUnit4
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DueDateSp(ByVal InvoiceDate As DateTime?, ByVal DueDays As Integer?, ByVal ProxCode As Integer?, ByVal ProxDay As Integer?, ByVal pTermsCode As String, ByVal ProxMonthToForward As Short?, ByVal CutoffDay As Byte?, ByVal HolidayOffsetMethod As String, ByVal ProxDiscMonthToForward As Short?, ByVal ProxDiscDay As Byte?, ByVal DiscDays As Integer?, ByRef DueDate As DateTime?, ByRef DiscDate As DateTime?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDueDateExt As IDueDate = New DueDateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DueDate As DateTime?, DiscDate As DateTime?) = iDueDateExt.DueDateSp(InvoiceDate, DueDays, ProxCode, ProxDay, pTermsCode, ProxMonthToForward, CutoffDay, HolidayOffsetMethod, ProxDiscMonthToForward, ProxDiscDay, DiscDays, DueDate, DiscDate)
            Dim Severity As Integer = result.ReturnCode.Value
            DueDate = result.DueDate
            DiscDate = result.DiscDate
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetVendExchRate2Sp(ByVal PaymentBankCode As String, ByVal VendNum As String, ByVal CheckDate As DateTime?, ByRef ExchRate As Decimal?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(1)> ByVal UseBuyRate As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetVendExchRate2Ext As IGetVendExchRate2 = New GetVendExchRate2Factory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ExchRate As Decimal?, Infobar As String) = iGetVendExchRate2Ext.GetVendExchRate2Sp(PaymentBankCode, VendNum, CheckDate, ExchRate, Infobar, UseBuyRate)
            Dim Severity As Integer = result.ReturnCode.Value
            ExchRate = result.ExchRate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetVendExchRateSp(ByVal VendNum As String, ByVal CheckDate As DateTime?, ByVal CurrCode As String, ByRef ExchRate As Decimal?, ByRef Infobar As String,
<[Optional], DefaultParameterValue(0)> ByVal UseBuyRate As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetVendExchRateExt As IGetVendExchRate = New GetVendExchRateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ExchRate As Decimal?, Infobar As String) = iGetVendExchRateExt.GetVendExchRateSp(VendNum, CheckDate, CurrCode, ExchRate, Infobar, UseBuyRate)
            Dim Severity As Integer = result.ReturnCode.Value
            ExchRate = result.ExchRate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class