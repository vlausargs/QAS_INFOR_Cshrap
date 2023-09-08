//PROJECT NAME: Codes
//CLASS NAME: IPortalAccountManagement.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IPortalAccountManagement
	{
		(int? ReturnCode, string Infobar) PortalAccountManagementSp(string Username,
		string CustVendNum,
		string Name,
		string Email,
		string Password,
		string DecryptedPassword,
		string AccountType,
		string Slsman,
		string VendNum,
		int? NotifyUser,
		string Primary,
		int? CreateUser,
		string PortalURL,
		decimal? ResellerCommission,
		int? LocaleId,
		string Infobar);
	}
}

