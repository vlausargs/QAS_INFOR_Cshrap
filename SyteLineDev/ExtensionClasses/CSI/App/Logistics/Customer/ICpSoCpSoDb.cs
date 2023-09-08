//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCpSoDb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCpSoDb
	{
		(int? ReturnCode,
			string Infobar) CpSoCpSoDbSp(
			string PCoNum,
			int? PCoLine,
			string PCoOrigSite,
			int? PHasCfg,
			string Infobar);
	}
}

