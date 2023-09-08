//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricShipping.cs

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
using CSI.Logistics.Vendor;

namespace CSI.Logistics.Customer
{
    public class Home_MetricShipping : IHome_MetricShipping
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ITransactionFactory transactionFactory;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly IGetSiteDate iGetSiteDate;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IMidnightOf iMidnightOf;
        readonly IStringUtil stringUtil;
        readonly IDayEndOf iDayEndOf;
        readonly ICurrCnvt iCurrCnvt;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IHome_MetricShippingCRUD iHome_MetricShippingCRUD;

        public Home_MetricShipping(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            IGetSiteDate iGetSiteDate,
            IDateTimeUtil dateTimeUtil,
            IMidnightOf iMidnightOf,
            IStringUtil stringUtil,
            IDayEndOf iDayEndOf,
            ICurrCnvt iCurrCnvt,
            ISQLValueComparerUtil sQLUtil,
            IHome_MetricShippingCRUD iHome_MetricShippingCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.transactionFactory = transactionFactory;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.iGetSiteDate = iGetSiteDate;
            this.dateTimeUtil = dateTimeUtil;
            this.iMidnightOf = iMidnightOf;
            this.stringUtil = stringUtil;
            this.iDayEndOf = iDayEndOf;
            this.iCurrCnvt = iCurrCnvt;
            this.sQLUtil = sQLUtil;
            this.iHome_MetricShippingCRUD = iHome_MetricShippingCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Home_MetricShippingSp(
            int? NumberOfRows = 6)
        {

            ICollectionLoadResponse Data = null;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            string Infobar = null;
            DateTime? Today = null;
            DateTime? PeriodStart1 = null;
            DateTime? PeriodStart2 = null;
            DateTime? PeriodStart3 = null;
            DateTime? PeriodStart4 = null;
            DateTime? PeriodStart5 = null;
            DateTime? PeriodStart6 = null;
            DateTime? PeriodStart7 = null;
            DateTime? PeriodStart8 = null;
            DateTime? PeriodStart9 = null;
            DateTime? PeriodStart10 = null;
            DateTime? PeriodStart11 = null;
            DateTime? PeriodStart12 = null;
            DateTime? PeriodEnd1 = null;
            DateTime? PeriodEnd2 = null;
            DateTime? PeriodEnd3 = null;
            DateTime? PeriodEnd4 = null;
            DateTime? PeriodEnd5 = null;
            DateTime? PeriodEnd6 = null;
            DateTime? PeriodEnd7 = null;
            DateTime? PeriodEnd8 = null;
            DateTime? PeriodEnd9 = null;
            DateTime? PeriodEnd10 = null;
            DateTime? PeriodEnd11 = null;
            DateTime? PeriodEnd12 = null;
            decimal? PeriodActual1 = null;
            decimal? PeriodActual2 = null;
            decimal? PeriodActual3 = null;
            decimal? PeriodActual4 = null;
            decimal? PeriodActual5 = null;
            decimal? PeriodActual6 = null;
            decimal? PeriodActual7 = null;
            decimal? PeriodActual8 = null;
            decimal? PeriodActual9 = null;
            decimal? PeriodActual10 = null;
            decimal? PeriodPlanned10 = null;
            decimal? PeriodPlanned11 = null;
            decimal? PeriodPlanned12 = null;
            string DomCurrCode = null;
            decimal? Price = null;
            DateTime? ShipDate = null;
            string CoCurrCode = null;
            int? Sequence = null;
            string ParmsSite = null;
            decimal? ExchRate = null;
            ICollectionLoadResponse co_shipCrsLoadResponseForCursor = null;
            int co_shipCrs_CursorFetch_Status = -1;
            int co_shipCrs_CursorCounter = -1;
            ICollectionLoadResponse coitemCrsLoadResponseForCursor = null;
            int coitemCrs_CursorFetch_Status = -1;
            int coitemCrs_CursorCounter = -1;
            if (this.iHome_MetricShippingCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

                this.iHome_MetricShippingCRUD.Optional_ModuleInsertSelect();
                while (this.iHome_MetricShippingCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iHome_MetricShippingCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iHome_MetricShippingCRUD.AltExtGen_Home_MetricShippingSp(ALTGEN_SpName,
                        NumberOfRows);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                                        
                    this.iHome_MetricShippingCRUD.Tv_ALTGEN2Delete(ALTGEN_SpName);

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_MetricShippingSp") != null)
            {
                var EXTGEN = this.iHome_MetricShippingCRUD.AltExtGen_Home_MetricShippingSp("dbo.EXTGEN_Home_MetricShippingSp",
                    NumberOfRows);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @results TABLE (
				    amount     AmtTotType  ,
				    planned    AmtTotType  ,
				    period_end NVARCHAR (6));
				SELECT * into #tv_results from @results");
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @CoShip TABLE (
				    CO_SHIP_ext_price AmountType           ,
				    ship_date         DateType             ,
				    CO_discount_type  ListAmountPercentType,
				    CO_disc_amount    AmountType           ,
				    CO_disc           OrderDiscType        ,
				    CO_amount         AmountType           ,
				    CO_fixed_rate     ListYesNoType        ,
				    CO_exch_rate      ExchRateType         ,
				    curr_code         CurrCodeType         ,
				    net_price         AmountType           ,
				    sequence          INT                   IDENTITY);
				SELECT * into #tv_CoShip from @CoShip
				ALTER TABLE #tv_CoShip ADD PRIMARY KEY (sequence)");
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @Coitem TABLE (
				    COITEM_ext_price AmountType           ,
				    due_date         DateType             ,
				    ship_date        DateType             ,
				    CO_discount_type ListAmountPercentType,
				    CO_disc_amount   AmountType           ,
				    CO_disc          OrderDiscType        ,
				    CO_amount        AmountType           ,
				    CO_fixed_rate    ListYesNoType        ,
				    CO_exch_rate     ExchRateType         ,
				    curr_code        CurrCodeType         ,
				    net_price        AmountType           ,
				    sequence         INT                   IDENTITY);
				SELECT * into #tv_Coitem from @Coitem
				ALTER TABLE #tv_Coitem ADD PRIMARY KEY (sequence)");
            NumberOfRows = (int?)(stringUtil.IsNull(
                NumberOfRows,
                6));
            if (sQLUtil.SQLGreaterThan(NumberOfRows, 12) == true)
            {
                NumberOfRows = 12;

            }
            Severity = 0;
            Today = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
            (DomCurrCode, rowCount) = this.iHome_MetricShippingCRUD.CurrparmsLoad(DomCurrCode);
            (ParmsSite, rowCount) = this.iHome_MetricShippingCRUD.ParmsLoad(ParmsSite);
            PeriodStart10 = convertToUtil.ToDateTime(Convert.ToString(dateTimeUtil.Year<int?>(Today)) + stringUtil.Replace(
                stringUtil.Str(
                    dateTimeUtil.Month<int?>(Today),
                    2),
                " ",
                "0") + "01");
            PeriodStart1 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", -9, PeriodStart10));
            PeriodStart2 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", -8, PeriodStart10));
            PeriodStart3 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", -7, PeriodStart10));
            PeriodStart4 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", -6, PeriodStart10));
            PeriodStart5 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", -5, PeriodStart10));
            PeriodStart6 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", -4, PeriodStart10));
            PeriodStart7 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", -3, PeriodStart10));
            PeriodStart8 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", -2, PeriodStart10));
            PeriodStart9 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", -1, PeriodStart10));
            PeriodStart11 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", 1, PeriodStart10));
            PeriodStart12 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", 2, PeriodStart10));
            PeriodEnd1 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart2)));
            PeriodEnd2 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart3)));
            PeriodEnd3 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart4)));
            PeriodEnd4 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart5)));
            PeriodEnd5 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart6)));
            PeriodEnd6 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart7)));
            PeriodEnd7 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart8)));
            PeriodEnd8 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart9)));
            PeriodEnd9 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart10)));
            PeriodEnd10 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart11)));
            PeriodEnd11 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart12)));
            PeriodEnd12 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, dateTimeUtil.DateAdd("Month", 1, PeriodStart12))));

            this.iHome_MetricShippingCRUD.Co_ShipInsert(PeriodStart1, PeriodEnd10);
            this.iHome_MetricShippingCRUD.CoshipUpdate();
            #region Cursor Statement
            co_shipCrsLoadResponseForCursor = this.iHome_MetricShippingCRUD.Tv_Coship1Select(DomCurrCode);
            co_shipCrs_CursorFetch_Status = co_shipCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
            co_shipCrs_CursorCounter = -1;

            #endregion Cursor Statement
            while (sQLUtil.SQLEqual(1, 1) == true)
            {
                co_shipCrs_CursorCounter++;
                if (co_shipCrsLoadResponseForCursor.Items.Count > co_shipCrs_CursorCounter)
                {
                    Price = co_shipCrsLoadResponseForCursor.Items[co_shipCrs_CursorCounter].GetValue<decimal?>(0);
                    ShipDate = co_shipCrsLoadResponseForCursor.Items[co_shipCrs_CursorCounter].GetValue<DateTime?>(1);
                    CoCurrCode = co_shipCrsLoadResponseForCursor.Items[co_shipCrs_CursorCounter].GetValue<string>(2);
                    ExchRate = co_shipCrsLoadResponseForCursor.Items[co_shipCrs_CursorCounter].GetValue<decimal?>(3);
                    Sequence = co_shipCrsLoadResponseForCursor.Items[co_shipCrs_CursorCounter].GetValue<int?>(4);
                }
                co_shipCrs_CursorFetch_Status = (co_shipCrs_CursorCounter == co_shipCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLNotEqual(co_shipCrs_CursorFetch_Status, 0) == true)
                {

                    break;

                }

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: CurrCnvtSp
                var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
                    CurrCode: CoCurrCode,
                    FromDomestic: 0,
                    UseBuyRate: 0,
                    RoundResult: 1,
                    Date: ShipDate,
                    TRate: ExchRate,
                    Infobar: Infobar,
                    Amount1: Price,
                    Result1: Price,
                    Site: ParmsSite,
                    DomCurrCode: DomCurrCode);
                Severity = CurrCnvt.ReturnCode;
                Infobar = CurrCnvt.Infobar;
                Price = CurrCnvt.Result1;

                #endregion ExecuteMethodCall

                this.iHome_MetricShippingCRUD.Coship2Update(Sequence, Price);

            }
            //Deallocate Cursor co_shipCrs
            (PeriodActual1,
                 PeriodActual2,
                 PeriodActual3,
                 PeriodActual4,
                 PeriodActual5,
                 PeriodActual6,
                 PeriodActual7,
                 PeriodActual8,
                 PeriodActual9,
                 PeriodActual10, rowCount) = this.iHome_MetricShippingCRUD.Tv_Coship3Load(PeriodStart1,
                 PeriodEnd1,
                 PeriodStart2,
                 PeriodEnd2,
                 PeriodStart3,
                 PeriodEnd3,
                 PeriodStart4,
                 PeriodEnd4,
                 PeriodStart5,
                 PeriodEnd5,
                 PeriodStart6,
                 PeriodEnd6,
                 PeriodStart7,
                 PeriodEnd7,
                 PeriodStart8,
                 PeriodEnd8,
                 PeriodStart9,
                 PeriodEnd9,
                 PeriodStart10,
                 PeriodEnd10,
                 PeriodActual1,
                 PeriodActual2,
                 PeriodActual3,
                 PeriodActual4,
                 PeriodActual5,
                 PeriodActual6,
                 PeriodActual7,
                 PeriodActual8,
                 PeriodActual9,
                 PeriodActual10);

            this.iHome_MetricShippingCRUD.CoitemInsert(PeriodStart10, PeriodEnd12);
            this.iHome_MetricShippingCRUD.CoitemUpdate();
            #region Cursor Statement
            coitemCrsLoadResponseForCursor = this.iHome_MetricShippingCRUD.Tv_Coitem1Select(DomCurrCode);
            coitemCrs_CursorFetch_Status = coitemCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
            coitemCrs_CursorCounter = -1;

            #endregion Cursor Statement
            while (sQLUtil.SQLEqual(1, 1) == true)
            {
                coitemCrs_CursorCounter++;
                if (coitemCrsLoadResponseForCursor.Items.Count > coitemCrs_CursorCounter)
                {
                    Price = coitemCrsLoadResponseForCursor.Items[coitemCrs_CursorCounter].GetValue<decimal?>(0);
                    ShipDate = coitemCrsLoadResponseForCursor.Items[coitemCrs_CursorCounter].GetValue<DateTime?>(1);
                    CoCurrCode = coitemCrsLoadResponseForCursor.Items[coitemCrs_CursorCounter].GetValue<string>(2);
                    ExchRate = coitemCrsLoadResponseForCursor.Items[coitemCrs_CursorCounter].GetValue<decimal?>(3);
                    Sequence = coitemCrsLoadResponseForCursor.Items[coitemCrs_CursorCounter].GetValue<int?>(4);
                }
                coitemCrs_CursorFetch_Status = (coitemCrs_CursorCounter == coitemCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLNotEqual(coitemCrs_CursorFetch_Status, 0) == true)
                {

                    break;

                }

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: CurrCnvtSp
                var CurrCnvt1 = this.iCurrCnvt.CurrCnvtSp(
                    CurrCode: CoCurrCode,
                    FromDomestic: 0,
                    UseBuyRate: 0,
                    RoundResult: 1,
                    Date: ShipDate,
                    TRate: ExchRate,
                    Infobar: Infobar,
                    Amount1: Price,
                    Result1: Price,
                    Site: ParmsSite,
                    DomCurrCode: DomCurrCode);
                Severity = CurrCnvt1.ReturnCode;
                Infobar = CurrCnvt1.Infobar;
                Price = CurrCnvt1.Result1;

                #endregion ExecuteMethodCall

                this.iHome_MetricShippingCRUD.Coitem2Update(Sequence, Price);

            }
            //Deallocate Cursor coitemCrs
            (PeriodPlanned10, PeriodPlanned11, PeriodPlanned12, rowCount) = this.iHome_MetricShippingCRUD.Tv_Coitem3Load(PeriodStart10,
                 PeriodEnd10,
                 PeriodStart11,
                 PeriodEnd11,
                 PeriodStart12,
                 PeriodEnd12,
                 PeriodPlanned10,
                 PeriodPlanned11,
                 PeriodPlanned12);
            if (sQLUtil.SQLGreaterThanOrEqual(NumberOfRows, 12) == true)
            {
                this.iHome_MetricShippingCRUD.NontableInsert(PeriodActual1, PeriodEnd1);

            }
            if (sQLUtil.SQLGreaterThanOrEqual(NumberOfRows, 11) == true)
            {
                this.iHome_MetricShippingCRUD.NontableInsert(PeriodActual2, PeriodEnd2);

            }
            if (sQLUtil.SQLGreaterThanOrEqual(NumberOfRows, 10) == true)
            {
                this.iHome_MetricShippingCRUD.NontableInsert(PeriodActual3, PeriodEnd3);

            }
            if (sQLUtil.SQLGreaterThanOrEqual(NumberOfRows, 9) == true)
            {
                this.iHome_MetricShippingCRUD.NontableInsert(PeriodActual4, PeriodEnd4);

            }
            if (sQLUtil.SQLGreaterThanOrEqual(NumberOfRows, 8) == true)
            {
                this.iHome_MetricShippingCRUD.NontableInsert(PeriodActual5, PeriodEnd5);

            }
            if (sQLUtil.SQLGreaterThanOrEqual(NumberOfRows, 7) == true)
            {
                this.iHome_MetricShippingCRUD.NontableInsert(PeriodActual6, PeriodEnd6);

            }
            if (sQLUtil.SQLGreaterThanOrEqual(NumberOfRows, 6) == true)
            {
                this.iHome_MetricShippingCRUD.NontableInsert(PeriodActual7, PeriodEnd7);

            }
            if (sQLUtil.SQLGreaterThanOrEqual(NumberOfRows, 5) == true)
            {
                this.iHome_MetricShippingCRUD.NontableInsert(PeriodActual8, PeriodEnd8);

            }
            if (sQLUtil.SQLGreaterThanOrEqual(NumberOfRows, 4) == true)
            {
                this.iHome_MetricShippingCRUD.NontableInsert(PeriodActual9, PeriodEnd9);

            }

            this.iHome_MetricShippingCRUD.Nontable2Insert(PeriodActual10, PeriodPlanned10, PeriodEnd10);
            this.iHome_MetricShippingCRUD.Nontable3Insert(PeriodPlanned11, PeriodEnd11);
            this.iHome_MetricShippingCRUD.Nontable3Insert(PeriodPlanned12, PeriodEnd12);

            var tv_resultsLoadResponse = this.iHome_MetricShippingCRUD.Tv_ResultsSelect();
            Data = tv_resultsLoadResponse;

            return (Data, Severity);

        }

    }
}