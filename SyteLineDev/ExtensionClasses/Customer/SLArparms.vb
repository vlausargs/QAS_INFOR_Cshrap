
Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.MG
Imports CSI.Logistics.Customer
Imports CSI.Data.SQL.UDDT
Imports CSI.Finance.AR

<IDOExtensionClass("SLArparms")>
Public Class SLArparms
    Inherits ExtensionClassBase

    <IDOMethod(MethodFlags.None)>
    Public Function GetArAcctInfo(
       ByVal strAcctType As String,
       ByRef strAcct As String,
       ByRef strUnitCode1 As String,
       ByRef strUnitCode2 As String,
       ByRef strUnitCode3 As String,
       ByRef strUnitCode4 As String) As Integer

        Dim response As LoadCollectionResponseData
        Dim propertyList As String
        Dim accountProperty As String
        Dim accountUnit1Property As String
        Dim accountUnit2Property As String
        Dim accountUnit3Property As String
        Dim accountUnit4Property As String

        accountProperty = Me.MakePropertyName(strAcctType & "_acct")
        accountUnit1Property = Me.MakePropertyName(strAcctType & "_acct_unit1")
        accountUnit2Property = Me.MakePropertyName(strAcctType & "_acct_unit2")
        accountUnit3Property = Me.MakePropertyName(strAcctType & "_acct_unit3")
        accountUnit4Property = Me.MakePropertyName(strAcctType & "_acct_unit4")

        propertyList = String.Format(
           "{0}, {1}, {2}, {3}, {4}",
           accountProperty,
           accountUnit1Property,
           accountUnit2Property,
           accountUnit3Property,
           accountUnit4Property)

        response = Me.LoadCollection(propertyList, "ArparmsKey = 0", String.Empty, 1)

        If response.Items.Count = 1 Then
            strAcct = response(0, accountProperty).Value
            strUnitCode1 = response(0, accountUnit1Property).Value
            strUnitCode2 = response(0, accountUnit2Property).Value
            strUnitCode3 = response(0, accountUnit3Property).Value
            strUnitCode4 = response(0, accountUnit4Property).Value
        Else
            MGException.Throw(Me.GetMessageProvider.GetMessage("E=NoExist0", "@arparms"))
        End If
    End Function

    Private Function MakePropertyName(ByVal propertyName As String) As String

        Dim name As String = String.Empty
        Dim parts As String()

        parts = propertyName.Split(CChar("_"))

        For Each part As String In parts
            If part.Length > 0 Then
                name = name & part.Substring(0, 1).ToUpper()
                If part.Length > 1 Then name = name & part.Substring(1).ToLower()
            End If
        Next

        Return name

    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ArParmsInfoSp(ByRef ReturnedCheckFeeType As String, ByRef ReturnedCheckFeeValue As Decimal?, ByRef ReturnedCheckMethod As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iArParmsInfoExt As IArParmsInfo = New ArParmsInfoFactory().Create(appDb)
            Dim oReturnedCheckFeeType As ListAmountPercentType = ReturnedCheckFeeType
            Dim oReturnedCheckFeeValue As AmountType = ReturnedCheckFeeValue
            Dim oReturnedCheckMethod As ListDebitMemoAdjustmentType = ReturnedCheckMethod
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iArParmsInfoExt.ArParmsInfoSp(oReturnedCheckFeeType, oReturnedCheckFeeValue, oReturnedCheckMethod, oInfobar)
            ReturnedCheckFeeType = oReturnedCheckFeeType
            ReturnedCheckFeeValue = oReturnedCheckFeeValue
            ReturnedCheckMethod = oReturnedCheckMethod
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetArParmInfoSp(ByRef AllowApplyToInvNumChanges As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetArParmInfoExt As IGetArParmInfo = New GetArParmInfoFactory().Create(appDb)

            Dim oAllowApplyToInvNumChanges As ListYesNoType = AllowApplyToInvNumChanges

            Dim Severity As Integer = iGetArParmInfoExt.GetArParmInfoSp(oAllowApplyToInvNumChanges)

            AllowApplyToInvNumChanges = oAllowApplyToInvNumChanges

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetArparmSiteGroupSp(ByRef PArparmSiteGroup As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetArparmSiteGroupExt As IGetArparmSiteGroup = New GetArparmSiteGroupFactory().Create(appDb)

            Dim oPArparmSiteGroup As SiteGroupType = PArparmSiteGroup

            Dim Severity As Integer = iGetArparmSiteGroupExt.GetArparmSiteGroupSp(oPArparmSiteGroup)

            PArparmSiteGroup = oPArparmSiteGroup

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetReportTemplateParmSp(ByVal pTable As String, ByVal pColumn As String, ByRef ReportTemplateID As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetReportTemplateParmExt As IGetReportTemplateParm = New GetReportTemplateParmFactory().Create(appDb)

            Dim oReportTemplateID As ReportTemplateIdType = ReportTemplateID

            Dim Severity As Integer = iGetReportTemplateParmExt.GetReportTemplateParmSp(pTable, pColumn, oReportTemplateID)

            ReportTemplateID = oReportTemplateID

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetArparmLinesPerDocSp(ByRef PArparmUsePrePrintedForms As Integer?, ByRef PArparmLinesPerInv As Integer?, ByRef PArparmLinesPerDM As Integer?, ByRef PArparmLinesPerCM As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetArparmLinesPerDocExt As IGetArparmLinesPerDoc = New GetArparmLinesPerDocFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PArparmUsePrePrintedForms As Integer?, PArparmLinesPerInv As Integer?, PArparmLinesPerDM As Integer?, PArparmLinesPerCM As Integer?) = iGetArparmLinesPerDocExt.GetArparmLinesPerDocSp(PArparmUsePrePrintedForms, PArparmLinesPerInv, PArparmLinesPerDM, PArparmLinesPerCM)
            Dim Severity As Integer = result.ReturnCode.Value
            PArparmUsePrePrintedForms = result.PArparmUsePrePrintedForms
            PArparmLinesPerInv = result.PArparmLinesPerInv
            PArparmLinesPerDM = result.PArparmLinesPerDM
            PArparmLinesPerCM = result.PArparmLinesPerCM
            Return Severity
        End Using
    End Function
End Class
