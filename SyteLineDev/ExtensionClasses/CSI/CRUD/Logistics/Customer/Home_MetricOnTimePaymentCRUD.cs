//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricOnTimePaymentCRUD.cs

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
    public class Home_MetricOnTimePaymentCRUD : IHome_MetricOnTimePaymentCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IStringUtil stringUtil;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;

        public Home_MetricOnTimePaymentCRUD(IApplicationDB appDB,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            ISQLValueComparerUtil sQLUtil,
            IDateTimeUtil dateTimeUtil,
            IStringUtil stringUtil,
            ICollectionLoadResponseUtil collectionLoadResponseUtil)
        {
            this.appDB = appDB;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.sQLUtil = sQLUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.stringUtil = stringUtil;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricOnTimePaymentSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricOnTimePaymentSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_MetricOnTimePaymentSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };

            var optional_module1RequiredColumns = new List<string>() { "SpName" };

            return collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

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

        public (string Site, int? rowCount) ParmsLoad(string Site)
        {
            SiteType _Site = DBNull.Value;

            var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_Site,"site"},
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
                Site = _Site;
            }

            int rowCount = parmsLoadResponse.Items.Count;
            return (Site, rowCount);
        }

        public ICollectionLoadResponse Tv_PoitemSelect(DateTime? PerStart, DateTime? PerEnd)
        {
            var tv_poitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "due_date", "poitem.due_date" },
                    { "qty_ordered", "poitem.qty_ordered" },
                    { "qty_received_on_time", "isnull((SELECT sum(qty_received)"
                                + $"        FROM   po_rcpt"
                                + $"        WHERE  po_rcpt.po_num = poitem.po_num"
                                + $"               AND po_rcpt.po_line = poitem.po_line"
                                + $"               AND po_rcpt.po_release = poitem.po_release"
                                + $"               AND po_rcpt.rcvd_date <= dbo.DayEndOf(poitem.due_date)), 0)" },
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "poitem",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("poitem.due_date BETWEEN {0} AND {1}", PerStart, PerEnd),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(tv_poitemLoadRequest);
        }

        public void Tv_PoitemInsert(ICollectionLoadResponse tv_poitemLoadResponse)
        {
            var tv_poitemInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_poitem",
                items: tv_poitemLoadResponse.Items);

            this.appDB.Insert(tv_poitemInsertRequest);
        }

        public (decimal? PeriodTotal1,
            decimal? PeriodOnTime1,
            decimal? PeriodTotal2,
            decimal? PeriodOnTime2,
            decimal? PeriodTotal3,
            decimal? PeriodOnTime3,
            decimal? PeriodTotal4,
            decimal? PeriodOnTime4,
            decimal? PeriodTotal5,
            decimal? PeriodOnTime5,
            decimal? PeriodTotal6,
            decimal? PeriodOnTime6,
            decimal? PeriodTotal7,
            decimal? PeriodOnTime7,
            decimal? PeriodTotal8,
            decimal? PeriodOnTime8,
            decimal? PeriodTotal9,
            decimal? PeriodOnTime9,
            decimal? PeriodTotal10,
            decimal? PeriodOnTime10, int? rowCount)
        Tv_Poitem1Load(DateTime? PeriodStart1,
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
            decimal? PeriodTotal1,
            decimal? PeriodTotal2,
            decimal? PeriodTotal3,
            decimal? PeriodTotal4,
            decimal? PeriodTotal5,
            decimal? PeriodTotal6,
            decimal? PeriodTotal7,
            decimal? PeriodTotal8,
            decimal? PeriodTotal9,
            decimal? PeriodTotal10,
            decimal? PeriodOnTime1,
            decimal? PeriodOnTime2,
            decimal? PeriodOnTime3,
            decimal? PeriodOnTime4,
            decimal? PeriodOnTime5,
            decimal? PeriodOnTime6,
            decimal? PeriodOnTime7,
            decimal? PeriodOnTime8,
            decimal? PeriodOnTime9,
            decimal? PeriodOnTime10)
        {
            AmtTotType _PeriodTotal1 = DBNull.Value;
            AmtTotType _PeriodOnTime1 = DBNull.Value;
            AmtTotType _PeriodTotal2 = DBNull.Value;
            AmtTotType _PeriodOnTime2 = DBNull.Value;
            AmtTotType _PeriodTotal3 = DBNull.Value;
            AmtTotType _PeriodOnTime3 = DBNull.Value;
            AmtTotType _PeriodTotal4 = DBNull.Value;
            AmtTotType _PeriodOnTime4 = DBNull.Value;
            AmtTotType _PeriodTotal5 = DBNull.Value;
            AmtTotType _PeriodOnTime5 = DBNull.Value;
            AmtTotType _PeriodTotal6 = DBNull.Value;
            AmtTotType _PeriodOnTime6 = DBNull.Value;
            AmtTotType _PeriodTotal7 = DBNull.Value;
            AmtTotType _PeriodOnTime7 = DBNull.Value;
            AmtTotType _PeriodTotal8 = DBNull.Value;
            AmtTotType _PeriodOnTime8 = DBNull.Value;
            AmtTotType _PeriodTotal9 = DBNull.Value;
            AmtTotType _PeriodOnTime9 = DBNull.Value;
            AmtTotType _PeriodTotal10 = DBNull.Value;
            AmtTotType _PeriodOnTime10 = DBNull.Value;

            var tv_poitem1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_PeriodTotal1,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart1)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd1)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime1,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart1)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd1)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                    {_PeriodTotal2,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart2)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd2)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime2,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart2)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd2)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                    {_PeriodTotal3,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart3)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd3)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime3,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart3)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd3)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                    {_PeriodTotal4,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart4)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd4)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime4,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart4)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd4)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                    {_PeriodTotal5,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart5)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd5)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime5,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart5)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd5)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                    {_PeriodTotal6,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart6)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd6)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime6,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart6)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd6)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                    {_PeriodTotal7,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart7)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd7)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime7,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart7)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd7)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                    {_PeriodTotal8,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart8)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd8)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime8,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart8)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd8)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                    {_PeriodTotal9,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart9)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd9)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime9,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart9)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd9)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                    {_PeriodTotal10,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart10)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd10)} THEN 1 ELSE 0 END)"},
                    {_PeriodOnTime10,$"sum(CASE WHEN due_date BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart10)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd10)}              AND qty_received_on_time >= qty_ordered THEN 1 ELSE 0 END)"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_poitem",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_poitem1LoadResponse = this.appDB.Load(tv_poitem1LoadRequest);
            if (tv_poitem1LoadResponse.Items.Count > 0)
            {
                PeriodTotal1 = _PeriodTotal1;
                PeriodOnTime1 = _PeriodOnTime1;
                PeriodTotal2 = _PeriodTotal2;
                PeriodOnTime2 = _PeriodOnTime2;
                PeriodTotal3 = _PeriodTotal3;
                PeriodOnTime3 = _PeriodOnTime3;
                PeriodTotal4 = _PeriodTotal4;
                PeriodOnTime4 = _PeriodOnTime4;
                PeriodTotal5 = _PeriodTotal5;
                PeriodOnTime5 = _PeriodOnTime5;
                PeriodTotal6 = _PeriodTotal6;
                PeriodOnTime6 = _PeriodOnTime6;
                PeriodTotal7 = _PeriodTotal7;
                PeriodOnTime7 = _PeriodOnTime7;
                PeriodTotal8 = _PeriodTotal8;
                PeriodOnTime8 = _PeriodOnTime8;
                PeriodTotal9 = _PeriodTotal9;
                PeriodOnTime9 = _PeriodOnTime9;
                PeriodTotal10 = _PeriodTotal10;
                PeriodOnTime10 = _PeriodOnTime10;
            }

            int rowCount = tv_poitem1LoadResponse.Items.Count;
            return (PeriodTotal1, PeriodOnTime1, PeriodTotal2, PeriodOnTime2, PeriodTotal3, PeriodOnTime3, PeriodTotal4, PeriodOnTime4, PeriodTotal5, PeriodOnTime5, PeriodTotal6, PeriodOnTime6, PeriodTotal7, PeriodOnTime7, PeriodTotal8, PeriodOnTime8, PeriodTotal9, PeriodOnTime9, PeriodTotal10, PeriodOnTime10, rowCount);
        }

        public ICollectionLoadResponse NontableSelect(decimal? PeriodOnTime1, decimal? PeriodTotal1, DateTime? PeriodEnd1)
        {
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime1 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal1, 0) == true ? 1 : PeriodTotal1)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd1, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd1},
            });

            return this.appDB.Load(nonTableLoadRequest);
        }
        public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
        {
            var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTableLoadResponse.Items);

            this.appDB.Insert(nonTableInsertRequest);
        }

        public ICollectionLoadResponse Nontable1Select(decimal? PeriodOnTime2, decimal? PeriodTotal2, DateTime? PeriodEnd2)
        {
            var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime2 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal2, 0) == true ? 1 : PeriodTotal2)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd2, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd2},
            });

            return this.appDB.Load(nonTable1LoadRequest);
        }
        public void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse)
        {
            var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable1LoadResponse.Items);

            this.appDB.Insert(nonTable1InsertRequest);
        }

        public ICollectionLoadResponse Nontable2Select(decimal? PeriodOnTime3, decimal? PeriodTotal3, DateTime? PeriodEnd3)
        {
            var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime3 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal3, 0) == true ? 1 : PeriodTotal3)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd3, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd3},
            });

            return this.appDB.Load(nonTable2LoadRequest);
        }
        public void Nontable2Insert(ICollectionLoadResponse nonTable2LoadResponse)
        {
            var nonTable2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable2LoadResponse.Items);

            this.appDB.Insert(nonTable2InsertRequest);
        }

        public ICollectionLoadResponse Nontable3Select(decimal? PeriodOnTime4, decimal? PeriodTotal4, DateTime? PeriodEnd4)
        {
            var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime4 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal4, 0) == true ? 1 : PeriodTotal4)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd4, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd4},
            });

            return this.appDB.Load(nonTable3LoadRequest);
        }
        public void Nontable3Insert(ICollectionLoadResponse nonTable3LoadResponse)
        {
            var nonTable3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable3LoadResponse.Items);

            this.appDB.Insert(nonTable3InsertRequest);
        }

        public ICollectionLoadResponse Nontable4Select(decimal? PeriodOnTime5, decimal? PeriodTotal5, DateTime? PeriodEnd5)
        {
            var nonTable4LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime5 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal5, 0) == true ? 1 : PeriodTotal5)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd5, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd5},
            });

            return this.appDB.Load(nonTable4LoadRequest);
        }
        public void Nontable4Insert(ICollectionLoadResponse nonTable4LoadResponse)
        {
            var nonTable4InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable4LoadResponse.Items);

            this.appDB.Insert(nonTable4InsertRequest);
        }

        public ICollectionLoadResponse Nontable5Select(decimal? PeriodOnTime6, decimal? PeriodTotal6, DateTime? PeriodEnd6)
        {
            var nonTable5LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime6 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal6, 0) == true ? 1 : PeriodTotal6)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd6, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd6},
            });

            return this.appDB.Load(nonTable5LoadRequest);
        }
        public void Nontable5Insert(ICollectionLoadResponse nonTable5LoadResponse)
        {
            var nonTable5InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable5LoadResponse.Items);

            this.appDB.Insert(nonTable5InsertRequest);
        }

        public ICollectionLoadResponse Nontable6Select(decimal? PeriodOnTime7, decimal? PeriodTotal7, DateTime? PeriodEnd7)
        {
            var nonTable6LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime7 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal7, 0) == true ? 1 : PeriodTotal7)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd7, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd7},
            });

            return this.appDB.Load(nonTable6LoadRequest);
        }
        public void Nontable6Insert(ICollectionLoadResponse nonTable6LoadResponse)
        {
            var nonTable6InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable6LoadResponse.Items);

            this.appDB.Insert(nonTable6InsertRequest);
        }

        public ICollectionLoadResponse Nontable7Select(decimal? PeriodOnTime8, decimal? PeriodTotal8, DateTime? PeriodEnd8)
        {
            var nonTable7LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime8 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal8, 0) == true ? 1 : PeriodTotal8)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd8, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd8},
            });

            return this.appDB.Load(nonTable7LoadRequest);
        }
        public void Nontable7Insert(ICollectionLoadResponse nonTable7LoadResponse)
        {
            var nonTable7InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable7LoadResponse.Items);

            this.appDB.Insert(nonTable7InsertRequest);
        }

        public ICollectionLoadResponse Nontable8Select(decimal? PeriodOnTime9, decimal? PeriodTotal9, DateTime? PeriodEnd9)
        {
            var nonTable8LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime9 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal9, 0) == true ? 1 : PeriodTotal9)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd9, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd9},
            });

            return this.appDB.Load(nonTable8LoadRequest);
        }
        public void Nontable8Insert(ICollectionLoadResponse nonTable8LoadResponse)
        {
            var nonTable8InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable8LoadResponse.Items);

            this.appDB.Insert(nonTable8InsertRequest);
        }

        public ICollectionLoadResponse Nontable9Select(decimal? PeriodOnTime10, decimal? PeriodTotal10, DateTime? PeriodEnd10)
        {
            var nonTable9LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime10 * 100.0M / (sQLUtil.SQLEqual(PeriodTotal10, 0) == true ? 1 : PeriodTotal10)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd10, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd10},
            });

            return this.appDB.Load(nonTable9LoadRequest);
        }
        public void Nontable9Insert(ICollectionLoadResponse nonTable9LoadResponse)
        {
            var nonTable9InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
                items: nonTable9LoadResponse.Items);

            this.appDB.Insert(nonTable9InsertRequest);
        }

        public ICollectionLoadResponse Tv_ResultsSelect()
        {
            var tv_resultsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"on_time","on_time"},
                    {"period_end","period_end"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_results",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(" period_end_date"));
            return this.appDB.Load(tv_resultsLoadRequest);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Home_MetricOnTimePaymentSp(
            string AltExtGenSp,
            int? Count = 4)
        {
            IntType _Count = Count;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "Count", _Count, ParameterDirection.Input);

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
