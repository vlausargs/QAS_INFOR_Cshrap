//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvPrt2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvPrt2
	{
		(int? ReturnCode,
			string Infobar) SSSFSConInvPrt2Sp(
			string TPrintInvNum,
			int? TransToDomCurr,
			string MooreForm,
			int? PrintContLineNotes,
			int? PrintInternalNotes,
			int? PrintExternalNotes,
			int? PrintFixedContLines,
			string Infobar,
			int? Summarize = 0);
	}
}

