//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPartnerGetPartnerFromUser.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPartnerGetPartnerFromUser
	{
		(int? ReturnCode,
			string Partner,
			string Infobar) SSSFSPartnerGetPartnerFromUserSp(
			string UserName,
			string Partner,
			string Infobar);
	}
}

