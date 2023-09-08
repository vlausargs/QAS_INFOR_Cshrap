//PROJECT NAME: RFQExt
//CLASS NAME: RFQItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.RFQ;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RFQ
{
    [IDOExtensionClass("RFQItems")]
    public class RFQItems : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable SSSRFQGenFromCoSp(byte? Commit,
                                           string Type,
                                           string StartCoNum,
                                           string EndCoNum,
                                           short? StartLine,
                                           short? EndLine,
                                           short? StartRel,
                                           short? EndRel,
                                           string StartProductCode,
                                           string EndProductCode,
                                           string StartItem,
                                           string EndItem,
                                           string GenMethod,
                                           string RollupMethod,
                                           byte? PurchasePartsOnly,
                                           string QtysToPrice,
                                           string AppendRfqNum,
                                           string PSessionID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSSSRFQGenFromCoExt = new SSSRFQGenFromCoFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSSSRFQGenFromCoExt.SSSRFQGenFromCoSp(Commit,
                                                                     Type,
                                                                     StartCoNum,
                                                                     EndCoNum,
                                                                     StartLine,
                                                                     EndLine,
                                                                     StartRel,
                                                                     EndRel,
                                                                     StartProductCode,
                                                                     EndProductCode,
                                                                     StartItem,
                                                                     EndItem,
                                                                     GenMethod,
                                                                     RollupMethod,
                                                                     PurchasePartsOnly,
                                                                     QtysToPrice,
                                                                     AppendRfqNum,
                                                                     PSessionID);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable SSSRFQGenFromInvSp(byte? Commit,
                                            string StartProductCode,
                                            string EndProductCode,
                                            string StartItem,
                                            string EndItem,
                                            string StartBuyer,
                                            string EndBuyer,
                                            string StartPlanCode,
                                            string EndPlanCode,
                                            string GenMethod,
                                            string RollupMethod,
                                            byte? PurchasePartsOnly,
                                            string QtysToPrice,
                                            string AppendRfqNum,
                                            string PSessionId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSSSRFQGenFromInvExt = new SSSRFQGenFromInvFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSSSRFQGenFromInvExt.SSSRFQGenFromInvSp(Commit,
                                                                       StartProductCode,
                                                                       EndProductCode,
                                                                       StartItem,
                                                                       EndItem,
                                                                       StartBuyer,
                                                                       EndBuyer,
                                                                       StartPlanCode,
                                                                       EndPlanCode,
                                                                       GenMethod,
                                                                       RollupMethod,
                                                                       PurchasePartsOnly,
                                                                       QtysToPrice,
                                                                       AppendRfqNum,
                                                                       PSessionId);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable SSSRFQGenFromJobSp(byte? Commit,
                                            string JobType,
                                            string StartJob,
                                            string EndJob,
                                            short? StartSuffix,
                                            short? EndSuffix,
                                            string StartProductCode,
                                            string EndProductCode,
                                            string StartItem,
                                            string EndItem,
                                            string GenMethod,
                                            string RollupMethod,
                                            byte? PurchasePartsOnly,
                                            byte? RollUpItems,
                                            string QtysToPrice,
                                            string AppendRfqNum,
                                            string PSessionId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSSSRFQGenFromJobExt = new SSSRFQGenFromJobFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSSSRFQGenFromJobExt.SSSRFQGenFromJobSp(Commit,
                                                                       JobType,
                                                                       StartJob,
                                                                       EndJob,
                                                                       StartSuffix,
                                                                       EndSuffix,
                                                                       StartProductCode,
                                                                       EndProductCode,
                                                                       StartItem,
                                                                       EndItem,
                                                                       GenMethod,
                                                                       RollupMethod,
                                                                       PurchasePartsOnly,
                                                                       RollUpItems,
                                                                       QtysToPrice,
                                                                       AppendRfqNum,
                                                                       PSessionId);

                return dt;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRFQItemGenVendorsSp(string RfqNum,
                                          int? RfqLine,
                                          string GenMethod,
                                          string LastRfqNum,
                                          int? LastRfqLine,
                                          string PSessionId,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRFQItemGenVendorsExt = new SSSRFQItemGenVendorsFactory().Create(appDb);

                int Severity = iSSSRFQItemGenVendorsExt.SSSRFQItemGenVendorsSp(RfqNum,
                                                                               RfqLine,
                                                                               GenMethod,
                                                                               LastRfqNum,
                                                                               LastRfqLine,
                                                                               PSessionId,
                                                                               ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRFQPOCreateFromOneSp(string RFQNum,
                                           int? RFQLine,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRFQPOCreateFromOneExt = new SSSRFQPOCreateFromOneFactory().Create(appDb);

                int Severity = iSSSRFQPOCreateFromOneExt.SSSRFQPOCreateFromOneSp(RFQNum,
                                                                                 RFQLine,
                                                                                 ref Infobar);

                return Severity;
            }
        }
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRFQGenFromReqSp(byte? Commit,
		                                    string ReqNum,
		                                    short? StartReqLine,
		                                    short? EndReqLine,
		                                    string GenMethod,
		                                    string RollupMethod,
		                                    byte? AllowDuplicates,
		                                    string AppendRfqNum,
		                                    string PSessiondId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSRFQGenFromReqExt = new SSSRFQGenFromReqFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSRFQGenFromReqExt.SSSRFQGenFromReqSp(Commit,
				                                                     ReqNum,
				                                                     StartReqLine,
				                                                     EndReqLine,
				                                                     GenMethod,
				                                                     RollupMethod,
				                                                     AllowDuplicates,
				                                                     AppendRfqNum,
				                                                     PSessiondId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRfqGenSetSelectedSp(Guid? RowPointer,
		int? Selected,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRfqGenSetSelectedExt = new SSSRfqGenSetSelectedFactory().Create(appDb);
				
				var result = iSSSRfqGenSetSelectedExt.SSSRfqGenSetSelectedSp(RowPointer,
				Selected,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQPOCreateAddLineSp(string RFQNum,
		int? RFQLine,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRFQPOCreateAddLineExt = new SSSRFQPOCreateAddLineFactory().Create(appDb);
				
				var result = iSSSRFQPOCreateAddLineExt.SSSRFQPOCreateAddLineSp(RFQNum,
				RFQLine,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQPOCreateCleanupSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRFQPOCreateCleanupExt = new SSSRFQPOCreateCleanupFactory().Create(appDb);
				
				var result = iSSSRFQPOCreateCleanupExt.SSSRFQPOCreateCleanupSp();
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRFQPOCreateSp(string iPONum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRFQPOCreateExt = new SSSRFQPOCreateFactory().Create(appDb);
				
				var result = iSSSRFQPOCreateExt.SSSRFQPOCreateSp(iPONum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
