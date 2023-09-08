//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSSubDemBuild2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSSubDemBuild2
	{
		ICollectionLoadResponse EXTSSSFSSubDemBuild2Fn(
			string Item,
			string Whse);
	}
}

