//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSProdacct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSProdacct
	{
		(int? ReturnCode,
			string Acct,
			string UnitCode1,
			string UnitCode2,
			string UnitCode3,
			string UnitCode4,
			string Infobar) SSSFSProdacctSp(
			string ProductCode,
			string Prefix,
			string Acct,
			string UnitCode1,
			string UnitCode2,
			string UnitCode3,
			string UnitCode4,
			string Infobar);
	}
}

