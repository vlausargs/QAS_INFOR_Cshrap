//PROJECT NAME: Finance
//CLASS NAME: ChartAcctDelete.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Finance
{
    public class ChartAcctDeleteCRUD : IChartAcctDeleteCRUD
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;

        public ChartAcctDeleteCRUD(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExistsChecker existsChecker)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.existsChecker = existsChecker;
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ChartAcctDeleteSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public ICollectionLoadResponse Optional_Module1Select()
        {
            var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SpName","CAST (NULL AS NVARCHAR)"},
                    {"u0","[om].[ModuleName]"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ChartAcctDeleteSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(optional_module1LoadRequest);
        }

        public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
        {
            var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                items: optional_module1LoadResponse.Items);

            this.appDB.Insert(optional_module1InsertRequest);
        }

        public bool Tv_ALTGENForExists()
        {
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""));
        }

        public string Tv_ALTGEN1Load()
        {
            string ALTGEN_SpName = null;
            StringType _ALTGEN_SpName = DBNull.Value;

            var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ALTGEN_SpName,"[SpName]"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
            if (tv_ALTGEN1LoadResponse.Items.Count > 0)
            {
                ALTGEN_SpName = _ALTGEN_SpName;
            }

            return ALTGEN_SpName;
        }

        public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
        {
            var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"[SpName]","[SpName]"},
                },
                tableName: "#tv_ALTGEN",
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(tv_ALTGEN2LoadRequest);
        }

        public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
        {
            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                items: tv_ALTGEN2LoadResponse.Items);
            this.appDB.Delete(tv_ALTGEN2DeleteRequest);
        }

        public bool LedgerForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "ledger",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("ledger.acct = {0}", pChartAcct));
        }

        public bool JournalForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "journal",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("journal.acct = {0}", pChartAcct));
        }

        public bool Ana_LedgerForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "ana_ledger",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("ana_ledger.acct = {0}", pChartAcct));
        }

        public bool ApdrafttForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "apdraftt",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("apdraftt.draft_payable_acct = {0}", pChartAcct));
        }

        public bool ApparmsForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "apparms",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("apparms.acquisition_vat_acct = {0} OR apparms.ap_acct = {0} OR apparms.brokerage_acct = {0} OR apparms.comm_acct = {0} OR apparms.deposit_acct = {0} OR apparms.disc_acct = {0} OR apparms.draft_payable_acct = {0} OR apparms.duty_acct = {0} OR apparms.freight_acct = {0} OR apparms.insurance_acct = {0} OR apparms.local_frt_acct = {0} OR apparms.misc_acct = {0} OR apparms.pur_acct = {0} OR apparms.suspense_acct = {0} OR apparms.tax_acct = {0} OR apparms.unmatched_acct = {0} OR apparms.external_pur_acct = {0}", pChartAcct));
        }

        public bool AppmtdForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "appmtd",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("appmtd.disc_acct = {0}", pChartAcct));
        }

        public bool AptrxForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "aptrx",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("aptrx.ap_acct = {0}", pChartAcct));
        }

        public bool AptrxdForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "aptrxd",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("aptrxd.acct = {0}", pChartAcct));
        }

        public bool AptrxpForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "aptrxp",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("aptrxp.ap_acct = {0}", pChartAcct));
        }

        public bool AptrxrForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "aptrxr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("aptrxr.ap_acct = {0}", pChartAcct));
        }

        public bool AptxrdForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "aptxrd",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("aptxrd.acct = {0}", pChartAcct));
        }

        public bool ArdrafttForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "ardraftt",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("ardraftt.credit_acct = {0} OR ardraftt.debit_acct = {0}", pChartAcct));
        }

        public bool ArfinForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "arfin",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("arfin.ar_acct = {0} OR arfin.fin_acct = {0}", pChartAcct));
        }

        public bool ArinvForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "arinv",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("arinv.acct = {0}", pChartAcct));
        }

        public bool ArinvdForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "arinvd",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("arinvd.acct = {0}", pChartAcct));
        }

        public bool ArparmsForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "arparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("arparms.allow_acct = {0} OR arparms.ar_acct = {0} OR arparms.deposit_acct = {0} OR arparms.disc_acct = {0} OR arparms.draft_receivable_acct = {0} OR arparms.fin_acct = {0} OR arparms.freight_acct = {0} OR arparms.misc_acct = {0} OR arparms.prog_acct = {0} OR arparms.proj_acct = {0} OR arparms.sales_acct = {0} OR arparms.sales_disc_acct = {0}", pChartAcct));
        }

        public bool ArpmtdForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "arpmtd",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("arpmtd.allow_acct = {0} OR arpmtd.deposit_acct = {0} OR arpmtd.disc_acct = {0}", pChartAcct));
        }

        public bool ArtranForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "artran",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("artran.acct = {0}", pChartAcct));
        }

        public bool Bank_AddrForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "bank_addr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("bank_addr.draft_discounted_acct = {0} OR bank_addr.draft_remitted_acct = {0}", pChartAcct));
        }

        public bool Bank_HdrForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "bank_hdr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("bank_hdr.acct = {0}", pChartAcct));
        }

        public bool Chart_BpForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "chart_bp",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("chart_bp.acct = {0}", pChartAcct));
        }

        public bool Chart_DForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "chart_d",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("chart_d.acct = {0} OR chart_d.d_acct = {0}", pChartAcct));
        }

        public bool CommdueForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "commdue",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("commdue.acct = {0}", pChartAcct));
        }

        public bool CommtranForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "commtran",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("commtran.acct = {0}", pChartAcct));
        }

        public bool CurracctForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "curracct",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("curracct.apoff_acct = {0} OR curracct.aroff_acct = {0} OR curracct.gain_acct = {0} OR curracct.loss_acct = {0} OR curracct.non_ap_acct = {0} OR curracct.non_ar_acct = {0} OR curracct.ungain_acct = {0} OR curracct.unloss_acct = {0} OR curracct.vchoff_acct = {0}", pChartAcct));
        }

        public bool CurrparmsForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "currparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("currparms.apoff_acct = {0} OR currparms.aroff_acct = {0} OR currparms.gain_acct = {0} OR currparms.loss_acct = {0} OR currparms.non_ap_acct = {0} OR currparms.non_ar_acct = {0} OR currparms.ungain_acct = {0} OR currparms.unloss_acct = {0} OR currparms.vchoff_acct = {0}", pChartAcct));
        }

        public bool DcjmForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "dcjm",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("dcjm.acct = {0}", pChartAcct));
        }

        public bool DeptForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "dept",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("dept.dl_acct = {0} OR dept.fo_acct = {0} OR dept.vo_acct = {0}", pChartAcct));
        }

        public bool DiscountForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "discount",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("discount.disc_acct = {0}", pChartAcct));
        }

        public bool DistacctForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "distacct",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("distacct.cgs_acct = {0} OR distacct.cgs_fovhd_acct = {0} OR distacct.cgs_lbr_acct = {0} OR distacct.cgs_out_acct = {0} OR distacct.cgs_vovhd_acct = {0} OR distacct.fovhd_acct = {0} OR distacct.inv_acct = {0} OR distacct.lbr_acct = {0} OR distacct.out_acct = {0} OR distacct.sale_ds_acct = {0} OR distacct.sales_acct = {0} OR distacct.tr_fovhd_acct = {0} OR distacct.tr_inv_acct = {0} OR distacct.tr_lbr_acct = {0} OR distacct.tr_out_acct = {0} OR distacct.tr_vovhd_acct = {0} OR distacct.vovhd_acct = {0}", pChartAcct));
        }

        public bool Edi_Inv_HdrForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "edi_inv_hdr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("edi_inv_hdr.freight_acct = {0} OR edi_inv_hdr.misc_acct = {0}", pChartAcct));
        }

        public bool Edi_Inv_ItemForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "edi_inv_item",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("edi_inv_item.sales_acct = {0}", pChartAcct));
        }

        public bool Edi_Inv_StaxForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "edi_inv_stax",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("edi_inv_stax.stax_acct = {0}", pChartAcct));
        }

        public bool EmployeeForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "employee",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("employee.union_acct = {0} OR employee.wage_acct = {0}", pChartAcct));
        }

        public bool EndtypeForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "endtype",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("endtype.ar_acct = {0} OR endtype.cgs_fovhd_acct = {0} OR endtype.cgs_lbr_acct = {0} OR endtype.cgs_matl_acct = {0} OR endtype.cgs_out_acct = {0} OR endtype.cgs_vovhd_acct = {0} OR endtype.draft_receivable_acct = {0} OR endtype.sales_acct = {0} OR endtype.sales_ds_acct = {0}", pChartAcct));
        }

        public bool FaclassForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "faclass",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("faclass.gl_asst_acct = {0} OR faclass.gl_exp_acct = {0} OR faclass.gl_res_acct = {0}", pChartAcct));
        }

        public bool FadistForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "fadist",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("fadist.acct = {0}", pChartAcct));
        }

        public bool FaparmsForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "faparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("faparms.cash_acct = {0} OR faparms.gain_acct = {0} OR faparms.loss_acct = {0}", pChartAcct));
        }

        public bool IndcodeForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "indcode",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("indcode.wage_acct = {0}", pChartAcct));
        }

        public bool Inv_HdrForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "inv_hdr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("inv_hdr.freight_acct = {0} OR inv_hdr.misc_acct = {0}", pChartAcct));
        }

        public bool Inv_ItemForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "inv_item",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("inv_item.sales_acct = {0}", pChartAcct));
        }

        public bool Inv_StaxForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "inv_stax",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("inv_stax.stax_acct = {0}", pChartAcct));
        }

        public bool ItemlifoForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "itemlifo",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("itemlifo.fovhd_acct = {0} OR itemlifo.inv_acct = {0} OR itemlifo.lbr_acct = {0} OR itemlifo.out_acct = {0} OR itemlifo.vovhd_acct = {0}", pChartAcct));
        }

        public bool ItemlocForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "itemloc",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("itemloc.fovhd_acct = {0} OR itemloc.inv_acct = {0} OR itemloc.lbr_acct = {0} OR itemloc.out_acct = {0} OR itemloc.vovhd_acct = {0}", pChartAcct));
        }

        public bool JobForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "job",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("job.jcb_acct = {0} OR job.wip_acct = {0} OR job.wip_fovhd_acct = {0} OR job.wip_lbr_acct = {0} OR job.wip_out_acct = {0} OR job.wip_vovhd_acct = {0}", pChartAcct));
        }

        public bool ParmsForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "parms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("parms.cta_acct = {0}", pChartAcct));
        }

        public bool PitemhForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "pitemh",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("pitemh.non_inv_acct = {0}", pChartAcct));
        }

        public bool Po_BlnForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "po_bln",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("po_bln.non_inv_acct = {0}", pChartAcct));
        }

        public bool PoblnhForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "poblnh",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("poblnh.non_inv_acct = {0}", pChartAcct));
        }

        public bool PoitemForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "poitem",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("poitem.non_inv_acct = {0}", pChartAcct));
        }

        public bool PoparmsForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "poparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("poparms.ana_inv_acct = {0} OR poparms.brokerage_acct = {0} OR poparms.duty_acct = {0} OR poparms.freight_acct = {0} OR poparms.insurance_acct = {0} OR poparms.local_frt_acct = {0} OR poparms.voucher_acct = {0}", pChartAcct));
        }

        public bool PrbankForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "prbank",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("prbank.acct = {0}", pChartAcct));
        }

        public bool PrdecdForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "prdecd",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("prdecd.acct = {0} OR prdecd.exp_acct = {0}", pChartAcct));
        }

        public bool PreqitemForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "preqitem",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("preqitem.non_inv_acct = {0}", pChartAcct));
        }

        public bool ProdcodeForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "prodcode",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("prodcode.cycle_adj_acct = {0} OR prodcode.fmor_acct = {0} OR prodcode.inv_adj_acct = {0} OR prodcode.inv_pur_acct = {0} OR prodcode.jcb_acct = {0} OR prodcode.lc_inv_adj_acct = {0} OR prodcode.pcgs_acct = {0} OR prodcode.proj_ga_acct = {0} OR prodcode.proj_labr_acct = {0} OR prodcode.proj_matl_acct = {0} OR prodcode.proj_other_acct = {0} OR prodcode.proj_ovh_acct = {0} OR prodcode.ps_scrap_acct = {0} OR prodcode.vmor_acct = {0} OR prodcode.wip_acct = {0} OR prodcode.wip_fovhd_acct = {0} OR prodcode.wip_lbr_acct = {0} OR prodcode.wip_out_acct = {0} OR prodcode.wip_vovhd_acct = {0}", pChartAcct));
        }

        public bool ProdvarForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "prodvar",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("prodvar.bcv_acct = {0} OR prodvar.dcv_acct = {0} OR prodvar.fcv_acct = {0} OR prodvar.icv_acct = {0} OR prodvar.lfcv_acct = {0} OR prodvar.flouv_acct = {0} OR prodvar.fmcouv_acct = {0} OR prodvar.fmouv_acct = {0} OR prodvar.lrv_acct = {0} OR prodvar.luv_acct = {0} OR prodvar.muv_acct = {0} OR prodvar.pcv_acct = {0} OR prodvar.slr_acct = {0} OR prodvar.srv_acct = {0} OR prodvar.vlouv_acct = {0} OR prodvar.vmcouv_acct = {0} OR prodvar.vmouv_acct = {0}", pChartAcct));
        }

        public bool Proj_WipForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "proj_wip",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("proj_wip.ga_acct##1 = {0} OR proj_wip.ga_acct##2 = {0} OR proj_wip.labor_acct##1 = {0} OR proj_wip.labor_acct##2 = {0} OR proj_wip.matl_acct##1 = {0} OR proj_wip.matl_acct##2 = {0} OR proj_wip.other_acct##1 = {0} OR proj_wip.other_acct##2 = {0} OR proj_wip.ovh_acct##1 = {0} OR proj_wip.ovh_acct##2 = {0}", pChartAcct));
        }

        public bool ProjparmForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "projparm",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("projparm.app_ga_acct = {0} OR projparm.app_ovh_acct = {0} OR projparm.labor_acct = {0} OR projparm.material_acct = {0} OR projparm.other_acct = {0} OR projparm.ret_rev_acct = {0} OR projparm.ub_rev_acct = {0} OR projparm.ubret_rev_acct = {0}", pChartAcct));
        }

        public bool PrparmsForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "prparms",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("prparms.cpie_acct = {0} OR prparms.cpil_acct = {0} OR prparms.eic_acct = {0} OR prparms.garn_acct = {0} OR prparms.hol_acct = {0} OR prparms.loan_acct = {0} OR prparms.other_acct = {0} OR prparms.rete_acct = {0} OR prparms.retl_acct = {0} OR prparms.sick_acct = {0} OR prparms.vac_acct = {0}", pChartAcct));
        }

        public bool PrtaxtForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "prtaxt",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("prtaxt.emp_fica_l_acct = {0} OR prtaxt.emp_med_l_acct = {0} OR prtaxt.empr_fica_e_acct = {0} OR prtaxt.empr_fica_l_acct = {0} OR prtaxt.empr_med_e_acct = {0} OR prtaxt.empr_med_l_acct = {0} OR prtaxt.fui_e_acct = {0} OR prtaxt.fui_l_acct = {0} OR prtaxt.ots_l_acct = {0} OR prtaxt.sui_e_acct = {0} OR prtaxt.sui_l_acct = {0} OR prtaxt.suppl_ben_e_acct = {0} OR prtaxt.suppl_ben_l_acct = {0} OR prtaxt.tax_l_acct = {0}", pChartAcct));
        }

        public bool PrtrxdForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "prtrxd",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("prtrxd.acct = {0}", pChartAcct));
        }

        public bool ReasonForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "reason",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("reason.inv_adj_acct = {0}", pChartAcct));
        }

        public bool Reason1ForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "reason",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("reason.inv_adj_acct = {0}", pChartAcct));
        }

        public bool RmaparmsForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "rmaparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("rmaparms.rest_acct = {0}", pChartAcct));
        }

        public bool SfcparmsForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "sfcparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("sfcparms.jcbo_acct = {0}", pChartAcct));
        }

        public string Parms1Load()
        {
            string ParmsSite = null;
            SiteType _ParmsSite = DBNull.Value;

            var parms1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ParmsSite,"parms.site"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "parms",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var parms1LoadResponse = this.appDB.Load(parms1LoadRequest);
            if (parms1LoadResponse.Items.Count > 0)
            {
                ParmsSite = _ParmsSite;
            }

            return ParmsSite;
        }

        public bool SitenetForExists(string pChartAcct, string ParmsSite)
        {
            return existsChecker.Exists(tableName: "sitenet",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("((sitenet.from_site = {1}) AND (sitenet.entity_clr_ship_acct = {0} OR sitenet.entity_ar_acct = {0} OR sitenet.entity_sales_acct = {0} OR sitenet.entity_profit_acct = {0} OR sitenet.ar_liab_acct = {0} OR sitenet.ap_asset_acct = {0} OR sitenet.entity_cos_inv_acct = {0} OR sitenet.entity_cos_lbr_acct = {0} OR sitenet.entity_cos_fov_acct = {0} OR sitenet.entity_cos_vov_acct = {0} OR sitenet.entity_cos_out_acct = {0})) OR ((sitenet.to_site = {1}) AND (sitenet.entity_clr_recv_acct = {0} OR sitenet.entity_ap_acct = {0} OR sitenet.entity_cost_acct = {0} OR sitenet.entity_val_var_acct = {0} OR sitenet.ar_asset_acct = {0} OR sitenet.ap_liab_acct = {0}))", pChartAcct, ParmsSite));
        }

        public bool TaxcodeForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "taxcode",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("taxcode.acquisition_vat_acct = {0} OR taxcode.ap_acct = {0} OR taxcode.ar_acct = {0}", pChartAcct));
        }

        public bool Vch_DistForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "vch_dist",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("vch_dist.acct = {0}", pChartAcct));
        }

        public bool Vch_HdrForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "vch_hdr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("vch_hdr.ap_acct = {0}", pChartAcct));
        }

        public bool Vch_ItemForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "vch_item",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("vch_item.non_inv_acct = {0}", pChartAcct));
        }

        public bool Vch_PrForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "vch_pr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("vch_pr.freight_acct = {0} OR vch_pr.misc_acct = {0} OR vch_pr.suspense_acct = {0} OR vch_pr.unmatched_acct = {0}", pChartAcct));
        }

        public bool Vch_StaxForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "vch_stax",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("vch_stax.stax_acct = {0}", pChartAcct));
        }

        public bool VendcatForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "vendcat",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("vendcat.ap_acct = {0} OR vendcat.draft_payable_acct = {0} OR vendcat.pur_acct = {0}", pChartAcct));
        }

        public bool VendorForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "vendor",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("vendor.pur_acct = {0}", pChartAcct));
        }

        public bool WcForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "wc",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("wc.flouv_acct = {0} OR wc.fmco_acct = {0} OR wc.fmcouv_acct = {0} OR wc.fmouv_acct = {0} OR wc.lrv_acct = {0} OR wc.luv_acct = {0} OR wc.muv_acct = {0} OR wc.vlouv_acct = {0} OR wc.vmco_acct = {0} OR wc.vmcouv_acct = {0} OR wc.vmouv_acct = {0} OR wc.wip_fovhd_acct = {0} OR wc.wip_lbr_acct = {0} OR wc.wip_matl_acct = {0} OR wc.wip_out_acct = {0} OR wc.wip_vovhd_acct = {0}", pChartAcct));
        }

        public bool Inv_Item_SurchargeForExists(string pChartAcct)
        {
            return existsChecker.Exists(tableName: "inv_item_surcharge",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("surcharge_acct = {0}", pChartAcct));
        }

        public (int? ReturnCode,
            string Infobar)
        AltExtGen_ChartAcctDeleteSp(
            string AltExtGenSp,
            int? pNewRecord = 0,
            string pChartAcct = null,
            string Infobar = null)
        {
            ListYesNoType _pNewRecord = pNewRecord;
            AcctType _pChartAcct = pChartAcct;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "pNewRecord", _pNewRecord, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pChartAcct", _pChartAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }

    }
}
