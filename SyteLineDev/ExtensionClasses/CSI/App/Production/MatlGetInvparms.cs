//PROJECT NAME: Production
//CLASS NAME: MatlGetInvparms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class MatlGetInvparms : IMatlGetInvparms
	{
		readonly IApplicationDB appDB;
		
		
		public MatlGetInvparms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DefWhse,
		string EcnEst,
		string EcnJob,
		string EcnStd,
		int? NegFlag,
		string Infobar) MatlGetInvparmsSp(string DefWhse,
		string EcnEst,
		string EcnJob,
		string EcnStd,
		int? NegFlag,
		string Infobar)
		{
			WhseType _DefWhse = DefWhse;
			EcnModeType _EcnEst = EcnEst;
			EcnModeType _EcnJob = EcnJob;
			EcnModeType _EcnStd = EcnStd;
			ListYesNoType _NegFlag = NegFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MatlGetInvparmsSp";
				
				appDB.AddCommandParameter(cmd, "DefWhse", _DefWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcnEst", _EcnEst, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcnJob", _EcnJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcnStd", _EcnStd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NegFlag", _NegFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DefWhse = _DefWhse;
				EcnEst = _EcnEst;
				EcnJob = _EcnJob;
				EcnStd = _EcnStd;
				NegFlag = _NegFlag;
				Infobar = _Infobar;
				
				return (Severity, DefWhse, EcnEst, EcnJob, EcnStd, NegFlag, Infobar);
			}
		}
	}
}
