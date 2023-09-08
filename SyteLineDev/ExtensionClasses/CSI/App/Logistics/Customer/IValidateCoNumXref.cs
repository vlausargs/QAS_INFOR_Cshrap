//PROJECT NAME: Logistics
//CLASS NAME: IValidateCoNumXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateCoNumXref
	{
		(int? ReturnCode, string Infobar) ValidateCoNumXrefSp(string DerCoNumXref,
			string CoNum,
			string InvNum,
			string SiteRef,
			string Infobar);
	}
}

