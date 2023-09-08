//PROJECT NAME: Data
//CLASS NAME: IApp_UserAndGroupCopyDBDataClean.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_UserAndGroupCopyDBDataClean
	{
		(int? ReturnCode,
			string Infobar) App_UserAndGroupCopyDBDataCleanSp(
			string SourceServer,
			string SourceDB,
			string SourceSite,
			int? UsersAreShared,
			string Infobar);
	}
}

