//PROJECT NAME: APSExt
//CLASS NAME: SLMATLPPSnnns.cs

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
	[IDOExtensionClass("SLMATLPPSnnns")]
	public class SLMATLPPSnnns : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetMATLPPSSp(int? AltNo,
		[Optional] string MatID,
		[Optional] string Filter)
		{
			var iCLM_ApsGetMATLPPSExt = new CLM_ApsGetMATLPPSFactory().Create(this, true);
			
			var result = iCLM_ApsGetMATLPPSExt.CLM_ApsGetMATLPPSSp(AltNo,
			MatID,
			Filter);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLPPSDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsMATLPPSDelExt = new ApsMATLPPSDelFactory().Create(appDb);
				
				var result = iApsMATLPPSDelExt.ApsMATLPPSDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLPPSSaveSp(int? InsertFlag,
		int? AltNo,
		string PROCPLANID,
		string MATERIALID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsMATLPPSSaveExt = new ApsMATLPPSSaveFactory().Create(appDb);
				
				var result = iApsMATLPPSSaveExt.ApsMATLPPSSaveSp(InsertFlag,
				AltNo,
				PROCPLANID,
				MATERIALID);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
