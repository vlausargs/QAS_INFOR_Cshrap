//PROJECT NAME: Production
//CLASS NAME: ApsCalcExpTime.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCalcExpTime : IApsCalcExpTime
	{
		readonly IApplicationDB appDB;
		
		public ApsCalcExpTime(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsCalcExpTimeFn(
			int? PCALExists,
			string USETNFG,
			DateTime? SchDate,
			decimal? FLEADTIME,
			decimal? VLEADTIME,
			decimal? DEMAND,
			DateTime? TIMENOW,
			DateTime? LASTSYNCH)
		{
			IntType _PCALExists = PCALExists;
			ApsFlagType _USETNFG = USETNFG;
			DateTimeType _SchDate = SchDate;
			ApsDurationType _FLEADTIME = FLEADTIME;
			ApsDurationType _VLEADTIME = VLEADTIME;
			ApsFloatType _DEMAND = DEMAND;
			DateTimeType _TIMENOW = TIMENOW;
			DateTimeType _LASTSYNCH = LASTSYNCH;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCalcExpTime](@PCALExists, @USETNFG, @SchDate, @FLEADTIME, @VLEADTIME, @DEMAND, @TIMENOW, @LASTSYNCH)";
				
				appDB.AddCommandParameter(cmd, "PCALExists", _PCALExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "USETNFG", _USETNFG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchDate", _SchDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FLEADTIME", _FLEADTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VLEADTIME", _VLEADTIME, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DEMAND", _DEMAND, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIMENOW", _TIMENOW, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LASTSYNCH", _LASTSYNCH, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
