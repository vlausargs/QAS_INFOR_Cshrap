//PROJECT NAME: Production
//CLASS NAME: UPD_InvMsNom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class UPD_InvMsNom : IUPD_InvMsNom
	{
		readonly IApplicationDB appDB;
		
		
		public UPD_InvMsNom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UPD_InvMsNomSp(string pProjNum,
		string pInvMsNum,
		int? pNominated,
		decimal? pActInvAmt,
		DateTime? pActDate,
		decimal? pTaxableAmt,
		decimal? pActFreight,
		decimal? pMiscCharges,
		decimal? pPlanInvAmt,
		decimal? pPlanFreight,
		decimal? pPlanMiscCharges)
		{
			ProjNumType _pProjNum = pProjNum;
			ProjMsNumType _pInvMsNum = pInvMsNum;
			ListYesNoType _pNominated = pNominated;
			AmtTotType _pActInvAmt = pActInvAmt;
			DateType _pActDate = pActDate;
			AmtTotType _pTaxableAmt = pTaxableAmt;
			AmtTotType _pActFreight = pActFreight;
			AmtTotType _pMiscCharges = pMiscCharges;
			AmtTotType _pPlanInvAmt = pPlanInvAmt;
			AmtTotType _pPlanFreight = pPlanFreight;
			AmtTotType _pPlanMiscCharges = pPlanMiscCharges;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UPD_InvMsNomSp";
				
				appDB.AddCommandParameter(cmd, "pProjNum", _pProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvMsNum", _pInvMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNominated", _pNominated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActInvAmt", _pActInvAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActDate", _pActDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTaxableAmt", _pTaxableAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActFreight", _pActFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMiscCharges", _pMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanInvAmt", _pPlanInvAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanFreight", _pPlanFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanMiscCharges", _pPlanMiscCharges, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
