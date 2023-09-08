//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPartReimbAddAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPartReimbAddAcct
	{
		int? SSSFSPartReimbAddAcctSp(
			string IAcct,
			string IUnit1,
			string IUnit2,
			string IUnit3,
			string IUnit4,
			decimal? PAmount,
			decimal? PTax);
	}
}

