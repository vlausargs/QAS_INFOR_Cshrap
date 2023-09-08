//PROJECT NAME: Logistics
//CLASS NAME: ICitemxPPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICitemxPPo
	{
		(int? ReturnCode,
			string Infobar) CitemxPPoSp(
			string Item,
			string PoNum,
			string Whse,
			string Infobar,
			string ExportType);
	}
}

