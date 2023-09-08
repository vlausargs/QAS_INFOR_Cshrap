//PROJECT NAME: Production
//CLASS NAME: IGetJobMatls.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IGetJobMatls
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) GetJobMatlsSp(string Site = null,
		string JobJob = null,
		int? JobSuffix = null,
		string JobmatlOperNum = null,
		string JobmatlSequence = null,
		string JobmatlItem = null,
		string JobmatlDesc = null,
		int? ExtScrap = 1,
		string CurWhse = null,
		int? ShowBFlushMatls = 0,
		string ContainerNum = null,
		string Infobar = null,
		string FilterString = null);
	}
}

