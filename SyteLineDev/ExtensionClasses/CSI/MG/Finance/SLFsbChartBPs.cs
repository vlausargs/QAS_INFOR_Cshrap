//PROJECT NAME: FinanceExt
//CLASS NAME: SLFsbChartBPs.cs

using System;
using System.Data;
using CSI.Data.SQL.UDDT;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFsbChartBPs")]
    public class SLFsbChartBPs : ExtensionClassBase
    {        
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiFSBBudRollSp(string FSBName,
                                     string pAssetChart,
                                     string pLiabilityChart,
                                     string pOwnersEquityChart,
                                     string pRevenueChart,
                                     string pExpenseChart,
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

                var iSLFsbChartBPsExt = new MultiFSBBudRollFactory().Create(appDb);

                InfobarType orInfobar = rInfobar;

                int Severity = iSLFsbChartBPsExt.MultiFSBBudRollSp(FSBName,
                                                                   pAssetChart,
                                                                   pLiabilityChart,
                                                                   pOwnersEquityChart,
                                                                   pRevenueChart,
                                                                   pExpenseChart,
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
		public int MultiFSBChartBpSavePrepSp(byte? PNewRecord,
		                                     string pChartBpAcct,
		                                     string pChartBpAcctUnit1,
		                                     string pChartBpAcctUnit2,
		                                     string pChartBpAcctUnit3,
		                                     string pChartBpAcctUnit4,
		                                     short? pChartBpFiscalYear,
		                                     ref string Infobar,
		                                     [Optional] string FSBName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMultiFSBChartBpSavePrepExt = new MultiFSBChartBpSavePrepFactory().Create(appDb);
				
				var result = iMultiFSBChartBpSavePrepExt.MultiFSBChartBpSavePrepSp(PNewRecord,
				                                                                   pChartBpAcct,
				                                                                   pChartBpAcctUnit1,
				                                                                   pChartBpAcctUnit2,
				                                                                   pChartBpAcctUnit3,
				                                                                   pChartBpAcctUnit4,
				                                                                   pChartBpFiscalYear,
				                                                                   Infobar,
				                                                                   FSBName);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MultiFSBGetChartInfoSp(string pFSBName,
		                                  string pChartAcct,
		                                  ref string rChartType,
		                                  ref string rAccessUnit1,
		                                  ref string rAccessUnit2,
		                                  ref string rAccessUnit3,
		                                  ref string rAccessUnit4,
		                                  ref string rDescription,
		                                  ref string Infobar,
		                                  [Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMultiFSBGetChartInfoExt = new MultiFSBGetChartInfoFactory().Create(appDb);
				
				var result = iMultiFSBGetChartInfoExt.MultiFSBGetChartInfoSp(pFSBName,
				                                                             pChartAcct,
				                                                             rChartType,
				                                                             rAccessUnit1,
				                                                             rAccessUnit2,
				                                                             rAccessUnit3,
				                                                             rAccessUnit4,
				                                                             rDescription,
				                                                             Infobar,
				                                                             Site);
				
				int Severity = result.ReturnCode.Value;
				rChartType = result.rChartType;
				rAccessUnit1 = result.rAccessUnit1;
				rAccessUnit2 = result.rAccessUnit2;
				rAccessUnit3 = result.rAccessUnit3;
				rAccessUnit4 = result.rAccessUnit4;
				rDescription = result.rDescription;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
