//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSupDemBuild.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSupDemBuild
	{
		ICollectionLoadResponse SSSFSSupDemBuildFn(
			string Item,
			string Whse);
	}
}

