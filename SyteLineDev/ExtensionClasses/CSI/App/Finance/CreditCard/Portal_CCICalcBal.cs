//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCICalcBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_CCICalcBal
	{
		int Portal_CCICalcBalSp(string CustNum,
		                        string CardSystemId,
		                        decimal? ForAmt,
		                        ref decimal? Balance,
		                        ref decimal? PayExchRate,
		                        ref string Infobar);
	}
	
	public class Portal_CCICalcBal : IPortal_CCICalcBal
	{
		readonly IApplicationDB appDB;
		
		public Portal_CCICalcBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int Portal_CCICalcBalSp(string CustNum,
		                               string CardSystemId,
		                               decimal? ForAmt,
		                               ref decimal? Balance,
		                               ref decimal? PayExchRate,
		                               ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CCICardSystemIDType _CardSystemId = CardSystemId;
			AmountType _ForAmt = ForAmt;
			AmountType _Balance = Balance;
			ExchRateType _PayExchRate = PayExchRate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Portal_CCICalcBalSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmt", _ForAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayExchRate", _PayExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Balance = _Balance;
				PayExchRate = _PayExchRate;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
