//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSDepositSum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSDepositSum
	{
		(int? ReturnCode,
			string Infobar) SSSFSDepositSumSp(
			string SRONum,
			string CustNum,
			string Infobar);
	}
}

