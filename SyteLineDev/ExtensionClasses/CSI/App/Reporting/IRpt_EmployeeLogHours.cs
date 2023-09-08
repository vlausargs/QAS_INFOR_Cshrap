//PROJECT NAME: Reporting
//CLASS NAME: IRpt_EmployeeLogHours.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_EmployeeLogHours
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmployeeLogHoursSp(string PStartingEmployee = null,
		string PEndingEmployee = null,
		DateTime? PStartingDate = null,
		DateTime? PEndingDate = null,
		decimal? PStartingTrans = null,
		decimal? PEndingTrans = null,
		string PCheckType = null,
		string PPayType = null,
		string PEmployeeType = null,
		int? PStartingDateOffset = null,
		int? PEndingDateOffset = null,
		int? PrintCost = 0,
		int? PDisplayHeader = 1,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null);
	}
}

