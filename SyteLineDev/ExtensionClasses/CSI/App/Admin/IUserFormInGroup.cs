//PROJECT NAME: Admin
//CLASS NAME: IUserFormInGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IUserFormInGroup
	{
		(int? ReturnCode, string Infobar) UserFormInGroupSp(string GroupName,
		decimal? UserId,
		string Infobar);
	}
}

