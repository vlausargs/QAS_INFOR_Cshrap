//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXCommonInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXCommonInit
	{
		(int? ReturnCode,
			string Infobar) SSSRMXCommonInitSp(
			string Infobar);
	}
}

