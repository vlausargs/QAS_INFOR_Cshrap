//PROJECT NAME: Logistics
//CLASS NAME: ICpSoDi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoDi
	{
		(int? ReturnCode,
			string DeleteSiteList,
			string Infobar) CpSoDiSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string CoOrigSite,
			int? HasPrt,
			int? HasCfg,
			string DeleteSiteList,
			string Infobar);
	}
}

