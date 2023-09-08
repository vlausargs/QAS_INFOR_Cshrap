//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSCustMatch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSCustMatch
	{
		int? SSSFSCustMatchFn(
			string CustNum,
			string SroCustNum,
			string OperCustNum);
	}
}

