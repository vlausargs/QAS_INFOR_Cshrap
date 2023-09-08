//PROJECT NAME: Data
//CLASS NAME: ITrkMap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrkMap
	{
		(int? ReturnCode,
			string PTransType) TrkMapSp(
			string PTrackType,
			string PRefType,
			decimal? PQty,
			string PLoc,
			string PWhse,
			string PRefNum,
			string PTransType);

		string TrkMapFn(
			string PTrackType,
			string PRefType,
			decimal? PQty,
			string PLoc,
			string PWhse,
			string PRefNum);
	}
}

