//PROJECT NAME: CSI.MG.Finance
//CLASS NAME: SLTmpMassJournal2s.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using System.IO;
using Mongoose.Core.DataAccess;
using System.Transactions;
using Mongoose.IDO.DataAccess;
using System.Collections.Generic;
using Mongoose.Core.Common;
using System.Data.SqlClient;
using CSI.Data.SQL;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLTmpMassJournal2s")]
    public class SLTmpMassJournal2s : ExtensionClassBase
    {
        public override void SetContext(Mongoose.IDO.IIDOExtensionClassContext context)
        {
            base.SetContext(context);
            this.Context.IDO.PreItemInsert += HandlePreUpdateCollection;
        }

        public void HandlePreUpdateCollection(object sender, IDOItemUpdateEventArgs args)
        {
            string sSiteName = IDORuntime.Context.Site.ToString();
            long i = 1;
            decimal dBalance = 0;
            string sControlPrefix = "";
            DateTime dPreviousDate = Convert.ToDateTime("1/1/1900");
            DateTime dTransDatebatch = Convert.ToDateTime("1900/1/1");
            string sPrevRef = "";
            //string sErrorMsg = "";
            string sUnit1 = "";
            string sUnit2 = "";
            string sUnit3 = "";
            string sUnit4 = "";
            decimal dAmtDebit;
            decimal dAmtCredit;
            bool bValidRow = true;
            string sAccessUnit1 = "";
            string sAccessUnit2 = "";
            string sAccessUnit3 = "";
            string sAccessUnit4 = "";
            string sEffDate = "";
            string sObsDate = "";
            string sRef = "";
            string sPreviousRef = "";
            string sRefbatch = "";
            //int iFiscalYear = 0;
            //int iPeriod;
            int iControlYear = default(int);
            int iControlPeriod = default(int);
            //decimal iControlNumber;
            string sInfobar = "";
            bool bDisableValidation = false;
            string sFileName = "";
            string sCurrCode = "";
            //string sAnalysisAttribute01 = "";
            //string sAnalysisAttribute02 = "";
            //string sAnalysisAttribute03 = "";
            //string sAnalysisAttribute04 = "";
            //string sAnalysisAttribute05 = "";
            //string sAnalysisAttribute06 = "";
            //string sAnalysisAttribute07 = "";
            //string sAnalysisAttribute08 = "";
            //string sAnalysisAttribute09 = "";
            //string sAnalysisAttribute10 = "";
            //string sAnalysisAttribute11 = "";
            //string sAnalysisAttribute12 = "";
            //string sAnalysisAttribute13 = "";
            //string sAnalysisAttribute14 = "";
            //string sAnalysisAttribute15 = "";
            string sRowPointer = "";
            int icount;
            string sicount = "";
            string sBankCode = "";


            // Get the original request:
            UpdateCollectionRequestData updateRequest = (UpdateCollectionRequestData)args.RequestPayload;

            string gPartition = System.Guid.NewGuid().ToString();
            string sJournalId = updateRequest.Items[0].Properties["Id"].Value;
            string gProcessId = updateRequest.Items[0].Properties["ProcessId"].Value;
            sRefbatch = updateRequest.Items[0].Properties["Ref"].Value;
            sFileName = updateRequest.Items[0].Properties["UbFileName"].Value;

            if (updateRequest.Items[0].Properties["UbDisableValidation"].Value == "1")
                bDisableValidation = true;

            if (updateRequest.Items[0].Properties["TransDate"].Value != "")
                dTransDatebatch = Convert.ToDateTime(updateRequest.Items[0].Properties["TransDate"].Value);

            byte[] byt;
            if (!updateRequest.Items[0].Properties["UbFileCSV"].IsNull)
            {
                byt = updateRequest.Items[0].Properties["UbFileCSV"].GetValue<byte[]>();
                updateRequest.Items[0].Properties["UbFileCSV"].SetValue(null);
            }
            else
                return;

            if (byt.Length < 1)
                return;
            else
            {
                MemoryStream ms = new MemoryStream(byt);
                StreamReader sr = new StreamReader(ms, true);

                byt = null;
                ms = null;

                DataTable dtPeriods = new DataTable();
                DataTable dtAcctUnitCodes = new DataTable();
                DataTable dtChart = new DataTable();
                DataTable dtBankCode = new DataTable();
                using (IDisposable txn = TransactionScopeFactory.Create(TransactionScopeOption.Suppress)) // no rollback needed
                {
                    using (ApplicationDB appDB = IDORuntime.Context.CreateApplicationDB()) // get appDb class
                    {
                        //Using txn As System.Transactions.TransactionScope = appDB.CreateTransactionScope(Transactions.TransactionScopeOption.Suppress) 'no rollback needed
                        try
                        {
                            using (IDisposable timer = MGLog.CreateTimer("SLTmpMassJournal2s", "Get Validation Data"))
                            {
                                // Get prefix
                                DataTable dtControlPrefix = new DataTable();
                                Dictionary<string, object> sqlParms = new Dictionary<string, object>()
                        {
                            {
                                "@JournalId",
                                sJournalId
                            }
                        };
                                dtControlPrefix = SelectData("SELECT TOP 1 [jour_control_prefix] FROM [jour_hdr] WHERE [jour_hdr].[id] = @JournalId", sqlParms);
                                sControlPrefix = dtControlPrefix.Rows[0]["jour_control_prefix"].ToString();
                                dtControlPrefix.Dispose();

                                // Get Currency Code
                                DataTable dtSiteCurr = new DataTable();
                                dtSiteCurr = SelectData("SELECT TOP 1 [curr_code] FROM [currparms]");
                                sCurrCode = dtSiteCurr.Rows[0]["curr_code"].ToString();
                                dtSiteCurr.Dispose();

                                // Get UnitCodes                            
                                dtAcctUnitCodes = SelectData("WITH cteChartUnitCode ([acct],[UnitCodeSeq],[UnitCodeValue]) " + "AS ( " + "SELECT [chart].[acct],1,[unit1] FROM [chart] INNER JOIN [chart_unitcd1] ON [chart_unitcd1].[acct]=[chart].[acct] " + "UNION " + "SELECT [chart].[acct],2,[unit2] FROM [chart] INNER JOIN [chart_unitcd2] ON [chart_unitcd2].[acct]=[chart].[acct] " + "UNION " + "SELECT [chart].[acct],3,[unit3] FROM [chart] INNER JOIN [chart_unitcd3] ON [chart_unitcd3].[acct]=[chart].[acct] " + "UNION " + "SELECT [chart].[acct],4,[unit4] FROM [chart] INNER JOIN [chart_unitcd4] ON [chart_unitcd4].[acct]=[chart].[acct] " + ") SELECT [acct],[UnitCodeSeq],[UnitCodeValue] FROM cteChartUnitCode ORDER BY [acct],[UnitCodeSeq];");
                                // Get Chart                            
                                dtChart = SelectData("SELECT [acct],ISNULL([eff_date],'1/1/1900') AS [eff_date],ISNULL([obs_date],'12/31/2999') AS [obs_date],[access_unit1],[access_unit2],[access_unit3],[access_unit4] FROM [dbo].[chart]");
                                // Get Periods                            
                                dtPeriods = SelectData("SELECT [FiscalYear],[period],[startDate],[endDate] FROM [PeriodsView] ORDER BY [FiscalYear],[period]");
                                // Get BankCode                            
                                Dictionary<string, object> sqlBankCodeParms = new Dictionary<string, object>()
                        {
                            {
                                "@CurrCode",
                                sCurrCode
                            }
                        };
                                dtBankCode = SelectData("SELECT [acct],ISNULL([acct_unit1],'') AS [acct_unit1],ISNULL([acct_unit2],'') AS [acct_unit2],ISNULL([acct_unit3],'') AS [acct_unit3],ISNULL([acct_unit4],'') AS [acct_unit4],[bank_code] from [bank_hdr] " + "WHERE [curr_code] = @CurrCode order by [bank_code]", sqlBankCodeParms);
                            }
                        }
                        catch (Exception ex)
                        {
                            MGException.Throw(MGException.ExtractMessages(ex));
                        }

                        // Define datatable schema from SQL table's schema
                        DataTable dtError = new DataTable();
                        dtError = SelectData("SELECT TOP 0 * FROM [dbo].[tmp_mass_journal_bulk]");

                        DataTable dtProcess = new DataTable();
                        dtProcess = SelectData("SELECT TOP 0 * FROM [dbo].[tmp_mass_journal_bulk]");

                        DataTable dtTmpMassJournal = new DataTable();
                        dtTmpMassJournal = SelectData("SELECT TOP 0 * FROM [dbo].[tmp_mass_journal2]");

                        DataTable dtTmpDimAttributeValue = new DataTable();
                        dtTmpDimAttributeValue = SelectData("SELECT TOP 0 * FROM [dbo].[tmp_dim_attr_value]");

                        // Set datatable default values
                        {
                            var withBlock = dtError;
                            withBlock.Columns["InProcess"].DefaultValue = 0;
                            withBlock.Columns["InWorkflow"].DefaultValue = 0;
                            withBlock.Columns["NoteExistsFlag"].DefaultValue = 0;
                            withBlock.Columns["RecordDate"].DefaultValue = DateTime.Now;
                            withBlock.Columns["CreateDate"].DefaultValue = DateTime.Now;
                            withBlock.Columns["CreatedBy"].DefaultValue = IDORuntime.Context.UserName.ToString();
                            withBlock.Columns["UpdatedBy"].DefaultValue = IDORuntime.Context.UserName.ToString();
                            withBlock.Columns["cancellation"].DefaultValue = 0;
                        }

                        {
                            var withBlock = dtProcess;
                            withBlock.Columns["InProcess"].DefaultValue = 0;
                            withBlock.Columns["InWorkflow"].DefaultValue = 0;
                            withBlock.Columns["NoteExistsFlag"].DefaultValue = 0;
                            withBlock.Columns["RecordDate"].DefaultValue = DateTime.Now;
                            withBlock.Columns["CreateDate"].DefaultValue = DateTime.Now;
                            withBlock.Columns["CreatedBy"].DefaultValue = IDORuntime.Context.UserName.ToString();
                            withBlock.Columns["UpdatedBy"].DefaultValue = IDORuntime.Context.UserName.ToString();
                            withBlock.Columns["cancellation"].DefaultValue = 0;
                        }

                        {
                            var withBlock = dtTmpMassJournal;
                            withBlock.Columns["control_number"].DefaultValue = 0;
                            withBlock.Columns["ref_control_number"].DefaultValue = 0;
                            withBlock.Columns["exch_rate"].DefaultValue = 1;
                            withBlock.Columns["reverse"].DefaultValue = 0;
                            withBlock.Columns["voucher"].DefaultValue = 0;
                            withBlock.Columns["vouch_seq"].DefaultValue = 0;
                            withBlock.Columns["check_num"].DefaultValue = 0;
                            withBlock.Columns["matl_trans_num"].DefaultValue = 0;
                            withBlock.Columns["ref_line_suf"].DefaultValue = 0;
                            withBlock.Columns["ref_release"].DefaultValue = 0;

                            // .Columns["InProcess"].DefaultValue = 0
                            withBlock.Columns["InWorkflow"].DefaultValue = 0;
                            withBlock.Columns["NoteExistsFlag"].DefaultValue = 0;
                            withBlock.Columns["RecordDate"].DefaultValue = DateTime.Now;
                            withBlock.Columns["CreateDate"].DefaultValue = DateTime.Now;
                            withBlock.Columns["CreatedBy"].DefaultValue = IDORuntime.Context.UserName.ToString();
                            withBlock.Columns["UpdatedBy"].DefaultValue = IDORuntime.Context.UserName.ToString();
                            withBlock.Columns["cancellation"].DefaultValue = 0;
                        }

                        using (IDisposable timer = MGLog.CreateTimer("SLTmpMassJournal2s", "Read Rows"))
                        {
                            DateTime dTransDate;
                            string sAcct = "";
                            string aRow;
                            string sCultureName = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
                            System.Globalization.CultureInfo cultureToUse = new System.Globalization.CultureInfo(sCultureName);
                            string sNumberDecimalSeparator;
                            sNumberDecimalSeparator = cultureToUse.NumberFormat.CurrencyDecimalSeparator;

                            aRow = sr.ReadLine();

                            while (!(aRow == null)) // read csv line
                            {
                                string[] sArray = aRow.Split(','); // split line into array based on comma-separated values
                                var oldSArray = sArray;
                                sArray = new string[51];
                                if (oldSArray != null)
                                    Array.Copy(oldSArray, sArray, Math.Min(51, oldSArray.Length));
                                // Get values
                                // Assign TransDate to imported value if batch date not provided
                                if (dTransDatebatch == Convert.ToDateTime("1/1/1900"))
                                    dTransDate = Convert.ToDateTime(sArray[0]);
                                else
                                    dTransDate = dTransDatebatch;
                                if (!String.IsNullOrEmpty(sArray[1]))
                                    sAcct = sArray[1].ToString();
                                if (!String.IsNullOrEmpty(sArray[2]))
                                    sUnit1 = sArray[2].ToString();
                                if (!String.IsNullOrEmpty(sArray[3]))
                                    sUnit2 = sArray[3].ToString();
                                if (!String.IsNullOrEmpty(sArray[4]))
                                    sUnit3 = sArray[4].ToString();
                                if (!String.IsNullOrEmpty(sArray[5]))
                                    sUnit4 = sArray[5].ToString();

                                if (!String.IsNullOrEmpty(sArray[6]))
                                    dAmtDebit = Convert.ToDecimal(sArray[6].ToString().Replace(".", sNumberDecimalSeparator));
                                else
                                    dAmtDebit = 0;
                                if (!String.IsNullOrEmpty(sArray[7]))
                                    dAmtCredit = Convert.ToDecimal(sArray[7].ToString().Replace(".", sNumberDecimalSeparator));
                                else
                                    dAmtCredit = 0;

                                // Assign Ref to imported Ref if batch Ref not assigned
                                if (sRefbatch != "")
                                    sRef = sRefbatch;
                                else if (!String.IsNullOrEmpty(sArray[8]) && sRefbatch == "")
                                    sRef = sArray[8].ToString();

                                bValidRow = true;

                                Mongoose.IDO.IMessageProvider msgprov;
                                msgprov = appDB.GetMessageProvider();

                                // Basic validation 
                                if (!bDisableValidation)
                                {
                                    bValidRow = true;
                                    if (Convert.IsDBNull(dTransDate))
                                    {
                                        bValidRow = false;
                                        sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@journal.trans_date", "@!blank", "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                    if ((Convert.IsDBNull(sAcct) || sAcct == "") && bValidRow == true)
                                    {
                                        bValidRow = false;
                                        sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@journal.acct", "@!blank", "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                    else
                                    {
                                        DataRow[] validAcct = dtChart.Select(string.Format("'{0}' = acct", sAcct.ToString()), "acct", DataViewRowState.CurrentRows);
                                        if (validAcct.Length == 0)
                                        {
                                            bValidRow = false;
                                            sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@journal.acct", sAcct, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                        }
                                        else
                                        {
                                            sAccessUnit1 = validAcct[0]["access_unit1"].ToString();
                                            sAccessUnit2 = validAcct[0]["access_unit2"].ToString();
                                            sAccessUnit3 = validAcct[0]["access_unit3"].ToString();
                                            sAccessUnit4 = validAcct[0]["access_unit4"].ToString();
                                            sEffDate = validAcct[0]["eff_date"].ToString();
                                            sObsDate = validAcct[0]["obs_date"].ToString();
                                        }
                                    }


                                    DataRow[] YearPeriod = dtPeriods.Select(string.Format("'{0}' >= startDate AND '{0}' <= endDate", dTransDate.ToString("d")), "FiscalYear", DataViewRowState.CurrentRows);
                                    if (YearPeriod.Length == 1)
                                    {
                                        iControlYear = Convert.ToInt16(YearPeriod[0]["FiscalYear"]);
                                        iControlPeriod = Convert.ToInt16(YearPeriod[0]["period"]);
                                    }

                                    DataRow[] BankCode = dtBankCode.Select(string.Format("'{0}' = acct AND '{1}'=acct_unit1 AND '{2}'=acct_unit2 AND '{3}'=acct_unit3 AND '{4}'=acct_unit4", sAcct.ToString(), sUnit1.ToString(), sUnit2.ToString(), sUnit3.ToString(), sUnit4.ToString()), "acct", DataViewRowState.CurrentRows);
                                    if (BankCode.Length >= 1)
                                        sBankCode = BankCode[0]["bank_code"].ToString();
                                    else if (BankCode.Length == 0)
                                    {
                                        DataRow[] BankCodeByAcct = dtBankCode.Select(string.Format("'{0}' = acct", sAcct.ToString()), "acct", DataViewRowState.CurrentRows);
                                        if (BankCodeByAcct.Length >= 1)
                                            sBankCode = BankCodeByAcct[0]["bank_code"].ToString();
                                    }

                                    DataRow[] validUnitCode1 = dtAcctUnitCodes.Select(string.Format("'{0}' = acct AND UnitCodeSeq=1 AND '{1}'=UnitCodeValue", sAcct.ToString(), sUnit1.ToString()), "acct", DataViewRowState.CurrentRows);
                                    DataRow[] validUnitCode2 = dtAcctUnitCodes.Select(string.Format("'{0}' = acct AND UnitCodeSeq=2 AND '{1}'=UnitCodeValue", sAcct.ToString(), sUnit2.ToString()), "acct", DataViewRowState.CurrentRows);
                                    DataRow[] validUnitCode3 = dtAcctUnitCodes.Select(string.Format("'{0}' = acct AND UnitCodeSeq=3 AND '{1}'=UnitCodeValue", sAcct.ToString(), sUnit3.ToString()), "acct", DataViewRowState.CurrentRows);
                                    DataRow[] validUnitCode4 = dtAcctUnitCodes.Select(string.Format("'{0}' = acct AND UnitCodeSeq=4 AND '{1}'=UnitCodeValue", sAcct.ToString(), sUnit4.ToString()), "acct", DataViewRowState.CurrentRows);

                                    if (bValidRow == true)
                                    {
                                        if (Convert.ToDateTime(sEffDate) > dTransDate && bValidRow == true)
                                        {
                                            bValidRow = false;
                                            sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@chart.eff_date", dTransDate, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                        }
                                        if (Convert.ToDateTime(sObsDate) < dTransDate && bValidRow == true)
                                        {
                                            bValidRow = false;
                                            sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@chart.obs_date", dTransDate, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                        }
                                    }
                                    if (YearPeriod.Length != 1)
                                    {
                                        bValidRow = false;
                                        sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@journal.control_year", iControlYear, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                    if ((sAccessUnit1 == "N" && sUnit1 != "") || ((sAccessUnit1 == "R") && sUnit1 == "") || (((sAccessUnit1 == "A" || sAccessUnit1 == "R") && sUnit1 != "") && (validUnitCode1.Length == 0)))
                                    {
                                        bValidRow = false;
                                        sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@journal.acct_unit1", sUnit1, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                    if ((sAccessUnit2 == "N" && sUnit2 != "") || ((sAccessUnit2 == "R") && sUnit2 == "") || (((sAccessUnit2 == "A" || sAccessUnit2 == "R") && sUnit2 != "") && (validUnitCode2.Length == 0)))
                                    {
                                        bValidRow = false;
                                        sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@journal.acct_unit2", sUnit1, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                    if ((sAccessUnit3 == "N" && sUnit3 != "") || ((sAccessUnit3 == "R") && sUnit3 == "") || (((sAccessUnit3 == "A" || sAccessUnit3 == "R") && sUnit3 != "") && (validUnitCode3.Length == 0)))
                                    {
                                        bValidRow = false;
                                        sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@journal.acct_unit3", sUnit1, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                    if ((sAccessUnit4 == "N" && sUnit4 != "") || ((sAccessUnit4 == "R") && sUnit4 == "") || (((sAccessUnit4 == "A" || sAccessUnit4 == "R") && sUnit4 != "") && (validUnitCode4.Length == 0)))
                                    {
                                        bValidRow = false;
                                        sInfobar = msgprov.AppendMessage(sInfobar, "E=IsCompare", "@journal.acct_unit4", sUnit1, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                    if (dAmtDebit == 0 && dAmtCredit == 0)
                                    {
                                        bValidRow = false;
                                        sInfobar = msgprov.AppendMessage(sInfobar, "E=CRDBGTZero", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    }
                                    if (!bValidRow)
                                    {
                                        DataRow rwError;
                                        rwError = (dtError.NewRow());
                                        rwError["ProcessId"] = gProcessId;
                                        rwError["Partition"] = gPartition;
                                        rwError["Id"] = sJournalId;
                                        rwError["seq"] = i;
                                        rwError["trans_date"] = dTransDate;
                                        rwError["acct"] = sAcct;
                                        rwError["amt_debit"] = dAmtDebit;
                                        rwError["amt_credit"] = dAmtCredit;
                                        if (sUnit1 != "")
                                            rwError["acct_unit1"] = sUnit1;
                                        if (sUnit2 != "")
                                            rwError["acct_unit2"] = sUnit2;
                                        if (sUnit3 != "")
                                            rwError["acct_unit3"] = sUnit3;
                                        if (sUnit4 != "")
                                            rwError["acct_unit4"] = sUnit4;
                                        if (sRef != "")
                                            rwError["ref"] = sRef;
                                        rwError["file_name"] = sFileName;
                                        rwError["ErrorMsg"] = sInfobar;
                                        rwError["RowPointer"] = System.Guid.NewGuid().ToString();
                                        rwError["CreatedBy"] = IDORuntime.Context.UserName.ToString();

                                        dtError.Rows.Add(rwError);
                                    }
                                }

                                if (bValidRow)
                                {
                                    DataRow rwTmpMassJournal;
                                    rwTmpMassJournal = (dtTmpMassJournal.NewRow());

                                    if (dTransDate != dPreviousDate || (dTransDate == dPreviousDate && sRef != sPreviousRef))
                                    {
                                        // Assign new gPartition value to represent journal "chunk"
                                        if (dBalance == 0 && i > 0)
                                        {
                                            gPartition = System.Guid.NewGuid().ToString();

                                            // Write row to Process database which will be used to extract Process/Partition values
                                            DataRow rwProcess;
                                            rwProcess = dtProcess.NewRow();
                                            rwProcess["ProcessId"] = gProcessId;
                                            rwProcess["Partition"] = gPartition;
                                            rwProcess["Id"] = sJournalId;
                                            rwProcess["seq"] = i;
                                            rwProcess["ErrorMsg"] = "NO ERROR";
                                            rwProcess["file_name"] = sFileName;
                                            rwProcess["RowPointer"] = System.Guid.NewGuid().ToString();

                                            dtProcess.Rows.Add(rwProcess);
                                        }
                                    }

                                    rwTmpMassJournal["ProcessId"] = gPartition;
                                    rwTmpMassJournal["Id"] = sJournalId;
                                    rwTmpMassJournal["seq"] = i;
                                    rwTmpMassJournal["trans_date"] = dTransDate;
                                    rwTmpMassJournal["acct"] = sAcct;
                                    if (dAmtDebit > 0)
                                    {
                                        rwTmpMassJournal["dom_amount"] = dAmtDebit;
                                        rwTmpMassJournal["for_amount"] = dAmtDebit;
                                        dBalance += dAmtDebit;
                                    }
                                    if (dAmtCredit > 0)
                                    {
                                        rwTmpMassJournal["dom_amount"] = dAmtCredit * -1;
                                        rwTmpMassJournal["for_amount"] = dAmtCredit * -1;
                                        dBalance = dBalance + (dAmtCredit * -1);
                                    }

                                    if (sUnit1 != "")
                                        rwTmpMassJournal["acct_unit1"] = sUnit1;
                                    if (sUnit2 != "")
                                        rwTmpMassJournal["acct_unit2"] = sUnit2;

                                    if (sUnit3 != "")
                                        rwTmpMassJournal["acct_unit3"] = sUnit3;
                                    if (sUnit4 != "")
                                        rwTmpMassJournal["acct_unit4"] = sUnit4;
                                    rwTmpMassJournal["ref"] = sRef;

                                    // rwTmpMassJournal.Item("control_number") = 0 (see datatable defaults)
                                    // rwTmpMassJournal.Item("ref_control_number") = 0 (see datatable defaults)
                                    rwTmpMassJournal["control_prefix"] = sControlPrefix;
                                    rwTmpMassJournal["ref_control_prefix"] = sControlPrefix;
                                    rwTmpMassJournal["control_site"] = sSiteName;
                                    rwTmpMassJournal["ref_control_site"] = sSiteName;
                                    rwTmpMassJournal["control_year"] = iControlYear;
                                    rwTmpMassJournal["ref_control_year"] = iControlYear;
                                    rwTmpMassJournal["control_period"] = iControlPeriod;
                                    rwTmpMassJournal["ref_control_period"] = iControlPeriod;
                                    rwTmpMassJournal["curr_code"] = sCurrCode;
                                    rwTmpMassJournal["from_site"] = sSiteName;
                                    sRowPointer = System.Guid.NewGuid().ToString();
                                    rwTmpMassJournal["RowPointer"] = sRowPointer;
                                    if (sBankCode != "")
                                        rwTmpMassJournal["bank_code"] = sBankCode;
                                    // rwTmpMassJournal("cancellation") = 0

                                    dtTmpMassJournal.Rows.Add(rwTmpMassJournal);

                                    DataRow rwTmpDimAttributeValue;
                                    if ((sArray[8 + 1]) != null)
                                    {
                                        rwTmpDimAttributeValue = (dtTmpDimAttributeValue.NewRow());

                                        rwTmpDimAttributeValue["ProcessId"] = gProcessId;
                                        rwTmpDimAttributeValue["DimensionObjectName"] = "Ledger";
                                        rwTmpDimAttributeValue["subscriberobjectrowpointer"] = sRowPointer;
                                        for (icount = 1; icount <= 15; icount++)
                                        {
                                            if ((sArray[8 + icount]) != null)
                                            {
                                                sicount = System.Convert.ToString(icount).PadLeft(2, System.Convert.ToChar("0"));
                                                rwTmpDimAttributeValue["AnalysisAttribute" + sicount] = sArray[8 + icount].ToString();
                                            }
                                        }

                                        dtTmpDimAttributeValue.Rows.Add(rwTmpDimAttributeValue);
                                    }
                                }

                                i += 1;
                                sAcct = "";
                                sUnit1 = "";
                                sUnit2 = "";
                                sUnit3 = "";
                                sUnit4 = "";
                                sPrevRef = sRef;
                                sRef = "";
                                dAmtDebit = 0;
                                dAmtCredit = 0;
                                sAccessUnit1 = "";
                                sAccessUnit2 = "";
                                sAccessUnit3 = "";
                                sAccessUnit4 = "";
                                //iFiscalYear = 0;
                                //iPeriod = default(int);
                                //iControlNumber = default(Decimal);
                                iControlYear = default(int);
                                bValidRow = true;
                                dPreviousDate = dTransDate;
                                sPreviousRef = sRef;
                                sInfobar = "";
                                sBankCode = "";

                                aRow = sr.ReadLine();
                            }
                        }

                        // Clear what's not needed anymore before sending to SQL
                        sr = null;
                        dtAcctUnitCodes.Dispose();
                        dtChart.Dispose();
                        dtPeriods.Dispose();
                        dtBankCode.Dispose();
                        txn.Dispose();

                        try
                        {
                            if (dtError.Rows.Count == 0)
                            {
                                using (IDisposable timer = MGLog.CreateTimer("SLTmpMassJournal2s", "tmp_mass_journal_bulk"))
                                {
                                    // Write ProcessId/Partition data to tmp_mass_journal_bulk which will be used to process tmp_mass_journal records using JournalDeferSp && JournalImmediateSp
                                    using (SqlBulkCopy bcTmpMassJournalBulk = new SqlBulkCopy((SqlConnection)appDB.Connection, SqlBulkCopyOptions.Default, null/* TODO Change to default(_) if this is not a reference type */))
                                    {
                                        bcTmpMassJournalBulk.DestinationTableName = "tmp_mass_journal_bulk";
                                        if (appDB.Connection.State == ConnectionState.Open)
                                        {
                                            bcTmpMassJournalBulk.BulkCopyTimeout = 1600; // seconds
                                            bcTmpMassJournalBulk.WriteToServer(dtProcess);
                                        }
                                    }
                                }
                                using (IDisposable timer = MGLog.CreateTimer("SLTmpMassJournal2s", "tmp_mass_journals2"))
                                {

                                    // Write tmp_mass_journal records whose ProcessId values have been "chunked" on transaction date and balance=0

                                    using (SqlBulkCopy bcTmpMassJournal = new SqlBulkCopy((SqlConnection)appDB.Connection, SqlBulkCopyOptions.Default, null/* TODO Change to default(_) if this is not a reference type */))
                                    {
                                        bcTmpMassJournal.DestinationTableName = "tmp_mass_journal2";
                                        if (appDB.Connection.State == ConnectionState.Open)
                                        {
                                            bcTmpMassJournal.BulkCopyTimeout = 1600; // seconds
                                            bcTmpMassJournal.WriteToServer(dtTmpMassJournal);
                                        }
                                    }
                                }
                                // Write DimAttributeValue
                                using (IDisposable timer = MGLog.CreateTimer("SLTmpMassJournal2s", "tmp_dim_attr_value"))
                                {
                                    using (SqlBulkCopy bcTmpDimAttributeValue = new SqlBulkCopy((SqlConnection)appDB.Connection, SqlBulkCopyOptions.Default, null/* TODO Change to default(_) if this is not a reference type */))
                                    {
                                        bcTmpDimAttributeValue.DestinationTableName = "tmp_dim_attr_value";
                                        if (appDB.Connection.State == ConnectionState.Open)
                                        {
                                            bcTmpDimAttributeValue.BulkCopyTimeout = 1600; // seconds
                                            bcTmpDimAttributeValue.WriteToServer(dtTmpDimAttributeValue);
                                        }
                                    }
                                }
                            }
                            else
                                using (IDisposable timer = MGLog.CreateTimer("SLTmpMassJournal2s", "tmp_mass_journal_bulk"))
                                {
                                    // Write invalid rows to tmp_mass_journal_bulk to visualize errors
                                    using (SqlBulkCopy bcTmpMassJournalBulkErrors = new SqlBulkCopy((SqlConnection)appDB.Connection, SqlBulkCopyOptions.Default, null/* TODO Change to default(_) if this is not a reference type */))
                                    {
                                        bcTmpMassJournalBulkErrors.DestinationTableName = "tmp_mass_journal_bulk";
                                        if (appDB.Connection.State == ConnectionState.Open)
                                        {
                                            bcTmpMassJournalBulkErrors.BulkCopyTimeout = 1600; // seconds
                                            bcTmpMassJournalBulkErrors.WriteToServer(dtError);
                                        }
                                    }
                                }

                            dtProcess.Dispose();
                            dtError.Dispose();
                            dtTmpMassJournal.Dispose();

                            args.SuppressStandardSave(); // skip standard IDO save, only want to commit records to bc.DestinationTableName()
                        }
                        catch (Exception ex)
                        {
                            MGException.Throw(MGException.ExtractMessages(ex));
                        }
                    }
                }
            }
        }

        private DataTable ConvertDataReaderToDataTable(IDataReader reader)
        {
            DataTable objDataTable = new DataTable();
            int intFieldCount = reader.FieldCount;
            int intCounter;
            for (intCounter = 0; intCounter <= intFieldCount - 1; intCounter++)
                objDataTable.Columns.Add(reader.GetName(intCounter), reader.GetFieldType(intCounter));

            objDataTable.BeginLoadData();
            object[] objValues = new object[intFieldCount - 1 + 1];
            while (reader.Read())
            {
                reader.GetValues(objValues);
                objDataTable.LoadDataRow(objValues, true);
            }
            reader.Close();
            objDataTable.EndLoadData();

            return objDataTable;
        }
        public DataTable SelectData(string sqlCommand, Dictionary<string, object> sqlParms = null)
        {
            //IDataReader oDataReader = null;/* TODO Change to default(_) if this is not a reference type */
            DataTable results = new DataTable();
            DataSet ds = new DataSet();
            IDbDataParameter param = null;/* TODO Change to default(_) if this is not a reference type */
            try
            {
                using (ApplicationDB appDB = IDORuntime.Context.CreateApplicationDB())
                {
                    try
                    {
                        using (IDbCommand cmd = appDB.CreateCommand())
                        {
                            cmd.CommandText = sqlCommand;
                            if (sqlParms != null)
                            {
                                foreach (KeyValuePair<string, object> kvp in sqlParms)
                                {
                                    param = cmd.CreateParameter();
                                    param.ParameterName = kvp.Key;
                                    param.Value = kvp.Value;
                                    cmd.Parameters.Add(param);
                                }
                            }
                            IDataReader dr = appDB.ExecuteReader(cmd);
                            results = ConvertDataReaderToDataTable(dr);
                            if (dr != null && !dr.IsClosed)
                            {
                                dr.Close();
                                dr.Dispose();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MGException.Throw(MGException.ExtractMessages(ex));
                    }
                }
            }
            catch (Exception ex)
            {
                MGException.Throw(MGException.ExtractMessages(ex));
            }
            return results;
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DeleteTmpMassJournalSp(Guid? ProcessId,
                                                  [Optional, DefaultParameterValue((byte)0)] byte? Initialize,
                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDeleteTmpMassJournalExt = new DeleteTmpMassJournalFactory().Create(appDb);

                var result = iDeleteTmpMassJournalExt.DeleteTmpMassJournalSp(ProcessId,
                                                                             Initialize,
                                                                             Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None)]
        public int ProcessTmpMassJournalBulkSp(Guid? ProcessId, int? BGTaskId)
        {
            using (AppDB MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSI.MG.CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var mgInvoker = new MGInvoker(Context);
                var iProcessTmpMassJournalBulkExt = new ProcessTmpMassJournalBulkFactory().Create(appDb,mgInvoker,new SQLParameterProvider(),true);
                var result = iProcessTmpMassJournalBulkExt.ProcessTmpMassJournalBulkSp(ProcessId, BGTaskId);
                int Severity = result.Value;
                return Severity;
            }
        }
    }
}
