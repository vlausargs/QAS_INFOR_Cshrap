//PROJECT NAME: Data
//CLASS NAME: IGetUsersEmailAddressList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetUsersEmailAddressList
	{
		(int? ReturnCode,
			string EmailAddressList,
			string Infobar) GetUsersEmailAddressListSp(
			string UserList,
			string EmailAddressList = null,
			string Infobar = null);
	}
}

