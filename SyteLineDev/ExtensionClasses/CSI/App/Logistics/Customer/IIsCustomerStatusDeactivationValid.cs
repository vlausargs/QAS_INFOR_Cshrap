//PROJECT NAME: Logistics
//CLASS NAME: IIsCustomerStatusDeactivationValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IIsCustomerStatusDeactivationValid
	{
		(int? ReturnCode, string Infobar) IsCustomerStatusDeactivationValidSp(string Stat,
		int? Active = 1,
		string Infobar = null);
	}
}

