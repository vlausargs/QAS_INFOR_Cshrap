Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.Codes
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Data.SQL.UDDT
Imports CSI.Logistics.FieldService

<IDOExtensionClass("SLCurrencyCodes")> _
Public Class SLCurrencyCodes
    Inherits ExtensionClassBase

    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)

        MyBase.SetContext(context)

        ' Add event handlers for pre and post UpdateCollection
        AddHandler Me.Context.IDO.PreUpdateCollection, AddressOf Me.PreUpdateCollection

    End Sub

    Private Sub PreUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)

        Dim updateArgs As IDOUpdateEventArgs
        Dim updateRequest As UpdateCollectionRequestData
        Dim oInvokeResponse As InvokeResponseData


        'If the action is update, call the CurrAcctSp to insert the currencycode into CurrAcct table, if it is not already present--
        'which is the base table as toolset doent handle insertions into base table

        'Cast the args parameter as an IDOUpdateEventArgs
        updateArgs = CType(args, IDOUpdateEventArgs)

        If (updateArgs.ActionMask And (UpdateAction.Insert Or UpdateAction.Update)) <> UpdateAction.None Then
            'Cast the RequestPayload arg as an UpdateCollectionRequestData
            updateRequest = CType(updateArgs.RequestPayload, UpdateCollectionRequestData)
            For Each updateItem As IDOUpdateItem In updateRequest.Items
                If (updateItem.Action = UpdateAction.Insert) Or (updateItem.Action = UpdateAction.Update) Then
                    oInvokeResponse = Me.Invoke("CurrAcctSp", updateItem.Properties("CurrCode").Value, IDONull.Value, IDONull.Value, IDONull.Value)
                    ' if a new record was created and since we are updating using optimistic locking, then
                    ' stuff the new RowPointer, RecordDate into the ItemID.  
                    If oInvokeResponse.Parameters(1).GetValue(Of Boolean)(False) And updateItem.UseOptimisticLocking Then

                        Dim itemID As UpdateItemID = UpdateItemID.Parse(updateItem.ItemID)
                        ' use the base table alias when setting the RecordDate and RowPointer values 
                        ' in the ItemID.
                        itemID.SetRecordDate("curracct", oInvokeResponse.Parameters(2).GetValue(Of Date))
                        itemID.SetRowID("curracct", oInvokeResponse.Parameters(3).GetValue(Of Guid))

                        ' replace the old ItemID in the update request
                        updateItem.ItemID = itemID.ToString()
                    End If
                End If
            Next
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EurDom3Sp(ByVal FormName As String, ByVal TUseStandard As Byte?, ByVal InAcct As String, ByVal InAcctUnit1 As String, ByVal InAcctUnit2 As String, ByVal InAcctUnit3 As String, ByVal InAcctUnit4 As String, ByVal AnaInAcct As String, ByVal AnaInAcctUnit1 As String, ByVal AnaInAcctUnit2 As String, ByVal AnaInAcctUnit3 As String, ByVal AnaInAcctUnit4 As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iEurDom3Ext As IEurDom3 = New EurDom3Factory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iEurDom3Ext.EurDom3Sp(FormName, TUseStandard, InAcct, InAcctUnit1, InAcctUnit2, InAcctUnit3, InAcctUnit4, AnaInAcct, AnaInAcctUnit1, AnaInAcctUnit2, AnaInAcctUnit3, AnaInAcctUnit4, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCurrAcctsSp(ByRef UngainAcct As String, ByRef UngainUnit1 As String, ByRef UngainUnit2 As String, ByRef UngainUnit3 As String, ByRef UngainUnit4 As String, ByRef UngainDesc As String, ByRef UnlossAcct As String, ByRef UnlossUnit1 As String, ByRef UnlossUnit2 As String, ByRef UnlossUnit3 As String, ByRef UnlossUnit4 As String, ByRef UnlossDesc As String, ByRef AroffAcct As String, ByRef AroffUnit1 As String, ByRef AroffUnit2 As String, ByRef AroffUnit3 As String, ByRef AroffUnit4 As String, ByRef AroffDesc As String, ByRef ApoffAcct As String, ByRef ApoffUnit1 As String, ByRef ApoffUnit2 As String, ByRef ApoffUnit3 As String, ByRef ApoffUnit4 As String, ByRef ApoffDesc As String, ByRef VchoffAcct As String, ByRef VchoffUnit1 As String, ByRef VchoffUnit2 As String, ByRef VchoffUnit3 As String, ByRef VchoffUnit4 As String, ByRef VchoffDesc As String, ByRef GainAcct As String, ByRef GainUnit1 As String, ByRef GainUnit2 As String, ByRef GainUnit3 As String, ByRef GainUnit4 As String, ByRef GainDesc As String, ByRef LossAcct As String, ByRef LossUnit1 As String, ByRef LossUnit2 As String, ByRef LossUnit3 As String, ByRef LossUnit4 As String, ByRef LossDesc As String, ByRef NonApAcct As String, ByRef NonApUnit1 As String, ByRef NonApUnit2 As String, ByRef NonApUnit3 As String, ByRef NonApUnit4 As String, ByRef NonApDesc As String, ByRef NonArAcct As String, ByRef NonArUnit1 As String, ByRef NonArUnit2 As String, ByRef NonArUnit3 As String, ByRef NonArUnit4 As String, ByRef NonArDesc As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetCurrAcctsExt As IGetCurrAccts = New GetCurrAcctsFactory().Create(appDb)
            Dim oUngainAcct As AcctType = UngainAcct
            Dim oUngainUnit1 As UnitCode1Type = UngainUnit1
            Dim oUngainUnit2 As UnitCode2Type = UngainUnit2
            Dim oUngainUnit3 As UnitCode3Type = UngainUnit3
            Dim oUngainUnit4 As UnitCode4Type = UngainUnit4
            Dim oUngainDesc As DescriptionType = UngainDesc
            Dim oUnlossAcct As AcctType = UnlossAcct
            Dim oUnlossUnit1 As UnitCode1Type = UnlossUnit1
            Dim oUnlossUnit2 As UnitCode2Type = UnlossUnit2
            Dim oUnlossUnit3 As UnitCode3Type = UnlossUnit3
            Dim oUnlossUnit4 As UnitCode4Type = UnlossUnit4
            Dim oUnlossDesc As DescriptionType = UnlossDesc
            Dim oAroffAcct As AcctType = AroffAcct
            Dim oAroffUnit1 As UnitCode1Type = AroffUnit1
            Dim oAroffUnit2 As UnitCode2Type = AroffUnit2
            Dim oAroffUnit3 As UnitCode3Type = AroffUnit3
            Dim oAroffUnit4 As UnitCode4Type = AroffUnit4
            Dim oAroffDesc As DescriptionType = AroffDesc
            Dim oApoffAcct As AcctType = ApoffAcct
            Dim oApoffUnit1 As UnitCode1Type = ApoffUnit1
            Dim oApoffUnit2 As UnitCode2Type = ApoffUnit2
            Dim oApoffUnit3 As UnitCode3Type = ApoffUnit3
            Dim oApoffUnit4 As UnitCode4Type = ApoffUnit4
            Dim oApoffDesc As DescriptionType = ApoffDesc
            Dim oVchoffAcct As AcctType = VchoffAcct
            Dim oVchoffUnit1 As UnitCode1Type = VchoffUnit1
            Dim oVchoffUnit2 As UnitCode2Type = VchoffUnit2
            Dim oVchoffUnit3 As UnitCode3Type = VchoffUnit3
            Dim oVchoffUnit4 As UnitCode4Type = VchoffUnit4
            Dim oVchoffDesc As DescriptionType = VchoffDesc
            Dim oGainAcct As AcctType = GainAcct
            Dim oGainUnit1 As UnitCode1Type = GainUnit1
            Dim oGainUnit2 As UnitCode2Type = GainUnit2
            Dim oGainUnit3 As UnitCode3Type = GainUnit3
            Dim oGainUnit4 As UnitCode4Type = GainUnit4
            Dim oGainDesc As DescriptionType = GainDesc
            Dim oLossAcct As AcctType = LossAcct
            Dim oLossUnit1 As UnitCode1Type = LossUnit1
            Dim oLossUnit2 As UnitCode2Type = LossUnit2
            Dim oLossUnit3 As UnitCode3Type = LossUnit3
            Dim oLossUnit4 As UnitCode4Type = LossUnit4
            Dim oLossDesc As DescriptionType = LossDesc
            Dim oNonApAcct As AcctType = NonApAcct
            Dim oNonApUnit1 As UnitCode1Type = NonApUnit1
            Dim oNonApUnit2 As UnitCode2Type = NonApUnit2
            Dim oNonApUnit3 As UnitCode3Type = NonApUnit3
            Dim oNonApUnit4 As UnitCode4Type = NonApUnit4
            Dim oNonApDesc As DescriptionType = NonApDesc
            Dim oNonArAcct As AcctType = NonArAcct
            Dim oNonArUnit1 As UnitCode1Type = NonArUnit1
            Dim oNonArUnit2 As UnitCode2Type = NonArUnit2
            Dim oNonArUnit3 As UnitCode3Type = NonArUnit3
            Dim oNonArUnit4 As UnitCode4Type = NonArUnit4
            Dim oNonArDesc As DescriptionType = NonArDesc
            Dim Severity As Integer = iGetCurrAcctsExt.GetCurrAcctsSp(oUngainAcct, oUngainUnit1, oUngainUnit2, oUngainUnit3, oUngainUnit4, oUngainDesc, oUnlossAcct, oUnlossUnit1, oUnlossUnit2, oUnlossUnit3, oUnlossUnit4, oUnlossDesc, oAroffAcct, oAroffUnit1, oAroffUnit2, oAroffUnit3, oAroffUnit4, oAroffDesc, oApoffAcct, oApoffUnit1, oApoffUnit2, oApoffUnit3, oApoffUnit4, oApoffDesc, oVchoffAcct, oVchoffUnit1, oVchoffUnit2, oVchoffUnit3, oVchoffUnit4, oVchoffDesc, oGainAcct, oGainUnit1, oGainUnit2, oGainUnit3, oGainUnit4, oGainDesc, oLossAcct, oLossUnit1, oLossUnit2, oLossUnit3, oLossUnit4, oLossDesc, oNonApAcct, oNonApUnit1, oNonApUnit2, oNonApUnit3, oNonApUnit4, oNonApDesc, oNonArAcct, oNonArUnit1, oNonArUnit2, oNonArUnit3, oNonArUnit4, oNonArDesc)
            UngainAcct = oUngainAcct
            UngainUnit1 = oUngainUnit1
            UngainUnit2 = oUngainUnit2
            UngainUnit3 = oUngainUnit3
            UngainUnit4 = oUngainUnit4
            UngainDesc = oUngainDesc
            UnlossAcct = oUnlossAcct
            UnlossUnit1 = oUnlossUnit1
            UnlossUnit2 = oUnlossUnit2
            UnlossUnit3 = oUnlossUnit3
            UnlossUnit4 = oUnlossUnit4
            UnlossDesc = oUnlossDesc
            AroffAcct = oAroffAcct
            AroffUnit1 = oAroffUnit1
            AroffUnit2 = oAroffUnit2
            AroffUnit3 = oAroffUnit3
            AroffUnit4 = oAroffUnit4
            AroffDesc = oAroffDesc
            ApoffAcct = oApoffAcct
            ApoffUnit1 = oApoffUnit1
            ApoffUnit2 = oApoffUnit2
            ApoffUnit3 = oApoffUnit3
            ApoffUnit4 = oApoffUnit4
            ApoffDesc = oApoffDesc
            VchoffAcct = oVchoffAcct
            VchoffUnit1 = oVchoffUnit1
            VchoffUnit2 = oVchoffUnit2
            VchoffUnit3 = oVchoffUnit3
            VchoffUnit4 = oVchoffUnit4
            VchoffDesc = oVchoffDesc
            GainAcct = oGainAcct
            GainUnit1 = oGainUnit1
            GainUnit2 = oGainUnit2
            GainUnit3 = oGainUnit3
            GainUnit4 = oGainUnit4
            GainDesc = oGainDesc
            LossAcct = oLossAcct
            LossUnit1 = oLossUnit1
            LossUnit2 = oLossUnit2
            LossUnit3 = oLossUnit3
            LossUnit4 = oLossUnit4
            LossDesc = oLossDesc
            NonApAcct = oNonApAcct
            NonApUnit1 = oNonApUnit1
            NonApUnit2 = oNonApUnit2
            NonApUnit3 = oNonApUnit3
            NonApUnit4 = oNonApUnit4
            NonApDesc = oNonApDesc
            NonArAcct = oNonArAcct
            NonArUnit1 = oNonArUnit1
            NonArUnit2 = oNonArUnit2
            NonArUnit3 = oNonArUnit3
            NonArUnit4 = oNonArUnit4
            NonArDesc = oNonArDesc
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrAcctSp(ByVal CurrCode As String, ByRef IsRecordCreated As Integer?, ByRef NewRecordDate As DateTime?, ByRef NewRowPointer As Guid?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCurrAcctExt As ICurrAcct = New CurrAcctFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, IsRecordCreated As Integer?, NewRecordDate As DateTime?, NewRowPointer As Guid?) = iCurrAcctExt.CurrAcctSp(CurrCode, IsRecordCreated, NewRecordDate, NewRowPointer)
            Dim Severity As Integer = result.ReturnCode.Value
            IsRecordCreated = result.IsRecordCreated
            NewRecordDate = result.NewRecordDate
            NewRowPointer = result.NewRowPointer
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CurrCnvtSingleValueSp(ByVal CurrCode As String, ByVal FromDomestic As Byte?, ByVal UseBuyRate As Byte?, ByVal RoundResult As Byte?,
<[Optional]> ByVal RateDate As DateTime?,
<[Optional]> ByVal RoundPlaces As Byte?,
<[Optional], DefaultParameterValue("currate")> ByVal BRateTable As String,
<[Optional]> ByVal ForceRate As Byte?,
<[Optional]> ByVal FindTTFixed As Byte?,
<[Optional]> ByRef TRate As Decimal?, ByRef Infobar As String, ByVal Amount As Decimal?, ByRef Res As Decimal?,
<[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCurrCnvtSingleValueExt As ICurrCnvtSingleValue = New CurrCnvtSingleValueFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TRate As Decimal?, Infobar As String, Res As Decimal?) = iCurrCnvtSingleValueExt.CurrCnvtSingleValueSp(CurrCode, FromDomestic, UseBuyRate, RoundResult, RateDate, RoundPlaces, BRateTable, ForceRate, FindTTFixed, TRate, Infobar, Amount, Res, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            TRate = result.TRate
            Infobar = result.Infobar
            Res = result.Res
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCurrDecimalPlacesSp(ByVal CurrCode As String, ByRef DecimalPlaces As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetCurrDecimalPlacesExt As IGetCurrDecimalPlaces = New GetCurrDecimalPlacesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DecimalPlaces As Integer?, Infobar As String) = iGetCurrDecimalPlacesExt.GetCurrDecimalPlacesSp(CurrCode, DecimalPlaces, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            DecimalPlaces = result.DecimalPlaces
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function JournalCalcExchRateSp(ByVal PCurrCode As String, ByVal PForAmt As Decimal?, ByVal PDomAmt As Decimal?, ByRef PRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iJournalCalcExchRateExt As IJournalCalcExchRate = New JournalCalcExchRateFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PRate As Decimal?, Infobar As String) = iJournalCalcExchRateExt.JournalCalcExchRateSp(PCurrCode, PForAmt, PDomAmt, PRate, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PRate = result.PRate
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
