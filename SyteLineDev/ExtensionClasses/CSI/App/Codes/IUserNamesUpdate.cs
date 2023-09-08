//PROJECT NAME: Codes
//CLASS NAME: IUserNamesUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IUserNamesUpdate
	{
		(int? ReturnCode,
			string Infobar) UserNamesUpdateSp(
			string Username,
			string UserPassword,
			string EmailAddress,
			string WorkstationLogin,
			string Infobar);
	}
}

