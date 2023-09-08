//PROJECT NAME: Material
//CLASS NAME: ItemwhseGetDetailsCRUD.cs

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
    public class ItemwhseGetDetailsCRUD : IItemwhseGetDetailsCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;

        public ItemwhseGetDetailsCRUD(IApplicationDB appDB,
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ItemwhseGetDetailsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ItemwhseGetDetailsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
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

        public (string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
        {
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

            int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
            return (ALTGEN_SpName, rowCount);
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

        public (decimal? QtyOnHand, decimal? QtyReorder, int? CntInProc, int? CycleFlag, int? rowCount) ItemwhseLoad(string Item, string Whse, decimal? QtyOnHand, decimal? QtyReorder, int? CntInProc, int? CycleFlag)
        {
            QtyTotlType _QtyOnHand = DBNull.Value;
            QtyUnitType _QtyReorder = DBNull.Value;
            ListYesNoType _CntInProc = DBNull.Value;
            ListYesNoType _CycleFlag = DBNull.Value;

            var itemwhseLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_QtyOnHand,"qty_on_hand"},
                    {_QtyReorder,"qty_reorder"},
                    {_CntInProc,"cnt_in_proc"},
                    {_CycleFlag,"cycle_flag"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "itemwhse",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("item = {0} AND whse = {1}", Item, Whse),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var itemwhseLoadResponse = this.appDB.Load(itemwhseLoadRequest);
            if (itemwhseLoadResponse.Items.Count > 0)
            {
                QtyOnHand = _QtyOnHand;
                QtyReorder = _QtyReorder;
                CntInProc = _CntInProc;
                CycleFlag = _CycleFlag;
            }

            int rowCount = itemwhseLoadResponse.Items.Count;
            return (QtyOnHand, QtyReorder, CntInProc, CycleFlag, rowCount);
        }

        public (string Loc, int? rowCount) ItemlocLoad(string Item, string Whse, string Loc)
        {
            LocType _Loc = DBNull.Value;

            var itemlocLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_Loc,"itemloc.loc"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "itemloc",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("itemloc.item = {0} AND itemloc.whse = {1} AND itemloc.rank = 1", Item, Whse),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var itemlocLoadResponse = this.appDB.Load(itemlocLoadRequest);
            if (itemlocLoadResponse.Items.Count > 0)
            {
                Loc = _Loc;
            }

            int rowCount = itemlocLoadResponse.Items.Count;
            return (Loc, rowCount);
        }

        public (int? ReturnCode,
            decimal? QtyOnHand,
            decimal? QtyReorder,
            int? CntInProc,
            int? CycleFlag,
            string Loc,
            string Infobar)
        AltExtGen_ItemwhseGetDetailsSp(
            string AltExtGenSp,
            string Item,
            string Whse,
            decimal? QtyOnHand,
            decimal? QtyReorder,
            int? CntInProc,
            int? CycleFlag,
            string Loc,
            string Infobar)
        {
            ItemType _Item = Item;
            WhseType _Whse = Whse;
            QtyTotlType _QtyOnHand = QtyOnHand;
            QtyUnitType _QtyReorder = QtyReorder;
            ListYesNoType _CntInProc = CntInProc;
            ListYesNoType _CycleFlag = CycleFlag;
            LocType _Loc = Loc;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyReorder", _QtyReorder, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CntInProc", _CntInProc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CycleFlag", _CycleFlag, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                QtyOnHand = _QtyOnHand;
                QtyReorder = _QtyReorder;
                CntInProc = _CntInProc;
                CycleFlag = _CycleFlag;
                Loc = _Loc;
                Infobar = _Infobar;

                return (Severity, QtyOnHand, QtyReorder, CntInProc, CycleFlag, Loc, Infobar);
            }
        }

    }
}
