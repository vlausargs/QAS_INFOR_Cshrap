//PROJECT NAME: POS
//CLASS NAME: ISSSPOSConPosP2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSConPosP2
	{
		(int? ReturnCode,
			string Infobar) SSSPOSConPosP2Sp(
			Guid? SessionId,
			string Contract,
			string ContStat,
			DateTime? BilledThruDate,
			string Infobar);
	}
}

