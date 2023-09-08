//PROJECT NAME: Material
//CLASS NAME: ICLM_ContainerGetJobMatls.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_ContainerGetJobMatls
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) CLM_ContainerGetJobMatlsSp(
			string Site = null,
			string JobJob = null,
			int? JobSuffix = null,
			string JobmatlOperNum = null,
			int? ExtScrap = 1,
			string CurWhse = null,
			int? ShowBFlushMatls = 0,
			string ContainerNum = null,
			string Infobar = null);
	}
}

