//PROJECT NAME: Logistics
//CLASS NAME: ICascadeStatusChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICascadeStatusChange
	{
		(int? ReturnCode, string Infobar) CascadeStatusChangeSp(string PPoNum,
		string POldStat,
		string PNewStat,
		int? PerformUpdate,
		string Infobar);
	}
}

