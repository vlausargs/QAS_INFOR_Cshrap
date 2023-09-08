//PROJECT NAME: Logistics
//CLASS NAME: ISetPoBlnStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ISetPoBlnStatus
	{
		(int? ReturnCode, string Infobar) SetPoBlnStatusSp(string PoNumAndPoLineList,
		string Infobar);
	}
}

