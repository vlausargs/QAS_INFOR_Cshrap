//PROJECT NAME: Logistics
//CLASS NAME: IValidateRMALineOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateRMALineOrder
	{
		(int? ReturnCode,
		string Infobar) ValidateRMALineOrderSp(
			string CoNum,
			string CurrCode,
			string Infobar);
	}
}

