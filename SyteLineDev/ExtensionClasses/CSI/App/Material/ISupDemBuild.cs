//PROJECT NAME: Material
//CLASS NAME: ISupDemBuild.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ISupDemBuild
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SupDemBuildSp(string Item,
		string Whse,
		DateTime? StartingDate,
		string Filter);
	}
}

