Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Xml
Imports CSI.MG
Imports CSI.Finance.ExtFin

<IDOExtensionClass("SLExtfinParms")>
Public Class SLExtfinParms
    Inherits CSIExtensionClassBase

    Private Const DateFormat As String = "yyyy-MM-dd"

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinExportAR(ByVal BatchId As Long)
        Dim oExtfinParms As LoadCollectionResponseData
        Dim FilterExtfinParms As String
        Dim PropertyListExtfinParms As String
        Dim oCollection1 As LoadCollectionResponseData
        Dim Filter1 As String
        Dim PropertyList1 As String
        Dim oCollection2 As LoadCollectionResponseData
        Dim Filter2 As String
        Dim PropertyList2 As String

        Dim oCollectionExpArtd As LoadCollectionResponseData
        Dim FilterExpArtd As String
        Dim PropertyListExpArtd As String

        Dim UpdateRequest As UpdateCollectionRequestData
        Dim UpdateChildRequest As UpdateCollectionRequestData
        Dim UpdateItem As IDOUpdateItem
        Dim ObjUpdateRequest As UpdateCollectionRequestData = Nothing
        Dim oSLSites As InvokeResponseData
        Dim Infobar As String = ""
        Dim ObjUpdateItem As IDOUpdateItem
        Dim iCounter2 As Integer

        Dim MaxBatchSize As Integer
        Dim NumRecords As Integer
        Dim NumXmldocs As Integer

        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim XMLDocument As String

        Dim oPerGet As InvokeResponseData
        Dim iPeriod As Integer = 0
        Dim iFiscalYear As Integer = 0

        Dim n As Integer
        Dim iTempCounter As Integer = 0
        Dim iCounter As Integer = 0

        DocumentName = "ExtFinARInvoicePosting"

        FilterExtfinParms = ""
        PropertyListExtfinParms = "ArMaximumBatchSize, Site"

        oExtfinParms = Me.LoadCollection(PropertyListExtfinParms, FilterExtfinParms, "", 0)
        If oExtfinParms.Items.Count > 0 Then
            MaxBatchSize = oExtfinParms(0, "ArMaximumBatchSize").GetValue(Of Integer)(0)
            ToSite = oExtfinParms(0, "Site").Value
        End If

        Filter1 = String.Format("ArBatchId = {0}", SqlLiteral.Format(BatchId))
        PropertyList1 = "CustNum, InvNum, InvSeq, Type, CoNum, InvDate, DueDate, Acct, "
        PropertyList1 = PropertyList1 & "Amount, MiscCharges, SalesTax, Freight, Ref, "
        PropertyList1 = PropertyList1 & "TermsCode, Description, PostFromCo, ExchRate, "
        PropertyList1 = PropertyList1 & "SalesTax_2, UseExchRate, TaxCode1, TaxCode2, "
        PropertyList1 = PropertyList1 & "AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, "
        PropertyList1 = PropertyList1 & "FixedRate, Rma, PayType, DraftPrintFlag, "
        PropertyList1 = PropertyList1 & "DoNum, Processed, AdrCurrCode, ApprovalStatus, ApplyToInvNum, ReturnedCheck"

        oCollection1 = Me.Context.Commands.LoadCollection("SLExportArInvs", PropertyList1, Filter1, "", 0)

        NumRecords = oCollection1.Items.Count

        If MaxBatchSize = 0 Then MaxBatchSize = NumRecords

        If (NumRecords Mod MaxBatchSize) = 0 Then
            NumXmldocs = (NumRecords \ MaxBatchSize)
        Else
            NumXmldocs = (NumRecords \ MaxBatchSize) + 1
        End If

        For n = 1 To NumXmldocs Step 1
            UpdateRequest = New UpdateCollectionRequestData With {
                .IDOName = "EXTFIN.ExtFinARInvoicePosting.export_arinv",
                .RefreshAfterUpdate = True
            }
            Dim iRecCount As Integer
            For iRecCount = 1 To MaxBatchSize Step 1
                If iCounter = oCollection1.Items.Count Then
                    Exit For
                End If

                UpdateItem = New IDOUpdateItem With {
                    .Action = UpdateAction.Insert,
                    .ItemNumber = iCounter
                }

                UpdateItem.Properties.Add("ar_batch_id", BatchId)
                UpdateItem.Properties.Add("batch_seq", n)
                UpdateItem.Properties.Add("cust_num", oCollection1(iCounter, "CustNum").Value)
                UpdateItem.Properties.Add("inv_num", oCollection1(iCounter, "InvNum").Value)
                UpdateItem.Properties.Add("inv_seq", oCollection1(iCounter, "InvSeq").Value)
                UpdateItem.Properties.Add("type", oCollection1(iCounter, "Type").Value)
                UpdateItem.Properties.Add("co_num", oCollection1(iCounter, "CoNum").Value)
                If Not String.IsNullOrEmpty(oCollection1(iCounter, "InvDate").Value) Then
                    UpdateItem.Properties.Add("inv_date", Format(oCollection1(iCounter, "InvDate").GetValue(Of Date), DateFormat))
                Else
                    UpdateItem.Properties.Add("inv_date", "")
                End If
                If Not String.IsNullOrEmpty(oCollection1(iCounter, "DueDate").Value) Then
                    UpdateItem.Properties.Add("due_date", Format(oCollection1(iCounter, "DueDate").GetValue(Of Date), DateFormat))
                Else
                    UpdateItem.Properties.Add("due_date", "")
                End If
                UpdateItem.Properties.Add("acct", oCollection1(iCounter, "Acct").Value)
                UpdateItem.Properties.Add("amount", oCollection1(iCounter, "Amount").Value)
                UpdateItem.Properties.Add("misc_charges", oCollection1(iCounter, "MiscCharges").Value)
                UpdateItem.Properties.Add("sales_tax", oCollection1(iCounter, "SalesTax").Value)
                UpdateItem.Properties.Add("freight", oCollection1(iCounter, "Freight").Value)
                UpdateItem.Properties.Add("ref", oCollection1(iCounter, "Ref").Value)
                UpdateItem.Properties.Add("terms_code", oCollection1(iCounter, "TermsCode").Value)
                UpdateItem.Properties.Add("description", oCollection1(iCounter, "Description").Value)
                UpdateItem.Properties.Add("post_from_co", oCollection1(iCounter, "PostFromCo").Value)
                UpdateItem.Properties.Add("exch_rate", oCollection1(iCounter, "ExchRate").Value)
                UpdateItem.Properties.Add("sales_tax_2", oCollection1(iCounter, "SalesTax_2").Value)
                UpdateItem.Properties.Add("use_exch_rate", oCollection1(iCounter, "UseExchRate").Value)
                UpdateItem.Properties.Add("tax_code1", oCollection1(iCounter, "TaxCode1").Value)
                UpdateItem.Properties.Add("tax_code2", oCollection1(iCounter, "TaxCode2").Value)
                UpdateItem.Properties.Add("acct_unit1", oCollection1(iCounter, "AcctUnit1").Value)
                UpdateItem.Properties.Add("acct_unit2", oCollection1(iCounter, "AcctUnit2").Value)
                UpdateItem.Properties.Add("acct_unit3", oCollection1(iCounter, "AcctUnit3").Value)
                UpdateItem.Properties.Add("acct_unit4", oCollection1(iCounter, "AcctUnit4").Value)
                UpdateItem.Properties.Add("fixed_rate", oCollection1(iCounter, "FixedRate").Value)
                UpdateItem.Properties.Add("rma", oCollection1(iCounter, "Rma").Value)
                UpdateItem.Properties.Add("pay_type", oCollection1(iCounter, "PayType").Value)
                UpdateItem.Properties.Add("draft_print_flag", oCollection1(iCounter, "DraftPrintFlag").Value)
                UpdateItem.Properties.Add("do_num", oCollection1(iCounter, "DoNum").Value)
                UpdateItem.Properties.Add("processed", oCollection1(iCounter, "Processed").Value)
                UpdateItem.Properties.Add("curr_code", oCollection1(iCounter, "AdrCurrCode").Value)
                UpdateItem.Properties.Add("approval_status", oCollection1(iCounter, "ApprovalStatus").Value)
                UpdateItem.Properties.Add("apply_to_inv_num", oCollection1(iCounter, "ApplyToInvNum").Value)
                UpdateItem.Properties.Add("returned_check", oCollection1(iCounter, "ReturnedCheck").Value)

                oPerGet = Me.Context.Commands.Invoke("SLExtPRInterfaces", "PerGetSp", oCollection1(iCounter, "InvDate").Value, iPeriod, DBNull.Value, Infobar, DBNull.Value, iFiscalYear)
                iPeriod = CInt(oPerGet.Parameters(1).Value)
                iFiscalYear = CInt(oPerGet.Parameters(5).Value)
                oPerGet = Nothing

                UpdateItem.Properties.Add("cur_per", iPeriod)
                UpdateItem.Properties.Add("fiscal_year", iFiscalYear)

                UpdateRequest.Items.Add(UpdateItem)

                FilterExpArtd = "ArBatchId = " & BatchId
                FilterExpArtd = FilterExpArtd & " AND CustNum = '" & oCollection1(iCounter, "CustNum").Value
                FilterExpArtd = FilterExpArtd & "' AND InvNum = '" & oCollection1(iCounter, "InvNum").Value
                FilterExpArtd = FilterExpArtd & "' AND InvSeq = " & oCollection1(iCounter, "InvSeq").Value

                PropertyListExpArtd = "ArBatchId, BatchSeq, CustNum, InvNum, InvSeq, "
                PropertyListExpArtd = PropertyListExpArtd & "Seq, DueDate, TermsPercent, Amount"

                oCollectionExpArtd = Me.Context.Commands.LoadCollection("SLExportArTermsDues", PropertyListExpArtd, FilterExpArtd, "", 0)

                UpdateChildRequest = New UpdateCollectionRequestData With {
                    .IDOName = "EXTFIN.ExtFinARInvoicePosting.export_ar_terms_due",
                    .RefreshAfterUpdate = True
                }
                UpdateChildRequest.SetLinkBy("cust_num", "cust_num", "inv_num", "inv_num", "inv_seq", "inv_seq")

                iTempCounter = 0
                For i As Integer = 0 To oCollectionExpArtd.Items.Count - 1
                    UpdateItem = New IDOUpdateItem With {
                        .Action = UpdateAction.Insert,
                        .ItemNumber = iTempCounter
                    }

                    UpdateItem.Properties.Add("ar_batch_id", BatchId)
                    UpdateItem.Properties.Add("batch_seq", n)
                    UpdateItem.Properties.Add("cust_num", oCollectionExpArtd(i, "CustNum").Value)
                    UpdateItem.Properties.Add("inv_num", oCollectionExpArtd(i, "InvNum").Value)
                    UpdateItem.Properties.Add("inv_seq", oCollectionExpArtd(i, "InvSeq").Value)
                    UpdateItem.Properties.Add("seq", oCollectionExpArtd(i, "Seq").Value)
                    If Not String.IsNullOrEmpty(oCollectionExpArtd(i, "DueDate").Value) Then
                        UpdateItem.Properties.Add("due_date", Format(oCollectionExpArtd(i, "DueDate").GetValue(Of Date), DateFormat))
                    Else
                        UpdateItem.Properties.Add("due_date", "")
                    End If
                    UpdateItem.Properties.Add("percent", oCollectionExpArtd(i, "TermsPercent").Value)
                    UpdateItem.Properties.Add("amount", oCollectionExpArtd(i, "Amount").Value)
                    UpdateChildRequest.Items.Add(UpdateItem)
                    iTempCounter = iTempCounter + 1
                Next
                UpdateRequest.Items(iRecCount - 1).AddNestedUpdate(UpdateChildRequest)

                Filter2 = "ArBatchId = " & BatchId
                Filter2 = Filter2 & " AND CustNum = '" & oCollection1(iCounter, "CustNum").Value
                Filter2 = Filter2 & "' AND InvNum = '" & oCollection1(iCounter, "InvNum").Value
                Filter2 = Filter2 & "' AND InvSeq = " & oCollection1(iCounter, "InvSeq").Value


                PropertyList2 = "CustNum, InvNum, InvSeq, DistSeq, Acct, Amount, TaxCode, "
                PropertyList2 = PropertyList2 & "TaxBasis, TaxSystem, TaxCodeE, RefType, "
                PropertyList2 = PropertyList2 & "RefNum, RefLineSuf, RefRelease, "
                PropertyList2 = PropertyList2 & "AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4"

                oCollection2 = Me.Context.Commands.LoadCollection("SLExportArInvds", PropertyList2, Filter2, "", 0)


                UpdateChildRequest = New UpdateCollectionRequestData With {
                    .IDOName = "EXTFIN.ExtFinARInvoicePosting.export_arinvd",
                    .RefreshAfterUpdate = True
                }
                UpdateChildRequest.SetLinkBy("cust_num", "cust_num", "inv_num", "inv_num", "inv_seq", "inv_seq")
                iTempCounter = 0
                For i As Integer = 0 To oCollection2.Items.Count - 1
                    UpdateItem = New IDOUpdateItem With {
                        .Action = UpdateAction.Insert,
                        .ItemNumber = iTempCounter
                    }

                    UpdateItem.Properties.Add("ar_batch_id", BatchId)
                    UpdateItem.Properties.Add("batch_seq", n)
                    UpdateItem.Properties.Add("cust_num", oCollection2(i, "CustNum").Value)
                    UpdateItem.Properties.Add("inv_num", oCollection2(i, "InvNum").Value)
                    UpdateItem.Properties.Add("inv_seq", oCollection2(i, "InvSeq").Value)
                    UpdateItem.Properties.Add("dist_seq", oCollection2(i, "DistSeq").Value)
                    UpdateItem.Properties.Add("acct", oCollection2(i, "Acct").Value)
                    UpdateItem.Properties.Add("amount", oCollection2(i, "Amount").Value)
                    UpdateItem.Properties.Add("tax_code", oCollection2(i, "TaxCode").Value)
                    UpdateItem.Properties.Add("tax_basis", oCollection2(i, "TaxBasis").Value)
                    UpdateItem.Properties.Add("tax_system", oCollection2(i, "TaxSystem").Value)
                    UpdateItem.Properties.Add("tax_code_e", oCollection2(i, "TaxCodeE").Value)
                    UpdateItem.Properties.Add("ref_type", oCollection2(i, "RefType").Value)
                    UpdateItem.Properties.Add("ref_num", oCollection2(i, "RefNum").Value)
                    UpdateItem.Properties.Add("ref_line_suf", oCollection2(i, "RefLineSuf").Value)
                    UpdateItem.Properties.Add("ref_release", oCollection2(i, "RefRelease").Value)
                    UpdateItem.Properties.Add("acct_unit1", oCollection2(i, "AcctUnit1").Value)
                    UpdateItem.Properties.Add("acct_unit2", oCollection2(i, "AcctUnit2").Value)
                    UpdateItem.Properties.Add("acct_unit3", oCollection2(i, "AcctUnit3").Value)
                    UpdateItem.Properties.Add("acct_unit4", oCollection2(i, "AcctUnit4").Value)

                    UpdateChildRequest.Items.Add(UpdateItem)
                    iTempCounter = iTempCounter + 1
                Next
                UpdateRequest.Items(iRecCount - 1).AddNestedUpdate(UpdateChildRequest)
                iCounter = iCounter + 1
            Next

            ' Assign the XmlDocument to a String Variable

            Dim requestEnvelope As New IDORequestEnvelope
            requestEnvelope.Requests.Add(RequestType.UpdateCollection, UpdateRequest)
            XMLDocument = requestEnvelope.ToXml

            Try
                oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, Infobar)
            Catch exARXML As Exception
                Throw New MGException("Invoking AR XML: " & MGException.ExtractMessages(exARXML))
            End Try

            If Not oSLSites.IsReturnValueStdError Then
                ' Set processed = 1 for all ledger record just processed
                iCounter2 = iCounter - 1
                ObjUpdateRequest = New UpdateCollectionRequestData With {
                    .IDOName = "SLExportArInvs"
                }

                Try
                    For j As Integer = 1 To iRecCount - 1 Step 1

                        ObjUpdateItem = New IDOUpdateItem With {
                            .ItemID = oCollection1.Items(iCounter2).ItemID,
                            .Action = UpdateAction.Update
                        }
                        ObjUpdateItem.Properties.Add("Processed", "1")
                        ObjUpdateRequest.Items.Add(ObjUpdateItem)

                        iCounter2 = iCounter2 - 1

                    Next j
                    Me.Context.Commands.UpdateCollection(ObjUpdateRequest)
                Catch exARUpdate As Exception
                    Throw New MGException("Updating AR: " & MGException.ExtractMessages(exARUpdate))
                End Try
            Else
                MGException.Throw(oSLSites.Parameters(4).GetValue(Of String))
            End If
        Next n

    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinExportAP(ByVal BatchId As Long)
        Dim oExtfinParms As LoadCollectionResponseData
        Dim FilterExtfinParms As String
        Dim PropertyListExtfinParms As String
        Dim oCollection1 As LoadCollectionResponseData
        Dim Filter1 As String
        Dim PropertyList1 As String
        Dim oCollection2 As LoadCollectionResponseData
        Dim Filter2 As String
        Dim PropertyList2 As String

        Dim UpdateRequest As UpdateCollectionRequestData
        Dim UpdateChildRequest As UpdateCollectionRequestData
        Dim UpdateItem As IDOUpdateItem
        Dim ObjUpdateRequest As UpdateCollectionRequestData = Nothing
        Dim oSLSites As InvokeResponseData
        Dim Infobar As String = ""
        Dim ObjUpdateItem As IDOUpdateItem

        Dim iCounter2 As Integer
        Dim iCounter As Integer = 0
        Dim n As Integer
        Dim iTempCounter As Integer = 0

        Dim MaxBatchSize As Integer
        Dim NumRecords As Integer
        Dim NumXmldocs As Integer

        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String

        Dim oPerGet As InvokeResponseData
        Dim iPeriod As Integer = 0
        Dim iFiscalYear As Integer = 0

        DocumentName = "ExtFinAPVoucherPosting"
        FilterExtfinParms = ""
        PropertyListExtfinParms = "ApMaximumBatchSize, Site"

        oExtfinParms = Me.LoadCollection(PropertyListExtfinParms, FilterExtfinParms, "", 0)
        If oExtfinParms.Items.Count > 0 Then
            MaxBatchSize = oExtfinParms(0, "ApMaximumBatchSize").GetValue(Of Integer)(0)
            ToSite = oExtfinParms(0, "Site").Value
        End If

        Filter1 = String.Format("ApBatchId = {0}", SqlLiteral.Format(BatchId))
        PropertyList1 = "VendNum, Voucher, Type, DistDate, PoNum, InvNum, InvDate, InvAmt, "
        PropertyList1 = PropertyList1 & "NonDiscAmt, DueDays, DueDate, DiscDays, DiscDate, "
        PropertyList1 = PropertyList1 & "DiscPct, DiscAmt, ApAcct, Ref, PostFromPo, Txt, "
        PropertyList1 = PropertyList1 & "ProxDay, ExchRate, IncludesTax, PurchAmt, "
        PropertyList1 = PropertyList1 & "MiscCharges, SalesTax, SalesTax_2, Freight, DutyAmt, "
        PropertyList1 = PropertyList1 & "BrokerageAmt, TaxCode1, TaxCode2, ApAcctUnit1, "
        PropertyList1 = PropertyList1 & "ApAcctUnit2, ApAcctUnit3, ApAcctUnit4, AuthStatus, "
        PropertyList1 = PropertyList1 & "FixedRate, ProxCode, GrnNum, Processed, VendCurrCode, "
        PropertyList1 = PropertyList1 & "PreRegister, Authorizer,InsuranceAmt,LocFrtAmt, "
        PropertyList1 = PropertyList1 & "BuilderPoOrigSite, BuilderPoNum,BuilderVoucherOrigSite,BuilderVoucher,AutoVouchered "

        oCollection1 = Me.Context.Commands.LoadCollection("SLExportApTrxs", PropertyList1, Filter1, "", 0)

        NumRecords = oCollection1.Items.Count

        If MaxBatchSize = 0 Then MaxBatchSize = NumRecords

        If (NumRecords Mod MaxBatchSize) = 0 Then
            NumXmldocs = (NumRecords \ MaxBatchSize)
        Else
            NumXmldocs = (NumRecords \ MaxBatchSize) + 1
        End If

        For n = 1 To NumXmldocs Step 1
            UpdateRequest = New UpdateCollectionRequestData With {
                .IDOName = "EXTFIN.ExtFinAPVoucherPosting.export_aptrx",
                .RefreshAfterUpdate = True
            }
            Dim iRecCount As Integer
            For iRecCount = 1 To MaxBatchSize Step 1
                If iCounter = oCollection1.Items.Count Then
                    Exit For
                End If

                UpdateItem = New IDOUpdateItem With {
                    .Action = UpdateAction.Insert,
                    .ItemNumber = iCounter
                }

                UpdateItem.Properties.Add("ap_batch_id", BatchId)
                UpdateItem.Properties.Add("batch_seq", n)
                UpdateItem.Properties.Add("vend_num", oCollection1(iCounter, "VendNum").Value)
                UpdateItem.Properties.Add("voucher", oCollection1(iCounter, "Voucher").Value)
                UpdateItem.Properties.Add("type", oCollection1(iCounter, "Type").Value)
                If Not String.IsNullOrEmpty(oCollection1(iCounter, "DistDate").Value) Then
                    UpdateItem.Properties.Add("dist_date", Format(oCollection1(iCounter, "DistDate").GetValue(Of Date), DateFormat))
                Else
                    UpdateItem.Properties.Add("dist_date", "")
                End If
                UpdateItem.Properties.Add("po_num", oCollection1(iCounter, "PoNum").Value)
                UpdateItem.Properties.Add("inv_num", oCollection1(iCounter, "InvNum").Value)
                If Not String.IsNullOrEmpty(oCollection1(iCounter, "InvDate").Value) Then
                    UpdateItem.Properties.Add("inv_date", Format(oCollection1(iCounter, "InvDate").GetValue(Of Date), DateFormat))
                Else
                    UpdateItem.Properties.Add("inv_date", "")
                End If
                UpdateItem.Properties.Add("inv_amt", oCollection1(iCounter, "InvAmt").Value)
                UpdateItem.Properties.Add("non_disc_amt", oCollection1(iCounter, "NonDiscAmt").Value)
                UpdateItem.Properties.Add("due_days", oCollection1(iCounter, "DueDays").Value)
                If Not String.IsNullOrEmpty(oCollection1(iCounter, "DueDate").Value) Then
                    UpdateItem.Properties.Add("due_date", Format(oCollection1(iCounter, "DueDate").GetValue(Of Date), DateFormat))
                Else
                    UpdateItem.Properties.Add("due_date", "")
                End If
                UpdateItem.Properties.Add("disc_days", oCollection1(iCounter, "DiscDays").Value)
                If Not String.IsNullOrEmpty(oCollection1(iCounter, "DiscDate").Value) Then
                    UpdateItem.Properties.Add("disc_date", Format(oCollection1(iCounter, "DiscDate").GetValue(Of Date), DateFormat))
                Else
                    UpdateItem.Properties.Add("disc_date", "")
                End If

                UpdateItem.Properties.Add("disc_pct", oCollection1(iCounter, "DiscPct").Value)
                UpdateItem.Properties.Add("disc_amt", oCollection1(iCounter, "DiscAmt").Value)
                UpdateItem.Properties.Add("ap_acct", oCollection1(iCounter, "ApAcct").Value)
                UpdateItem.Properties.Add("ref", oCollection1(iCounter, "Ref").Value)
                UpdateItem.Properties.Add("post_from_po", oCollection1(iCounter, "PostFromPo").Value)
                UpdateItem.Properties.Add("txt", oCollection1(iCounter, "Txt").Value)
                UpdateItem.Properties.Add("prox_day", oCollection1(iCounter, "ProxDay").Value)
                UpdateItem.Properties.Add("exch_rate", oCollection1(iCounter, "ExchRate").Value)
                UpdateItem.Properties.Add("includes_tax", oCollection1(iCounter, "IncludesTax").Value)
                UpdateItem.Properties.Add("purch_amt", oCollection1(iCounter, "PurchAmt").Value)
                UpdateItem.Properties.Add("misc_charges", oCollection1(iCounter, "MiscCharges").Value)
                UpdateItem.Properties.Add("sales_tax", oCollection1(iCounter, "SalesTax").Value)
                UpdateItem.Properties.Add("sales_tax_2", oCollection1(iCounter, "SalesTax_2").Value)
                UpdateItem.Properties.Add("freight", oCollection1(iCounter, "Freight").Value)
                UpdateItem.Properties.Add("duty_amt", oCollection1(iCounter, "DutyAmt").Value)
                UpdateItem.Properties.Add("brokerage_amt", oCollection1(iCounter, "BrokerageAmt").Value)
                UpdateItem.Properties.Add("tax_code1", oCollection1(iCounter, "TaxCode1").Value)
                UpdateItem.Properties.Add("tax_code2", oCollection1(iCounter, "TaxCode2").Value)
                UpdateItem.Properties.Add("ap_acct_unit1", oCollection1(iCounter, "ApAcctUnit1").Value)
                UpdateItem.Properties.Add("ap_acct_unit2", oCollection1(iCounter, "ApAcctUnit2").Value)
                UpdateItem.Properties.Add("ap_acct_unit3", oCollection1(iCounter, "ApAcctUnit3").Value)
                UpdateItem.Properties.Add("ap_acct_unit4", oCollection1(iCounter, "ApAcctUnit4").Value)
                UpdateItem.Properties.Add("auth_status", oCollection1(iCounter, "AuthStatus").Value)
                UpdateItem.Properties.Add("fixed_rate", oCollection1(iCounter, "FixedRate").Value)
                UpdateItem.Properties.Add("prox_code", oCollection1(iCounter, "ProxCode").Value)
                UpdateItem.Properties.Add("grn_num", oCollection1(iCounter, "GrnNum").Value)
                UpdateItem.Properties.Add("processed", oCollection1(iCounter, "Processed").Value)
                UpdateItem.Properties.Add("curr_code", oCollection1(iCounter, "VendCurrCode").Value)
                UpdateItem.Properties.Add("pre_register", oCollection1(iCounter, "PreRegister").Value)
                UpdateItem.Properties.Add("authorizer", oCollection1(iCounter, "Authorizer").Value)
                UpdateItem.Properties.Add("pre_register", oCollection1(iCounter, "PreRegister").Value)
                UpdateItem.Properties.Add("insurance_amt", oCollection1(iCounter, "InsuranceAmt").Value)
                UpdateItem.Properties.Add("loc_frt_amt", oCollection1(iCounter, "LocFrtAmt").Value)

                oPerGet = Me.Context.Commands.Invoke("SLExtPRInterfaces", "PerGetSp", oCollection1(iCounter, "DistDate").Value, iPeriod, DBNull.Value, Infobar, DBNull.Value, iFiscalYear)
                If oPerGet.IsReturnValueStdError Then
                    MGException.Throw(oPerGet.Parameters(3).GetValue(Of String))
                End If
                iPeriod = CInt(oPerGet.Parameters(1).Value)
                iFiscalYear = CInt(oPerGet.Parameters(5).Value)
                oPerGet = Nothing

                UpdateItem.Properties.Add("cur_per", iPeriod)
                UpdateItem.Properties.Add("fiscal_year", iFiscalYear)

                UpdateItem.Properties.Add("builder_po_orig_site", oCollection1(iCounter, "BuilderPoOrigSite").Value)
                UpdateItem.Properties.Add("builder_po_num", oCollection1(iCounter, "BuilderPoNum").Value)
                UpdateItem.Properties.Add("builder_voucher_orig_site", oCollection1(iCounter, "BuilderVoucherOrigSite").Value)
                UpdateItem.Properties.Add("builder_voucher", oCollection1(iCounter, "BuilderVoucher").Value)
                UpdateItem.Properties.Add("auto_vouchered", oCollection1(iCounter, "AutoVouchered").Value)

                UpdateRequest.Items.Add(UpdateItem)

                Filter2 = String.Format("ApBatchId = {0}", SqlLiteral.Format(BatchId))
                Filter2 = Filter2 & " AND VendNum = '" & oCollection1(iCounter, "VendNum").Value
                Filter2 = Filter2 & "' AND Voucher = " & oCollection1(iCounter, "Voucher").Value

                PropertyList2 = "VendNum, Voucher, DistSeq, Acct, Amount, InvNum, TaxCode, "
                PropertyList2 = PropertyList2 & "TaxBasis, TaxSystem, TaxCodeE, "
                PropertyList2 = PropertyList2 & "AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, "
                PropertyList2 = PropertyList2 & "ProjNum, TaskNum, CostCode"

                oCollection2 = Me.Context.Commands.LoadCollection("SLExportApTrxds", PropertyList2, Filter2, "", 0)

                UpdateChildRequest = New UpdateCollectionRequestData With {
                    .IDOName = "EXTFIN.ExtFinAPVoucherPosting.export_aptrxd",
                    .RefreshAfterUpdate = True
                }
                UpdateChildRequest.SetLinkBy("vend_num", "vend_num", "voucher", "voucher")
                iTempCounter = 0
                For i As Integer = 0 To oCollection2.Items.Count - 1
                    UpdateItem = New IDOUpdateItem With {
                        .Action = UpdateAction.Insert,
                        .ItemNumber = iTempCounter
                    }

                    UpdateItem.Properties.Add("ap_batch_id", BatchId)
                    UpdateItem.Properties.Add("batch_seq", n)
                    UpdateItem.Properties.Add("vend_num", oCollection2(i, "VendNum").Value)
                    UpdateItem.Properties.Add("voucher", oCollection2(i, "Voucher").Value)
                    UpdateItem.Properties.Add("dist_seq", oCollection2(i, "DistSeq").Value)
                    UpdateItem.Properties.Add("acct", oCollection2(i, "Acct").Value)
                    UpdateItem.Properties.Add("amount", oCollection2(i, "Amount").Value)
                    UpdateItem.Properties.Add("tax_code", oCollection2(i, "TaxCode").Value)
                    UpdateItem.Properties.Add("tax_basis", oCollection2(i, "TaxBasis").Value)
                    UpdateItem.Properties.Add("tax_system", oCollection2(i, "TaxSystem").Value)
                    UpdateItem.Properties.Add("tax_code_e", oCollection2(i, "TaxCodeE").Value)
                    UpdateItem.Properties.Add("acct_unit1", oCollection2(i, "AcctUnit1").Value)
                    UpdateItem.Properties.Add("acct_unit2", oCollection2(i, "AcctUnit2").Value)
                    UpdateItem.Properties.Add("acct_unit3", oCollection2(i, "AcctUnit3").Value)
                    UpdateItem.Properties.Add("acct_unit4", oCollection2(i, "AcctUnit4").Value)
                    UpdateItem.Properties.Add("proj_num", oCollection2(i, "ProjNum").Value)
                    UpdateItem.Properties.Add("task_num", oCollection2(i, "TaskNum").Value)
                    UpdateItem.Properties.Add("cost_code", oCollection2(i, "CostCode").Value)
                    UpdateChildRequest.Items.Add(UpdateItem)
                    iTempCounter = iTempCounter + 1
                Next
                UpdateRequest.Items(iRecCount - 1).AddNestedUpdate(UpdateChildRequest)
                iCounter = iCounter + 1
            Next

            Dim requestEnvelope As New IDORequestEnvelope()
            requestEnvelope.Requests.Add(RequestType.UpdateCollection, UpdateRequest)

            Try
                oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, Infobar)
            Catch exAPXML As Exception
                Throw New MGException("Invoking AP XML: " & MGException.ExtractMessages(exAPXML))
            End Try

            If Not oSLSites.IsReturnValueStdError Then
                ' Set processed = 1 for all ledger record just processed
                ObjUpdateRequest = New UpdateCollectionRequestData With {
                    .IDOName = "SLExportApTrxs"
                }
                iCounter2 = iCounter - 1

                Try
                    For j As Integer = 1 To iRecCount - 1 Step 1

                        ObjUpdateItem = New IDOUpdateItem With {
                            .ItemID = oCollection1.Items(iCounter2).ItemID,
                            .Action = UpdateAction.Update
                        }
                        ObjUpdateItem.Properties.Add("Processed", "1")
                        ObjUpdateRequest.Items.Add(ObjUpdateItem)

                        iCounter2 = iCounter2 - 1

                    Next j
                    Me.Context.Commands.UpdateCollection(ObjUpdateRequest)
                Catch exAPUpdate As Exception
                    Throw New MGException("Updating AP: " & MGException.ExtractMessages(exAPUpdate))
                End Try
            Else
                MGException.Throw(oSLSites.Parameters(4).GetValue(Of String))
            End If

        Next n
        Exit Sub
    End Sub

    Private Sub ExtFinExportLedgerBase(ByVal BatchId As Long, ByVal bIsAnaLedger As Boolean, ByVal bDebug As Boolean)

        Dim oExtfinParms As LoadCollectionResponseData
        Dim FilterExtfinParms As String
        Dim PropertyListExtfinParms As String
        Dim oControl As LoadCollectionResponseData
        Dim oLedger As LoadCollectionResponseData
        Dim FilterLedger As String
        Dim PropertyListLedger As String

        Dim objUpdateRequest As UpdateCollectionRequestData = Nothing
        Dim oSLSites As InvokeResponseData
        Dim Infobar As String = ""
        Dim ObjUpdateItem As IDOUpdateItem

        Dim loadRequest As LoadCollectionRequestData
        Dim ControlPrefix As String = ""
        Dim ControlSite As String = ""
        Dim ControlYear As String = ""
        Dim ControlPeriod As String = ""
        Dim ControlNumber As String = ""

        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim XMLDocument As String

        Dim oPerGet As InvokeResponseData
        Dim iPeriod As Integer = 0
        Dim iFiscalYear As Integer = 0

        Dim n As Integer = 1
        Dim i As Integer = 0
        Dim RecordCount As Integer = 0

        Dim iCounter As Integer

        If bIsAnaLedger = True Then
            DocumentName = "ExtFinAnaLedgerPosting"
        Else
            DocumentName = "ExtFinLedgerPosting"
        End If
        FilterExtfinParms = ""
        PropertyListExtfinParms = "Site"

        oExtfinParms = Me.LoadCollection(PropertyListExtfinParms, FilterExtfinParms, "", 0)
        If oExtfinParms.Items.Count > 0 Then
            ToSite = oExtfinParms(0, "Site").Value
        End If

        loadRequest = New LoadCollectionRequestData With {
            .IDOName = CStr(IIf(bIsAnaLedger, "SL.SLAnaLedgers", "SLLedgers"))
        }
        loadRequest.PropertyList.SetProperties("ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber")
        loadRequest.Distinct = True
        loadRequest.Filter = String.Format("JournalBatchId = {0}", SqlLiteral.Format(BatchId))
        loadRequest.RecordCap = 0
        oControl = Me.Context.Commands.LoadCollection(loadRequest)

        For iCounter = 0 To oControl.Items.Count - 1
            Dim updateRequest As New UpdateCollectionRequestData()
            Dim updateItem As IDOUpdateItem
            If bIsAnaLedger = True Then
                updateRequest.IDOName = "EXTFIN.ExtFinLedgerPosting.ana_ledger"
            Else
                updateRequest.IDOName = "EXTFIN.ExtFinLedgerPosting.ledger"
            End If

            ControlPrefix = oControl(iCounter, "ControlPrefix").Value
            ControlSite = oControl(iCounter, "ControlSite").Value
            ControlYear = oControl(iCounter, "ControlYear").Value
            ControlPeriod = oControl(iCounter, "ControlPeriod").Value
            ControlNumber = oControl(iCounter, "ControlNumber").Value

            FilterLedger = String.Format("JournalBatchId = {0}", SqlLiteral.Format(BatchId))

            If String.IsNullOrEmpty(ControlPrefix) Then
                FilterLedger = FilterLedger & " AND ControlPrefix IS NULL"
            Else
                FilterLedger = FilterLedger & " AND ControlPrefix = '" & ControlPrefix & "'"
            End If
            If String.IsNullOrEmpty(ControlSite) Then
                FilterLedger = FilterLedger & " AND ControlSite IS NULL"
            Else
                FilterLedger = FilterLedger & " AND ControlSite = '" & ControlSite & "'"
            End If
            If String.IsNullOrEmpty(ControlYear) Then
                FilterLedger = FilterLedger & " AND ControlYear IS NULL"
            Else
                FilterLedger = FilterLedger & " AND ControlYear = " & ControlYear
            End If
            If String.IsNullOrEmpty(ControlPeriod) Then
                FilterLedger = FilterLedger & " AND ControlPeriod IS NULL"
            Else
                FilterLedger = FilterLedger & " AND ControlPeriod = " & ControlPeriod
            End If
            If String.IsNullOrEmpty(ControlNumber) Then
                FilterLedger = FilterLedger & " AND ControlNumber IS NULL"
            Else
                FilterLedger = FilterLedger & " AND ControlNumber = " & ControlNumber
            End If

            PropertyListLedger = "TransNum, Acct, TransDate, " _
                & "DomAmount, Ref, VendNum, Voucher, CheckNum, " _
                & "CheckDate, FromSite, FromId, VouchSeq, RefType, " _
                & "MatlTransNum, DTransNum, BankCode, AcctUnit1, " _
                & "AcctUnit2, AcctUnit3, AcctUnit4, CurrCode, " _
                & "ExchRate, ForAmount, Site, Hierarchy, Consolidated, " _
                & "RefControlPrefix, RefControlSite, RefControlYear, " _
                & "RefControlPeriod, RefControlNumber, Processed"

            If bIsAnaLedger = True Then
                oLedger = Me.Context.Commands.LoadCollection("SL.SLAnaLedgers", PropertyListLedger, FilterLedger, "", 0)
            Else
                oLedger = Me.Context.Commands.LoadCollection("SL.SLLedgers", PropertyListLedger, FilterLedger, "", 0)
            End If

            For i = 0 To oLedger.Items.Count - 1

                updateItem = New IDOUpdateItem With {
                    .Action = UpdateAction.Insert
                }
                updateItem.Properties.Add("journal_batch_id", BatchId)
                updateItem.Properties.Add("control_prefix", ControlPrefix)
                updateItem.Properties.Add("control_site", ControlSite)
                updateItem.Properties.Add("control_year", ControlYear)
                updateItem.Properties.Add("control_period", ControlPeriod)
                updateItem.Properties.Add("control_number", ControlNumber)
                updateItem.Properties.Add("trans_num", oLedger(i, "TransNum").Value)
                updateItem.Properties.Add("acct", oLedger(i, "Acct").Value)
                If Not String.IsNullOrEmpty(oLedger(i, "TransDate").Value) Then
                    updateItem.Properties.Add("trans_date", Format(oLedger(i, "TransDate").GetValue(Of Date), DateFormat))
                Else
                    updateItem.Properties.Add("trans_date", "")
                End If
                updateItem.Properties.Add("dom_amount", oLedger(i, "DomAmount").Value)
                updateItem.Properties.Add("ref", oLedger(i, "Ref").Value)
                updateItem.Properties.Add("vend_num", oLedger(i, "VendNum").Value)
                updateItem.Properties.Add("voucher", oLedger(i, "Voucher").Value)
                updateItem.Properties.Add("check_num", oLedger(i, "CheckNum").Value)
                If Not String.IsNullOrEmpty(oLedger(i, "CheckDate").Value) Then
                    updateItem.Properties.Add("check_date", Format(oLedger(i, "CheckDate").GetValue(Of Date), DateFormat))
                Else
                    updateItem.Properties.Add("check_date", "")
                End If
                updateItem.Properties.Add("from_site", oLedger(i, "FromSite").Value)
                updateItem.Properties.Add("from_id", oLedger(i, "FromId").Value)
                updateItem.Properties.Add("vouch_seq", oLedger(i, "VouchSeq").Value)
                updateItem.Properties.Add("ref_type", oLedger(i, "RefType").Value)
                updateItem.Properties.Add("matl_trans_num", oLedger(i, "MatlTransNum").Value)
                updateItem.Properties.Add("d_trans_num", oLedger(i, "DTransNum").Value)
                updateItem.Properties.Add("bank_code", oLedger(i, "BankCode").Value)
                updateItem.Properties.Add("acct_unit1", oLedger(i, "AcctUnit1").Value)
                updateItem.Properties.Add("acct_unit2", oLedger(i, "AcctUnit2").Value)
                updateItem.Properties.Add("acct_unit3", oLedger(i, "AcctUnit3").Value)
                updateItem.Properties.Add("acct_unit4", oLedger(i, "AcctUnit4").Value)
                updateItem.Properties.Add("curr_code", oLedger(i, "CurrCode").Value)
                updateItem.Properties.Add("exch_rate", oLedger(i, "ExchRate").Value)
                updateItem.Properties.Add("for_amount", oLedger(i, "ForAmount").Value)
                updateItem.Properties.Add("site", oLedger(i, "Site").Value)
                updateItem.Properties.Add("hierarchy", oLedger(i, "Hierarchy").Value)
                updateItem.Properties.Add("consolidated", oLedger(i, "Consolidated").Value)
                updateItem.Properties.Add("ref_control_prefix", oLedger(i, "RefControlPrefix").Value)
                updateItem.Properties.Add("ref_control_site", oLedger(i, "RefControlSite").Value)
                updateItem.Properties.Add("ref_control_year", oLedger(i, "RefControlYear").Value)
                updateItem.Properties.Add("ref_control_period", oLedger(i, "RefControlPeriod").Value)
                updateItem.Properties.Add("ref_control_number", oLedger(i, "RefControlNumber").Value)
                updateItem.Properties.Add("processed", oLedger(i, "Processed").Value)

                oPerGet = Me.Context.Commands.Invoke("SLExtPRInterfaces", "PerGetSp", oLedger(i, "TransDate").Value, iPeriod, DBNull.Value, Infobar, DBNull.Value, iFiscalYear)
                If oPerGet.IsReturnValueStdError Then
                    MGException.Throw(oPerGet.Parameters(3).GetValue(Of String))
                End If
                iPeriod = CInt(oPerGet.Parameters(1).Value)
                iFiscalYear = CInt(oPerGet.Parameters(5).Value)
                oPerGet = Nothing

                updateItem.Properties.Add("cur_per", iPeriod)
                updateItem.Properties.Add("fiscal_year", iFiscalYear)

                updateRequest.Items.Add(updateItem)

            Next i

            If bDebug = True Then
                Dim fileName As String
                If bIsAnaLedger = True Then
                    fileName = "c:\\AnaLedgerBatch" & iCounter + 1 & ".xml"
                Else
                    fileName = "c:\\LedgerBatch" & iCounter + 1 & ".xml"
                End If
                updateRequest.ToXml(fileName)

            End If

            ' Assign the XmlDocument to a String Variable
            Dim requestEnvelope As New IDORequestEnvelope()
            requestEnvelope.Requests.Add(RequestType.UpdateCollection, updateRequest)
            XMLDocument = requestEnvelope.ToXml()

            Try
                oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, XMLDocument, IDONull.Value, Infobar)
            Catch exLedgerXML As Exception
                Throw New MGException("Invoking Ledger XML: " & MGException.ExtractMessages(exLedgerXML))
            End Try

            If Not oSLSites.IsReturnValueStdError Then
                objUpdateRequest = New UpdateCollectionRequestData With {
                    .IDOName = "SLLedgers"
                }
                Try
                    For j As Integer = 0 To oLedger.Items.Count - 1
                        ObjUpdateItem = New IDOUpdateItem With {
                            .ItemID = oLedger.Items(j).ItemID,
                            .Action = UpdateAction.Update
                        }
                        ObjUpdateItem.Properties.Add("Processed", "1")
                        objUpdateRequest.Items.Add(ObjUpdateItem)
                    Next j
                    Me.Context.Commands.UpdateCollection(objUpdateRequest)
                Catch exLedgerUpdate As Exception
                    Throw New MGException("Updating ledger: " & MGException.ExtractMessages(exLedgerUpdate))
                End Try
            Else
                MGException.Throw(oSLSites.Parameters(4).GetValue(Of String))
            End If
        Next
        Exit Sub
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinExportLedger(ByVal BatchId As Long)
        Call ExtFinExportLedgerBase(BatchId, False, False)
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinExportAnaLedger(ByVal BatchId As Long)
        Call ExtFinExportLedgerBase(BatchId, True, False)
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestUnitCd1()
        On Error GoTo ErrorHandler
        Dim oSLExtFin As InvokeResponseData
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestUnitcd1"
        oSLExtFin = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLExtFin.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLExtFin.Parameters(0).Value
        End If
        oSLExtFin = Nothing
        sColumns = ""

        'Get table columns
        oSLExtFin = Me.Invoke("ExtFinGetTableColsSp", "Unitcd1", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLExtFin.IsReturnValueStdError Then
            Infobar = oSLExtFin.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLExtFin.Parameters(2).Value
            sColumns = oSLExtFin.Parameters(3).Value
            iAllColsReceived = CInt(oSLExtFin.Parameters(4).Value)
        End If

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestUnitcd1.unitcd1",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing
        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestUnitCd2()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestUnitcd2"

        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing
        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Unitcd2", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestUnitcd2.unitcd2",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestUnitCd3()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestUnitcd3"

        'Get site
        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Unitcd3", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestUnitcd3.unitcd3",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestUnitCd4()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim iAllColsReceivedoSite As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestUnitcd4"

        'Get site
        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Unitcd4", IDONull.Value, IDONull.Value, sColumns, iAllColsReceivedoSite)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If

        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestUnitcd4.unitcd4",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp

        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestPeriods()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestPeriods"

        'Get site
        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing
        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Periods", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = Replace(oSLSites.Parameters(3).Value, "#", "")
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestPeriods.Periods",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp

        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestBankHdr()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestBankHdr"

        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing
        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Bank_hdr", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestBankHdr.Bank_hdr",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)
        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestTerms()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestTerms"

        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Terms", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestTerms.Terms",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp

        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestChart()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestChart"
        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing
        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Chart", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestChart.Chart",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestCountry()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestCountry"

        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Country", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestCountry.Country",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If
        oSLSites = Nothing

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestCurrency()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestCurrency"

        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Currency", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestCurrency.Currency",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestCurrate()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestCurrate"

        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Currate", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestCurrate.Currate",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If
        oSLSites = Nothing

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestDept()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestDept"
        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Dept", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestDept.Dept",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestLanguageIDs()
        On Error GoTo ErrorHandler

        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()


        'assign document name
        DocumentName = "ExtFinRequestLanguageIDs"

        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "LanguageIDs", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestLanguageIDs.LanguageIDs",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestTaxcode()
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim iAllColsReceived As Integer
        Dim Infobar As String : Infobar = ""
        Dim sColumns As String
        Dim sLastColReceived As String
        Dim iSeparatorPos As Integer
        Dim LoadRequest As LoadCollectionRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestTaxcode"

        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        sColumns = ""

        'Get table columns
        oSLSites = Me.Invoke("ExtFinGetTableColsSp", "Taxcode", IDONull.Value, IDONull.Value, sColumns, iAllColsReceived)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(2).Value
            GoTo ErrorHandler
        Else
            Infobar = oSLSites.Parameters(2).Value
            sColumns = oSLSites.Parameters(3).Value
            iAllColsReceived = CInt(oSLSites.Parameters(4).Value)
        End If
        oSLSites = Nothing

        LoadRequest = New LoadCollectionRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestTaxcode.Taxcode",
            .PropertyList = New PropertyList(sColumns)
        }

        requestEnvelope.Requests.Add(RequestType.LoadCollection, LoadRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If
        oSLSites = Nothing

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Sub ExtFinRequestPostedBal(ByVal PStartingCustNum As String, ByVal PEndingCustNum As String)
        On Error GoTo ErrorHandler
        Dim ToSite As String : ToSite = ""
        Dim DocumentName As String
        Dim oSLSites As InvokeResponseData
        Dim iRetVal As Integer
        Dim Infobar As String : Infobar = ""
        Dim InvokeRequest As InvokeRequestData
        Dim requestEnvelope As New IDORequestEnvelope()

        'assign document name
        DocumentName = "ExtFinRequestCustomerPostedBalance"

        oSLSites = Me.Invoke("ExtFinGetSiteSp", ToSite)
        If oSLSites.IsReturnValueStdError Then
            GoTo ErrorHandler
        Else
            ToSite = oSLSites.Parameters(0).Value
        End If
        oSLSites = Nothing

        InvokeRequest = New InvokeRequestData With {
            .IDOName = "EXTFIN.ExtFinRequestCustomerPostedBalance",
            .MethodName = "ExtFinRequestCustomerPostedBalance"
        }
        InvokeRequest.Parameters.Add(PStartingCustNum)
        InvokeRequest.Parameters.Add(PEndingCustNum)
        oSLSites.ToXml()
        requestEnvelope.Requests.Add(RequestType.Invoke, InvokeRequest)

        ' Create an instance of the IDO and call the request sp
        oSLSites = Me.Context.Commands.Invoke("SLSites", "SubmitReplicationXMLSP", ToSite, DocumentName, requestEnvelope.ToXml(), IDONull.Value, IDONull.Value)
        If oSLSites.IsReturnValueStdError Then
            Infobar = oSLSites.Parameters(4).Value
            GoTo ErrorHandler
        End If

        'destroy objects
        oSLSites = Nothing

        Exit Sub
ErrorHandler:
        If iRetVal <> 0 Then
            Err.Raise(iRetVal)
        End If
    End Sub


    ' This method will loop through each tmp_export_extfin_batch record,
    'according to the order in which the rows were inserted into the table,
    'and process the row by calling the existing functionality to build the xml(s) and
    'submit them to the Replication infrastructure for export
    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Sub ExtFinExportBatches()
        Dim bDone As Boolean
        Dim oInvokeResponseData As InvokeResponseData

        bDone = False

        Do While Not bDone
            Try
                'invoke the batch function
                oInvokeResponseData = Me.Invoke("ExtFinExportBatch", bDone)

                'if batch function does not return error,get the bDone value
                'Any functional error will be anyway thrown as an exception by individual
                'export methods. Hence there is no need to check the returnvalue 16 for the 
                'call
                If Not oInvokeResponseData.IsReturnValueStdError Then
                    bDone = oInvokeResponseData.Parameters(0).GetValue(Of Boolean)(False)
                End If
            Catch ex As Exception
                bDone = True
                Throw New MGException("ExtFinExportBatches: " & MGException.ExtractMessages(ex))
            End Try
        Loop
    End Sub

    <IDOMethod(MethodFlags.RequiresTransaction, "Infobar")> _
    Public Sub ExtFinExportBatch(ByRef bDone As Boolean)

        Dim oTmpExportExtFinBatches As LoadCollectionResponseData
        Dim oDeleteCollectionRequest As UpdateCollectionRequestData
        Dim oDeleteCollectionResponse As UpdateCollectionResponseData
        Dim oSLExtFinParms As InvokeResponseData
        Dim PropertyList As String
        Dim sFilter As String
        Dim BatchId As String
        Dim ExportCounter As String
        Dim DeleteItem As IDOUpdateItem
        oSLExtFinParms = Nothing
        oDeleteCollectionRequest = Nothing
        oDeleteCollectionResponse = Nothing

        PropertyList = "ObjectName, BatchNum, RowPointer, ExportCounter"
        sFilter = "ExportCounter"

        'Get the first record to be replicated.
        oTmpExportExtFinBatches = Me.Context.Commands.LoadCollection("SLTmpExportExtfinBatches", PropertyList, "", sFilter, 1)

        'If no more records to process then exit
        If oTmpExportExtFinBatches.Items.Count = 0 Then
            bDone = True
            Exit Sub

        End If

        'Now, get the batchid for the batch to be replicated
        BatchId = oTmpExportExtFinBatches.Item(0, "BatchNum").Value
        ExportCounter = oTmpExportExtFinBatches.Item(0, "ExportCounter").Value

        Select Case oTmpExportExtFinBatches.Item(0, "ObjectName").Value
            Case "ExtFinExportAP"
                Try
                    'Call the SL.SLExtfinParms.ExtFinExportAP
                    oSLExtFinParms = Me.Invoke("ExtFinExportAP", BatchId)
                Catch exAP As Exception
                    bDone = True
                    Throw New MGException("Calling ExtFinExportAP, ExportCounter=" & ExportCounter & ", " & "BatchId=" & BatchId & ": " & MGException.ExtractMessages(exAP))
                End Try

            Case "ExtFinExportAR"
                Try
                    'Call the SL.SLExtfinParms.ExtFinExportAR
                    oSLExtFinParms = Me.Invoke("ExtFinExportAR", BatchId)
                Catch exAR As Exception
                    bDone = True
                    Throw New MGException("Calling ExtFinExportAR, ExportCounter=" & ExportCounter & ", " & "BatchId=" & BatchId & ": " & MGException.ExtractMessages(exAR))
                End Try

            Case "ExtFinExportAnaLedger"
                Try
                    'Call the SL.SLExtfinParms.ExtFinExportAnaLedger
                    oSLExtFinParms = Me.Invoke("ExtFinExportAnaLedger", BatchId)
                Catch exAnaLedger As Exception
                    bDone = True
                    Throw New MGException("Calling ExtFinExportAnaLedger, ExportCounter=" & ExportCounter & ", " & "BatchId=" & BatchId & ": " & MGException.ExtractMessages(exAnaLedger))
                End Try

            Case "ExtFinExportLedger"
                Try
                    'Call the SL.SLExtfinParms.ExtFinExportLedger
                    oSLExtFinParms = Me.Invoke("ExtFinExportLedger", BatchId)
                Catch exLedger As Exception
                    bDone = True
                    Throw New MGException("Calling ExtFinExportLedger, ExportCounter=" & ExportCounter & ", " & "BatchId=" & BatchId & ": " & MGException.ExtractMessages(exLedger))
                End Try
        End Select

        If Not oSLExtFinParms.IsReturnValueStdError Then
            Try
                'Replication successful
                ' Delete the batch record using the same transaction
                oDeleteCollectionRequest = New UpdateCollectionRequestData With {
                    .IDOName = "SL.SLTmpExportExtfinBatches",
                    .RefreshAfterUpdate = True
                }
                DeleteItem = New IDOUpdateItem With {
                    .ItemID = oTmpExportExtFinBatches.Items(0).ItemID,
                    .Action = UpdateAction.Delete
                }
                oDeleteCollectionRequest.Items.Add(DeleteItem)
                oDeleteCollectionResponse = Me.Context.Commands.UpdateCollection(oDeleteCollectionRequest)
            Catch ex As Exception
                bDone = True
                Throw New MGException("ExtFinExportBatch, ExportCounter=" & ExportCounter & ", " & "BatchId=" & BatchId & ": " & MGException.ExtractMessages(ex))
            End Try
        End If

Cleanup:
        oSLExtFinParms = Nothing
        oTmpExportExtFinBatches = Nothing
        DeleteItem = Nothing
        oDeleteCollectionResponse = Nothing
        oDeleteCollectionRequest = Nothing
    End Sub

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ExternalFinancialChkSP(ByRef ExtFinEnabled As Integer?, ByRef ExtFinUseExternalAR As Integer?, ByRef ExtFinExtFinancial As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iExternalFinancialChkExt As IExternalFinancialChk = New ExternalFinancialChkFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, ExtFinEnabled As Integer?, ExtFinUseExternalAR As Integer?, ExtFinExtFinancial As String, Infobar As String) = iExternalFinancialChkExt.ExternalFinancialChkSp(ExtFinEnabled, ExtFinUseExternalAR, ExtFinExtFinancial, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            ExtFinEnabled = result.ExtFinEnabled
            ExtFinUseExternalAR = result.ExtFinUseExternalAR
            ExtFinExtFinancial = result.ExtFinExtFinancial
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ExtFinAddBatchToBGQueueSp(ByVal object_name As String, ByVal batch_num As Decimal?, ByRef Infobar As String, ByVal ToSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iExtFinAddBatchToBGQueueExt As IExtFinAddBatchToBGQueue = New ExtFinAddBatchToBGQueueFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iExtFinAddBatchToBGQueueExt.ExtFinAddBatchToBGQueueSp(object_name, batch_num, Infobar, ToSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ExtFinGetSiteSp(ByRef Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iExtFinGetSiteExt As IExtFinGetSite = New ExtFinGetSiteFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Site As String) = iExtFinGetSiteExt.ExtFinGetSiteSp(Site)
            Dim Severity As Integer = result.ReturnCode.Value
            Site = result.Site
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ExtFinGetTableColsSp(ByVal PTableName As String, ByVal LastColReturned As String, ByRef Infobar As String, ByRef ColNames As String, ByRef AllColsAppended As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iExtFinGetTableColsExt As IExtFinGetTableCols = New ExtFinGetTableColsFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String, ColNames As String, AllColsAppended As Integer?) = iExtFinGetTableColsExt.ExtFinGetTableColsSp(PTableName, LastColReturned, Infobar, ColNames, AllColsAppended)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            ColNames = result.ColNames
            AllColsAppended = result.AllColsAppended
            Return Severity
        End Using
    End Function
End Class
