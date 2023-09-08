//PROJECT NAME: Production
//CLASS NAME: ProjInvMsLoadTot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjInvMsLoadTot : IProjInvMsLoadTot
	{
		readonly IApplicationDB appDB;
		
		
		public ProjInvMsLoadTot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PTotPerPlanInvAmt,
		decimal? PTotPerActInvAmt,
		decimal? PTotPerNomPlanInvAmt,
		decimal? PTotPerNomActInvAmt,
		decimal? PTotYrPlanInvAmt,
		decimal? PTotYrActInvAmt,
		decimal? PTotYrNomPlanInvAmt,
		decimal? PTotYrNomActInvAmt) ProjInvMsLoadTotSp(DateTime? PCurrentPeriodStart,
		DateTime? PCurrentPeriodEnd,
		decimal? PTotPerPlanInvAmt,
		decimal? PTotPerActInvAmt,
		decimal? PTotPerNomPlanInvAmt,
		decimal? PTotPerNomActInvAmt,
		decimal? PTotYrPlanInvAmt,
		decimal? PTotYrActInvAmt,
		decimal? PTotYrNomPlanInvAmt,
		decimal? PTotYrNomActInvAmt)
		{
			DateType _PCurrentPeriodStart = PCurrentPeriodStart;
			DateType _PCurrentPeriodEnd = PCurrentPeriodEnd;
			AmtTotType _PTotPerPlanInvAmt = PTotPerPlanInvAmt;
			AmtTotType _PTotPerActInvAmt = PTotPerActInvAmt;
			AmtTotType _PTotPerNomPlanInvAmt = PTotPerNomPlanInvAmt;
			AmtTotType _PTotPerNomActInvAmt = PTotPerNomActInvAmt;
			AmtTotType _PTotYrPlanInvAmt = PTotYrPlanInvAmt;
			AmtTotType _PTotYrActInvAmt = PTotYrActInvAmt;
			AmtTotType _PTotYrNomPlanInvAmt = PTotYrNomPlanInvAmt;
			AmtTotType _PTotYrNomActInvAmt = PTotYrNomActInvAmt;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjInvMsLoadTotSp";
				
				appDB.AddCommandParameter(cmd, "PCurrentPeriodStart", _PCurrentPeriodStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrentPeriodEnd", _PCurrentPeriodEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotPerPlanInvAmt", _PTotPerPlanInvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotPerActInvAmt", _PTotPerActInvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotPerNomPlanInvAmt", _PTotPerNomPlanInvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotPerNomActInvAmt", _PTotPerNomActInvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotYrPlanInvAmt", _PTotYrPlanInvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotYrActInvAmt", _PTotYrActInvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotYrNomPlanInvAmt", _PTotYrNomPlanInvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotYrNomActInvAmt", _PTotYrNomActInvAmt, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PTotPerPlanInvAmt = _PTotPerPlanInvAmt;
				PTotPerActInvAmt = _PTotPerActInvAmt;
				PTotPerNomPlanInvAmt = _PTotPerNomPlanInvAmt;
				PTotPerNomActInvAmt = _PTotPerNomActInvAmt;
				PTotYrPlanInvAmt = _PTotYrPlanInvAmt;
				PTotYrActInvAmt = _PTotYrActInvAmt;
				PTotYrNomPlanInvAmt = _PTotYrNomPlanInvAmt;
				PTotYrNomActInvAmt = _PTotYrNomActInvAmt;
				
				return (Severity, PTotPerPlanInvAmt, PTotPerActInvAmt, PTotPerNomPlanInvAmt, PTotPerNomActInvAmt, PTotYrPlanInvAmt, PTotYrActInvAmt, PTotYrNomPlanInvAmt, PTotYrNomActInvAmt);
			}
		}
	}
}
