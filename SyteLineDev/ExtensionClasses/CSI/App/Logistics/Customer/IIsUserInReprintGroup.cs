//PROJECT NAME: Logistics
//CLASS NAME: IIsUserInReprintGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IIsUserInReprintGroup
	{
		(int? ReturnCode, int? IsUserInReprintGroup) IsUserInReprintGroupSp(decimal? Userid,
		int? IsUserInReprintGroup);
	}
}

