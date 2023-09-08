//PROJECT NAME: Production
//CLASS NAME: ICLM_ContainerItemsForCompareToProjRes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICLM_ContainerItemsForCompareToProjRes
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ContainerItemsForCompareToProjResSp(string ProjNum,
		int? ProjTaskNum,
		string ContainerNum,
		string Infobar);
	}
}

