//PROJECT NAME: Production
//CLASS NAME: IUPD_InvMsNom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IUPD_InvMsNom
	{
		int? UPD_InvMsNomSp(string pProjNum,
		string pInvMsNum,
		int? pNominated,
		decimal? pActInvAmt,
		DateTime? pActDate,
		decimal? pTaxableAmt,
		decimal? pActFreight,
		decimal? pMiscCharges,
		decimal? pPlanInvAmt,
		decimal? pPlanFreight,
		decimal? pPlanMiscCharges);
	}
}

