Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Mongoose.Core.DataAccess
Imports System.Runtime.InteropServices
Imports CSI.MG
Imports CSI.Logistics.Customer
Imports CSI.Data.SQL.UDDT
Imports CSI.Finance.AR
Imports CSI.Logistics.Vendor
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD

<IDOExtensionClass("SLArtrans")> _
Public Class SLArtrans
    Inherits CSIExtensionClassBase

    <IDOMethod(MethodFlags.CustomLoad)>
    Public Function EuroCustSitesCustomLoad(
          ByVal StartingCustomer1 As String, ByVal EndingCustomer1 As String,
          ByVal StartingCustomer2 As String, ByVal EndingCustomer2 As String,
          ByVal StartingCustomer3 As String, ByVal EndingCustomer3 As String,
          ByVal StartingCustomer4 As String, ByVal EndingCustomer4 As String,
          ByVal StartingCustomer5 As String, ByVal EndingCustomer5 As String,
          ByVal StartingCustomer6 As String, ByVal EndingCustomer6 As String,
          ByVal StartingCustomer7 As String, ByVal EndingCustomer7 As String,
          ByVal StartingCustomer8 As String, ByVal EndingCustomer8 As String,
          ByVal StartingCustomer9 As String, ByVal EndingCustomer9 As String,
          ByVal StartingCustomer10 As String, ByVal EndingCustomer10 As String,
          ByVal CurrencyCode As String, ByVal Process As String,
          ByRef Infobar As String) As DataTable

        Dim result As New DataTable()
        Dim cmd As IDbCommand = Nothing
        Using txn As ITransactionScope = TransactionScopeFactory.Create(Transactions.TransactionScopeOption.Required, Transactions.IsolationLevel.ReadCommitted, Transactions.TransactionManager.MaximumTimeout)
            Dim so As SLServerOperations = New SLServerOperations()
            Try
                cmd = so.AppDBConnection.CreateCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "EuroCustSitesSp"
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum1", StartingCustomer1).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum1", EndingCustomer1).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum2", StartingCustomer2).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum2", EndingCustomer2).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum3", StartingCustomer3).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum3", EndingCustomer3).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum4", StartingCustomer4).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum4", EndingCustomer4).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum5", StartingCustomer5).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum5", EndingCustomer5).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum6", StartingCustomer6).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum6", EndingCustomer6).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum7", StartingCustomer7).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum7", EndingCustomer7).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum8", StartingCustomer8).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum8", EndingCustomer8).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum9", StartingCustomer9).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum9", EndingCustomer9).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pBeginCustNum10", StartingCustomer10).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pEndCustNum10", EndingCustomer10).Size = 100
                so.AppDBConnection.AddCommandParameterWithValue(cmd, "pFromCurrencyCode", CurrencyCode).Size = 100
                so.AppDBConnection.DataProvider.AddCommandParameterWithValue(Of String)(cmd, "rInfobar", Infobar, ParameterDirection.Output).Size = 5600

                result = so.ConvertDataReaderToDataTable(so.AppDBConnection.ExecuteReader(cmd))
                Dim parmInfobar As IDbDataParameter = CType(cmd.Parameters(21), IDbDataParameter)
                ' if this is not a preview commit the txn
                If Process <> "P" Then txn.Complete()
                ' NOTE: output parameters are not supported on custom load methods
                ' so I don't think this will ever get back to the caller
                If Not IDONull.IsNull(parmInfobar.Value) Then
                    Infobar = parmInfobar.Value.ToString()
                End If
            Catch ex As Exception
            Finally
                If cmd IsNot Nothing Then
                    If cmd.Connection IsNot Nothing Then
                        cmd.Connection.Dispose()
                    End If
                    cmd.Dispose()
                End If
                If so IsNot Nothing Then
                    If so.AppDBConnection IsNot Nothing Then
                        so.AppDBConnection = Nothing
                    End If
                    so.Dispose()
                End If
            End Try

        End Using

        Return result
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ARActDeactPostedTransSp(ByVal pActivate As Byte?, ByVal pStartCustNum As String, ByVal pEndCustNum As String, ByVal pStartLastActivityDate As DateTime?, ByVal pEndLastActivityDate As DateTime?, ByVal pStartInvDate As DateTime?, ByVal pEndInvDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal UserID As Decimal?,
<[Optional]> ByVal BGTaskID As Integer?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal ReturnCounts As Byte?,
<[Optional], DefaultParameterValue(CByte(0))> ByVal CountOnly As Byte?,
<[Optional], DefaultParameterValue(0)> ByRef ActiveCount As Integer?,
<[Optional], DefaultParameterValue(0)> ByRef InactiveCount As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iARActDeactPostedTransExt As CSI.Logistics.Customer.IARActDeactPostedTrans = New CSI.Logistics.Customer.ARActDeactPostedTransFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String, ActiveCount As Integer?, InactiveCount As Integer?) = iARActDeactPostedTransExt.ARActDeactPostedTransSp(pActivate, pStartCustNum, pEndCustNum, pStartLastActivityDate, pEndLastActivityDate, pStartInvDate, pEndInvDate, Infobar, UserID, BGTaskID, ReturnCounts, CountOnly, ActiveCount, InactiveCount)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            ActiveCount = result.ActiveCount
            InactiveCount = result.InactiveCount
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_DeleteARPostedTransSp(ByVal pThruDate As DateTime?, ByVal pStateCycle As String, ByVal pStartCustNum As String, ByVal pEndCustNum As String, ByVal pCommit As Byte?, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iCLM_DeleteARPostedTransExt As ICLM_DeleteARPostedTrans = New CLM_DeleteARPostedTransFactory().Create(appDb, bunchedLoadCollection)

            Dim oInfobar As InfobarType = Infobar

            Dim dt As DataTable = iCLM_DeleteARPostedTransExt.CLM_DeleteARPostedTransSp(pThruDate, pStateCycle, pStartCustNum, pEndCustNum, pCommit, oInfobar)

            Infobar = oInfobar

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ResidualInvoiceSp(ByVal PStartingInvNum As String, ByVal PEndingInvNum As String, ByVal PStartingCustNum As String, ByVal PEndingCustNum As String, ByVal PStartingInvDate As DateTime?, ByVal PEndingInvDate As DateTime?, ByVal PStartingAmount As Decimal?, ByVal PEndingAmount As Decimal?, ByVal PCurrencyCode As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iCLM_ResidualInvoiceExt As ICLM_ResidualInvoice = New CLM_ResidualInvoiceFactory().Create(appDb, bunchedLoadCollection)

            Dim dt As DataTable = iCLM_ResidualInvoiceExt.CLM_ResidualInvoiceSp(PStartingInvNum, PEndingInvNum, PStartingCustNum, PEndingCustNum, PStartingInvDate, PEndingInvDate, PStartingAmount, PEndingAmount, PCurrencyCode)

            Return dt
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ProfileARInvoiceCDMSp(
<[Optional]> ByVal PrePrint As Byte?,
<[Optional]> ByVal DocType As String,
<[Optional]> ByVal StartCustomer As String,
<[Optional]> ByVal EndCustomer As String,
<[Optional]> ByVal StartInvoice As String,
<[Optional]> ByVal EndInvoice As String,
<[Optional]> ByVal StartChkRef As Integer?,
<[Optional]> ByVal EndChkRef As Integer?,
<[Optional]> ByVal StartInvDate As DateTime?,
<[Optional]> ByVal EndInvDate As DateTime?,
<[Optional]> ByVal StartIssueDate As DateTime?,
<[Optional]> ByVal EndIssueDate As DateTime?,
<[Optional]> ByVal StartInvDateOffset As Short?,
<[Optional]> ByVal EndInvDateOffset As Short?,
<[Optional]> ByVal StartIssueDateOffset As Short?,
<[Optional]> ByVal EndIssueDateOffset As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iProfileARInvoiceCDMExt As IProfileARInvoiceCDM = New ProfileARInvoiceCDMFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iProfileARInvoiceCDMExt.ProfileARInvoiceCDMSp(PrePrint, DocType, StartCustomer, EndCustomer, StartInvoice, EndInvoice, StartChkRef, EndChkRef, StartInvDate, EndInvDate, StartIssueDate, EndIssueDate, StartInvDateOffset, EndInvDateOffset, StartIssueDateOffset, EndIssueDateOffset)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ResidualARBalElimSp(ByVal PInvoiceNum As String, ByVal PCustomerNum As String, ByVal PAmount As Decimal?, ByVal ArinvdAcct As String, ByVal ArinvdAcctUnit1 As String, ByVal ArinvdAcctUnit2 As String, ByVal ArinvdAcctUnit3 As String, ByVal ArinvdAcctUnit4 As String,
<[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iResidualARBalElimExt As IResidualARBalElim = New ResidualARBalElimFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iResidualARBalElimExt.ResidualARBalElimSp(PInvoiceNum, PCustomerNum, PAmount, ArinvdAcct, ArinvdAcctUnit1, ArinvdAcctUnit2, ArinvdAcctUnit3, ArinvdAcctUnit4, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_ARBalanceSp(ByVal FiscalYear As Short?, ByVal Period As Byte?, ByVal SiteGroup As String,
<[Optional]> ByVal FilterString As String, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_ARBalanceExt As ICLM_ARBalance = New CLM_ARBalanceFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iCLM_ARBalanceExt.CLM_ARBalanceSp(FiscalYear, Period, SiteGroup, FilterString, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EuroCustSitesSp(ByVal pBeginCustNum1 As String, ByVal pEndCustNum1 As String,
<[Optional]> ByVal pBeginCustNum2 As String,
<[Optional]> ByVal pEndCustNum2 As String,
<[Optional]> ByVal pBeginCustNum3 As String,
<[Optional]> ByVal pEndCustNum3 As String,
<[Optional]> ByVal pBeginCustNum4 As String,
<[Optional]> ByVal pEndCustNum4 As String,
<[Optional]> ByVal pBeginCustNum5 As String,
<[Optional]> ByVal pEndCustNum5 As String,
<[Optional]> ByVal pBeginCustNum6 As String,
<[Optional]> ByVal pEndCustNum6 As String,
<[Optional]> ByVal pBeginCustNum7 As String,
<[Optional]> ByVal pEndCustNum7 As String,
<[Optional]> ByVal pBeginCustNum8 As String,
<[Optional]> ByVal pEndCustNum8 As String,
<[Optional]> ByVal pBeginCustNum9 As String,
<[Optional]> ByVal pEndCustNum9 As String,
<[Optional]> ByVal pBeginCustNum10 As String,
<[Optional]> ByVal pEndCustNum10 As String, ByVal pFromCurrencyCode As String, ByRef rInfobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEuroCustSitesExt As IEuroCustSites = New EuroCustSitesFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, rInfobar As String) = iEuroCustSitesExt.EuroCustSitesSp(pBeginCustNum1, pEndCustNum1, pBeginCustNum2, pEndCustNum2, pBeginCustNum3, pEndCustNum3, pBeginCustNum4, pEndCustNum4, pBeginCustNum5, pEndCustNum5, pBeginCustNum6, pEndCustNum6, pBeginCustNum7, pEndCustNum7, pBeginCustNum8, pEndCustNum8, pBeginCustNum9, pEndCustNum9, pBeginCustNum10, pEndCustNum10, pFromCurrencyCode, rInfobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            rInfobar = result.rInfobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EuroCustSp(ByVal pProcess As String, ByVal pBeginCustNum1 As String, ByVal pEndCustNum1 As String,
        <[Optional]> ByVal pBeginCustNum2 As String,
        <[Optional]> ByVal pEndCustNum2 As String,
        <[Optional]> ByVal pBeginCustNum3 As String,
        <[Optional]> ByVal pEndCustNum3 As String,
        <[Optional]> ByVal pBeginCustNum4 As String,
        <[Optional]> ByVal pEndCustNum4 As String,
        <[Optional]> ByVal pBeginCustNum5 As String,
        <[Optional]> ByVal pEndCustNum5 As String,
        <[Optional]> ByVal pBeginCustNum6 As String,
        <[Optional]> ByVal pEndCustNum6 As String,
        <[Optional]> ByVal pBeginCustNum7 As String,
        <[Optional]> ByVal pEndCustNum7 As String,
        <[Optional]> ByVal pBeginCustNum8 As String,
        <[Optional]> ByVal pEndCustNum8 As String,
        <[Optional]> ByVal pBeginCustNum9 As String,
        <[Optional]> ByVal pEndCustNum9 As String,
        <[Optional]> ByVal pBeginCustNum10 As String,
        <[Optional]> ByVal pEndCustNum10 As String, ByVal pInCurrencyCode As String,
        <[Optional]> ByRef rInfobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEuroCustExt As IEuroCust = New EuroCustFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, rInfobar As String) = iEuroCustExt.EuroCustSp(pProcess, pBeginCustNum1, pEndCustNum1, pBeginCustNum2, pEndCustNum2, pBeginCustNum3, pEndCustNum3, pBeginCustNum4, pEndCustNum4, pBeginCustNum5, pEndCustNum5, pBeginCustNum6, pEndCustNum6, pBeginCustNum7, pEndCustNum7, pBeginCustNum8, pEndCustNum8, pBeginCustNum9, pEndCustNum9, pBeginCustNum10, pEndCustNum10, pInCurrencyCode, rInfobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            rInfobar = result.rInfobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetArParmsSp(ByVal AcctType As String, ByRef Acct As String, ByRef UnitCode1 As String, ByRef UnitCode2 As String, ByRef UnitCode3 As String, ByRef UnitCode4 As String, ByRef Infobar As String,
        <[Optional]> ByRef Description As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetArParmsExt As IGetArParms = New GetArParmsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Acct As String, UnitCode1 As String, UnitCode2 As String, UnitCode3 As String, UnitCode4 As String, Infobar As String, Description As String) = iGetArParmsExt.GetArParmsSp(AcctType, Acct, UnitCode1, UnitCode2, UnitCode3, UnitCode4, Infobar, Description)
            Dim Severity As Integer = result.ReturnCode.Value
            Acct = result.Acct
            UnitCode1 = result.UnitCode1
            UnitCode2 = result.UnitCode2
            UnitCode3 = result.UnitCode3
            UnitCode4 = result.UnitCode4
            Infobar = result.Infobar
            Description = result.Description
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_DomesticCurrencySp(ByVal CurrCode As String,
<[Optional], DefaultParameterValue(0)> ByVal UseBuyRate As Integer?,
<[Optional]> ByVal TRate As Decimal?,
<[Optional]> ByVal PossibleDate As DateTime?,
<[Optional]> ByVal Amount1 As Decimal?,
<[Optional]> ByVal Amount2 As Decimal?,
<[Optional]> ByVal Amount3 As Decimal?,
<[Optional]> ByVal Amount4 As Decimal?,
<[Optional]> ByVal Amount5 As Decimal?,
<[Optional]> ByVal Amount6 As Decimal?,
<[Optional]> ByVal Amount7 As Decimal?,
<[Optional]> ByVal Amount8 As Decimal?,
<[Optional]> ByVal Amount9 As Decimal?,
<[Optional]> ByVal Amount10 As Decimal?,
<[Optional]> ByVal Amount11 As Decimal?,
<[Optional]> ByVal Amount12 As Decimal?,
<[Optional]> ByVal Amount13 As Decimal?,
<[Optional]> ByVal Amount14 As Decimal?,
<[Optional]> ByVal Amount15 As Decimal?,
<[Optional]> ByVal Amount16 As Decimal?,
<[Optional]> ByVal Amount17 As Decimal?,
<[Optional]> ByVal Amount18 As Decimal?,
<[Optional]> ByVal Amount19 As Decimal?,
<[Optional]> ByVal Amount20 As Decimal?,
<[Optional]> ByVal Amount21 As Decimal?,
<[Optional]> ByVal Amount22 As Decimal?,
<[Optional]> ByVal Amount23 As Decimal?,
<[Optional]> ByVal Amount24 As Decimal?,
<[Optional]> ByVal Amount25 As Decimal?,
<[Optional]> ByVal Amount26 As Decimal?,
<[Optional]> ByVal Amount27 As Decimal?,
<[Optional]> ByVal Amount28 As Decimal?,
<[Optional]> ByVal Amount29 As Decimal?,
<[Optional]> ByVal Amount30 As Decimal?,
<[Optional]> ByVal Amount31 As Decimal?,
<[Optional]> ByVal Amount32 As Decimal?,
<[Optional]> ByVal Amount33 As Decimal?,
<[Optional]> ByVal Amount34 As Decimal?,
<[Optional]> ByVal Amount35 As Decimal?,
<[Optional]> ByVal Amount36 As Decimal?,
<[Optional]> ByVal Amount37 As Decimal?,
<[Optional]> ByVal Amount38 As Decimal?,
<[Optional]> ByVal Amount39 As Decimal?,
<[Optional]> ByVal Amount40 As Decimal?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iCLM_DomesticCurrencyExt As CSI.Logistics.Customer.ICLM_DomesticCurrency = New CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode, UseBuyRate, TRate, PossibleDate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Amount16, Amount17, Amount18, Amount19, Amount20, Amount21, Amount22, Amount23, Amount24, Amount25, Amount26, Amount27, Amount28, Amount29, Amount30, Amount31, Amount32, Amount33, Amount34, Amount35, Amount36, Amount37, Amount38, Amount39, Amount40)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckforFRCPSp(ByRef FRCP As Integer?) As Integer
        Dim iCheckforFRCPExt As ICheckforFRCP = New CheckforFRCPFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, FRCP As Integer?) = iCheckforFRCPExt.CheckforFRCPSp(FRCP)
        Dim Severity As Integer = result.ReturnCode.Value
        FRCP = result.FRCP
        Return Severity
    End Function
End Class

