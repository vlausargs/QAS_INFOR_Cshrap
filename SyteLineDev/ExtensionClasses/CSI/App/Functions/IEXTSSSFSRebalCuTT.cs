//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSRebalCuTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSRebalCuTT
	{
		ICollectionLoadResponse EXTSSSFSRebalCuTTFn(
			string StartCustNum,
			string EndCustNum,
			int? CorpCustIncluded);
	}
}

