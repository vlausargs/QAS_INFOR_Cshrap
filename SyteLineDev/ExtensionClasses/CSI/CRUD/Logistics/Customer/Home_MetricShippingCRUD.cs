//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricShippingCRUD.cs

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
    public class Home_MetricShippingCRUD : IHome_MetricShippingCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;

        public Home_MetricShippingCRUD(IApplicationDB appDB,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IDateTimeUtil dateTimeUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor)
        {
            this.appDB = appDB;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricShippingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public void Optional_ModuleInsertSelect()
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricShippingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_MetricShippingSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };

            var optional_module1RequiredColumns = new List<string>() { "SpName" };

            optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

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

        public (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
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

        public void Tv_ALTGEN2Delete(string ALTGEN_SpName)
        {

            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");

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

            var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);

            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                items: tv_ALTGEN2LoadResponse.Items);
            this.appDB.Delete(tv_ALTGEN2DeleteRequest);

            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
        }

        public (string DomCurrCode, int? rowCount) CurrparmsLoad(string DomCurrCode)
        {
            CurrCodeType _DomCurrCode = DBNull.Value;

            var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_DomCurrCode,"curr_code"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "currparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
            if (currparmsLoadResponse.Items.Count > 0)
            {
                DomCurrCode = _DomCurrCode;
            }

            int rowCount = currparmsLoadResponse.Items.Count;
            return (DomCurrCode, rowCount);
        }

        public (string ParmsSite, int? rowCount) ParmsLoad(string ParmsSite)
        {
            SiteType _ParmsSite = DBNull.Value;

            var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ParmsSite,"site"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "parms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
            if (parmsLoadResponse.Items.Count > 0)
            {
                ParmsSite = _ParmsSite;
            }

            int rowCount = parmsLoadResponse.Items.Count;
            return (ParmsSite, rowCount);
        }

        public void Co_ShipInsert(DateTime? PeriodStart1, DateTime? PeriodEnd10)
        {
            var co_shipLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"CO_SHIP_ext_price","CAST (NULL AS DECIMAL)"},
                    {"ship_date","co_ship.ship_date"},
                    {"CO_discount_type","co.discount_type"},
                    {"CO_disc_amount","co.disc_amount"},
                    {"CO_disc","co.disc"},
                    {"CO_amount","CAST (NULL AS DECIMAL)"},
                    {"CO_fixed_rate","co.fixed_rate"},
                    {"CO_exch_rate","co.exch_rate"},
                    {"curr_code","custaddr.curr_code"},
                    {"net_price","CAST (NULL AS INT)"},
                    {"u0","co_ship.qty_shipped"},
                    {"u1","co_ship.price"},
                    {"u2","coitem.disc"},
                    {"u3","co.price"},
                    {"u4","co.misc_charges"},
                    {"u5","co.sales_tax"},
                    {"u6","co.sales_tax_2"},
                    {"u7","co.freight"},
                    {"u8","co.m_charges_t"},
                    {"u9","co.sales_tax_t"},
                    {"u10","co.sales_tax_t2"},
                    {"u11","co.freight_t"},
                },
                tableName: "co_ship",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN coitem ON coitem.co_num = co_ship.co_num
					AND coitem.co_line = co_ship.co_line
					AND coitem.co_release = co_ship.co_release INNER JOIN co ON co.co_num = co_ship.co_num INNER JOIN custaddr ON custaddr.cust_num = co.cust_num
					AND custaddr.cust_seq = 0"),
                whereClause: collectionLoadRequestFactory.Clause("co_ship.ship_date BETWEEN {0} AND {1}", PeriodStart1, PeriodEnd10),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var co_shipLoadResponse = this.appDB.Load(co_shipLoadRequest);

            foreach (var co_shipItem in co_shipLoadResponse.Items)
            {
                co_shipItem.SetValue<decimal?>("CO_SHIP_ext_price", co_shipItem.GetValue<decimal?>("u0") * co_shipItem.GetValue<decimal?>("u1") * (1.0M - (co_shipItem.GetValue<decimal?>("u2") / 100.0M)));
                co_shipItem.SetValue<DateTime?>("ship_date", co_shipItem.GetValue<DateTime?>("ship_date"));
                co_shipItem.SetValue<string>("CO_discount_type", co_shipItem.GetValue<string>("CO_discount_type"));
                co_shipItem.SetValue<decimal?>("CO_disc_amount", co_shipItem.GetValue<decimal?>("CO_disc_amount"));
                co_shipItem.SetValue<decimal?>("CO_disc", co_shipItem.GetValue<decimal?>("CO_disc"));
                co_shipItem.SetValue<decimal?>("CO_amount", co_shipItem.GetValue<decimal?>("u3") - co_shipItem.GetValue<decimal?>("u4") - co_shipItem.GetValue<decimal?>("u5") - co_shipItem.GetValue<decimal?>("u6") - co_shipItem.GetValue<decimal?>("u7") - co_shipItem.GetValue<decimal?>("u8") - co_shipItem.GetValue<decimal?>("u9") - co_shipItem.GetValue<decimal?>("u10") - co_shipItem.GetValue<decimal?>("u11"));
                co_shipItem.SetValue<int?>("CO_fixed_rate", co_shipItem.GetValue<int?>("CO_fixed_rate"));
                co_shipItem.SetValue<decimal?>("CO_exch_rate", co_shipItem.GetValue<decimal?>("CO_exch_rate"));
                co_shipItem.SetValue<string>("curr_code", co_shipItem.GetValue<string>("curr_code"));
                co_shipItem.SetValue<int?>("net_price", 0);
            };

            var co_shipRequiredColumns = new List<string>() { "CO_SHIP_ext_price", "ship_date", "CO_discount_type", "CO_disc_amount", "CO_disc", "CO_amount", "CO_fixed_rate", "CO_exch_rate", "curr_code", "net_price" };

            co_shipLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(co_shipLoadResponse, co_shipRequiredColumns);

            var co_shipInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_CoShip",
                items: co_shipLoadResponse.Items);

            this.appDB.Insert(co_shipInsertRequest);

        }

        public void CoshipUpdate()
        {
            var tv_CoShipLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"net_price","#tv_CoShip.net_price"},
                    {"u0","CO_SHIP_ext_price"},
                    {"u1","CO_discount_type"},
                    {"u2","CO_disc"},
                    {"u3","CO_disc_amount"},
                    {"u4","CO_amount"},
                },
                tableName: "#tv_CoShip",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var tv_CoShipLoadResponse = this.appDB.Load(tv_CoShipLoadRequest);

            foreach (var tv_CoShipItem in tv_CoShipLoadResponse.Items)
            {
                tv_CoShipItem.SetValue<decimal?>("net_price", (decimal?)(tv_CoShipItem.GetDeletedValue<decimal?>("u0")) * (1.0M - (decimal?)((sQLUtil.SQLEqual(tv_CoShipItem.GetDeletedValue<string>("u1"), "P") == true ? tv_CoShipItem.GetDeletedValue<decimal?>("u2") : tv_CoShipItem.GetDeletedValue<decimal?>("u3") / (sQLUtil.SQLEqual(tv_CoShipItem.GetDeletedValue<decimal?>("u3") + tv_CoShipItem.GetDeletedValue<decimal?>("u4"), 0) == true ? 1 : tv_CoShipItem.GetDeletedValue<decimal?>("u3") + tv_CoShipItem.GetDeletedValue<decimal?>("u4")))) / 100.0M));
            };

            var tv_CoShipRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_CoShip",
                items: tv_CoShipLoadResponse.Items);

            this.appDB.Update(tv_CoShipRequestUpdate);

        }

        public ICollectionLoadResponse Tv_Coship1Select(string DomCurrCode)
        {
            var co_shipCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"net_price","co_ship.net_price"},
                    {"ship_date","co_ship.ship_date"},
                    {"curr_code","co_ship.curr_code"},
                    {"col0","CAST (NULL AS DECIMAL)"},
                    {"sequence","co_ship.sequence"},
                    {"u0","co_ship.CO_fixed_rate"},
                    {"u1","co_ship.CO_exch_rate"},
                },
                tableName: "#tv_CoShip",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(" AS co_ship"),
                whereClause: collectionLoadRequestFactory.Clause("curr_code != {0} AND CO_SHIP_ext_price != 0", DomCurrCode),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var co_shipCrsLoadResponseForCursor = this.appDB.Load(co_shipCrsLoadRequestForCursor);
            foreach (var tv_CoShip1Item in co_shipCrsLoadResponseForCursor.Items)
            {
                tv_CoShip1Item.SetValue<decimal?>("net_price", tv_CoShip1Item.GetValue<decimal?>("net_price"));
                tv_CoShip1Item.SetValue<DateTime?>("ship_date", tv_CoShip1Item.GetValue<DateTime?>("ship_date"));
                tv_CoShip1Item.SetValue<string>("curr_code", tv_CoShip1Item.GetValue<string>("curr_code"));
                tv_CoShip1Item.SetValue<decimal?>("col0", (sQLUtil.SQLEqual(tv_CoShip1Item.GetValue<int?>("u0"), 1) == true ? tv_CoShip1Item.GetValue<decimal?>("u1") : null));
                tv_CoShip1Item.SetValue<int?>("sequence", tv_CoShip1Item.GetValue<int?>("sequence"));
            };

            return co_shipCrsLoadResponseForCursor;
        }

        public void Coship2Update(int? Sequence, decimal? Price)
        {
            var tv_CoShip2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"net_price","#tv_CoShip.net_price"},
                },
                tableName: "#tv_CoShip",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("sequence = {0}", Sequence),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var tv_CoShip2LoadResponse = this.appDB.Load(tv_CoShip2LoadRequest);

            foreach (var tv_CoShip2Item in tv_CoShip2LoadResponse.Items)
            {
                tv_CoShip2Item.SetValue<decimal?>("net_price", Price);
            };

            var tv_CoShip2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_CoShip",
                items: tv_CoShip2LoadResponse.Items);

            this.appDB.Update(tv_CoShip2RequestUpdate);

        }

        public (decimal? PeriodActual1,
            decimal? PeriodActual2,
            decimal? PeriodActual3,
            decimal? PeriodActual4,
            decimal? PeriodActual5,
            decimal? PeriodActual6,
            decimal? PeriodActual7,
            decimal? PeriodActual8,
            decimal? PeriodActual9,
            decimal? PeriodActual10, int? rowCount)
        Tv_Coship3Load(DateTime? PeriodStart1,
            DateTime? PeriodEnd1,
            DateTime? PeriodStart2,
            DateTime? PeriodEnd2,
            DateTime? PeriodStart3,
            DateTime? PeriodEnd3,
            DateTime? PeriodStart4,
            DateTime? PeriodEnd4,
            DateTime? PeriodStart5,
            DateTime? PeriodEnd5,
            DateTime? PeriodStart6,
            DateTime? PeriodEnd6,
            DateTime? PeriodStart7,
            DateTime? PeriodEnd7,
            DateTime? PeriodStart8,
            DateTime? PeriodEnd8,
            DateTime? PeriodStart9,
            DateTime? PeriodEnd9,
            DateTime? PeriodStart10,
            DateTime? PeriodEnd10,
            decimal? PeriodActual1,
            decimal? PeriodActual2,
            decimal? PeriodActual3,
            decimal? PeriodActual4,
            decimal? PeriodActual5,
            decimal? PeriodActual6,
            decimal? PeriodActual7,
            decimal? PeriodActual8,
            decimal? PeriodActual9,
            decimal? PeriodActual10)
        {
            AmtTotType _PeriodActual1 = DBNull.Value;
            AmtTotType _PeriodActual2 = DBNull.Value;
            AmtTotType _PeriodActual3 = DBNull.Value;
            AmtTotType _PeriodActual4 = DBNull.Value;
            AmtTotType _PeriodActual5 = DBNull.Value;
            AmtTotType _PeriodActual6 = DBNull.Value;
            AmtTotType _PeriodActual7 = DBNull.Value;
            AmtTotType _PeriodActual8 = DBNull.Value;
            AmtTotType _PeriodActual9 = DBNull.Value;
            AmtTotType _PeriodActual10 = DBNull.Value;

            var tv_CoShip3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_PeriodActual1,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart1)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd1)} THEN net_price ELSE 0 END)"},
                    {_PeriodActual2,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart2)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd2)} THEN net_price ELSE 0 END)"},
                    {_PeriodActual3,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart3)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd3)} THEN net_price ELSE 0 END)"},
                    {_PeriodActual4,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart4)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd4)} THEN net_price ELSE 0 END)"},
                    {_PeriodActual5,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart5)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd5)} THEN net_price ELSE 0 END)"},
                    {_PeriodActual6,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart6)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd6)} THEN net_price ELSE 0 END)"},
                    {_PeriodActual7,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart7)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd7)} THEN net_price ELSE 0 END)"},
                    {_PeriodActual8,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart8)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd8)} THEN net_price ELSE 0 END)"},
                    {_PeriodActual9,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart9)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd9)} THEN net_price ELSE 0 END)"},
                    {_PeriodActual10,$"sum(CASE WHEN ship_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart10)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd10)} THEN net_price ELSE 0 END)"},
                },
                tableName: "#tv_CoShip",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_CoShip3LoadResponse = this.appDB.Load(tv_CoShip3LoadRequest);
            if (tv_CoShip3LoadResponse.Items.Count > 0)
            {
                PeriodActual1 = _PeriodActual1;
                PeriodActual2 = _PeriodActual2;
                PeriodActual3 = _PeriodActual3;
                PeriodActual4 = _PeriodActual4;
                PeriodActual5 = _PeriodActual5;
                PeriodActual6 = _PeriodActual6;
                PeriodActual7 = _PeriodActual7;
                PeriodActual8 = _PeriodActual8;
                PeriodActual9 = _PeriodActual9;
                PeriodActual10 = _PeriodActual10;
            }

            int rowCount = tv_CoShip3LoadResponse.Items.Count;
            return (PeriodActual1, PeriodActual2, PeriodActual3, PeriodActual4, PeriodActual5, PeriodActual6, PeriodActual7, PeriodActual8, PeriodActual9, PeriodActual10, rowCount);
        }

        public void CoitemInsert(DateTime? PeriodStart10, DateTime? PeriodEnd12)
        {
            var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"COITEM_ext_price","CAST (NULL AS DECIMAL)"},
                    {"due_date","coitem.due_date"},
                    {"ship_date","coitem.ship_date"},
                    {"CO_discount_type","co.discount_type"},
                    {"CO_disc_amount","co.disc_amount"},
                    {"CO_disc","co.disc"},
                    {"CO_amount","CAST (NULL AS DECIMAL)"},
                    {"CO_fixed_rate","co.fixed_rate"},
                    {"CO_exch_rate","co.exch_rate"},
                    {"curr_code","co.curr_code"},
                    {"net_price","CAST (NULL AS INT)"},
                    {"u0","coitem.qty_ordered"},
                    {"u1","coitem.qty_shipped"},
                    {"u2","coitem.price"},
                    {"u3","coitem.disc"},
                    {"u4","co.price"},
                    {"u5","co.misc_charges"},
                    {"u6","co.sales_tax"},
                    {"u7","co.sales_tax_2"},
                    {"u8","co.freight"},
                    {"u9","co.m_charges_t"},
                    {"u10","co.sales_tax_t"},
                    {"u11","co.sales_tax_t2"},
                    {"u12","co.freight_t"},
                },
                tableName: "coitem",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN co ON co.co_num = coitem.co_num
					AND co.type IN ('R', 'B')"),
                whereClause: collectionLoadRequestFactory.Clause("coitem.due_date BETWEEN {0} AND {1}", PeriodStart10, PeriodEnd12),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var coitemLoadResponse = this.appDB.Load(coitemLoadRequest);

            foreach (var coitemItem in coitemLoadResponse.Items)
            {
                coitemItem.SetValue<decimal?>("COITEM_ext_price", ((sQLUtil.SQLGreaterThan(coitemItem.GetValue<decimal?>("u0"), coitemItem.GetValue<decimal?>("u1")) == true) ? (coitemItem.GetValue<decimal?>("u0") - coitemItem.GetValue<decimal?>("u1")) * coitemItem.GetValue<decimal?>("u2") * (1.0M - (coitemItem.GetValue<decimal?>("u3") / 100.0M)) : 0));
                coitemItem.SetValue<DateTime?>("due_date", coitemItem.GetValue<DateTime?>("due_date"));
                coitemItem.SetValue<DateTime?>("ship_date", coitemItem.GetValue<DateTime?>("ship_date"));
                coitemItem.SetValue<string>("CO_discount_type", coitemItem.GetValue<string>("CO_discount_type"));
                coitemItem.SetValue<decimal?>("CO_disc_amount", coitemItem.GetValue<decimal?>("CO_disc_amount"));
                coitemItem.SetValue<decimal?>("CO_disc", coitemItem.GetValue<decimal?>("CO_disc"));
                coitemItem.SetValue<decimal?>("CO_amount", coitemItem.GetValue<decimal?>("u4") - coitemItem.GetValue<decimal?>("u5") - coitemItem.GetValue<decimal?>("u6") - coitemItem.GetValue<decimal?>("u7") - coitemItem.GetValue<decimal?>("u8") - coitemItem.GetValue<decimal?>("u9") - coitemItem.GetValue<decimal?>("u10") - coitemItem.GetValue<decimal?>("u11") - coitemItem.GetValue<decimal?>("u12"));
                coitemItem.SetValue<int?>("CO_fixed_rate", coitemItem.GetValue<int?>("CO_fixed_rate"));
                coitemItem.SetValue<decimal?>("CO_exch_rate", coitemItem.GetValue<decimal?>("CO_exch_rate"));
                coitemItem.SetValue<string>("curr_code", coitemItem.GetValue<string>("curr_code"));
                coitemItem.SetValue<int?>("net_price", 0);
            };

            var coitemRequiredColumns = new List<string>() { "COITEM_ext_price", "due_date", "ship_date", "CO_discount_type", "CO_disc_amount", "CO_disc", "CO_amount", "CO_fixed_rate", "CO_exch_rate", "curr_code", "net_price" };

            coitemLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(coitemLoadResponse, coitemRequiredColumns);

            var coitemInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Coitem",
                items: coitemLoadResponse.Items);

            this.appDB.Insert(coitemInsertRequest);
        }

        public void CoitemUpdate()
        {
            var tv_CoitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"net_price","#tv_Coitem.net_price"},
                    {"u0","COITEM_ext_price"},
                    {"u1","CO_discount_type"},
                    {"u2","CO_disc"},
                    {"u3","CO_disc_amount"},
                    {"u4","CO_amount"},
                },
                tableName: "#tv_Coitem",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var tv_CoitemLoadResponse = this.appDB.Load(tv_CoitemLoadRequest);

            foreach (var tv_CoitemItem in tv_CoitemLoadResponse.Items)
            {
                tv_CoitemItem.SetValue<decimal?>("net_price", (decimal?)(tv_CoitemItem.GetDeletedValue<decimal?>("u0")) * (1.0M - (decimal?)((sQLUtil.SQLEqual(tv_CoitemItem.GetDeletedValue<string>("u1"), "P") == true ? tv_CoitemItem.GetDeletedValue<decimal?>("u2") : tv_CoitemItem.GetDeletedValue<decimal?>("u3") / (sQLUtil.SQLEqual(tv_CoitemItem.GetDeletedValue<decimal?>("u3") + tv_CoitemItem.GetDeletedValue<decimal?>("u4"), 0) == true ? 1 : tv_CoitemItem.GetDeletedValue<decimal?>("u3") + tv_CoitemItem.GetDeletedValue<decimal?>("u4")))) / 100.0M));
            };

            var tv_CoitemRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Coitem",
                items: tv_CoitemLoadResponse.Items);

            this.appDB.Update(tv_CoitemRequestUpdate);

        }

        public ICollectionLoadResponse Tv_Coitem1Select(string DomCurrCode)
        {
            var coitemCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"net_price","coitem.net_price"},
                    {"ship_date","coitem.ship_date"},
                    {"curr_code","coitem.curr_code"},
                    {"col0","CAST (NULL AS DECIMAL)"},
                    {"sequence","coitem.sequence"},
                    {"u0","coitem.CO_fixed_rate"},
                    {"u1","coitem.CO_exch_rate"},
                },
                tableName: "#tv_Coitem",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(" AS coitem"),
                whereClause: collectionLoadRequestFactory.Clause("curr_code != {0} AND COITEM_ext_price != 0", DomCurrCode),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var coitemCrsLoadResponseForCursor = this.appDB.Load(coitemCrsLoadRequestForCursor);
            foreach (var tv_Coitem1Item in coitemCrsLoadResponseForCursor.Items)
            {
                tv_Coitem1Item.SetValue<decimal?>("net_price", tv_Coitem1Item.GetValue<decimal?>("net_price"));
                tv_Coitem1Item.SetValue<DateTime?>("ship_date", tv_Coitem1Item.GetValue<DateTime?>("ship_date"));
                tv_Coitem1Item.SetValue<string>("curr_code", tv_Coitem1Item.GetValue<string>("curr_code"));
                tv_Coitem1Item.SetValue<decimal?>("col0", (sQLUtil.SQLEqual(tv_Coitem1Item.GetValue<int?>("u0"), 1) == true ? tv_Coitem1Item.GetValue<decimal?>("u1") : null));
                tv_Coitem1Item.SetValue<int?>("sequence", tv_Coitem1Item.GetValue<int?>("sequence"));
            };

            return coitemCrsLoadResponseForCursor;
        }

        public void Coitem2Update(int? Sequence, decimal? Price)
        {
            var tv_Coitem2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"net_price","#tv_Coitem.net_price"},
                },
                tableName: "#tv_Coitem",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("sequence = {0}", Sequence),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var tv_Coitem2LoadResponse = this.appDB.Load(tv_Coitem2LoadRequest);

            foreach (var tv_Coitem2Item in tv_Coitem2LoadResponse.Items)
            {
                tv_Coitem2Item.SetValue<decimal?>("net_price", Price);
            };

            var tv_Coitem2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Coitem",
                items: tv_Coitem2LoadResponse.Items);

            this.appDB.Update(tv_Coitem2RequestUpdate);

        }

        public (decimal? PeriodPlanned10, decimal? PeriodPlanned11, decimal? PeriodPlanned12, int? rowCount) Tv_Coitem3Load(DateTime? PeriodStart10,
            DateTime? PeriodEnd10,
            DateTime? PeriodStart11,
            DateTime? PeriodEnd11,
            DateTime? PeriodStart12,
            DateTime? PeriodEnd12,
            decimal? PeriodPlanned10,
            decimal? PeriodPlanned11,
            decimal? PeriodPlanned12)
        {
            AmtTotType _PeriodPlanned10 = DBNull.Value;
            AmtTotType _PeriodPlanned11 = DBNull.Value;
            AmtTotType _PeriodPlanned12 = DBNull.Value;

            var tv_Coitem3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_PeriodPlanned10,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart10)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd10)} THEN net_price ELSE 0 END)"},
                    {_PeriodPlanned11,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart11)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd11)} THEN net_price ELSE 0 END)"},
                    {_PeriodPlanned12,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart12)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd12)} THEN net_price ELSE 0 END)"},
                },
                tableName: "#tv_Coitem",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_Coitem3LoadResponse = this.appDB.Load(tv_Coitem3LoadRequest);
            if (tv_Coitem3LoadResponse.Items.Count > 0)
            {
                PeriodPlanned10 = _PeriodPlanned10;
                PeriodPlanned11 = _PeriodPlanned11;
                PeriodPlanned12 = _PeriodPlanned12;
            }

            int rowCount = tv_Coitem3LoadResponse.Items.Count;
            return (PeriodPlanned10, PeriodPlanned11, PeriodPlanned12, rowCount);
        }

        public void NontableInsert(decimal? PeriodActual, DateTime? PeriodEnd)
        {
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "amount", PeriodActual},
                    { "planned", 0},
                    { "period_end", stringUtil.Substring(
                        dateTimeUtil.DateName("Month",(PeriodEnd)),
                        1,
                        3)},
            });

            var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);

            var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTableLoadResponse.Items);

            this.appDB.Insert(nonTableInsertRequest);
        }

        public void Nontable2Insert(decimal? PeriodActual2, decimal? PeriodPlanned2, DateTime? PeriodEnd2)
        {
            var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "amount", PeriodActual2},
                    { "planned", PeriodPlanned2},
                    { "period_end", stringUtil.Substring(
                        dateTimeUtil.DateName("Month",(PeriodEnd2)),
                        1,
                        3)},
            });

            var nonTable2LoadResponse = this.appDB.Load(nonTable2LoadRequest);

            var nonTable2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable2LoadResponse.Items);

            this.appDB.Insert(nonTable2InsertRequest);
        }

        public void Nontable3Insert(decimal? PeriodPlanned3, DateTime? PeriodEnd3)
        {
            var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "amount", 0},
                    { "planned", PeriodPlanned3},
                    { "period_end", stringUtil.Substring(
                        dateTimeUtil.DateName("Month",(PeriodEnd3)),
                        1,
                        3)},
            });

            var nonTable3LoadResponse = this.appDB.Load(nonTable3LoadRequest);

            var nonTable3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable3LoadResponse.Items);

            this.appDB.Insert(nonTable3InsertRequest);

        }

        public ICollectionLoadResponse Tv_ResultsSelect()
        {
            var tv_resultsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"amount","amount"},
                    {"planned","planned"},
                    {"period_end","period_end"},
                },
                tableName: "#tv_results",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(tv_resultsLoadRequest);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Home_MetricShippingSp(
            string AltExtGenSp,
            int? NumberOfRows = 6)
        {
            IntType _NumberOfRows = NumberOfRows;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "NumberOfRows", _NumberOfRows, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
                var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

                return (resultSet, returnCode);
            }
        }

    }
}