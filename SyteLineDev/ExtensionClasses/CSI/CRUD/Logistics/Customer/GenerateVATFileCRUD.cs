//PROJECT NAME: Logistics
//CLASS NAME: GenerateVATFile.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
    public class GenerateVATFileCRUD : IGenerateVATFileCRUD
    {
        readonly IApplicationDB appDB;

        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExistsChecker existsChecker;
        readonly IDataTableUtil dataTableUtil;
        readonly IVariableUtil variableUtil;
        readonly ISplitString iSplitString;
        readonly IStringUtil stringUtil;

        public GenerateVATFileCRUD(IApplicationDB appDB,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExistsChecker existsChecker,
            IDataTableUtil dataTableUtil,
            IVariableUtil variableUtil,
            ISplitString iSplitString,
            IStringUtil stringUtil)
        {
            this.appDB = appDB;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.existsChecker = existsChecker;
            this.dataTableUtil = dataTableUtil;
            this.variableUtil = variableUtil;
            this.iSplitString = iSplitString;
            this.stringUtil = stringUtil;
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GenerateVATFileSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GenerateVATFileSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
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
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName: "#tv_ALTGEN",
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

        public (int? TaxSystem, string TaxMode) Tax_SystemLoad()
        {
            int? TaxSystem = null;
            TaxSystemType _TaxSystem = DBNull.Value;
            string TaxMode = null;
            TaxModeType _TaxMode = DBNull.Value;

            var tax_systemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_TaxSystem,"tax_system"},
                    {_TaxMode,"tax_mode"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "tax_system",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("tax_mode = 'I'"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tax_systemLoadResponse = this.appDB.Load(tax_systemLoadRequest);
            if (tax_systemLoadResponse.Items.Count > 0)
            {
                TaxSystem = _TaxSystem;
                TaxMode = _TaxMode;
            }

            return (TaxSystem, TaxMode);
        }

        public (int? TaxSystem, string TaxMode) Tax_System1Load()
        {
            int? TaxSystem = null;
            TaxSystemType _TaxSystem = DBNull.Value;
            string TaxMode = null;
            TaxModeType _TaxMode = DBNull.Value;

            var tax_system1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_TaxSystem,"tax_system"},
                    {_TaxMode,"tax_mode"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "tax_system",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tax_system1LoadResponse = this.appDB.Load(tax_system1LoadRequest);
            if (tax_system1LoadResponse.Items.Count > 0)
            {
                TaxSystem = _TaxSystem;
                TaxMode = _TaxMode;
            }

            return (TaxSystem, TaxMode);
        }

        public string CoparmsLoad()
        {
            string VATExportLogicalFolder = null;
            AuthorizationObjectNameType _VATExportLogicalFolder = DBNull.Value;

            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_VATExportLogicalFolder,"CN_vat_export_dir"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "coparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
            if (coparmsLoadResponse.Items.Count > 0)
            {
                VATExportLogicalFolder = _VATExportLogicalFolder;
            }

            return VATExportLogicalFolder;
        }

        public string LanguageidsLoad(string pLanguage)
        {
            string MessageLanguage = null;
            MessageLanguageType _MessageLanguage = DBNull.Value;

            var LanguageIDsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_MessageLanguage,"LocaleID"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "LanguageIDs",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("LanguageID = {0}", pLanguage),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var LanguageIDsLoadResponse = this.appDB.Load(LanguageIDsLoadRequest);
            if (LanguageIDsLoadResponse.Items.Count > 0)
            {
                MessageLanguage = _MessageLanguage;
            }

            return MessageLanguage;
        }

        public ICollectionLoadResponse InvoiceSelect(string InvoiceList)
        {
            //Please Generate the bounce for this function: SplitString.
            iSplitString.SplitStringFn("~", InvoiceList);

            var InvoiceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"InvNum","Element"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#fnt_SplitString",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(InvoiceLoadRequest);
        }

        public void InvoiceInsert(ICollectionLoadResponse InvoiceLoadResponse)
        {
            var InvoiceInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Invoice",
                items: InvoiceLoadResponse.Items);

            this.appDB.Insert(InvoiceInsertRequest);
        }

        public bool Tv_InvoiceForExists(string FileType)
        {
            return existsChecker.Exists(tableName: "#tv_Invoice",
                fromClause: collectionLoadRequestFactory.Clause(@" AS inv INNER JOIN arinv ON LTRIM(RTRIM(inv.InvNum)) = LTRIM(RTRIM(arinv.inv_num))
					AND arinv.inv_seq = 0"),
                whereClause: collectionLoadRequestFactory.Clause("CN_vat_inv_num IS NOT NULL AND CN_vat_status = 'C'"));
        }

        public ICollectionLoadResponse Tv_Invoice1Select()
        {
            var inv_CrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"arinv.inv_num","arinv.inv_num"},
                    {"arinv.CN_vat_inv_num","arinv.CN_vat_inv_num"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_Invoice",
                fromClause: collectionLoadRequestFactory.Clause(@" AS inv INNER JOIN arinv ON LTRIM(RTRIM(inv.InvNum)) = LTRIM(RTRIM(arinv.inv_num))
					AND inv_seq = 0"),
                whereClause: collectionLoadRequestFactory.Clause("CN_vat_inv_num IS NOT NULL AND CN_vat_status = 'C'"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            return this.appDB.Load(inv_CrsLoadRequestForCursor);
        }
        public bool Tv_Invoice2ForExists(string FileType)
        {
            return existsChecker.Exists(tableName: "#tv_Invoice AS inv",
                fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN arinv ON LTRIM(RTRIM(inv.InvNum)) = LTRIM(RTRIM(arinv.inv_num))
					AND arinv.inv_seq = 0 INNER JOIN Customer AS cus ON cus.cust_num = arinv.cust_num INNER JOIN CustAddr AS cusa ON cusa.cust_num = cus.cust_num
					AND cusa.cust_seq = 0
					AND cus.cust_seq = 0"),
                whereClause: collectionLoadRequestFactory.Clause("arinv.CN_vat_status = 'R'"));
        }

        public string BANK_HdrasbhLoad()
        {
            string SellerBankAccount = null;
            StringType _SellerBankAccount = DBNull.Value;

            var BANK_HDRASbhLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_SellerBankAccount,"ISNULL(bh.CN_long_bank_acct_no, bh.bank_acct_no)"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "BANK_HDR AS bh",
                fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN coparms AS cp ON bh.bank_code = cp.CN_vat_general_bank_code"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var BANK_HDRASbhLoadResponse = this.appDB.Load(BANK_HDRASbhLoadRequest);
            if (BANK_HDRASbhLoadResponse.Items.Count > 0)
            {
                SellerBankAccount = _SellerBankAccount;
            }

            return SellerBankAccount;
        }

        public ICollectionLoadResponse Tv_Invoiceasinv1Select(int? TaxSystem)
        {
            var inv_CrsLoadStatementRequestForCursor = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"arinv.inv_num","arinv.inv_num"},
                    {"arinv.inv_date","arinv.inv_date"},
                    {"arinv.co_num","arinv.co_num"},
                    {"cusa.name","cusa.name"},
                    {"col4",$"CASE WHEN {variableUtil.GetQuotedValue<int?>(TaxSystem)} = 1 THEN cus.tax_reg_num1 ELSE cus.tax_reg_num2 END"},
                    {"AddressAndPhone","dbo.FormatAddressForCP(cusa.cust_num, 0) + '/' + ISNULL(cus.phone##3, '')"},
                    {"col6","ISNULL(cus.CN_long_bank_acct_no, cus.bank_acct_no)"},
                    {"arinv.CN_comment","arinv.CN_comment"},
                },
                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
					FROM #tv_Invoice AS inv
					INNER JOIN
					arinv
					ON LTRIM(RTRIM(inv.InvNum)) = LTRIM(RTRIM(arinv.inv_num))
					AND arinv.inv_seq = 0
					INNER JOIN
					Customer AS cus
					ON cus.cust_num = arinv.cust_num
					AND cus.cust_seq = 0
					INNER JOIN
					CustAddr AS cusa
					ON cusa.cust_num = cus.cust_num
					AND cusa.cust_seq = 0
					WHERE arinv.CN_vat_status = 'R'"));

            return this.appDB.Load(inv_CrsLoadStatementRequestForCursor);
        }
        public int? Inv_ItemLoad(string InvNum)
        {
            int? DetailCount = null;
            IntType _DetailCount = DBNull.Value;

            var inv_itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_DetailCount,"COUNT(*)"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "inv_item",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("inv_num = {0} AND inv_item.inv_seq = 0", InvNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var inv_itemLoadResponse = this.appDB.Load(inv_itemLoadRequest);
            if (inv_itemLoadResponse.Items.Count > 0)
            {
                DetailCount = _DetailCount;
            }

            return DetailCount;
        }

        public ICollectionLoadResponse ArinvSelect(string InvNum, int? TaxSystem, string TaxMode)
        {
            var invitem_CrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"col0","CAST (NULL AS NVARCHAR)"},
                    {"u_m","item.u_m"},
                    {"qty_invoiced","inv_item.qty_invoiced"},
                    {"col1","CAST (NULL AS DECIMAL)"},
                    {"col2","CAST (NULL AS DECIMAL)"},
                    {"col3","CAST (NULL AS DECIMAL)"},
                    {"col4","CAST (NULL AS DECIMAL)"},
                    {"col5","CAST (NULL AS DECIMAL)"},
                    {"disc","inv_item.disc"},
                    {"col6","CAST (NULL AS DECIMAL)"},
                    {"col7","CAST (NULL AS INT)"},
                    {"CN_item_tax_category","item.CN_item_tax_category"},
                    {"u0","item_lang.description"},
                    {"u1","item.description"},
                    {"u2","co.include_tax_in_price"},
                    {"u3","arinv.include_tax_in_price"},
                    {"u4","coitem.price"},
                    {"u5","inv_item.price"},
                    {"u6","tx.tax_rate"},
                    {"u7","inv_item.disc"},
                    {"u8","tx.tax_discount"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "arinv",
                fromClause: collectionLoadRequestFactory.Clause(@" inner join inv_item on inv_item.inv_num = arinv.inv_num
					and inv_item.inv_seq = 0
					and arinv.inv_seq = 0 inner join item on item.item = inv_item.item left outer join item_lang on item.item = item_lang.item left outer join co on co.co_num = arinv.co_num left outer join coitem on inv_item.co_num = coitem.co_num
					and inv_item.co_line = coitem.co_line
					and inv_item.co_release = coitem.co_release left outer join taxcode as tx on tx.tax_code = (case when {0} = 1 then case when {1} = 'a' then isnull(coitem.tax_code1, co.tax_code1) else coitem.tax_code1 end else case when {1} = 'a' then isnull(coitem.tax_code2, co.tax_code2) else coitem.tax_code2 end end)
					and tx.tax_system = {0}", TaxSystem, TaxMode),
                whereClause: collectionLoadRequestFactory.Clause("arinv.inv_num = {0}", InvNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            return this.appDB.Load(invitem_CrsLoadRequestForCursor);
        }
        public ICollectionLoadResponse Arinv1Select(string InvNum)
        {
            var arinv1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"CN_vat_status","arinv.CN_vat_status"},
                }, 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName: "arinv",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("inv_num = {0} AND inv_seq = 0", InvNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(arinv1LoadRequest);
        }

        public void Arinv1Update(ICollectionLoadResponse arinv1LoadResponse)
        {
            foreach (var arinv1Item in arinv1LoadResponse.Items)
            {
                arinv1Item.SetValue<string>("CN_vat_status", "P");
            };

            var arinv1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "arinv",
                items: arinv1LoadResponse.Items);

            this.appDB.Update(arinv1RequestUpdate);
        }

        public (int? ReturnCode,
            string VATExportLogicalFolder,
            string FileName,
            string FileContent,
            string Infobar)
        AltExtGen_GenerateVATFileSp(
            string AltExtGenSp,
            string InvoiceList,
            string FileType,
            string pLanguage,
            string VATExportLogicalFolder = null,
            string FileName = null,
            string FileContent = null,
            string Infobar = null)
        {
            StringType _InvoiceList = InvoiceList;
            StringType _FileType = FileType;
            MessageLanguageType _pLanguage = pLanguage;
            AuthorizationObjectNameType _VATExportLogicalFolder = VATExportLogicalFolder;
            StringType _FileName = FileName;
            VeryLongListType _FileContent = FileContent;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "InvoiceList", _InvoiceList, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FileType", _FileType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pLanguage", _pLanguage, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VATExportLogicalFolder", _VATExportLogicalFolder, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FileContent", _FileContent, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                VATExportLogicalFolder = _VATExportLogicalFolder;
                FileName = _FileName;
                FileContent = _FileContent;
                Infobar = _Infobar;

                return (Severity, VATExportLogicalFolder, FileName, FileContent, Infobar);
            }
        }

    }
}