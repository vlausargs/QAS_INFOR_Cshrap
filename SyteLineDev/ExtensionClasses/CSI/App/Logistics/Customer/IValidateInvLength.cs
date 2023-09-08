//PROJECT NAME: Logistics
//CLASS NAME: IValidateInvLength.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateInvLength
	{
		(int? ReturnCode, string Infobar) ValidateInvLengthSp(int? InvNumLen,
		string Infobar);
	}
}

