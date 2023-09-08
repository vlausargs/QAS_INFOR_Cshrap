//PROJECT NAME: Production
//CLASS NAME: GetRepparParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IGetRepparParms
	{
		(int? ReturnCode, decimal? LateThreshold, decimal? BotnkUtilThresh) GetRepparParmsSp(decimal? LateThreshold,
		decimal? BotnkUtilThresh);
	}
	
	public class GetRepparParms : IGetRepparParms
	{
		readonly IApplicationDB appDB;
		
		public GetRepparParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? LateThreshold, decimal? BotnkUtilThresh) GetRepparParmsSp(decimal? LateThreshold,
		decimal? BotnkUtilThresh)
		{
			GenericFloatType _LateThreshold = LateThreshold;
			GenericFloatType _BotnkUtilThresh = BotnkUtilThresh;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetRepparParmsSp";
				
				appDB.AddCommandParameter(cmd, "LateThreshold", _LateThreshold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BotnkUtilThresh", _BotnkUtilThresh, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LateThreshold = _LateThreshold;
				BotnkUtilThresh = _BotnkUtilThresh;
				
				return (Severity, LateThreshold, BotnkUtilThresh);
			}
		}
	}
}
