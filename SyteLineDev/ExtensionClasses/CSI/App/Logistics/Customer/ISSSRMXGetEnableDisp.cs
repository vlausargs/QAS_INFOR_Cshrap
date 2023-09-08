//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXGetEnableDisp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXGetEnableDisp
	{
			(int? ReturnCode,
			int? EnableDisp,
		string Infobar) SSSRMXGetEnableDispSp(
			int? EnableDisp,
			string Infobar);
	}
}

