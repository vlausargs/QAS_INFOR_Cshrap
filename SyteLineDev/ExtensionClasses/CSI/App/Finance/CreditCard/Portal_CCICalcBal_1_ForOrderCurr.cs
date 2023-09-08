//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCICalcBal_1_ForOrderCurr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_CCICalcBal_1_ForOrderCurr
	{
		int Portal_CCICalcBal_1_ForOrderCurrSp(string CustNum,
		                                       string CardSystemId,
		                                       string RefType,
		                                       string RefNum,
		                                       decimal? OrderAmt,
		                                       decimal? OrderExchRate,
		                                       ref decimal? Balance,
		                                       ref decimal? PayExchRate,
		                                       ref decimal? BankAmt,
		                                       ref decimal? BankExchRate,
		                                       ref string Infobar);
	}
	
	public class Portal_CCICalcBal_1_ForOrderCurr : IPortal_CCICalcBal_1_ForOrderCurr
	{
		readonly IApplicationDB appDB;
		
		public Portal_CCICalcBal_1_ForOrderCurr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int Portal_CCICalcBal_1_ForOrderCurrSp(string CustNum,
		                                              string CardSystemId,
		                                              string RefType,
		                                              string RefNum,
		                                              decimal? OrderAmt,
		                                              decimal? OrderExchRate,
		                                              ref decimal? Balance,
		                                              ref decimal? PayExchRate,
		                                              ref decimal? BankAmt,
		                                              ref decimal? BankExchRate,
		                                              ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CCICardSystemIDType _CardSystemId = CardSystemId;
			CCITransRefTypeType _RefType = RefType;
			InvNumType _RefNum = RefNum;
			AmountType _OrderAmt = OrderAmt;
			ExchRateType _OrderExchRate = OrderExchRate;
			AmountType _Balance = Balance;
			ExchRateType _PayExchRate = PayExchRate;
			AmountType _BankAmt = BankAmt;
			ExchRateType _BankExchRate = BankExchRate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Portal_CCICalcBal_1_ForOrderCurrSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderAmt", _OrderAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderExchRate", _OrderExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayExchRate", _PayExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BankAmt", _BankAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BankExchRate", _BankExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Balance = _Balance;
				PayExchRate = _PayExchRate;
				BankAmt = _BankAmt;
				BankExchRate = _BankExchRate;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
