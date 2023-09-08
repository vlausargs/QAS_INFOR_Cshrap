//PROJECT NAME: Data
//CLASS NAME: IJobPf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobPf
	{
		(int? ReturnCode,
			string Infobar,
			string PromptButtons) JobPfSp(
			decimal? CurTransNum,
			string TWc,
			string TLoc,
			string TLot,
			Guid? SessionId,
			int? TCoby,
			int? pPostNeg,
			string Infobar,
			string TImportDocId,
			string ContainerNum = null,
			string PromptButtons = null,
			string DocumentNum = null);
	}
}

