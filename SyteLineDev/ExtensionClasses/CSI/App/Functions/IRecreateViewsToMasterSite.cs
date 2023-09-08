//PROJECT NAME: Data
//CLASS NAME: IRecreateViewsToMasterSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRecreateViewsToMasterSite
	{
		(int? ReturnCode,
			string Infobar) RecreateViewsToMasterSiteSp(
			string Infobar);
	}
}

