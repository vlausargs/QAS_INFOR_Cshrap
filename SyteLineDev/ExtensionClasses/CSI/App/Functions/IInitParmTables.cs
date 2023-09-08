//PROJECT NAME: Data
//CLASS NAME: IInitParmTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInitParmTables
	{
		(int? ReturnCode,
			string Infobar) InitParmTablesSp(
			string Site,
			string SiteGroup = null,
			string TimeZone = null,
			string Infobar = null,
			string SiteType = null);
	}
}

