//PROJECT NAME: ProductExt
//CLASS NAME: SLBatch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLBatch")]
    public class SLBatch : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ChgBatchProdStatSp(string ProcSel,
                                                string IOldStat,
                                                string INewStat,
                                                int? SBatchID,
                                                int? EBatchID,
                                                string SBatchDef,
                                                string EBatchDef,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_ChgBatchProdStatExt = new CLM_ChgBatchProdStatFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iCLM_ChgBatchProdStatExt.CLM_ChgBatchProdStatSp(ProcSel,
                                                                               IOldStat,
                                                                               INewStat,
                                                                               SBatchID,
                                                                               EBatchID,
                                                                               SBatchDef,
                                                                               EBatchDef,
                                                                               ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CreateBatchProdSp(string ProcSel,
                                              int? SBatchID,
                                              int? EBatchID,
                                              string SBatchDef,
                                              string EBatchDef,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_CreateBatchProdExt = new CLM_CreateBatchProdFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iCLM_CreateBatchProdExt.CLM_CreateBatchProdSp(ProcSel,
                                                                             SBatchID,
                                                                             EBatchID,
                                                                             SBatchDef,
                                                                             EBatchDef,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_RemoveBatchProdSp(string ProcSel,
                                               int? SBatchID,
                                               int? EBatchID,
                                               string SBatchDef,
                                               string EBatchDef,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_RemoveBatchProdExt = new CLM_RemoveBatchProdFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iCLM_RemoveBatchProdExt.CLM_RemoveBatchProdSp(ProcSel,
                                                                             SBatchID,
                                                                             EBatchID,
                                                                             SBatchDef,
                                                                             EBatchDef,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LoadDataFromBatchIdSp(int? ProdBatchId,
		string ReturnType,
		string Loc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_LoadDataFromBatchIdExt = new CLM_LoadDataFromBatchIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_LoadDataFromBatchIdExt.CLM_LoadDataFromBatchIdSp(ProdBatchId,
				ReturnType,
				Loc);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CLM_SavePPJobInfoSp(int? ProdBatchId,
		decimal? MinSheetCount,
		decimal? PrintQuatePrice,
		decimal? PaperConsumptionQty,
		int? Out,
		int? Up,
		int? IsNeedAddppJob,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_SavePPJobInfoExt = new CLM_SavePPJobInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_SavePPJobInfoExt.CLM_SavePPJobInfoSp(ProdBatchId,
				MinSheetCount,
				PrintQuatePrice,
				PaperConsumptionQty,
				Out,
				Up,
				IsNeedAddppJob,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenUnpostedJobTransForBatchedProdSp(int? ProdBatchId,
		string TransType,
		DateTime? TransDate,
		decimal? QtyComplete,
		decimal? QtyScrapped,
		decimal? AHrs,
		string EmpNum,
		int? StartTimeHrs,
		int? EndTimeHrs,
		string IndCode,
		string PayRate,
		decimal? QtyMoved,
		string UserCode,
		decimal? PrRate,
		decimal? JobRate,
		string Shift,
		string ReasonCode,
		string Loc,
		string ContainerNum,
		string Lot,
		string CostCode,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenUnpostedJobTransForBatchedProdExt = new GenUnpostedJobTransForBatchedProdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenUnpostedJobTransForBatchedProdExt.GenUnpostedJobTransForBatchedProdSp(ProdBatchId,
				TransType,
				TransDate,
				QtyComplete,
				QtyScrapped,
				AHrs,
				EmpNum,
				StartTimeHrs,
				EndTimeHrs,
				IndCode,
				PayRate,
				QtyMoved,
				UserCode,
				PrRate,
				JobRate,
				Shift,
				ReasonCode,
				Loc,
				ContainerNum,
				Lot,
				CostCode,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetBatchedProdSp(ref int? BatchedProdId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetBatchedProdExt = new GetBatchedProdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetBatchedProdExt.GetBatchedProdSp(BatchedProdId);
				
				int Severity = result.ReturnCode.Value;
				BatchedProdId = result.BatchedProdId;
				return Severity;
			}
		}
    }
}
