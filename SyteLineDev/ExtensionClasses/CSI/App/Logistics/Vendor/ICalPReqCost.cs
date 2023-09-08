//PROJECT NAME: Logistics
//CLASS NAME: ICalPReqCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICalPReqCost
	{
		(int? ReturnCode, string Infobar) CalPReqCostSp(string ReqNum,
		string Infobar);
	}
}

