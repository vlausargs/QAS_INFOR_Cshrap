//PROJECT NAME: Material
//CLASS NAME: ItemwhseGetDetails.cs

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
    public class ItemwhseGetDetails : IItemwhseGetDetails
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IItemwhseGetDetailsCRUD iItemwhseGetDetailsCRUD;

        public ItemwhseGetDetails(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            IItemwhseGetDetailsCRUD iItemwhseGetDetailsCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.iItemwhseGetDetailsCRUD = iItemwhseGetDetailsCRUD;
        }

        public (
            int? ReturnCode,
            decimal? QtyOnHand,
            decimal? QtyReorder,
            int? CntInProc,
            int? CycleFlag,
            string Loc,
            string Infobar)
        ItemwhseGetDetailsSp(
            string Item,
            string Whse,
            decimal? QtyOnHand,
            decimal? QtyReorder,
            int? CntInProc,
            int? CycleFlag,
            string Loc,
            string Infobar)
        {

            QtyTotlType _QtyOnHand = QtyOnHand;
            QtyUnitType _QtyReorder = QtyReorder;
            ListYesNoType _CntInProc = CntInProc;
            ListYesNoType _CycleFlag = CycleFlag;
            LocType _Loc = Loc;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            if (this.iItemwhseGetDetailsCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iItemwhseGetDetailsCRUD.Optional_Module1Select();
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ItemwhseGetDetailsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iItemwhseGetDetailsCRUD.Optional_Module1Insert(optional_module1LoadResponse);

                while (this.iItemwhseGetDetailsCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iItemwhseGetDetailsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iItemwhseGetDetailsCRUD.AltExtGen_ItemwhseGetDetailsSp(ALTGEN_SpName,
                        Item,
                        Whse,
                        QtyOnHand,
                        QtyReorder,
                        CntInProc,
                        CycleFlag,
                        Loc,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, QtyOnHand, QtyReorder, CntInProc, CycleFlag, Loc, Infobar);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iItemwhseGetDetailsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iItemwhseGetDetailsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ItemwhseGetDetailsSp") != null)
            {
                var EXTGEN = this.iItemwhseGetDetailsCRUD.AltExtGen_ItemwhseGetDetailsSp("dbo.EXTGEN_ItemwhseGetDetailsSp",
                    Item,
                    Whse,
                    QtyOnHand,
                    QtyReorder,
                    CntInProc,
                    CycleFlag,
                    Loc,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.QtyOnHand, EXTGEN.QtyReorder, EXTGEN.CntInProc, EXTGEN.CycleFlag, EXTGEN.Loc, EXTGEN.Infobar);
                }
            }

            Infobar = null;
            Severity = 0;
            (QtyOnHand, QtyReorder, CntInProc, CycleFlag, rowCount) = this.iItemwhseGetDetailsCRUD.ItemwhseLoad(Item, Whse, QtyOnHand, QtyReorder, CntInProc, CycleFlag);
            if (rowCount == 0)
            {

                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "E=NoExist2",
                    Parm1: "@item",
                    Parm2: "@item.item",
                    Parm3: Item,
                    Parm4: "@whse",
                    Parm5: Whse);
                Severity = MsgApp.ReturnCode;
                Infobar = MsgApp.Infobar;

                #endregion ExecuteMethodCall

            }
            if (sQLUtil.SQLEqual(Severity, 0) == true)
            {
                (Loc, rowCount) = this.iItemwhseGetDetailsCRUD.ItemlocLoad(Item, Whse, Loc);
                if (rowCount == 0)
                {

                    #region CRUD ExecuteMethodCall

                    var MsgApp1 = this.iMsgApp.MsgAppSp(
                        Infobar: Infobar,
                        BaseMsg: "E=NoExist2",
                        Parm1: "@itemloc",
                        Parm2: "@item.item",
                        Parm3: Item,
                        Parm4: "@whse",
                        Parm5: Whse);
                    Severity = MsgApp1.ReturnCode;
                    Infobar = MsgApp1.Infobar;

                    #endregion ExecuteMethodCall

                }

            }
            return (Severity, QtyOnHand, QtyReorder, CntInProc, CycleFlag, Loc, Infobar);

        }

    }
}
