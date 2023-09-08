//PROJECT NAME: Production
//CLASS NAME: IUPD_RevMsNom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IUPD_RevMsNom
	{
		int? UPD_RevMsNomSp(string pProjNum,
		string pRevMsNum,
		int? pNominated,
		DateTime? pPlanDate,
		decimal? pPlanMatlCost,
		decimal? pPlanLaborCost,
		decimal? pPlanOtherCost,
		decimal? pPlanOvhCost,
		decimal? pPlanGACost,
		decimal? pPlanRev,
		DateTime? pActDate,
		decimal? pActMatlCost,
		decimal? pActLaborCost,
		decimal? pActOtherCost,
		decimal? pActOvhCost,
		decimal? pActGACost,
		decimal? pActRev);
	}
}

