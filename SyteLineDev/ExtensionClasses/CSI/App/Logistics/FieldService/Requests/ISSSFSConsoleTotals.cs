//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConsoleTotals.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSConsoleTotals
	{
		(int? ReturnCode, decimal? PlanMatl,
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
		decimal? UnActProject = 0);
	}
}

