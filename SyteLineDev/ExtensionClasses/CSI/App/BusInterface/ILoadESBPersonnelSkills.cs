//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBPersonnelSkills.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBPersonnelSkills
	{
		(int? ReturnCode, string Infobar) LoadESBPersonnelSkillsSp(string ActionExpression = null,
		string EmpNum = null,
		string Skill = null,
		string CompetencyCode = null,
		DateTime? SkillDate = null,
		string Infobar = null);
	}
}

