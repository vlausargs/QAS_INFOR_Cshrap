//PROJECT NAME: Data
//CLASS NAME: IChangeReportsToBuildSiteList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsToBuildSiteList
	{
		(int? ReturnCode,
			string Infobar) ChangeReportsToBuildSiteListSp(
			string pEntity,
			string Infobar);
	}
}

