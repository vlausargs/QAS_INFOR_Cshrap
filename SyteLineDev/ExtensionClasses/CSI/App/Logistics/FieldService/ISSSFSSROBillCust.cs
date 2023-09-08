//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROBillCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROBillCust
	{
		string SSSFSSROBillCustFn(
			string SroNum,
			int? SroLine,
			int? SroOper);
	}
}

