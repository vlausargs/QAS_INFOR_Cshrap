//PROJECT NAME: Production
//CLASS NAME: IJobBookingCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobBookingCheck
	{
		(int? ReturnCode, string Infobar) JobBookingCheckSp(string pJob,
		int? pSuffix,
		int? pOperNum,
		int? pComplete,
		decimal? pQtyComplete,
		decimal? pQtyScrapped,
		int? pHasLoc,
		string Infobar);
	}
}

