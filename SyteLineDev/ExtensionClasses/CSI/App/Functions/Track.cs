//PROJECT NAME: Data
//CLASS NAME: Track.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Track : ITrack
	{
		readonly IApplicationDB appDB;
		
		public Track(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			int? SkipMatlTrack = 0)
		{
			ItemType _Item = Item;
			TrackTypeType _TrackType = TrackType;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			DateType _Date = Date;
			IntType _DateSeq = DateSeq;
			QtyUnitType _Qty = Qty;
			RefTypeIJOPRSTType _RefType = RefType;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			VariousSmallRefLineType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
			CustNumType _CustNum = CustNum;
			VendNumType _VendNum = VendNum;
			MatlTransNumType _TrackLink = TrackLink;
			WhseType _Whse = Whse;
			StringType _Workkey = Workkey;
			MatlTransNumType _TrackNum = TrackNum;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _SkipMatlTrack = SkipMatlTrack;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrackSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrackType", _TrackType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateSeq", _DateSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrackLink", _TrackLink, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Workkey", _Workkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrackNum", _TrackNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipMatlTrack", _SkipMatlTrack, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TrackNum = _TrackNum;
				
				return (Severity, TrackNum);
			}
		}
	}
}
