//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroInvPrt2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroInvPrt2
	{
		(int? ReturnCode,
			decimal? TSubTotal,
			string Infobar) SSSFSSroInvPrt2Sp(
			string Mode = "PROCESS",
			string TPrintInvNum = null,
			int? TransToDomCurr = 0,
			int? TEuroExists = 0,
			int? PrintSROLineNotes = 0,
			int? PrintSROOperNotes = 0,
			int? PrintTransNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintSerials = 0,
			int? PrintProjMatl = 0,
			int? PrintProjLabor = 0,
			int? PrintProjMisc = 0,
			int? SummarizeTrans = 0,
			string OrderBy = null,
			decimal? TSubTotal = null,
			string Infobar = null);
	}
}

