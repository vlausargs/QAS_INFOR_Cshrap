using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using PLLOC.Interfaces;
using System;
using System.Data;
using System.IO;
using CSI.Reporting;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using PLLOC.Objects;

namespace PLLOC.Objects
{
    public class RptVATValuesFromSp : IRptVATValuesFromSp
    {
        IRptVATManager rptVATManager;
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;
        IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        IRpt_VAT rpt_VAT;
        ICLM_VatProceduralMarkingsSp CLM_VatProceduralMarkingsSp;
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        IRecordCollectionToDataTable recordCollectionToDataTable;

        public RptVATValuesFromSp(IRptVATManager rptVATManager, IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection,
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IRpt_VAT rpt_VAT, ICLM_VatProceduralMarkingsSp CLM_VatProceduralMarkingsSp, ICollectionLoadRequestFactory collectionLoadRequestFactory, IRecordCollectionToDataTable recordCollectionToDataTable)
        {
            this.rptVATManager = rptVATManager;
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.rpt_VAT = rpt_VAT;
            this.CLM_VatProceduralMarkingsSp = CLM_VatProceduralMarkingsSp;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.recordCollectionToDataTable = recordCollectionToDataTable;
        }

        public DataTable GetRpt_VATSp(byte? TaxJurTaxSystem, byte? ExOptszShowDetail, string TaxJurTaxJur, DateTime? ExBegInvStaxInvDate, DateTime? ExEndInvStaxInvDate, short? TaxDateStartingOffset, short? TaxDateEndingOffset, string ExOptgoJournalId, byte? DisplayHeader, string BGSessionId, int? TaskId, string pSite, string BGUser, string SortBy, byte? ExcludeNullLineNum, byte? ExcludeJournalEntries)
        {
            var rpt_VATSp = rpt_VAT.Rpt_VATSp(TaxJurTaxSystem, ExOptszShowDetail, TaxJurTaxJur, ExBegInvStaxInvDate, ExEndInvStaxInvDate, TaxDateStartingOffset, TaxDateEndingOffset, ExOptgoJournalId, DisplayHeader, BGSessionId, TaskId, pSite, BGUser, SortBy, ExcludeNullLineNum, ExcludeJournalEntries);

            DataTable dtRpt_VATSp = new DataTable();

            if (rpt_VATSp.Data.Items.Count > 0)
            {
                dtRpt_VATSp = this.recordCollectionToDataTable.ToDataTable(rpt_VATSp.Data.Items);
            }

            return (dtRpt_VATSp);
        }
        public DataTable GetCLM_VatProceduralMarkingsSp(DateTime? ExBegInvStaxInvDate, DateTime? ExEndInvStaxInvDate)
        {
            var CLM_VatProceduralMarkingsSp = this.CLM_VatProceduralMarkingsSp.ExecuteSp(ExBegInvStaxInvDate, ExEndInvStaxInvDate);

            var dtCLM_VatProceduralMarkingsSp = recordCollectionToDataTable.ToDataTable(CLM_VatProceduralMarkingsSp.Data.Items);

            return dtCLM_VatProceduralMarkingsSp;
        }

