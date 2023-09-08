//PROJECT NAME: MG
//CLASS NAME: SLVatProceduralMarkingDefaults.cs

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
	[IDOExtensionClass("SLVatProceduralMarkingDefaults")]
	public class SLVatProceduralMarkingDefaults : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetVatProceduralMarkingDefaultsSp(string RefNum,
		string RefType,
		ref string Infobar)
		{
			var iCLM_GetVatProceduralMarkingDefaultsExt = new CLM_GetVatProceduralMarkingDefaultsFactory().Create(this, true);
			
			var result = iCLM_GetVatProceduralMarkingDefaultsExt.CLM_GetVatProceduralMarkingDefaultsSp(RefNum,
			RefType,
			Infobar);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			Infobar = result.Infobar;
			return dt;
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VatProceduralMarkingDefaultsUpdSp(int? Select,
		string RefNum,
		string RefType,
		string ProcMarKingId,
		[Optional] ref string Infobar)
		{
			var iVatProceduralMarkingDefaultsUpdExt = new VatProceduralMarkingDefaultsUpdFactory().Create(this, true);
			
			var result = iVatProceduralMarkingDefaultsUpdExt.VatProceduralMarkingDefaultsUpdSp(Select,
			RefNum,
			RefType,
			ProcMarKingId,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}
	}
}
