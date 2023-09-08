//PROJECT NAME: Production
//CLASS NAME: IProjectResourceJobTrxIssueRsrc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjectResourceJobTrxIssueRsrc
	{
		(int? ReturnCode,
			string Infobar) ProjectResourceJobTrxIssueRsrcSp(
			string PProjNum,
			int? PTaskNum,
			int? PSeqNum,
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
			string PImportDocId1 = null);
	}
}

