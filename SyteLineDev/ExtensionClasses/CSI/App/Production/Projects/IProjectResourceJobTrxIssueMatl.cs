//PROJECT NAME: Production
//CLASS NAME: IProjectResourceJobTrxIssueMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjectResourceJobTrxIssueMatl
	{
		(int? ReturnCode,
			string Infobar) ProjectResourceJobTrxIssueMatlSp(
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSequence,
			string PItem,
			decimal? PQty,
			string CurWhse,
			string PLoc1,
			string PLot1,
			DateTime? PTransDate,
			string PTranType,
			string PRefType,
			string CallArg = "",
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string Infobar = null,
			string PImportDocId1 = null,
			string DocumentNum = null);
	}
}

