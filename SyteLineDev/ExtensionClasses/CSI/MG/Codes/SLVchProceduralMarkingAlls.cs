//PROJECT NAME: MG
//CLASS NAME: SLVchProceduralMarkingAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLVchProceduralMarkingAlls")]
	public class SLVchProceduralMarkingAlls : CSIExtensionClassBase
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
		public int SaveVchProceduralMarkingsSp(string SiteRef,
		int? VchNum,
		int? VchSeq,
		int? Selected,
		string VATProceduralMarkingId,
		ref string Infobar)
		{
			var iSaveVchProceduralMarkingsExt = this.GetService<ISaveVchProceduralMarkings>();
			var result = iSaveVchProceduralMarkingsExt.SaveVchProceduralMarkingsSp(SiteRef,
			VchNum,
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
