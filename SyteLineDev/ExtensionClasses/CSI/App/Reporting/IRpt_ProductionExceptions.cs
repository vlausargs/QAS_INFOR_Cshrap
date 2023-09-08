//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductionExceptions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductionExceptions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionExceptionsSp(string ScheduleType = null,
		string SJob = null,
		string EJob = null,
		int? SSuffix = null,
		int? ESuffix = null,
		string SItem = null,
		string EItem = null,
		decimal? SDaysLate = null,
		decimal? EDaysLate = null,
		int? ShowDetail = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

