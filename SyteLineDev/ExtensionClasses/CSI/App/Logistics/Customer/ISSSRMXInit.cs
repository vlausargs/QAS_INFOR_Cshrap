//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXInit
	{
		(int? ReturnCode,
			string Infobar) SSSRMXInitSp(
			string Infobar);
	}
}

