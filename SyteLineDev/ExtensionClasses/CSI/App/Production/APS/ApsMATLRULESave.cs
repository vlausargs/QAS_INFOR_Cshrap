//PROJECT NAME: Production
//CLASS NAME: ApsMATLRULESave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLRULESave : IApsMATLRULESave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsMATLRULESave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsMATLRULESaveSp(int? InsertFlag,
		int? AltNo,
		string LMATLID,
		string RSITEID,
		string EFFECTID,
		string RMATLID,
		decimal? FLEADTIME,
		decimal? VLEADTIME,
		decimal? TRANSIT,
		int? TIMEOUT,
		decimal? UOMSCALE)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsMaterialType _LMATLID = LMATLID;
			ApsSiteType _RSITEID = RSITEID;
			ApsEffectType _EFFECTID = EFFECTID;
			ApsMaterialType _RMATLID = RMATLID;
			ApsDurationType _FLEADTIME = FLEADTIME;
			ApsDurationType _VLEADTIME = VLEADTIME;
			ApsDurationType _TRANSIT = TRANSIT;
			ApsIntType _TIMEOUT = TIMEOUT;
			ApsFloatType _UOMSCALE = UOMSCALE;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsMATLRULESaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LMATLID", _LMATLID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RSITEID", _RSITEID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFFECTID", _EFFECTID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMATLID", _RMATLID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FLEADTIME", _FLEADTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VLEADTIME", _VLEADTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRANSIT", _TRANSIT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIMEOUT", _TIMEOUT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UOMSCALE", _UOMSCALE, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
