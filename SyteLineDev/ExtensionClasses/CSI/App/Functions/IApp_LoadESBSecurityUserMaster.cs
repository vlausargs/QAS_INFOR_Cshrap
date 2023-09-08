//PROJECT NAME: Data
//CLASS NAME: IApp_LoadESBSecurityUserMaster.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_LoadESBSecurityUserMaster
	{
		(int? ReturnCode,
			string InfoBar) App_LoadESBSecurityUserMasterSp(
			string WorkstationLogin,
			string Action,
			string Status,
			string GivenName,
			string FamilyName,
			string UserName,
			string EmailAddress,
			int? IsNewUserNameRow,
			decimal? OldUserId,
			string InfoBar);
	}
}

