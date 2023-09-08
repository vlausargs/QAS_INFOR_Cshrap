//PROJECT NAME: Production
//CLASS NAME: IJobRBookingCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobRBookingCheck
	{
		(int? ReturnCode, int? CanOverride,
		string Infobar) JobRBookingCheckSp(string Job,
		int? Suffix,
		decimal? Qty,
		int? Override,
		int? CanOverride,
		string Infobar,
		string JobItem = null);
	}
}

