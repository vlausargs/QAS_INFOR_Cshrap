//PROJECT NAME: Logistics
//CLASS NAME: IValidateInvVoid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateInvVoid
	{
		(int? ReturnCode, string Infobar) ValidateInvVoidSP(string VInvNum,
			string Type,
			string Infobar);
	}
}

