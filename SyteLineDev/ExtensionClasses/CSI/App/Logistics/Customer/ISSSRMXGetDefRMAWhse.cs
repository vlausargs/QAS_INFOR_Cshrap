//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXGetDefRMAWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXGetDefRMAWhse
	{
			(int? ReturnCode,
			string Whse,
		string Infobar) SSSRMXGetDefRMAWhseSp(
			string Whse,
			string Infobar);
	}
}

