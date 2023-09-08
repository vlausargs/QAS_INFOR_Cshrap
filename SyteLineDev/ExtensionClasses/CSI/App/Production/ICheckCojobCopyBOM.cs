//PROJECT NAME: Production
//CLASS NAME: ICheckCojobCopyBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckCojobCopyBOM
	{
		(int? ReturnCode, string NewJobStat,
		string Infobar) CheckCojobCopyBOMSp(string Job,
		int? Suffix,
		string Item,
		string AlternateID,
		int? JobRouteExist,
		string OldJobStat,
		string NewJobStat,
		string Infobar);
	}
}

