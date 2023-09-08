//PROJECT NAME: APSExt
//CLASS NAME: SLPBOMnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLPBOMnnns")]
    public class SLPBOMnnns : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetPBOMSp(int? AltNo,
			[Optional] string Filter)
		{
			var iCLM_ApsGetPBOMExt = new CLM_ApsGetPBOMFactory().Create(this, true);
			
			var result = iCLM_ApsGetPBOMExt.CLM_ApsGetPBOMSp(AltNo,
				Filter);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateSeqNoSp(string TableName,
		[Optional] int? AltNum,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateSeqNoExt = new UpdateSeqNoFactory().Create(appDb);
				
				var result = iUpdateSeqNoExt.UpdateSeqNoSp(TableName,
				AltNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsPBOMDelSp(int? AltNo,
			Guid? RowPointer)
		{
			var iApsPBOMDelExt = new ApsPBOMDelFactory().Create(this, true);

			var result = iApsPBOMDelExt.ApsPBOMDelSp(AltNo,
				RowPointer);

			return result ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsPBOMSaveSp(int? InsertFlag,
		int? AltNo,
		string BOMID,
		string DESCR,
		string EFFECTID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsPBOMSaveExt = new ApsPBOMSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsPBOMSaveExt.ApsPBOMSaveSp(InsertFlag,
				AltNo,
				BOMID,
				DESCR,
				EFFECTID);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsMergeToListSp(int? AltNum,
		Guid? Rowpointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsMergeToListExt = new CLM_ApsMergeToListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsMergeToListExt.CLM_ApsMergeToListSp(AltNum,
				Rowpointer);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
