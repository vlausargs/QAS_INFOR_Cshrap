//PROJECT NAME: APSExt
//CLASS NAME: SLBATPRODnnns.cs

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
    [IDOExtensionClass("SLBATPRODnnns")]
    public class SLBATPRODnnns : ExtensionClassBase
    {



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetBATPRODSp(short? AltNo,
		                                     [Optional] string Filter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetBATPRODExt = new CLM_ApsGetBATPRODFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetBATPRODExt.CLM_ApsGetBATPRODSp(AltNo,
				                                                       Filter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsBATPRODDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsBATPRODDelExt = new ApsBATPRODDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsBATPRODDelExt.ApsBATPRODDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsBATPRODSaveSp(int? InsertFlag,
		int? AltNo,
		int? BATPRODID,
		string BATDEFID,
		DateTime? BATCHDATE,
		string PROCPLANID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsBATPRODSaveExt = new ApsBATPRODSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsBATPRODSaveExt.ApsBATPRODSaveSp(InsertFlag,
				AltNo,
				BATPRODID,
				BATDEFID,
				BATCHDATE,
				PROCPLANID);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetBATPRODIDSp(int? AltNo,
		ref int? BatchedProdId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetBATPRODIDExt = new GetBATPRODIDFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetBATPRODIDExt.GetBATPRODIDSp(AltNo,
				BatchedProdId);
				
				int Severity = result.ReturnCode.Value;
				BatchedProdId = result.BatchedProdId;
				return Severity;
			}
		}
    }
}
