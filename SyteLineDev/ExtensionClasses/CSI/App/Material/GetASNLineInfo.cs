//PROJECT NAME: Material
//CLASS NAME: GetASNLineInfo.cs

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
    public class GetASNLineInfo : IGetASNLineInfo
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

        public GetASNLineInfo(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil)
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
        }

        public (int? ReturnCode,
            string BolItemItem,
            string BolItemDescription,
            decimal? BolItemQty,
            string BolItemUM,
            decimal? BolItemWeight,
            int? ItemSerialTracked,
            decimal? ItemUnitWeight) 
        GetASNLineInfoSp(string BolItemRefNum,
            string BolItemBolNum,
            int? BolItemRefLine,
            string BolItemItem,
            string BolItemDescription,
            decimal? BolItemQty,
            string BolItemUM,
            decimal? BolItemWeight,
            int? ItemSerialTracked,
            decimal? ItemUnitWeight)
        {

            ItemType _BolItemItem = BolItemItem;
            DescriptionType _BolItemDescription = BolItemDescription;
            QtyUnitNoNegType _BolItemQty = BolItemQty;
            UMType _BolItemUM = BolItemUM;
            LineWeightType _BolItemWeight = BolItemWeight;
            ListYesNoType _ItemSerialTracked = ItemSerialTracked;
            ItemWeightType _ItemUnitWeight = ItemUnitWeight;

            int? Severity = 0;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetASNLineInfoSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetASNLineInfoSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("GetASNLineInfoSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_GetASNLineInfoSp(_ALTGEN_SpName,
                        BolItemRefNum,
                        BolItemBolNum,
                        BolItemRefLine,
                        BolItemItem,
                        BolItemDescription,
                        BolItemQty,
                        BolItemUM,
                        BolItemWeight,
                        ItemSerialTracked,
                        ItemUnitWeight);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        BolItemItem = _BolItemItem;
                        BolItemUM = _BolItemUM;
                        BolItemQty = _BolItemQty;
                        BolItemDescription = _BolItemDescription;
                        ItemSerialTracked = _ItemSerialTracked;
                        ItemUnitWeight = _ItemUnitWeight;
                        BolItemWeight = _BolItemWeight;
                        return (ALTGEN_Severity, BolItemItem, BolItemDescription, BolItemQty, BolItemUM, BolItemWeight, ItemSerialTracked, ItemUnitWeight);

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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_GetASNLineInfoSp") != null)
            {
                var EXTGEN = AltExtGen_GetASNLineInfoSp("dbo.EXTGEN_GetASNLineInfoSp",
                    BolItemRefNum,
                    BolItemBolNum,
                    BolItemRefLine,
                    BolItemItem,
                    BolItemDescription,
                    BolItemQty,
                    BolItemUM,
                    BolItemWeight,
                    ItemSerialTracked,
                    ItemUnitWeight);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.BolItemItem, EXTGEN.BolItemDescription, EXTGEN.BolItemQty, EXTGEN.BolItemUM, EXTGEN.BolItemWeight, EXTGEN.ItemSerialTracked, EXTGEN.ItemUnitWeight);
                }
            }

            if (sQLUtil.SQLEqual(stringUtil.IsNumeric(BolItemBolNum), 1) == true && existsChecker.Exists(
                tableName: "trp_hdr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("trp_hdr.trn_num = {0} AND trp_hdr.pack_num = {1}", BolItemRefNum, BolItemBolNum)))
            {
                #region CRUD LoadToVariable
                var trp_itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_BolItemItem,"trp_item.item"},
                        {_BolItemUM,"trp_item.u_m"},
                        {_BolItemQty,"trp_item.qty_packed"},
                        {_BolItemDescription,"item.description"},
                        {_ItemSerialTracked,"item.serial_tracked"},
                        {_ItemUnitWeight,"item.unit_weight"},
                        {_BolItemWeight,"trp_item.qty_packed * item.unit_weight"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "trp_item",
                    fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN item AS item WITH (READUNCOMMITTED) ON trp_item.item = item.item"),
                    whereClause: collectionLoadRequestFactory.Clause("trp_item.trn_num = {1} AND trp_item.trn_line = {0}", BolItemRefLine, BolItemRefNum),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var trp_itemLoadResponse = this.appDB.Load(trp_itemLoadRequest);
                if (trp_itemLoadResponse.Items.Count > 0)
                {
                    BolItemItem = _BolItemItem;
                    BolItemUM = _BolItemUM;
                    BolItemQty = _BolItemQty;
                    BolItemDescription = _BolItemDescription;
                    ItemSerialTracked = _ItemSerialTracked;
                    ItemUnitWeight = _ItemUnitWeight;
                    BolItemWeight = _BolItemWeight;
                }
                #endregion  LoadToVariable
            }
            else
            {
                #region CRUD LoadToVariable
                var trnitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_BolItemItem,"trnitem.item"},
                        {_BolItemUM,"trnitem.u_m"},
                        {_BolItemQty,"trnitem.qty_req"},
                        {_BolItemDescription,"item.description"},
                        {_ItemSerialTracked,"item.serial_tracked"},
                        {_BolItemWeight,"trnitem.qty_req * item.unit_weight"},
                        {_ItemUnitWeight,"item.unit_weight"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "trnitem",
                    fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN item AS item WITH (READUNCOMMITTED) ON trnitem.item = item.item"),
                    whereClause: collectionLoadRequestFactory.Clause("trnitem.trn_num = {1} AND trnitem.trn_line = {0}", BolItemRefLine, BolItemRefNum),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var trnitemLoadResponse = this.appDB.Load(trnitemLoadRequest);
                if (trnitemLoadResponse.Items.Count > 0)
                {
                    BolItemItem = _BolItemItem;
                    BolItemUM = _BolItemUM;
                    BolItemQty = _BolItemQty;
                    BolItemDescription = _BolItemDescription;
                    ItemSerialTracked = _ItemSerialTracked;
                    BolItemWeight = _BolItemWeight;
                    ItemUnitWeight = _ItemUnitWeight;
                }
                #endregion  LoadToVariable
            }
            BolItemItem = _BolItemItem;
            BolItemUM = _BolItemUM;
            BolItemQty = _BolItemQty;
            BolItemDescription = _BolItemDescription;
            ItemSerialTracked = _ItemSerialTracked;
            ItemUnitWeight = _ItemUnitWeight;
            BolItemWeight = _BolItemWeight;

            return (Severity, BolItemItem, BolItemDescription, BolItemQty, BolItemUM, BolItemWeight, ItemSerialTracked, ItemUnitWeight);
        }

        public (int? ReturnCode, string BolItemItem,
            string BolItemDescription,
            decimal? BolItemQty,
            string BolItemUM,
            decimal? BolItemWeight,
            int? ItemSerialTracked,
            decimal? ItemUnitWeight) 
        AltExtGen_GetASNLineInfoSp(string AltExtGenSp,
            string BolItemRefNum,
            string BolItemBolNum,
            int? BolItemRefLine,
            string BolItemItem,
            string BolItemDescription,
            decimal? BolItemQty,
            string BolItemUM,
            decimal? BolItemWeight,
            int? ItemSerialTracked,
            decimal? ItemUnitWeight)
        {
            TrnNumType _BolItemRefNum = BolItemRefNum;
            BolNumType _BolItemBolNum = BolItemBolNum;
            TrnLineType _BolItemRefLine = BolItemRefLine;
            ItemType _BolItemItem = BolItemItem;
            DescriptionType _BolItemDescription = BolItemDescription;
            QtyUnitNoNegType _BolItemQty = BolItemQty;
            UMType _BolItemUM = BolItemUM;
            LineWeightType _BolItemWeight = BolItemWeight;
            ListYesNoType _ItemSerialTracked = ItemSerialTracked;
            ItemWeightType _ItemUnitWeight = ItemUnitWeight;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "BolItemRefNum", _BolItemRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BolItemBolNum", _BolItemBolNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BolItemRefLine", _BolItemRefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BolItemItem", _BolItemItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BolItemDescription", _BolItemDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BolItemQty", _BolItemQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BolItemUM", _BolItemUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BolItemWeight", _BolItemWeight, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemUnitWeight", _ItemUnitWeight, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                BolItemItem = _BolItemItem;
                BolItemDescription = _BolItemDescription;
                BolItemQty = _BolItemQty;
                BolItemUM = _BolItemUM;
                BolItemWeight = _BolItemWeight;
                ItemSerialTracked = _ItemSerialTracked;
                ItemUnitWeight = _ItemUnitWeight;

                return (Severity, BolItemItem, BolItemDescription, BolItemQty, BolItemUM, BolItemWeight, ItemSerialTracked, ItemUnitWeight);
            }
        }
    }
}
