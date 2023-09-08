//PROJECT NAME: Data
//CLASS NAME: ICoBlnChgStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoBlnChgStat
	{
		(int? ReturnCode,
			int? PReplicateAllCoitem,
			string Infobar) CoBlnChgStatSp(
			string PCoNum,
			int? PCoLine,
			string PCoOrigSite,
			string POldCoBlnStat,
			string PNewCoBlnStat,
			int? PReplicateAllCoitem,
			string Infobar);
	}
}

