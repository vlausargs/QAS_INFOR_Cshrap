//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConsoleTotals.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSConsoleTotals : ISSSFSConsoleTotals
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSConsoleTotals(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PlanMatl,
		decimal? PlanLabor,
		decimal? PlanMisc,
		decimal? ActMatl,
		decimal? ActLabor,
		decimal? ActMisc,
		decimal? ActProject,
		decimal? PlanTotal,
		decimal? ActTotal,
		string Infobar,
		decimal? PlanProject,
		decimal? UnActProject) SSSFSConsoleTotalsSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string Level,
		string ValueType,
		decimal? PlanMatl,
		decimal? PlanLabor,
		decimal? PlanMisc,
		decimal? ActMatl,
		decimal? ActLabor,
		decimal? ActMisc,
		decimal? ActProject,
		decimal? PlanTotal,
		decimal? ActTotal,
		string Infobar,
		decimal? PlanProject = 0,
		decimal? UnActProject = 0)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			StringType _Level = Level;
			StringType _ValueType = ValueType;
			AmountType _PlanMatl = PlanMatl;
			AmountType _PlanLabor = PlanLabor;
			AmountType _PlanMisc = PlanMisc;
			AmountType _ActMatl = ActMatl;
			AmountType _ActLabor = ActLabor;
			AmountType _ActMisc = ActMisc;
			AmountType _ActProject = ActProject;
			AmountType _PlanTotal = PlanTotal;
			AmountType _ActTotal = ActTotal;
			Infobar _Infobar = Infobar;
			AmountType _PlanProject = PlanProject;
			AmountType _UnActProject = UnActProject;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConsoleTotalsSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ValueType", _ValueType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanMatl", _PlanMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanLabor", _PlanLabor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanMisc", _PlanMisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ActMatl", _ActMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ActLabor", _ActLabor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ActMisc", _ActMisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ActProject", _ActProject, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanTotal", _PlanTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ActTotal", _ActTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanProject", _PlanProject, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnActProject", _UnActProject, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PlanMatl = _PlanMatl;
				PlanLabor = _PlanLabor;
				PlanMisc = _PlanMisc;
				ActMatl = _ActMatl;
				ActLabor = _ActLabor;
				ActMisc = _ActMisc;
				ActProject = _ActProject;
				PlanTotal = _PlanTotal;
				ActTotal = _ActTotal;
				Infobar = _Infobar;
				PlanProject = _PlanProject;
				UnActProject = _UnActProject;
				
				return (Severity, PlanMatl, PlanLabor, PlanMisc, ActMatl, ActLabor, ActMisc, ActProject, PlanTotal, ActTotal, Infobar, PlanProject, UnActProject);
			}
		}
	}
}
