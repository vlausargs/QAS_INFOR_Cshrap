//PROJECT NAME: MG
//CLASS NAME: SLVchProceduralMarkings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLVchProceduralMarkings")]
	public class SLVchProceduralMarkings : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetVchProceduralMarkingsSp(string SiteRef,
		int? VchNum,
		int? VchSeq)
		{
			var iCLM_GetVchProceduralMarkingsExt = new CLM_GetVchProceduralMarkingsFactory().Create(this, true);
			
			var result = iCLM_GetVchProceduralMarkingsExt.CLM_GetVchProceduralMarkingsSp(SiteRef,
			VchNum,
			VchSeq);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VchProceduralMarkingsUpdSp(int? VchNum,
		int? VchSeq,
		int? Selected,
		string VATProceduralMarkingId,
		ref string Infobar)
		{
			var iVchProceduralMarkingsUpdExt = new VchProceduralMarkingsUpdFactory().Create(this, true);
			
			var result = iVchProceduralMarkingsUpdExt.VchProceduralMarkingsUpdSp(VchNum,
			VchSeq,
			Selected,
			VATProceduralMarkingId,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}
	}
}
