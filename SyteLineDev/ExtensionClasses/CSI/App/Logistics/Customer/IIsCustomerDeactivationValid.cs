//PROJECT NAME: Logistics
//CLASS NAME: IIsCustomerDeactivationValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IIsCustomerDeactivationValid
	{
		(int? ReturnCode, string Infobar) IsCustomerDeactivationValidSp(string CustNum,
		int? Active = 1,
		int? FromMethod = 1,
		string Infobar = null);
	}
}

