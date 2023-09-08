//PROJECT NAME: Production
//CLASS NAME: ApsWhseIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsWhseIns : IApsWhseIns
	{
		readonly IApplicationDB appDB;
		
		
		public ApsWhseIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsWhseInsSp(string WHSE,
		int? derPLANINTRASITETRANSFERS,
		decimal? TRNTIME,
		int? AltNo)
		{
			ApsWhseType _WHSE = WHSE;
			ApsBitFlagsType _derPLANINTRASITETRANSFERS = derPLANINTRASITETRANSFERS;
			ApsFloatType _TRNTIME = TRNTIME;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsWhseInsSp";
				
				appDB.AddCommandParameter(cmd, "WHSE", _WHSE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "derPLANINTRASITETRANSFERS", _derPLANINTRASITETRANSFERS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRNTIME", _TRNTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
