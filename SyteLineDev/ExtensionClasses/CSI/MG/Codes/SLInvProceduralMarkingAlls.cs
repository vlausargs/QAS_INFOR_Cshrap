//PROJECT NAME: MG
//CLASS NAME: SLInvProceduralMarkingAlls.cs

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
	[IDOExtensionClass("SLInvProceduralMarkingAlls")]
	public class SLInvProceduralMarkingAlls : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetInvProceduralMarkingsSp(string InvNum,
			int? InvSeq,
			string SiteRef)
		{
			var iCLM_GetInvProceduralMarkingsExt = new CLM_GetInvProceduralMarkingsFactory().Create(this, true);

			var result = iCLM_GetInvProceduralMarkingsExt.CLM_GetInvProceduralMarkingsSp(InvNum,
				InvSeq,
				SiteRef);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateInvDistProceduralMarkingsSp(string InvNum,
		int? InvSeq,
		[Optional] ref string Infobar)
		{
			var iGenerateInvDistProceduralMarkingsExt = new GenerateInvDistProceduralMarkingsFactory().Create(this, true);
			
			var result = iGenerateInvDistProceduralMarkingsExt.GenerateInvDistProceduralMarkingsSp(InvNum,
			InvSeq,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateInvHdrProceduralMarkingsSp(string InvNum,
		int? InvSeq,
		string CustNum,
		string TaxCode,
		[Optional] string ApplyToInvNum,
		[Optional] ref string Infobar)
		{
			var iGenerateInvHdrProceduralMarkingsExt = new GenerateInvHdrProceduralMarkingsFactory().Create(this, true);
			
			var result = iGenerateInvHdrProceduralMarkingsExt.GenerateInvHdrProceduralMarkingsSp(InvNum,
			InvSeq,
			CustNum,
			TaxCode,
			ApplyToInvNum,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SaveInvProceduralMarkingsUpdSp(string SiteRef,
		string InvNum,
		int? InvSeq,
		int? Selected,
		string VATProceduralMarkingId,
		ref string Infobar)
		{
			var iSaveInvProceduralMarkingsUpdExt = new SaveInvProceduralMarkingsUpdFactory().Create(this, true);
			
			var result = iSaveInvProceduralMarkingsUpdExt.SaveInvProceduralMarkingsUpdSp(SiteRef,
			InvNum,
			InvSeq,
			Selected,
			VATProceduralMarkingId,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}
	}
}
