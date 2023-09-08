//PROJECT NAME: APSExt
//CLASS NAME: SLBATPRODORDnnns.cs

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
	[IDOExtensionClass("SLBATPRODORDnnns")]
	public class SLBATPRODORDnnns : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetBATPRODORDSp(int? AltNo,
		[Optional] int? BatProd,
		[Optional] string Filter)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iCLM_ApsGetBATPRODORDExt = new CLM_ApsGetBATPRODORDFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);

				var result = iCLM_ApsGetBATPRODORDExt.CLM_ApsGetBATPRODORDSp(AltNo,
				BatProd,
				Filter);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetBPOperSp(int? AltNo,
		string ORDERID,
		string BATID,
		[Optional] string OperFilter)
		{
			var iCLM_ApsGetBPOperExt = new CLM_ApsGetBPOperFactory().Create(this, true);
			
			var result = iCLM_ApsGetBPOperExt.CLM_ApsGetBPOperSp(AltNo,
			ORDERID,
			BATID,
			OperFilter);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsBATPRODORDDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsBATPRODORDDelExt = new ApsBATPRODORDDelFactory().Create(appDb);
				
				var result = iApsBATPRODORDDelExt.ApsBATPRODORDDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsBATPRODORDSaveSp(int? InsertFlag,
		int? AltNo,
		int? BATPRODID,
		string ORDERID,
		string JSID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsBATPRODORDSaveExt = new ApsBATPRODORDSaveFactory().Create(appDb);
				
				var result = iApsBATPRODORDSaveExt.ApsBATPRODORDSaveSp(InsertFlag,
				AltNo,
				BATPRODID,
				ORDERID,
				JSID);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
