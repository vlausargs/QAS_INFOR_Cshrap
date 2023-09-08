//PROJECT NAME: Data
//CLASS NAME: ITrack.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrack
	{
		(int? ReturnCode,
			decimal? TrackNum) TrackSp(
			string Item,
			string TrackType,
			string Loc,
			string Lot,
			DateTime? Date,
			int? DateSeq = 0,
			decimal? Qty = 0,
			string RefType = "I",
			string RefNum = null,
			int? RefLineSuf = 0,
			int? RefRelease = 0,
			string CustNum = null,
			string VendNum = null,
			decimal? TrackLink = 0,
			string Whse = null,
			string Workkey = null,
			decimal? TrackNum = null,
			string ImportDocId = null,
			int? SkipMatlTrack = 0);
	}
}

