//PROJECT NAME: Production
//CLASS NAME: UPD_RevMsNom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class UPD_RevMsNom : IUPD_RevMsNom
	{
		readonly IApplicationDB appDB;
		
		
		public UPD_RevMsNom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UPD_RevMsNomSp(string pProjNum,
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
		decimal? pActRev)
		{
			ProjNumType _pProjNum = pProjNum;
			ProjMsNumType _pRevMsNum = pRevMsNum;
			ListYesNoType _pNominated = pNominated;
			DateType _pPlanDate = pPlanDate;
			AmountType _pPlanMatlCost = pPlanMatlCost;
			AmountType _pPlanLaborCost = pPlanLaborCost;
			AmountType _pPlanOtherCost = pPlanOtherCost;
			AmountType _pPlanOvhCost = pPlanOvhCost;
			AmountType _pPlanGACost = pPlanGACost;
			AmountType _pPlanRev = pPlanRev;
			DateType _pActDate = pActDate;
			AmountType _pActMatlCost = pActMatlCost;
			AmountType _pActLaborCost = pActLaborCost;
			AmountType _pActOtherCost = pActOtherCost;
			AmountType _pActOvhCost = pActOvhCost;
			AmountType _pActGACost = pActGACost;
			AmountType _pActRev = pActRev;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UPD_RevMsNomSp";
				
				appDB.AddCommandParameter(cmd, "pProjNum", _pProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRevMsNum", _pRevMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNominated", _pNominated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanDate", _pPlanDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanMatlCost", _pPlanMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanLaborCost", _pPlanLaborCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanOtherCost", _pPlanOtherCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanOvhCost", _pPlanOvhCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanGACost", _pPlanGACost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanRev", _pPlanRev, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActDate", _pActDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActMatlCost", _pActMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActLaborCost", _pActLaborCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActOtherCost", _pActOtherCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActOvhCost", _pActOvhCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActGACost", _pActGACost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActRev", _pActRev, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
