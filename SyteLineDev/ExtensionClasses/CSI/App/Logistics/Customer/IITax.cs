//PROJECT NAME: Logistics
//CLASS NAME: IITax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IITax
	{
		(int? ReturnCode, string PDefaultTaxCode) ITaxSp(int? PTaxSystem,
		string PTaxCode,
		string PItem,
		string PDefaultTaxCode,
		string Site = null);
	}
}

