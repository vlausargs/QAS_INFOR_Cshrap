//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSUnitConfigAutoCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSUnitConfigAutoCreate
	{
		int? EXTSSSFSUnitConfigAutoCreateSp(
			decimal? TrackNum);
	}
}

