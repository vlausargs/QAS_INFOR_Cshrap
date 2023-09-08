//PROJECT NAME: APSExt
//CLASS NAME: SLORDATTRnnns.cs

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
	[IDOExtensionClass("SLORDATTRnnns")]
	public class SLORDATTRnnns : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetORDATTRSp(int? AltNo,
		[Optional] string OrdID)
		{
			var iCLM_ApsGetORDATTRExt = new CLM_ApsGetORDATTRFactory().Create(this, true);
			
			var result = iCLM_ApsGetORDATTRExt.CLM_ApsGetORDATTRSp(AltNo,
			OrdID);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsORDATTRDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsORDATTRDelExt = new ApsORDATTRDelFactory().Create(appDb);
				
				var result = iApsORDATTRDelExt.ApsORDATTRDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsORDATTRSaveSp(int? InsertFlag,
		int? AltNo,
		string ATTID,
		string ATTVALUE,
		string ORDERID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsORDATTRSaveExt = new ApsORDATTRSaveFactory().Create(appDb);
				
				var result = iApsORDATTRSaveExt.ApsORDATTRSaveSp(InsertFlag,
				AltNo,
				ATTID,
				ATTVALUE,
				ORDERID);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
