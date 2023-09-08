//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSSupDemBuild.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSSupDemBuild
	{
		ICollectionLoadResponse EXTSSSFSSupDemBuildFn(
			string Item,
			string Whse);
	}
}

