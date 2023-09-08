//PROJECT NAME: Data
//CLASS NAME: ICoHld3.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoHld3
	{
		(int? ReturnCode,
			decimal? POutstandingBalance,
			int? PProcessCreditHold) CoHld3Sp(
			string PCustNum,
			string PSite,
			string PInvDue,
			DateTime? PAgingDate,
			decimal? POutstandingBalance,
			int? PProcessCreditHold);
	}
}

