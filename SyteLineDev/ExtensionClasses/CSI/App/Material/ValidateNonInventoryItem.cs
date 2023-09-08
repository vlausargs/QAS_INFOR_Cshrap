﻿//PROJECT NAME: Material
//CLASS NAME: ValidateNonInventoryItem.cs

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

namespace CSI.Material
{
    public class ValidateNonInventoryItem : IValidateNonInventoryItem
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;

        public ValidateNonInventoryItem(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
        }

        public (int? ReturnCode, string PromptMsg) ValidateNonInventoryItemSp(string item, string PromptMsg)
        {
            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            RowPointerType _RowPointer = DBNull.Value;
            Guid? RowPointer = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateNonInventoryItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
                        [SpName] SYSNAME);
                    SELECT * into #tv_ALTGEN from @ALTGEN ");

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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateNonInventoryItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ValidateNonInventoryItemSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                    items: optional_module1LoadResponse.Items);

                this.appDB.Insert(optional_module1InsertRequest);
                #endregion InsertByRecords

                while (existsChecker.Exists(
                    tableName: "#tv_ALTGEN",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("")))
                {
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

                    var ALTGEN = AltExtGen_ValidateNonInventoryItemSp(_ALTGEN_SpName,
                        item,
                        PromptMsg);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, PromptMsg);
                    }

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    #region CRUD LoadToRecord
                    var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"col0","1"},
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
                }
            }

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ValidateNonInventoryItemSp") != null)
            {
                var EXTGEN = AltExtGen_ValidateNonInventoryItemSp("dbo.EXTGEN_ValidateNonInventoryItemSp",
                    item,
                    PromptMsg);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.PromptMsg);
                }
            }

            Severity = 0;
            RowPointer = null;
            PromptMsg = null;

            #region CRUD LoadToVariable
            var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_RowPointer,"item.RowPointer"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "item",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", item),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var itemLoadResponse = this.appDB.Load(itemLoadRequest);
            if (itemLoadResponse.Items.Count > 0)
            {
                RowPointer = _RowPointer;
            }
            #endregion  LoadToVariable

            if (RowPointer != null)
            {
                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
                    , BaseMsg: "E=ExistIn"
                    , Parm1: "@non_inventory_item"
                    , Parm2: "@non_inventory_item.item"
                    , Parm3: item
                    , Parm4: "@item");
                Severity = MsgApp.ReturnCode;
                PromptMsg = MsgApp.Infobar;

                #endregion ExecuteMethodCall
            }

            return (Severity, PromptMsg);
        }

        public (int? ReturnCode, string PromptMsg) AltExtGen_ValidateNonInventoryItemSp(string AltExtGenSp,
            string item,
            string PromptMsg)
        {
            ItemType _item = item;
            InfobarType _PromptMsg = PromptMsg;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PromptMsg = _PromptMsg;

                return (Severity, PromptMsg);
            }
        }
    }
}
