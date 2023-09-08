//PROJECT NAME: Finance
//CLASS NAME: IExtFinAddBatchToBGQueue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinAddBatchToBGQueue
	{
		(int? ReturnCode, string Infobar) ExtFinAddBatchToBGQueueSp(string object_name,
		decimal? batch_num,
		string Infobar,
		string ToSite);
	}
}

