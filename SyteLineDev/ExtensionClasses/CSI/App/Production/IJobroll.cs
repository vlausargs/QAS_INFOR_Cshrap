//PROJECT NAME: Production
//CLASS NAME: IJobroll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobroll
	{
		(ICollectionLoadResponse Data, int? ReturnCode) JobrollSp(string ExBegFinishJob,
		int? ExBegSuffix,
		string ExEndFinishJob,
		int? ExEndSuffix,
		int? TResetI,
		int? TResetP,
		int? TResetR,
		int? TResetJ,
		int? TUpdateA,
		int? ExOptprResetByProdCost,
		int? ExOptgoListOpts,
		int? BgTaskID = null,
		decimal? UserID = null);
	}
}

