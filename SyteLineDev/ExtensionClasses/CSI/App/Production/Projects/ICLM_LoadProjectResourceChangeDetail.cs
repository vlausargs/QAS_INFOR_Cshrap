//PROJECT NAME: Production
//CLASS NAME: ICLM_LoadProjectResourceChangeDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICLM_LoadProjectResourceChangeDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_LoadProjectResourceChangeDetailSP(string ProjNum,
		int? ChgNum);
	}
}

