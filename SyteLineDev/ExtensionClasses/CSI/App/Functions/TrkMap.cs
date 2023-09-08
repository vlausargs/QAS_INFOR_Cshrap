//PROJECT NAME: Data
//CLASS NAME: TrkMap.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TrkMap : ITrkMap
	{
		readonly IApplicationDB appDB;
		
		public TrkMap(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PTransType) TrkMapSp(
			string PTrackType,
			string PRefType,
			decimal? PQty,
			string PLoc,
			string PWhse,
			string PRefNum,
			string PTransType)
		{
			TrackTypeType _PTrackType = PTrackType;
			RefTypeIJOPRSTType _PRefType = PRefType;
			QtyUnitType _PQty = PQty;
			LocType _PLoc = PLoc;
			WhseType _PWhse = PWhse;
			EmpJobCoPoRmaProjPsTrnNumType _PRefNum = PRefNum;
			LongListType _PTransType = PTransType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrkMapSp";
				
				appDB.AddCommandParameter(cmd, "PTrackType", _PTrackType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransType", _PTransType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PTransType = _PTransType;
				
				return (Severity, PTransType);
			}
		}

		public string TrkMapFn(
			string PTrackType,
			string PRefType,
			decimal? PQty,
			string PLoc,
			string PWhse,
			string PRefNum)
		{
			TrackTypeType _PTrackType = PTrackType;
			RefTypeIJOPRSTType _PRefType = PRefType;
			QtyPerType _PQty = PQty;
			LocType _PLoc = PLoc;
			WhseType _PWhse = PWhse;
			EmpJobCoPoRmaProjPsTrnNumType _PRefNum = PRefNum;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[TrkMap](@PTrackType, @PRefType, @PQty, @PLoc, @PWhse, @PRefNum)";

				appDB.AddCommandParameter(cmd, "PTrackType", _PTrackType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
