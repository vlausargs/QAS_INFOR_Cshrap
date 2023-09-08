//PROJECT NAME: Logistics
//CLASS NAME: IFTSLJobOpTeamSkillValidation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLJobOpTeamSkillValidation
	{
		(int? ReturnCode, string Infobar) FTSLJobOpTeamSkillValidationSp(string Team,
		string Job,
		int? Suffix,
		int? Operation,
		string Infobar,
		DateTime? PunchDate,
		string EmpNums,
		string ERPQueryResponseString);
	}
}

