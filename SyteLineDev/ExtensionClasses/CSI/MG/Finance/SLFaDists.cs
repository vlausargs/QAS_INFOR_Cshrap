//PROJECT NAME: FinanceExt
//CLASS NAME: SLFaDists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using CSI.Finance.FixedAssets;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFaDists")]
    public class SLFaDists : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_FaPostSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSLFaDistsExt = new CLM_FaPostFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSLFaDistsExt.CLM_FaPostSp();

                return dt;
            }
        }








		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FaDispDistSp(string pFaNum,
		ref string rFaDescription,
		ref string rFaClassCode,
		ref string rDepartment,
		ref string rDepDescription,
		ref string rGLAssetAcct,
		ref string rGLAssetAcctUnit1,
		ref string rGLAssetAcctUnit2,
		ref string rGLAssetAcctUnit3,
		ref string rGLAssetAcctUnit4,
		ref string rGLAssetAcctDescription,
		ref string rGLAccumAcct,
		ref string rGLAccumAcctUnit1,
		ref string rGLAccumAcctUnit2,
		ref string rGLAccumAcctUnit3,
		ref string rGLAccumAcctUnit4,
		ref string rGLAccumAcctDescription,
		ref decimal? rFaPurchaseAmount,
		ref decimal? rFaEnhancementAmount,
		ref decimal? rAccumDeprec,
		ref decimal? rCurrentValue,
		ref DateTime? rDisposalDate,
		ref decimal? rDisposalAmount,
		ref decimal? rGainLoss,
		ref int? rFaDistSeq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFaDispDistExt = new FaDispDistFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFaDispDistExt.FaDispDistSp(pFaNum,
				rFaDescription,
				rFaClassCode,
				rDepartment,
				rDepDescription,
				rGLAssetAcct,
				rGLAssetAcctUnit1,
				rGLAssetAcctUnit2,
				rGLAssetAcctUnit3,
				rGLAssetAcctUnit4,
				rGLAssetAcctDescription,
				rGLAccumAcct,
				rGLAccumAcctUnit1,
				rGLAccumAcctUnit2,
				rGLAccumAcctUnit3,
				rGLAccumAcctUnit4,
				rGLAccumAcctDescription,
				rFaPurchaseAmount,
				rFaEnhancementAmount,
				rAccumDeprec,
				rCurrentValue,
				rDisposalDate,
				rDisposalAmount,
				rGainLoss,
				rFaDistSeq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				rFaDescription = result.rFaDescription;
				rFaClassCode = result.rFaClassCode;
				rDepartment = result.rDepartment;
				rDepDescription = result.rDepDescription;
				rGLAssetAcct = result.rGLAssetAcct;
				rGLAssetAcctUnit1 = result.rGLAssetAcctUnit1;
				rGLAssetAcctUnit2 = result.rGLAssetAcctUnit2;
				rGLAssetAcctUnit3 = result.rGLAssetAcctUnit3;
				rGLAssetAcctUnit4 = result.rGLAssetAcctUnit4;
				rGLAssetAcctDescription = result.rGLAssetAcctDescription;
				rGLAccumAcct = result.rGLAccumAcct;
				rGLAccumAcctUnit1 = result.rGLAccumAcctUnit1;
				rGLAccumAcctUnit2 = result.rGLAccumAcctUnit2;
				rGLAccumAcctUnit3 = result.rGLAccumAcctUnit3;
				rGLAccumAcctUnit4 = result.rGLAccumAcctUnit4;
				rGLAccumAcctDescription = result.rGLAccumAcctDescription;
				rFaPurchaseAmount = result.rFaPurchaseAmount;
				rFaEnhancementAmount = result.rFaEnhancementAmount;
				rAccumDeprec = result.rAccumDeprec;
				rCurrentValue = result.rCurrentValue;
				rDisposalDate = result.rDisposalDate;
				rDisposalAmount = result.rDisposalAmount;
				rGainLoss = result.rGainLoss;
				rFaDistSeq = result.rFaDistSeq;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FaPostSp(Guid? CurrFadistRowPointer,
		int? IsLastFadistFaNum,
		ref decimal? DTot,
		ref int? XErrorCnt,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFaPostExt = new FaPostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFaPostExt.FaPostSp(CurrFadistRowPointer,
				IsLastFadistFaNum,
				DTot,
				XErrorCnt,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				DTot = result.DTot;
				XErrorCnt = result.XErrorCnt;
				Infobar = result.Infobar;
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
		public int GetInitialFaDispSp(string pFaNum,
		string pClass,
		string pDept,
		ref string rGLAsstAcct,
		ref string rGLAsstUnit1,
		ref string rGLAsstUnit2,
		ref string rGLAsstUnit3,
		ref string rGLAsstUnit4,
		ref string rGLResAcct,
		ref string rGLResUnit1,
		ref string rGLResUnit2,
		ref string rGLResUnit3,
		ref string rGLResUnit4,
		ref decimal? rFadeprBonusDepr,
		ref decimal? rFadeprAccumDepr,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetInitialFaDispExt = new GetInitialFaDispFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetInitialFaDispExt.GetInitialFaDispSp(pFaNum,
				pClass,
				pDept,
				rGLAsstAcct,
				rGLAsstUnit1,
				rGLAsstUnit2,
				rGLAsstUnit3,
				rGLAsstUnit4,
				rGLResAcct,
				rGLResUnit1,
				rGLResUnit2,
				rGLResUnit3,
				rGLResUnit4,
				rFadeprBonusDepr,
				rFadeprAccumDepr,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				rGLAsstAcct = result.rGLAsstAcct;
				rGLAsstUnit1 = result.rGLAsstUnit1;
				rGLAsstUnit2 = result.rGLAsstUnit2;
				rGLAsstUnit3 = result.rGLAsstUnit3;
				rGLAsstUnit4 = result.rGLAsstUnit4;
				rGLResAcct = result.rGLResAcct;
				rGLResUnit1 = result.rGLResUnit1;
				rGLResUnit2 = result.rGLResUnit2;
				rGLResUnit3 = result.rGLResUnit3;
				rGLResUnit4 = result.rGLResUnit4;
				rFadeprBonusDepr = result.rFadeprBonusDepr;
				rFadeprAccumDepr = result.rFadeprAccumDepr;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}