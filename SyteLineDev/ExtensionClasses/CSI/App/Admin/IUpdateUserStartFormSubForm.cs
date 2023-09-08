//PROJECT NAME: Admin
//CLASS NAME: IUpdateUserStartFormSubForm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IUpdateUserStartFormSubForm
	{
		(int? ReturnCode, string Infobar) UpdateUserStartFormSubFormSp(string Username,
		string SubFormName,
		int? SubFormInstanceId,
		int? Selected,
		decimal? Sequence,
		string Infobar);
	}
}

