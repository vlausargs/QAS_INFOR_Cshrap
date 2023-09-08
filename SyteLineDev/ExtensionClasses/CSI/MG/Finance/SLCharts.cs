//PROJECT NAME: FinanceExt
//CLASS NAME: SLCharts.cs

using System;
using System.Data;
using CSI.Data.SQL.UDDT;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.Chart;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
   
    [IDOExtensionClass("SLCharts")]
    public class SLCharts : CSIExtensionClassBase
    {
       
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ReplaceUnitCodesSp(string BegAcct,
			string EndAcct,
			int? UnitNumber,
			string OldUnitCode,
			string NewUnitCode,
			ref string Infobar)
		{
			var iReplaceUnitCodesExt = new ReplaceUnitCodesFactory().Create(this, true);
			
			var result = iReplaceUnitCodesExt.ReplaceUnitCodesSp(BegAcct,
				EndAcct,
				UnitNumber,
				OldUnitCode,
				NewUnitCode,
				Infobar);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RemoveAccountUnitCodesSp(string BegAcct,
                                            string EndAcct,
                                            int? UnitNumber,
                                            string UnitCode,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLChartsExt = new RemoveAccountUnitCodesFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLChartsExt.RemoveAccountUnitCodesSp(BegAcct,
                                                                     EndAcct,
                                                                     UnitNumber,
                                                                     UnitCode,
                                                                     ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiSiteChartCopySp(string pStartAcct,
                                        string pEndAcct,
                                        string pToSite,
                                        byte? pCopyReportsToAcct,
                                        byte? pOverwriteExistingRecords,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLChartsExt = new MultiSiteChartCopyFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLChartsExt.MultiSiteChartCopySp(pStartAcct,
                                                                 pEndAcct,
                                                                 pToSite,
                                                                 pCopyReportsToAcct,
                                                                 pOverwriteExistingRecords,
                                                                 ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }
       
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetSiteInfoSp(ref string SiteType,
                                  ref string SiteReportsTo,
                                  ref string SiteReportsToType,
                                  ref byte? SiteAnalyticalLedger)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLChartsExt = new GetSiteInfoFactory().Create(appDb);

                SiteType oSiteType = SiteType;
                SiteType oSiteReportsTo = SiteReportsTo;
                ListSiteEntityType oSiteReportsToType = SiteReportsToType;
                ListYesNoType oSiteAnalyticalLedger = SiteAnalyticalLedger;

                int Severity = iSLChartsExt.GetSiteInfoSp(ref oSiteType,
                                                          ref oSiteReportsTo,
                                                          ref oSiteReportsToType,
                                                          ref oSiteAnalyticalLedger);

                SiteType = oSiteType;
                SiteReportsTo = oSiteReportsTo;
                SiteReportsToType = oSiteReportsToType;
                SiteAnalyticalLedger = oSiteAnalyticalLedger;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ChartAcctGetIsControlSP(string ChartAcct,
			ref int? IsControl,
			ref string Infobar)
        {
            var iChartAcctGetIsControlExt = new ChartAcctGetIsControlFactory().Create(this, true);

            var result = iChartAcctGetIsControlExt.ChartAcctGetIsControlSP(ChartAcct,
				IsControl,
				Infobar);

            IsControl = result.IsControl;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ChartAcctDeleteSp([Optional, DefaultParameterValue(0)] int? pNewRecord,
            string pChartAcct,
            ref string Infobar)
        {
            var iChartAcctDeleteExt = new ChartAcctDeleteFactory().Create(this, true);

            var result = iChartAcctDeleteExt.ChartAcctDeleteSp(pNewRecord,
                pChartAcct,
                Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int ChartAcctPreDelSp([Optional, DefaultParameterValue(0)] int? pNewRecord,
		string pChartAcct,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iChartAcctPreDelExt = new CSI.Finance.ChartAcctPreDelFactory().Create(appDb);
				
				var result = iChartAcctPreDelExt.ChartAcctPreDelSp(pNewRecord,
				                                                   pChartAcct,
				                                                   Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadAllUnitCodesSp(string StartAcct,
		                              string EndAcct,
		                              [Optional, DefaultParameterValue((byte)0)] byte? CopyUnit1,
		string StartUnitCode1,
		string EndUnitCode1,
		[Optional, DefaultParameterValue((byte)0)] byte? CopyUnit2,
		string StartUnitCode2,
		string EndUnitCode2,
		[Optional, DefaultParameterValue((byte)0)] byte? CopyUnit3,
		string StartUnitCode3,
		string EndUnitCode3,
		[Optional, DefaultParameterValue((byte)0)] byte? CopyUnit4,
		string StartUnitCode4,
		string EndUnitCode4,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadAllUnitCodesExt = new LoadAllUnitCodesFactory().Create(appDb);
				
				var result = iLoadAllUnitCodesExt.LoadAllUnitCodesSp(StartAcct,
				                                                     EndAcct,
				                                                     CopyUnit1,
				                                                     StartUnitCode1,
				                                                     EndUnitCode1,
				                                                     CopyUnit2,
				                                                     StartUnitCode2,
				                                                     EndUnitCode2,
				                                                     CopyUnit3,
				                                                     StartUnitCode3,
				                                                     EndUnitCode3,
				                                                     CopyUnit4,
				                                                     StartUnitCode4,
				                                                     EndUnitCode4,
				                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetConsSp(string SAcct,
		                     string EAcct,
		                     DateTime? STransDate,
		                     DateTime? ETransDate,
		                     string ExOptacChartType,
		                     ref string Infobar,
		                     [Optional] short? StartingDateOffset,
		                     [Optional] short? EndingDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetConsExt = new SetConsFactory().Create(appDb);
				
				var result = iSetConsExt.SetConsSp(SAcct,
				                                   EAcct,
				                                   STransDate,
				                                   ETransDate,
				                                   ExOptacChartType,
				                                   Infobar,
				                                   StartingDateOffset,
				                                   EndingDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChkAcctAllSp(string acct,
		DateTime? date,
		string pSite,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iChkAcctAllExt = new ChkAcctAllFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iChkAcctAllExt.ChkAcctAllSp(acct,
				date,
				pSite,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChkAcctSp(string acct,
		DateTime? date,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iChkAcctExt = new ChkAcctFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iChkAcctExt.ChkAcctSp(acct,
				date,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_UnitCodesSp(int? UnitCodeNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_UnitCodesExt = new CLM_UnitCodesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_UnitCodesExt.CLM_UnitCodesSp(UnitCodeNumber);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
