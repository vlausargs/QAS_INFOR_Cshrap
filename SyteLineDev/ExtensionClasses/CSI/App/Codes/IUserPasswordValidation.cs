//PROJECT NAME: Codes
//CLASS NAME: IUserPasswordValidation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IUserPasswordValidation
	{
		(int? ReturnCode, string Infobar) UserPasswordValidationSp(string Username,
		string Password,
		string OldPassword,
		string RetypePassword,
		string Infobar);
	}
}

