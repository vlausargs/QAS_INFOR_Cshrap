//PROJECT NAME: Logistics
//CLASS NAME: ICheckPoStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICheckPoStatus
	{
		(int? ReturnCode, string PoNumAndStatList,
		string Infobar) CheckPoStatusSp(string PoType,
		string PoNumListToCheck,
		string PoNumAndStatList,
		string Infobar);
	}
}

