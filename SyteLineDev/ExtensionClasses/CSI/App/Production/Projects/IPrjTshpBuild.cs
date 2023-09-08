//PROJECT NAME: Production
//CLASS NAME: IPrjTshpBuild.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IPrjTshpBuild
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PrjTshpBuildSp(string TProjNum,
		int? TTaskNum,
		string FilterString);
	}
}

