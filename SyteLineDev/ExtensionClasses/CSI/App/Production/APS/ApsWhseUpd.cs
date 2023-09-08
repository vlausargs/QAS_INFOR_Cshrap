//PROJECT NAME: Production
//CLASS NAME: ApsWhseUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsWhseUpd : IApsWhseUpd
	{
		readonly IApplicationDB appDB;
		
		
		public ApsWhseUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsWhseUpdSp(string WHSE,
		int? derPLANINTRASITETRANSFERS,
		decimal? TRNTIME,
		Guid? RowP,
		int? AltNo)
		{
			ApsWhseType _WHSE = WHSE;
			ApsBitFlagsType _derPLANINTRASITETRANSFERS = derPLANINTRASITETRANSFERS;
			ApsFloatType _TRNTIME = TRNTIME;
			RowPointerType _RowP = RowP;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsWhseUpdSp";
				
				appDB.AddCommandParameter(cmd, "WHSE", _WHSE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "derPLANINTRASITETRANSFERS", _derPLANINTRASITETRANSFERS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRNTIME", _TRNTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowP", _RowP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
