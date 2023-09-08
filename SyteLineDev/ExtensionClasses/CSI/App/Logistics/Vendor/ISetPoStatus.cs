//PROJECT NAME: Logistics
//CLASS NAME: ISetPoStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ISetPoStatus
	{
		(int? ReturnCode, string Infobar) SetPoStatusSp(string PoNumList,
		string Infobar);
	}
}

