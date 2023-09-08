//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPartReimbGetAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPartReimbGetAcct
	{
		(int? ReturnCode,
			string PAcct,
			string PUnit1,
			string PUnit2,
			string PUnit3,
			string PUnit4) SSSFSPartReimbGetAcctSp(
			string PType,
			string PCatType,
			string IAcct,
			string IUnit1,
			string IUnit2,
			string IUnit3,
			string IUnit4,
			string IVendNum,
			string PAcct,
			string PUnit1,
			string PUnit2,
			string PUnit3,
			string PUnit4);
	}
}

