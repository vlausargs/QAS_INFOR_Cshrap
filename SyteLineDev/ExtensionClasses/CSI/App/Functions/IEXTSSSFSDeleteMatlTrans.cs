//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSDeleteMatlTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSDeleteMatlTrans
	{
		ICollectionLoadResponse EXTSSSFSDeleteMatlTransFn(
			DateTime? FromTransDate,
			DateTime? ToTransDate,
			decimal? FromTransNum,
			decimal? ToTransNum,
			string FromItem,
			string ToItem,
			string FromLoc,
			string ToLoc,
			string RefType);
	}
}