        public bool SetResultToRPTVATManager(DataTable dtRpt_VATSp, DataTable dtCLM_VatProceduralMarkingsSp)
        {
            decimal TotalPurchaseTax = 0;
            decimal TotalTaxSales = 0;
            int countPurchase = 0;
            int countSales = 0;

            if (dtRpt_VATSp.Rows.Count <= 0)
            {
                return true;
            }

            try
            {
                //var dr = dtRpt_VATSp.DefaultView.ToTable(true, "name", "cust_num", "inv_date", "inv_vch", "tax_date", "tax_type", "country", "addr##1", "addr##2", "addr##3", "addr##4", "tax_reg_num1", "is_offset");
                foreach (DataRow row in dtRpt_VATSp.Rows)
                {
                    string inv_vch = row["inv_vch"].ToString();
                    string cust_num = row["cust_num"].ToString();
                    string name = row["name"].ToString();
                    DateTime inv_date = DateTime.ParseExact((row["inv_date"] == DBNull.Value ? DateTime.Now.ToString("yyyy-MM-dd") : Convert.ToDateTime(row["inv_date"]).ToString("yyyy-MM-dd")), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime tax_date = DateTime.ParseExact((row["tax_date"] == DBNull.Value ? DateTime.Now.ToString("yyyy-MM-dd") : Convert.ToDateTime(row["tax_date"]).ToString("yyyy-MM-dd")), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime payment_due_date = DateTime.ParseExact((row["payment_due_date"] == DBNull.Value ? DateTime.Now.ToString("yyyy-MM-dd") : Convert.ToDateTime(row["payment_due_date"]).ToString("yyyy-MM-dd")), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string is_offset = row["is_offset"].ToString();
                    string tax_type = row["tax_type"].ToString();
                    string country = row["country"].ToString();
                    string addr1 = row["addr##1"].ToString();
                    string addr2 = row["addr##2"].ToString();
                    string addr3 = row["addr##3"].ToString();
                    string addr4 = row["addr##4"].ToString();
                    string tax_reg_num1 = row["tax_reg_num1"].ToString();
                    string vend_inv_num = row["vend_inv_num"].ToString();
                    string number_for_tax = row["number_for_tax"].ToString();
                    string number_for_tax_basis = row["number_for_tax_basis"].ToString();
                    decimal goods_value = Convert.ToDecimal(row["goods_value"].ToString());
                    decimal sales_tax = Convert.ToDecimal(row["sales_tax"].ToString());
                    int inv_vch_seq = Convert.ToInt32(row["inv_vch_seq"].ToString());

                    StringType _CountryCode = DBNull.Value;

                    #region CRUD LoadToVariable
                    var countryAScountryLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                    {_CountryCode,$"iso_country.iso_country_code"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "country AS country",
                    fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN iso_country AS iso_country ON country.iso_country_code = iso_country.iso_country_code"),
                    whereClause: collectionLoadRequestFactory.Clause("country = {0}", country),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                    this.appDB.Load(countryAScountryLoadRequest);
                    #endregion  LoadToVariable

                    if (tax_type == "P")
                    {
                        countPurchase++;

                        string CountryOriginCodeTIN = string.IsNullOrEmpty(tax_reg_num1)?"":(_CountryCode.IsNull ? "" : _CountryCode.Value);
                        bool IMP = IsVatProcMarkingSelectedInInvVch(inv_vch, "IMP", "V", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq); ;
                        decimal K40 = GetColumnValue(number_for_tax_basis, number_for_tax, "40", "40", goods_value, sales_tax, is_offset);
                        decimal K41 = GetColumnValue(number_for_tax_basis, number_for_tax, "41", "41", goods_value, sales_tax, is_offset);
                        decimal K42 = GetColumnValue(number_for_tax_basis, number_for_tax, "42", "42", goods_value, sales_tax, is_offset);
                        decimal K43 = GetColumnValue(number_for_tax_basis, number_for_tax, "43", "43", goods_value, sales_tax, is_offset);
                        decimal K44 = GetColumnValue(number_for_tax_basis, number_for_tax, "44", "44", goods_value, sales_tax, is_offset);
                        decimal K45 = GetColumnValue(number_for_tax_basis, number_for_tax, "45", "45", goods_value, sales_tax, is_offset);
                        decimal K46 = GetColumnValue(number_for_tax_basis, number_for_tax, "46", "46", goods_value, sales_tax, is_offset);
                        decimal K47 = GetColumnValue(number_for_tax_basis, number_for_tax, "47", "47", goods_value, sales_tax, is_offset);
                        bool MPP = IsVatProcMarkingSelectedInInvVch(inv_vch, "MPP", "V", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        DateTime PurchaseDate = inv_date;
                        string PurchaseDocument = "";
                        string PurchaseNumber = countPurchase.ToString();
                        string PurchaseProof = vend_inv_num;
                        DateTime ReceiptDate = tax_date;
                        string SupplierName = name;
                        string SupplierNumber =  string.IsNullOrEmpty(tax_reg_num1)?"BRAK": tax_reg_num1;

                        var purchase = rptVATManager.CreateJPKV7MPurchaseRegister(CountryOriginCodeTIN, IMP, K40, K41, K42, K43, K44, K45, K46, K47, MPP, PurchaseDate, PurchaseDocument, PurchaseNumber, PurchaseProof, ReceiptDate, SupplierName, SupplierNumber);

                        rptVATManager.AddJPKV7MPurchaseRegister(purchase);
                        //Total amount of input tax to be deducted - the sum of the amounts from K_41, K_43, K_44, K_45, K_46, K_47. If none of the indicated elements has been completed in the records, then 0.00 should be provided
                        TotalPurchaseTax += purchase.K41 + purchase.K43 + purchase.K44 + purchase.K45 + purchase.K46 + purchase.K47;
                    }

                    if (tax_type == "S")
                    {
                        countSales++;

                        string SalesNumber = countSales.ToString();
                        string CountryOriginCodeTIN = string.IsNullOrEmpty(tax_reg_num1) ? "" : (_CountryCode.IsNull ? "" : _CountryCode.Value);
                        string CounterPartyNo = string.IsNullOrEmpty(tax_reg_num1) ? "BRAK" : tax_reg_num1;
                        string ContractorsName = name;
                        string SalesEvidence = is_offset == "1" ? vend_inv_num : inv_vch;
                        DateTime IssueDate = inv_date;
                        DateTime SalesDate = tax_date;
                        DateTime DueDate = payment_due_date;
                        string DocumentType = "";
                        bool GTU1 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_01", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU2 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_02", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU3 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_03", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU4 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_04", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU5 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_05", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU6 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_06", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU7 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_07", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU8 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_08", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU9 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_09", "T", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool GTU10 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_10", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU11 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_11", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU12 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_12", "T", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool GTU13 = IsVatProcMarkingSelectedInInvVch(inv_vch, "GTU_13", "T", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool WSTO_EE = IsVatProcMarkingSelectedInInvVch(inv_vch, "WSTO_EE", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool IED = IsVatProcMarkingSelectedInInvVch(inv_vch, "IED", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool SW = IsVatProcMarkingSelectedInInvVch(inv_vch, "SW", "C", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool EE = IsVatProcMarkingSelectedInInvVch(inv_vch, "EE", "C", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool TP = IsVatProcMarkingSelectedInInvVch(inv_vch, "TP", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool TTWNT = IsVatProcMarkingSelectedInInvVch(inv_vch, "TT_WNT", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool TTD = IsVatProcMarkingSelectedInInvVch(inv_vch, "TT_D", "C", tax_date, dtCLM_VatProceduralMarkingsSp,inv_vch_seq);
                        bool MRT = IsVatProcMarkingSelectedInInvVch(inv_vch, "MR_T", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool MRUZ = IsVatProcMarkingSelectedInInvVch(inv_vch, "MR_UZ", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool I42 = IsVatProcMarkingSelectedInInvVch(inv_vch, "I_42", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool I63 = IsVatProcMarkingSelectedInInvVch(inv_vch, "I_63", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool BSPV = IsVatProcMarkingSelectedInInvVch(inv_vch, "B_SPV", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool BSPVDOSTAWA = IsVatProcMarkingSelectedInInvVch(inv_vch, "B_SPV_DOSTAWA", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool BMPVPROWIZJA = IsVatProcMarkingSelectedInInvVch(inv_vch, "B_MPV_PROWIZJA", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        string proceduralmarkingreftype = (is_offset == "1" ? "V" : "C");
                        bool MPP = IsVatProcMarkingSelectedInInvVch(inv_vch, "MPP", proceduralmarkingreftype, tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);
                        bool BaseCorrection = IsVatProcMarkingSelectedInInvVch(inv_vch, "KorektaPodstawyOpodt", "C", tax_date, dtCLM_VatProceduralMarkingsSp, inv_vch_seq);

                        decimal K10 = GetColumnValue(number_for_tax_basis, number_for_tax, "10", "10", goods_value, sales_tax, is_offset);
                        decimal K11 = GetColumnValue(number_for_tax_basis, number_for_tax, "11", "11", goods_value, sales_tax, is_offset);
                        decimal K12 = GetColumnValue(number_for_tax_basis, number_for_tax, "12", "12", goods_value, sales_tax, is_offset);
                        decimal K13 = GetColumnValue(number_for_tax_basis, number_for_tax, "13", "13", goods_value, sales_tax, is_offset);
                        decimal K14 = GetColumnValue(number_for_tax_basis, number_for_tax, "14", "14", goods_value, sales_tax, is_offset);
                        decimal K15 = GetColumnValue(number_for_tax_basis, number_for_tax, "15", "15", goods_value, sales_tax, is_offset);
                        decimal K16 = GetColumnValue(number_for_tax_basis, number_for_tax, "16", "16", goods_value, sales_tax, is_offset);
                        decimal K17 = GetColumnValue(number_for_tax_basis, number_for_tax, "17", "17", goods_value, sales_tax, is_offset);
                        decimal K18 = GetColumnValue(number_for_tax_basis, number_for_tax, "18", "18", goods_value, sales_tax, is_offset);
                        decimal K19 = GetColumnValue(number_for_tax_basis, number_for_tax, "19", "19", goods_value, sales_tax, is_offset);
                        decimal K20 = GetColumnValue(number_for_tax_basis, number_for_tax, "20", "20", goods_value, sales_tax, is_offset);
                        decimal K21 = GetColumnValue(number_for_tax_basis, number_for_tax, "21", "21", goods_value, sales_tax, is_offset);
                        decimal K22 = GetColumnValue(number_for_tax_basis, number_for_tax, "22", "22", goods_value, sales_tax, is_offset);
                        decimal K23 = GetColumnValue(number_for_tax_basis, number_for_tax, "23", "23", goods_value, sales_tax, is_offset);
                        decimal K24 = GetColumnValue(number_for_tax_basis, number_for_tax, "24", "24", goods_value, sales_tax, is_offset);
                        decimal K25 = GetColumnValue(number_for_tax_basis, number_for_tax, "25", "25", goods_value, sales_tax, is_offset);
                        decimal K26 = GetColumnValue(number_for_tax_basis, number_for_tax, "26", "26", goods_value, sales_tax, is_offset);
                        decimal K27 = GetColumnValue(number_for_tax_basis, number_for_tax, "27", "27", goods_value, sales_tax, is_offset);
                        decimal K28 = GetColumnValue(number_for_tax_basis, number_for_tax, "28", "28", goods_value, sales_tax, is_offset);
                        decimal K29 = GetColumnValue(number_for_tax_basis, number_for_tax, "29", "29", goods_value, sales_tax, is_offset);
                        decimal K30 = GetColumnValue(number_for_tax_basis, number_for_tax, "30", "30", goods_value, sales_tax, is_offset);
                        decimal K31 = GetColumnValue(number_for_tax_basis, number_for_tax, "31", "31", goods_value, sales_tax, is_offset);
                        decimal K32 = GetColumnValue(number_for_tax_basis, number_for_tax, "32", "32", goods_value, sales_tax, is_offset);
                        decimal K33 = GetColumnValue(number_for_tax_basis, number_for_tax, "33", "33", goods_value, sales_tax, is_offset);
                        decimal K34 = GetColumnValue(number_for_tax_basis, number_for_tax, "34", "34", goods_value, sales_tax, is_offset);
                        decimal K35 = GetColumnValue(number_for_tax_basis, number_for_tax, "35", "35", goods_value, sales_tax, is_offset);
                        decimal K36 = GetColumnValue(number_for_tax_basis, number_for_tax, "36", "36", goods_value, sales_tax, is_offset);

                        var sales = rptVATManager.CreateJPK7MSalesRegister(SalesNumber, CountryOriginCodeTIN, CounterPartyNo, ContractorsName, SalesEvidence, IssueDate, SalesDate, DocumentType, GTU1, GTU2, GTU3, GTU4, GTU5, GTU6, GTU7, GTU8, GTU9, GTU10, GTU11, GTU12, GTU13, WSTO_EE, IED, SW, EE, TP, TTWNT, TTD, MRT, MRUZ, I42, I63, BSPV, BSPVDOSTAWA, BMPVPROWIZJA, MPP, BaseCorrection, K10, K11, K12, K13, K14, K15, K16, K17, K18, K19, K20, K21, K22, K23, K24, K25, K26, K27, K28, K29, K30, K31, K32, K33, K34, K35, K36, DueDate);

                        rptVATManager.AddJPK7MSalesRegister(sales);
                        //Tax due according to the records in the period to which JPK relates - the sum of the amounts from K_16, K_18, K_20, K_24, K_26, K_28, K_30, K_32, K_33 and K_34 reduced by the amount from K_35 and K_36, excluding the invoices referred to in art. . 109 section 3d act (marked with FP). 
                        //If none of the indicated elements has been completed in the records, then 0.00 should be provided
                        TotalTaxSales += (sales.K16 + sales.K18 + sales.K20 + sales.K24 + sales.K26 + sales.K28 + sales.K30 + sales.K32 + sales.K33 + sales.K34) - (sales.K35 + sales.K36);
                    }
                }

                if (rptVATManager.GetJPKV7MPurchaseRegister().Count > 0)
                {
                    var jPKV7MPurchaseControl = rptVATManager.CreateJPKV7MPurchaseControl(rptVATManager.GetJPKV7MPurchaseRegister().Count, TotalPurchaseTax);
                    rptVATManager.SetJPKV7MPurchaseControl(jPKV7MPurchaseControl);
                }

                if (rptVATManager.GetJPK7MSalesRegister().Count > 0)
                {
                    var jPKV7MSalesControl = rptVATManager.CreateJPKV7MSalesControl(rptVATManager.GetJPK7MSalesRegister().Count, TotalTaxSales);
                    rptVATManager.SetJPKV7MSalesControl(jPKV7MSalesControl);
                }

                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }

        }

        private bool IsVatProcMarkingSelectedInInvVch(string invVch, string procMarkingId, string pmRefType, DateTime taxDate, DataTable VatProceduralMarkings,int InvVchSeq)
        {
            DataRow row = Enumerable.AsEnumerable(VatProceduralMarkings).FirstOrDefault(x => (x["InvVch"] == DBNull.Value ? string.Empty : x["InvVch"].ToString()) == invVch
                                                             & (((x["VatProceduralMarkingId"] == DBNull.Value ? string.Empty : x["VatProceduralMarkingId"].ToString().Replace("(T)", "")) == procMarkingId & pmRefType == "T") ||
                                                             ((x["VatProceduralMarkingId"] == DBNull.Value ? string.Empty : x["VatProceduralMarkingId"].ToString().Replace("(V)", "")) == procMarkingId & pmRefType == "V") ||
                                                             ((x["VatProceduralMarkingId"] == DBNull.Value ? string.Empty : x["VatProceduralMarkingId"].ToString().Replace("(C)", "")) == procMarkingId & pmRefType == "C"))
                                                             & (x["TaxDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(x["TaxDate"])) == taxDate
                                                             & (Convert.ToInt32(x["InvVchSeq"].ToString())) == InvVchSeq);

            if (row != null && !row.IsNull("VatProceduralMarkingId"))
            {
                return true;
            }

            return false;
        }

        private decimal GetColumnValue(string NumberForTaxBasisFromSp,
                        string NumberForTaxFromSp,
                        string NumberForTaxBasis,
                        string NumberForTax,
                       decimal TaxBasis,
                       decimal SalesTax,
                        string IsOffset)
        {
            decimal returnValue = 0;
            decimal saleStax = 0;
            decimal taxBasis = 0;
            if (NumberForTaxFromSp == NumberForTax)
            { 
                saleStax = SalesTax;
            }

            if (NumberForTaxBasisFromSp == NumberForTaxBasis)
            {
                taxBasis = TaxBasis;
            }
            returnValue = saleStax + taxBasis;
            return returnValue;
        }

    }
}