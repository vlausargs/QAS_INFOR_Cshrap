//PROJECT NAME: Data
//CLASS NAME: IAPP_ChangeSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_ChangeSite
	{
		(int? ReturnCode,
			string Infobar) APP_ChangeSiteSp(
			string POldSite,
			string PNewSite,
			string Infobar);
	}
}

