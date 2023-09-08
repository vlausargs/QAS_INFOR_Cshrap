//PROJECT NAME: APSExt
//CLASS NAME: SLMATLPBOMSnnns.cs

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
	[IDOExtensionClass("SLMATLPBOMSnnns")]
	public class SLMATLPBOMSnnns : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetMATLPBOMSSp(int? AltNo,
		[Optional] string MatID,
		[Optional] string Filter)
		{
			var iCLM_ApsGetMATLPBOMSExt = new CLM_ApsGetMATLPBOMSFactory().Create(this, true);
			
			var result = iCLM_ApsGetMATLPBOMSExt.CLM_ApsGetMATLPBOMSSp(AltNo,
			MatID,
			Filter);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLPBOMSDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsMATLPBOMSDelExt = new ApsMATLPBOMSDelFactory().Create(appDb);
				
				var result = iApsMATLPBOMSDelExt.ApsMATLPBOMSDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLPBOMSSaveSp(int? InsertFlag,
		int? AltNo,
		string PBOMID,
		string MATERIALID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsMATLPBOMSSaveExt = new ApsMATLPBOMSSaveFactory().Create(appDb);
				
				var result = iApsMATLPBOMSSaveExt.ApsMATLPBOMSSaveSp(InsertFlag,
				AltNo,
				PBOMID,
				MATERIALID);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
