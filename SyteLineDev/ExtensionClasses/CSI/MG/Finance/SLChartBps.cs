//PROJECT NAME: FinanceExt
//CLASS NAME: SLChartBps.cs

using System;
using System.Data;
using CSI.Data.SQL.UDDT;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using CSI.Finance.Chart;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using CSI.Reporting;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLChartBps")]
    public class SLChartBps : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateSpecifiedUnitCodeForDistributionSp(string CompareAccount,
                                                              string unit1,
                                                              string unit2,
                                                              string unit3,
                                                              string unit4,
                                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLChartBpsExt = new ValidateSpecifiedUnitCodeForDistributionFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSLChartBpsExt.ValidateSpecifiedUnitCodeForDistributionSp(CompareAccount,
                                                                                         unit1,
                                                                                         unit2,
                                                                                         unit3,
                                                                                         unit4,
                                                                                         ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateUnitCodeForDistributionSp(string TargetAccount,
                                                      string DistributionAccount,
                                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLChartBpsExt = new ValidateUnitCodeForDistributionFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSLChartBpsExt.ValidateUnitCodeForDistributionSp(TargetAccount,
                                                                                DistributionAccount,
                                                                                ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ChartBpSavePrepSp(byte? PNewRecord,
                                      string pChartBpAcct,
                                      string pChartBpAcctUnit1,
                                      string pChartBpAcctUnit2,
                                      string pChartBpAcctUnit3,
                                      string pChartBpAcctUnit4,
                                      short? pChartBpFiscalYear,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLChartBpsExt = new ChartBpSavePrepFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLChartBpsExt.ChartBpSavePrepSp(PNewRecord,
                                                                pChartBpAcct,
                                                                pChartBpAcctUnit1,
                                                                pChartBpAcctUnit2,
                                                                pChartBpAcctUnit3,
                                                                pChartBpAcctUnit4,
                                                                pChartBpFiscalYear,
                                                                ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int BudrollSp(string pAssetChart,
                             string pLiabilityChart,
                             string pOwnersEquityChart,
                             string pRevenueChart,
                             string pExpenseChart,
                             string pAnalyticalChart,
                             short? pFromFiscalYear,
                             short? pToFiscalYear,
                             string pBudPlan,
                             string pBegAcct,
                             string pEndAcct,
                             string pBegAcctUnit1,
                             string pEndAcctUnit1,
                             string pBegAcctUnit2,
                             string pEndAcctUnit2,
                             string pBegAcctUnit3,
                             string pEndAcctUnit3,
                             string pBegAcctUnit4,
                             string pEndAcctUnit4,
                             ref string rInfobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLChartBpsExt = new BudrollFactory().Create(appDb);

                InfobarType orInfobar = rInfobar;

                int Severity = iSLChartBpsExt.BudrollSp(pAssetChart,
                                                        pLiabilityChart,
                                                        pOwnersEquityChart,
                                                        pRevenueChart,
                                                        pExpenseChart,
                                                        pAnalyticalChart,
                                                        pFromFiscalYear,
                                                        pToFiscalYear,
                                                        pBudPlan,
                                                        pBegAcct,
                                                        pEndAcct,
                                                        pBegAcctUnit1,
                                                        pEndAcctUnit1,
                                                        pBegAcctUnit2,
                                                        pEndAcctUnit2,
                                                        pBegAcctUnit3,
                                                        pEndAcctUnit3,
                                                        pBegAcctUnit4,
                                                        pEndAcctUnit4,
                                                        ref orInfobar);

                rInfobar = orInfobar;


                return Severity;
            }
        }










		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetChartInfoSp(string pChartAcct,
		ref string rChartType,
		ref string rAccessUnit1,
		ref string rAccessUnit2,
		ref string rAccessUnit3,
		ref string rAccessUnit4,
		ref string rDescription,
		ref string Infobar,
		[Optional] string Site,
		ref int? rIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetChartInfoExt = new GetChartInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetChartInfoExt.GetChartInfoSp(pChartAcct,
				rChartType,
				rAccessUnit1,
				rAccessUnit2,
				rAccessUnit3,
				rAccessUnit4,
				rDescription,
				Infobar,
				Site,
				rIsControl);
				
				int Severity = result.ReturnCode.Value;
				rChartType = result.rChartType;
				rAccessUnit1 = result.rAccessUnit1;
				rAccessUnit2 = result.rAccessUnit2;
				rAccessUnit3 = result.rAccessUnit3;
				rAccessUnit4 = result.rAccessUnit4;
				rDescription = result.rDescription;
				Infobar = result.Infobar;
				rIsControl = result.rIsControl;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetFiscalPeriodsSp(int? pFiscalYear,
		ref DateTime? rPer1Start,
		ref DateTime? rPer2Start,
		ref DateTime? rPer3Start,
		ref DateTime? rPer4Start,
		ref DateTime? rPer5Start,
		ref DateTime? rPer6Start,
		ref DateTime? rPer7Start,
		ref DateTime? rPer8Start,
		ref DateTime? rPer9Start,
		ref DateTime? rPer10Start,
		ref DateTime? rPer11Start,
		ref DateTime? rPer12Start,
		ref DateTime? rPer13Start,
		ref DateTime? rPer1End,
		ref DateTime? rPer2End,
		ref DateTime? rPer3End,
		ref DateTime? rPer4End,
		ref DateTime? rPer5End,
		ref DateTime? rPer6End,
		ref DateTime? rPer7End,
		ref DateTime? rPer8End,
		ref DateTime? rPer9End,
		ref DateTime? rPer10End,
		ref DateTime? rPer11End,
		ref DateTime? rPer12End,
		ref DateTime? rPer13End,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetFiscalPeriodsExt = new GetFiscalPeriodsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetFiscalPeriodsExt.GetFiscalPeriodsSp(pFiscalYear,
				rPer1Start,
				rPer2Start,
				rPer3Start,
				rPer4Start,
				rPer5Start,
				rPer6Start,
				rPer7Start,
				rPer8Start,
				rPer9Start,
				rPer10Start,
				rPer11Start,
				rPer12Start,
				rPer13Start,
				rPer1End,
				rPer2End,
				rPer3End,
				rPer4End,
				rPer5End,
				rPer6End,
				rPer7End,
				rPer8End,
				rPer9End,
				rPer10End,
				rPer11End,
				rPer12End,
				rPer13End,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				rPer1Start = result.rPer1Start;
				rPer2Start = result.rPer2Start;
				rPer3Start = result.rPer3Start;
				rPer4Start = result.rPer4Start;
				rPer5Start = result.rPer5Start;
				rPer6Start = result.rPer6Start;
				rPer7Start = result.rPer7Start;
				rPer8Start = result.rPer8Start;
				rPer9Start = result.rPer9Start;
				rPer10Start = result.rPer10Start;
				rPer11Start = result.rPer11Start;
				rPer12Start = result.rPer12Start;
				rPer13Start = result.rPer13Start;
				rPer1End = result.rPer1End;
				rPer2End = result.rPer2End;
				rPer3End = result.rPer3End;
				rPer4End = result.rPer4End;
				rPer5End = result.rPer5End;
				rPer6End = result.rPer6End;
				rPer7End = result.rPer7End;
				rPer8End = result.rPer8End;
				rPer9End = result.rPer9End;
				rPer10End = result.rPer10End;
				rPer11End = result.rPer11End;
				rPer12End = result.rPer12End;
				rPer13End = result.rPer13End;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public DataTable GLBudgetConsbpSp(DateTime? pCutoffDate,
		int? pPostTrx,
		int? pSummaryOrDetail,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iGLBudgetConsbpExt = new GLBudgetConsbpFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iGLBudgetConsbpExt.GLBudgetConsbpSp(pCutoffDate,
                pPostTrx,
                pSummaryOrDetail,
                pSite);


                if (result.Data is null)
                    return new DataTable();
                else
                {
                    IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                    return recordCollectionToDataTable.ToDataTable(result.Data.Items);
                }
            }
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PostedTrnsAcctSummSp(string PAcct,
		int? PFiscalYear,
		ref string Infobar,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPostedTrnsAcctSummExt = new PostedTrnsAcctSummFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPostedTrnsAcctSummExt.PostedTrnsAcctSummSp(PAcct,
				PFiscalYear,
				Infobar,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}