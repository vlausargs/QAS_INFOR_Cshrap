//PROJECT NAME: Production
//CLASS NAME: IWBSPopulateProjWbs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IWBSPopulateProjWbs
	{
		(ICollectionLoadResponse Data, int? ReturnCode) WBSPopulateProjWbsSP(string RefType);
	}
}

