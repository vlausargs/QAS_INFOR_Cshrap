//PROJECT NAME: Codes
//CLASS NAME: IIdentifyCustomerPortalUserType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IIdentifyCustomerPortalUserType
	{
		(int? ReturnCode, int? IsBTB,
		string Infobar) IdentifyCustomerPortalUserTypeSp(string Username,
		int? IsBTB,
		string Infobar);
	}
}

