//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCalcTotals.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCalcTotals : ISSSFSConInvSubCalcTotals
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSConInvSubCalcTotals(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? oSubTotal,
		decimal? oTotSurcharge,
		decimal? oTotWaiver,
		decimal? oSalesTax1,
		decimal? oSalesTax2,
		decimal? oTotBilled,
		decimal? oBalance,
		decimal? oPayments,
		string Infobar) SSSFSConInvSubCalcTotalsSp(Guid? SessionId,
		string iContract,
		DateTime? iInvDate,
		string iInvNum,
		string iMode = null,
		decimal? oSubTotal = null,
		decimal? oTotSurcharge = null,
		decimal? oTotWaiver = null,
		decimal? oSalesTax1 = null,
		decimal? oSalesTax2 = null,
		decimal? oTotBilled = null,
		decimal? oBalance = null,
		decimal? oPayments = null,
		string Infobar = null)
		{
			RowPointerType _SessionId = SessionId;
			FSContractType _iContract = iContract;
			DateType _iInvDate = iInvDate;
			InvNumType _iInvNum = iInvNum;
			StringType _iMode = iMode;
			CostPrcType _oSubTotal = oSubTotal;
			CostPrcType _oTotSurcharge = oTotSurcharge;
			CostPrcType _oTotWaiver = oTotWaiver;
			CostPrcType _oSalesTax1 = oSalesTax1;
			CostPrcType _oSalesTax2 = oSalesTax2;
			CostPrcType _oTotBilled = oTotBilled;
			CostPrcType _oBalance = oBalance;
			CostPrcType _oPayments = oPayments;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubCalcTotalsSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iContract", _iContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iInvDate", _iInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iInvNum", _iInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oSubTotal", _oSubTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oTotSurcharge", _oTotSurcharge, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oTotWaiver", _oTotWaiver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSalesTax1", _oSalesTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSalesTax2", _oSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oTotBilled", _oTotBilled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oBalance", _oBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oPayments", _oPayments, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oSubTotal = _oSubTotal;
				oTotSurcharge = _oTotSurcharge;
				oTotWaiver = _oTotWaiver;
				oSalesTax1 = _oSalesTax1;
				oSalesTax2 = _oSalesTax2;
				oTotBilled = _oTotBilled;
				oBalance = _oBalance;
				oPayments = _oPayments;
				Infobar = _Infobar;
				
				return (Severity, oSubTotal, oTotSurcharge, oTotWaiver, oSalesTax1, oSalesTax2, oTotBilled, oBalance, oPayments, Infobar);
			}
		}
	}
}
