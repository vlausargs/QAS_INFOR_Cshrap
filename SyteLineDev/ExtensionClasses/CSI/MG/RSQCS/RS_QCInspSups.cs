//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCInspSups.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
    [IDOExtensionClass("RS_QCInspSups")]
    public class RS_QCInspSups : ExtensionClassBase, IExtFTRS_QCInspSups
    {


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_QCCheckSp(string i_PoNum,
                                  short? i_PoLine,
                                  string i_PoRelease,
                                  decimal? i_Qty,
                                  string i_Loc,
                                  string i_Lot,
                                  int? i_Seq,
                                  string i_Whse,
                                  DateTime? i_transdate,
                                  ref string o_Loc,
                                  ref int? o_IsQC,
                                  ref int? o_IsCertified,
                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_QCCheckExt = new RSQC_QCCheckFactory().Create(appDb);

                int Severity = iRSQC_QCCheckExt.RSQC_QCCheckSp(i_PoNum,
                                                               i_PoLine,
                                                               i_PoRelease,
                                                               i_Qty,
                                                               i_Loc,
                                                               i_Lot,
                                                               i_Seq,
                                                               i_Whse,
                                                               i_transdate,
                                                               ref o_Loc,
                                                               ref o_IsQC,
                                                               ref o_IsCertified,
                                                               ref Infobar);

                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CheckforTestPlanSp(int? i_rcvr,
		ref string o_output,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CheckforTestPlanExt = new RSQC_CheckforTestPlanFactory().Create(appDb);
				
				var result = iRSQC_CheckforTestPlanExt.RSQC_CheckforTestPlanSp(i_rcvr,
				o_output,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_output = result.o_output;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_HomeAlertsSp(ref int? PastDueSReceivers,
		ref int? PastDueOReceivers,
		ref int? PastDueRReceivers,
		ref int? PastDueJReceivers,
		ref int? PastDuePReceivers,
		ref int? PastDueMRR,
		ref int? PastDueCAR,
		ref int? PastDueTRR,
		ref int? PastDueCMR,
		ref int? PastDueCOC,
		ref int? PastDueTM,
		ref int? PastDueCM,
		ref int? PastDueCC,
		ref int? PastDueGages1,
		ref int? PastDueGages2)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_HomeAlertsExt = new RSQC_HomeAlertsFactory().Create(appDb);
				
				var result = iRSQC_HomeAlertsExt.RSQC_HomeAlertsSp(PastDueSReceivers,
				PastDueOReceivers,
				PastDueRReceivers,
				PastDueJReceivers,
				PastDuePReceivers,
				PastDueMRR,
				PastDueCAR,
				PastDueTRR,
				PastDueCMR,
				PastDueCOC,
				PastDueTM,
				PastDueCM,
				PastDueCC,
				PastDueGages1,
				PastDueGages2);
				
				int Severity = result.ReturnCode.Value;
				PastDueSReceivers = result.PastDueSReceivers;
				PastDueOReceivers = result.PastDueOReceivers;
				PastDueRReceivers = result.PastDueRReceivers;
				PastDueJReceivers = result.PastDueJReceivers;
				PastDuePReceivers = result.PastDuePReceivers;
				PastDueMRR = result.PastDueMRR;
				PastDueCAR = result.PastDueCAR;
				PastDueTRR = result.PastDueTRR;
				PastDueCMR = result.PastDueCMR;
				PastDueCOC = result.PastDueCOC;
				PastDueTM = result.PastDueTM;
				PastDueCM = result.PastDueCM;
				PastDueCC = result.PastDueCC;
				PastDueGages1 = result.PastDueGages1;
				PastDueGages2 = result.PastDueGages2;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RSQC_CLM_SupVendorPerformanceSp([Optional] string TVendNum,
		[Optional] string TItem,
		[Optional] DateTime? begtdate,
		[Optional] DateTime? endtdate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CLM_SupVendorPerformanceExt = new RSQC_CLM_SupVendorPerformanceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CLM_SupVendorPerformanceExt.RSQC_CLM_SupVendorPerformanceSp(TVendNum,
				TItem,
				begtdate,
				endtdate);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
