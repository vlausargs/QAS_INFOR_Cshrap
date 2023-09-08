//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBPersonnelSkills.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBPersonnelSkills : ILoadESBPersonnelSkills
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBPersonnelSkills(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadESBPersonnelSkillsSp(string ActionExpression = null,
		string EmpNum = null,
		string Skill = null,
		string CompetencyCode = null,
		DateTime? SkillDate = null,
		string Infobar = null)
		{
			StringType _ActionExpression = ActionExpression;
			EmpNumType _EmpNum = EmpNum;
			SkillType _Skill = Skill;
			SkillType _CompetencyCode = CompetencyCode;
			DateType _SkillDate = SkillDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBPersonnelSkillsSp";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Skill", _Skill, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompetencyCode", _CompetencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkillDate", _SkillDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
