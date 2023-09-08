//PROJECT NAME: APSExt
//CLASS NAME: SLMATLATTRnnns.cs

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
	[IDOExtensionClass("SLMATLATTRnnns")]
	public class SLMATLATTRnnns : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetMATLATTRSp(int? AltNo,
		[Optional] string MatID,
		[Optional] string Filter)
		{
			var iCLM_ApsGetMATLATTRExt = new CLM_ApsGetMATLATTRFactory().Create(this, true);
			
			var result = iCLM_ApsGetMATLATTRExt.CLM_ApsGetMATLATTRSp(AltNo,
			MatID,
			Filter);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLATTRDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsMATLATTRDelExt = new ApsMATLATTRDelFactory().Create(appDb);
				
				var result = iApsMATLATTRDelExt.ApsMATLATTRDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLATTRSaveSp(int? InsertFlag,
		int? AltNo,
		string ATTID,
		string ATTVALUE,
		string MATERIALID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsMATLATTRSaveExt = new ApsMATLATTRSaveFactory().Create(appDb);
				
				var result = iApsMATLATTRSaveExt.ApsMATLATTRSaveSp(InsertFlag,
				AltNo,
				ATTID,
				ATTVALUE,
				MATERIALID);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
