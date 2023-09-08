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
    public class GenerateVATFile : IGenerateVATFile
    {
        readonly IApplicationDB appDB;

        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IFormatAddressForCP iFormatAddressForCP;
        readonly ITransactionFactory transactionFactory;
        readonly IStringOfLanguage iStringOfLanguage;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IDataTableUtil dataTableUtil;
        readonly ISplitString iSplitString;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly IRaiseError raiseError;
        readonly IUserName2 iUserName;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;

        public GenerateVATFile(IApplicationDB appDB,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IFormatAddressForCP iFormatAddressForCP,
            ITransactionFactory transactionFactory,
            IStringOfLanguage iStringOfLanguage,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IDataTableUtil dataTableUtil,
            ISplitString iSplitString,
            IDateTimeUtil dateTimeUtil,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            IRaiseError raiseError,
            IUserName2 iUserName,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp)
        {
            this.appDB = appDB;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iFormatAddressForCP = iFormatAddressForCP;
            this.transactionFactory = transactionFactory;
            this.iStringOfLanguage = iStringOfLanguage;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.dataTableUtil = dataTableUtil;
            this.iSplitString = iSplitString;
            this.dateTimeUtil = dateTimeUtil;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.raiseError = raiseError;
            this.iUserName = iUserName;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
        }

        public (
            int? ReturnCode,
            string VATExportLogicalFolder,
            string FileName,
            string FileContent,
            string Infobar)
        GenerateVATFileSp(
            string InvoiceList,
            string FileType,
            string pLanguage,
            string VATExportLogicalFolder = null,
            string FileName = null,
            string FileContent = null,
            string Infobar = null)
        {

            AuthorizationObjectNameType _VATExportLogicalFolder = VATExportLogicalFolder;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            string InvNum = null;
            string CoNum = null;
            string CustomerName = null;
            string CustomerVATTaxNumber = null;
            string AddressAndPhone = null;
            string CustomerBankAccount = null;
            string Comment = null;
            string Reviewer = null;
            string Recipient = null;
            string ItemofList = null;
            DateTime? InvDate = null;
            StringType _SellerBankAccount = DBNull.Value;
            string SellerBankAccount = null;
            int? ObjFileSystem = null;
            int? ObjTextStream = null;
            int? ObjErrorObject = null;
            string strErrorMessage = null;
            int? ReturnHandler = null;
            string FileAndPath = null;
            string Connector = null;
            string LineBreak = null;
            string FileHeader = null;
            string InvoiceHeader = null;
            IntType _DetailCount = DBNull.Value;
            int? DetailCount = null;
            StringType _Detail = DBNull.Value;
            string Detail = null;
            string CNVatInvNum = null;
            string Specification = null;
            string ItemTaxCategory = null;
            decimal? Quantity = null;
            decimal? AmountWithoutTax = null;
            decimal? TaxRate = null;
            decimal? DiscountAmount = null;
            decimal? TaxAmount = null;
            decimal? DiscountTaxAmount = null;
            decimal? Discount = null;
            string ItemDesc = null;
            string UM = null;
            decimal? UnitPrice = null;
            int? IncludeTaxInPrice = null;
            MessageLanguageType _MessageLanguage = DBNull.Value;
            string MessageLanguage = null;
            string CreateSalesMemo = null;
            string VoidSalesMemo = null;
            TaxSystemType _TaxSystem = DBNull.Value;
            int? TaxSystem = null;
            TaxModeType _TaxMode = DBNull.Value;
            string TaxMode = null;
            ICollectionLoadRequest inv_CrsLoadRequestForCursor = null;
            ICollectionLoadResponse inv_CrsLoadResponseForCursor = null;
            ICollectionLoadStatementRequest inv_CrsLoadStatementRequestForCursor = null;
            int inv_Crs_CursorFetch_Status = -1;
            int inv_Crs_CursorCounter = -1;
            ICollectionLoadRequest invitem_CrsLoadRequestForCursor = null;
            ICollectionLoadResponse invitem_CrsLoadResponseForCursor = null;
            int invitem_Crs_CursorFetch_Status = -1;
            int invitem_Crs_CursorCounter = -1;
            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GenerateVATFileSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
            )
            {
                //BEGIN
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

                #region CRUD LoadToRecord
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
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("GenerateVATFileSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                    items: optional_module1LoadResponse.Items);

                this.appDB.Insert(optional_module1InsertRequest);
                #endregion InsertByRecords

                while (existsChecker.Exists(tableName: "#tv_ALTGEN",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""))
                )
                {
                    //BEGIN

                    #region CRUD LoadToVariable
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
                    #endregion  LoadToVariable

                    var ALTGEN = AltExtGen_GenerateVATFileSp(ALTGEN_SpName,
                        InvoiceList,
                        FileType,
                        pLanguage,
                        VATExportLogicalFolder,
                        FileName,
                        FileContent,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        VATExportLogicalFolder = _VATExportLogicalFolder;
                        return (ALTGEN_Severity, VATExportLogicalFolder, FileName, FileContent, Infobar);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    #region CRUD LoadToRecord
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
                    var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD DeleteByRecord
                    var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                        items: tv_ALTGEN2LoadResponse.Items);
                    this.appDB.Delete(tv_ALTGEN2DeleteRequest);
                    #endregion DeleteByRecord

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
                    //END

                }
                //END

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_GenerateVATFileSp") != null)
            {
                var EXTGEN = AltExtGen_GenerateVATFileSp("dbo.EXTGEN_GenerateVATFileSp",
                    InvoiceList,
                    FileType,
                    pLanguage,
                    VATExportLogicalFolder,
                    FileName,
                    FileContent,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.VATExportLogicalFolder, EXTGEN.FileName, EXTGEN.FileContent, EXTGEN.Infobar);
                }
            }

            if (InvoiceList == null)
            {
                return (Severity, VATExportLogicalFolder, FileName, FileContent, Infobar);
            }
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @Invoice TABLE (
				    InvNum InvNumType);
				SELECT * into #tv_Invoice from @Invoice");

            #region CRUD LoadToVariable
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
            #endregion  LoadToVariable

            if (TaxSystem == null)
            {

                #region CRUD LoadToVariable
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
                #endregion  LoadToVariable

            }
            Severity = 0;
            FileAndPath = "";
            Comment = "";
            Reviewer = "";
            Recipient = convertToUtil.ToString(this.iUserName.UserName2Sp());
            ItemofList = "";
            Connector = "~~";
            LineBreak = convertToUtil.ToString(stringUtil.Concat(stringUtil.Char(13), stringUtil.Char(10)));
            FileContent = "";

            #region CRUD LoadToVariable
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
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
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
            #endregion  LoadToVariable

            if (MessageLanguage == null)
            {
                MessageLanguage = "1033";

            }
            CreateSalesMemo = this.iStringOfLanguage.StringOfLanguageFn(
                "@!CHSCreateSalesMemo",
                MessageLanguage);
            VoidSalesMemo = this.iStringOfLanguage.StringOfLanguageFn(
                "@!CHSVoidSalesMemo",
                MessageLanguage);
            if (VATExportLogicalFolder == null || sQLUtil.SQLEqual(stringUtil.Len(VATExportLogicalFolder), 0) == true)
            {
                //BEGIN

                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "E=NoExist0",
                    Parm1: "@coparms.CN_vat_export_dir");
                Severity = MsgApp.ReturnCode;
                Infobar = MsgApp.Infobar;

                #endregion ExecuteMethodCall

                return (Severity, VATExportLogicalFolder, FileName, FileContent, Infobar);//END

            }
            //Please Generate the bounce for this function: SplitString.
            iSplitString.SplitStringFn("~", InvoiceList);

            #region CRUD LoadToRecord
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
            var InvoiceLoadResponse = this.appDB.Load(InvoiceLoadRequest);
            #endregion  LoadToRecord

            #region CRUD InsertByRecords
            var InvoiceInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Invoice",
                items: InvoiceLoadResponse.Items);

            this.appDB.Insert(InvoiceInsertRequest);
            #endregion InsertByRecords

            this.transactionFactory.BeginTransaction("");
            if (sQLUtil.SQLEqual(FileType, "V") == true && existsChecker.Exists(tableName: "#tv_Invoice",
                fromClause: collectionLoadRequestFactory.Clause(@" AS inv INNER JOIN arinv ON LTRIM(RTRIM(inv.InvNum)) = LTRIM(RTRIM(arinv.inv_num))
					AND arinv.inv_seq = 0"),
                whereClause: collectionLoadRequestFactory.Clause("CN_vat_inv_num IS NOT NULL AND CN_vat_status = 'C'"))
            )
            {
                //BEGIN
                FileName = stringUtil.Concat("Void", stringUtil.Replace(
                    stringUtil.Replace(
                        stringUtil.Replace(
                            dateTimeUtil.ConvertToString(scalarFunction.Execute<DateTime>("GETDATE"), "yyyy-MM-dd HH:mm:ss"),
                            "-",
                            ""),
                        " ",
                        ""),
                    ":",
                    ""), ".txt");
                FileAndPath = stringUtil.Concat(VATExportLogicalFolder, "\\", FileName);

                if (sQLUtil.SQLEqual(ReturnHandler, 0) == true)
                {
                    ObjErrorObject = ObjFileSystem;
                    strErrorMessage = stringUtil.Concat("Creating file ", FileAndPath);

                }
                FileHeader = stringUtil.Concat("SJJK0102~~", VoidSalesMemo);
                FileHeader = stringUtil.Concat(FileHeader, LineBreak);
                FileHeader = stringUtil.Concat(FileHeader, LineBreak);
                FileHeader = stringUtil.Concat(FileHeader, LineBreak);
                FileContent = stringUtil.Concat(FileContent, FileHeader);
                #region Cursor Statement

                #region CRUD LoadToRecord
                inv_CrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
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
                #endregion  LoadToRecord

                #endregion Cursor Statement
                inv_CrsLoadResponseForCursor = this.appDB.Load(inv_CrsLoadRequestForCursor);
                inv_Crs_CursorFetch_Status = inv_CrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                inv_Crs_CursorCounter = -1;

                while (sQLUtil.SQLEqual(Severity, 0) == true)
                {
                    //BEGIN
                    inv_Crs_CursorCounter++;
                    if (inv_CrsLoadResponseForCursor.Items.Count > inv_Crs_CursorCounter)
                    {
                        InvNum = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<string>(0);
                        CNVatInvNum = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<string>(1);
                    }
                    inv_Crs_CursorFetch_Status = (inv_Crs_CursorCounter == inv_CrsLoadResponseForCursor.Items.Count ? -1 : 0);

                    if (sQLUtil.SQLEqual(inv_Crs_CursorFetch_Status, -1) == true)
                    {

                        break;

                    }
                    FileContent = stringUtil.Concat(FileContent, CNVatInvNum, LineBreak);
                    //END

                }
                //Deallocate Cursor inv_Crs
                //END

            }
            else
            {
                if (sQLUtil.SQLEqual(FileType, "C") == true && existsChecker.Exists(tableName: "#tv_Invoice AS inv",
                    fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN arinv ON LTRIM(RTRIM(inv.InvNum)) = LTRIM(RTRIM(arinv.inv_num))
						AND arinv.inv_seq = 0 INNER JOIN Customer AS cus ON cus.cust_num = arinv.cust_num INNER JOIN CustAddr AS cusa ON cusa.cust_num = cus.cust_num
						AND cusa.cust_seq = 0
						AND cus.cust_seq = 0"),
                    whereClause: collectionLoadRequestFactory.Clause("arinv.CN_vat_status = 'R'"))
                )
                {
                    //BEGIN
                    FileName = stringUtil.Concat("Create", stringUtil.Replace(
                        stringUtil.Replace(
                            stringUtil.Replace(
                                dateTimeUtil.ConvertToString(scalarFunction.Execute<DateTime>("GETDATE"), "yyyy-MM-dd HH:mm:ss"),
                                "-",
                                ""),
                            " ",
                            ""),
                        ":",
                        ""), ".txt");
                    FileAndPath = stringUtil.Concat(VATExportLogicalFolder, "\\", FileName);

                    FileHeader = stringUtil.Concat("SJJK0101~~", CreateSalesMemo);
                    FileHeader = stringUtil.Concat(FileHeader, LineBreak);
                    FileHeader = stringUtil.Concat(FileHeader, LineBreak);
                    FileHeader = stringUtil.Concat(FileHeader, LineBreak);
                    FileContent = stringUtil.Concat(FileContent, FileHeader);

                    #region CRUD LoadToVariable
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
                    #endregion  LoadToVariable

                    #region Cursor Statement

                    #region CRUD LoadArbitrary
                    inv_CrsLoadStatementRequestForCursor = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
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

                    #endregion  LoadArbitrary

                    #endregion Cursor Statement
                    inv_CrsLoadResponseForCursor = this.appDB.Load(inv_CrsLoadStatementRequestForCursor);
                    inv_Crs_CursorFetch_Status = inv_CrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                    inv_Crs_CursorCounter = -1;

                    while (sQLUtil.SQLEqual(Severity, 0) == true)
                    {
                        //BEGIN
                        inv_Crs_CursorCounter++;
                        if (inv_CrsLoadResponseForCursor.Items.Count > inv_Crs_CursorCounter)
                        {
                            InvNum = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<string>(0);
                            InvDate = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<DateTime?>(1);
                            CoNum = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<string>(2);
                            CustomerName = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<string>(3);
                            CustomerVATTaxNumber = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<string>(4);
                            AddressAndPhone = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<string>(5);
                            CustomerBankAccount = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<string>(6);
                            Comment = inv_CrsLoadResponseForCursor.Items[inv_Crs_CursorCounter].GetValue<string>(7);
                        }
                        inv_Crs_CursorFetch_Status = (inv_Crs_CursorCounter == inv_CrsLoadResponseForCursor.Items.Count ? -1 : 0);

                        if (sQLUtil.SQLEqual(inv_Crs_CursorFetch_Status, -1) == true)
                        {

                            break;

                        }
                        InvoiceHeader = InvNum;
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, "@DetailCount");
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, stringUtil.IsNull(
                            CustomerName,
                            ""));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, stringUtil.IsNull(
                            CustomerVATTaxNumber,
                            ""));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, stringUtil.IsNull(
                            AddressAndPhone,
                            ""));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, stringUtil.IsNull(
                            CustomerBankAccount,
                            ""));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, stringUtil.IsNull(
                            Comment,
                            ""));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, stringUtil.IsNull(
                            Reviewer,
                            ""));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, stringUtil.IsNull(
                            Recipient,
                            ""));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, stringUtil.IsNull(
                            ItemofList,
                            ""));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, dateTimeUtil.ConvertToString(InvDate, "yyyyMMdd"));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, Connector, stringUtil.IsNull(
                            SellerBankAccount,
                            ""));

                        #region CRUD LoadToVariable
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
                        #endregion  LoadToVariable

                        InvoiceHeader = stringUtil.Replace(
                            stringUtil.IsNull(
                                InvoiceHeader,
                                ""),
                            "@DetailCount",
                            Convert.ToString(DetailCount));
                        InvoiceHeader = stringUtil.Concat(InvoiceHeader, LineBreak);
                        FileContent = stringUtil.Concat(FileContent, InvoiceHeader);
                        Specification = "";
                        ItemTaxCategory = "";
                        DetailCount = 0;
                        #region Cursor Statement

                        #region CRUD LoadToRecord
                        invitem_CrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
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
                        #endregion  LoadToRecord

                        #endregion Cursor Statement
                        invitem_CrsLoadResponseForCursor = this.appDB.Load(invitem_CrsLoadRequestForCursor);
                        foreach (var arinvItem in invitem_CrsLoadResponseForCursor.Items)
                        {
                            arinvItem.SetValue<string>("col0", stringUtil.IsNull(
                                arinvItem.GetValue<string>("u0"),
                                arinvItem.GetValue<string>("u1")));
                            arinvItem.SetValue<string>("u_m", arinvItem.GetValue<string>("u_m"));
                            arinvItem.SetValue<decimal?>("qty_invoiced", arinvItem.GetValue<decimal?>("qty_invoiced"));
                            arinvItem.SetValue<decimal?>("col1", (sQLUtil.SQLEqual(stringUtil.IsNull(
                                arinvItem.GetValue<int?>("u2"),
                                arinvItem.GetValue<int?>("u3")), 0) == true ? convertToUtil.ToString(arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5")))) :
                            sQLUtil.SQLEqual(stringUtil.IsNull(
                                arinvItem.GetValue<int?>("u2"),
                                arinvItem.GetValue<int?>("u3")), 1) == true ? convertToUtil.ToString(arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5"))) / (1M + arinvItem.GetValue<decimal?>("u6") / 100.0M)) : null));
                            arinvItem.SetValue<decimal?>("col2", arinvItem.GetValue<decimal?>("u6") / 100.0M);
                            arinvItem.SetValue<decimal?>("col3", (sQLUtil.SQLEqual(stringUtil.IsNull(
                                arinvItem.GetValue<int?>("u2"),
                                arinvItem.GetValue<int?>("u3")), 0) == true ? arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5"))) * (arinvItem.GetValue<decimal?>("u7") / 100.0M) :
                            sQLUtil.SQLEqual(stringUtil.IsNull(
                                arinvItem.GetValue<int?>("u2"),
                                arinvItem.GetValue<int?>("u3")), 1) == true ? arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5"))) / (1M + arinvItem.GetValue<decimal?>("u6") / 100.0M) * arinvItem.GetValue<decimal?>("u7") / 100M : null));
                            arinvItem.SetValue<decimal?>("col4", (sQLUtil.SQLEqual(stringUtil.IsNull(
                                arinvItem.GetValue<int?>("u2"),
                                arinvItem.GetValue<int?>("u3")), 0) == true ? (sQLUtil.SQLEqual(arinvItem.GetValue<int?>("u8"), 0) == true ? arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5"))) * (1M - arinvItem.GetValue<decimal?>("u7") / 100.0M) * (arinvItem.GetValue<decimal?>("u6") / 100.0M) :
                            sQLUtil.SQLEqual(arinvItem.GetValue<int?>("u8"), 1) == true ? arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5"))) * (arinvItem.GetValue<decimal?>("u6") / 100.0M) : null) :
                            sQLUtil.SQLEqual(stringUtil.IsNull(
                                arinvItem.GetValue<int?>("u2"),
                                arinvItem.GetValue<int?>("u3")), 1) == true ? (sQLUtil.SQLEqual(arinvItem.GetValue<int?>("u8"), 0) == true ? arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5"))) / (1M + arinvItem.GetValue<decimal?>("u6") / 100.0M) * (1M - arinvItem.GetValue<decimal?>("u7") / 100.0M) * (arinvItem.GetValue<decimal?>("u6") / 100.0M) :
                            sQLUtil.SQLEqual(arinvItem.GetValue<int?>("u8"), 1) == true ? arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5"))) / (1M + arinvItem.GetValue<decimal?>("u6") / 100.0M) * (arinvItem.GetValue<decimal?>("u6") / 100.0M) : null) : null));
                            arinvItem.SetValue<decimal?>("col5", (sQLUtil.SQLEqual(stringUtil.IsNull(
                                arinvItem.GetValue<int?>("u2"),
                                arinvItem.GetValue<int?>("u3")), 0) == true ? (sQLUtil.SQLEqual(arinvItem.GetValue<int?>("u8"), 0) == true ? arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5"))) * (arinvItem.GetValue<decimal?>("u7") / 100.0M) * (arinvItem.GetValue<decimal?>("u6") / 100.0M) :
                            sQLUtil.SQLEqual(arinvItem.GetValue<int?>("u8"), 1) == true ? 0 : convertToUtil.ToDecimal(0)) :
                            sQLUtil.SQLEqual(stringUtil.IsNull(
                                arinvItem.GetValue<int?>("u2"),
                                arinvItem.GetValue<int?>("u3")), 1) == true ? (sQLUtil.SQLEqual(arinvItem.GetValue<int?>("u8"), 0) == true ? arinvItem.GetValue<decimal?>("qty_invoiced") * (decimal?)(stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5"))) / (1M + arinvItem.GetValue<decimal?>("u6") / 100.0M) * (arinvItem.GetValue<decimal?>("u7") / 100.0M) * (arinvItem.GetValue<decimal?>("u6") / 100.0M) :
                            sQLUtil.SQLEqual(arinvItem.GetValue<int?>("u8"), 1) == true ? 0 : convertToUtil.ToDecimal(0)) : null));
                            arinvItem.SetValue<decimal?>("disc", arinvItem.GetValue<decimal?>("u7"));
                            arinvItem.SetValue<decimal?>("col6", stringUtil.IsNull(
                                arinvItem.GetValue<decimal?>("u4"),
                                arinvItem.GetValue<decimal?>("u5")));
                            arinvItem.SetValue<int?>("col7", stringUtil.IsNull(
                                arinvItem.GetValue<int?>("u2"),
                                arinvItem.GetValue<int?>("u3")));
                            arinvItem.SetValue<string>("CN_item_tax_category", arinvItem.GetValue<string>("CN_item_tax_category"));
                        };

                        invitem_Crs_CursorFetch_Status = invitem_CrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                        invitem_Crs_CursorCounter = -1;

                        while (sQLUtil.SQLEqual(Severity, 0) == true)
                        {
                            //BEGIN
                            invitem_Crs_CursorCounter++;
                            if (invitem_CrsLoadResponseForCursor.Items.Count > invitem_Crs_CursorCounter)
                            {
                                ItemDesc = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<string>(0);
                                UM = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<string>(1);
                                Quantity = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<decimal?>(2);
                                AmountWithoutTax = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<decimal?>(3);
                                TaxRate = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<decimal?>(4);
                                DiscountAmount = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<decimal?>(5);
                                TaxAmount = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<decimal?>(6);
                                DiscountTaxAmount = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<decimal?>(7);
                                Discount = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<decimal?>(8);
                                UnitPrice = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<decimal?>(9);
                                IncludeTaxInPrice = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<int?>(10);
                                ItemTaxCategory = invitem_CrsLoadResponseForCursor.Items[invitem_Crs_CursorCounter].GetValue<string>(11);
                            }
                            invitem_Crs_CursorFetch_Status = (invitem_Crs_CursorCounter == invitem_CrsLoadResponseForCursor.Items.Count ? -1 : 0);

                            if (sQLUtil.SQLEqual(invitem_Crs_CursorFetch_Status, -1) == true)
                            {

                                break;

                            }
                            Detail = "";
                            Detail = stringUtil.IsNull(
                                ItemDesc,
                                "");
                            Detail = stringUtil.Concat(Detail, Connector, stringUtil.IsNull(
                                UM,
                                ""));
                            Detail = stringUtil.Concat(Detail, Connector, stringUtil.IsNull(
                                Specification,
                                ""));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull<decimal?>(
                                Quantity,
                                0)));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull<decimal?>(
                                AmountWithoutTax,
                                0)));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull<decimal?>(
                                TaxRate,
                                0)));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull<string>(
                                ItemTaxCategory,
                                "0")));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull<decimal?>(
                                DiscountAmount,
                                0)));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull<decimal?>(
                                TaxAmount,
                                0)));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull<decimal?>(
                                DiscountTaxAmount,
                                0)));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull<decimal?>(
                                Discount,
                                0)));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull<decimal?>(
                                UnitPrice,
                                0)));
                            Detail = stringUtil.Concat(Detail, Connector, Convert.ToString(stringUtil.IsNull(
                                IncludeTaxInPrice,
                                0)));
                            Detail = stringUtil.Concat(Detail, LineBreak);
                            FileContent = stringUtil.Concat(FileContent, Detail);
                            //END

                        }
                        //Deallocate Cursor invitem_Crs
                        FileContent = stringUtil.Concat(FileContent, LineBreak);

                        #region CRUD LoadToRecord
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
                        var arinv1LoadResponse = this.appDB.Load(arinv1LoadRequest);
                        #endregion  LoadToRecord

                        #region CRUD UpdateByRecord
                        foreach (var arinv1Item in arinv1LoadResponse.Items)
                        {
                            arinv1Item.SetValue<string>("CN_vat_status", "P");
                        };

                        var arinv1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "arinv",
                            items: arinv1LoadResponse.Items);

                        this.appDB.Update(arinv1RequestUpdate);
                        #endregion UpdateByRecord

                        //END

                    }
                    //Deallocate Cursor inv_Crs
                    //END

                }

            }
            if (sQLUtil.SQLEqual(ReturnHandler, 0) == true)
            {
                ObjErrorObject = ObjTextStream;
                strErrorMessage = stringUtil.Concat("closing the file ", FileAndPath);

            }
            if (sQLUtil.SQLNotEqual(this.scalarFunction.Execute<int>("@@ERROR"), 0) == true || sQLUtil.SQLNotEqual(ReturnHandler, 0) == true)
            {
                //BEGIN
                if (sQLUtil.SQLNotEqual(ReturnHandler, 0) == true)
                {
                    //BEGIN
                    raiseError.RaiseErrorSp(strErrorMessage, 16, 1);
                    //END

                }
                this.transactionFactory.RollbackTransaction("");
                //END

            }
            else
            {
                this.transactionFactory.CommitTransaction("");

            }

            #region CRUD ExecuteMethodCall

            var MsgApp1 = this.iMsgApp.MsgAppSp(
                Infobar: Infobar,
                BaseMsg: "I=CmdSucceeded",
                Parm1: "@%generate");
            Severity = MsgApp1.ReturnCode;
            Infobar = MsgApp1.Infobar;

            #endregion ExecuteMethodCall

            return (Severity = 0, VATExportLogicalFolder, FileName, FileContent, Infobar);

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