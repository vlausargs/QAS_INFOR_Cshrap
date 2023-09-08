//PROJECT NAME: Data
//CLASS NAME: IConsignmentCoExistsForCustomer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConsignmentCoExistsForCustomer
	{
		int? ConsignmentCoExistsForCustomerFn(
			string CustNum,
			int? CustSeq);
	}
}

