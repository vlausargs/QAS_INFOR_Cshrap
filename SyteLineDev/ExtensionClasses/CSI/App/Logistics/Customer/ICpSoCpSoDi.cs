//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCpSoDi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCpSoDi
	{
		(int? ReturnCode,
			string Infobar) CpSoCpSoDiSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			string PCoOrigSite,
			int? PHasCfg,
			string Infobar);
	}
}

