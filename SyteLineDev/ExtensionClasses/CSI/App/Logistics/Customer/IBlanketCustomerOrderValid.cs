//PROJECT NAME: Logistics
//CLASS NAME: IBlanketCustomerOrderValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IBlanketCustomerOrderValid
	{
		(int? ReturnCode,
			string Infobar) BlanketCustomerOrderValidSp(
			string CoNum,
			string Infobar);
	}
}

