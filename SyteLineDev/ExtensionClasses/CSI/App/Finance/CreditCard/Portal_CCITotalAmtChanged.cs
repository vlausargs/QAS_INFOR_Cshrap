//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCITotalAmtChanged.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_CCITotalAmtChanged
	{
		int Portal_CCITotalAmtChangedSp(string CustNum,
		                                string CardSystemId,
		                                decimal? TotalAmt,
		                                ref decimal? DomAmt,
		                                ref decimal? ForAmt,
		                                ref decimal? ExchRate,
		                                ref decimal? PayExchRate,
		                                ref string Infobar);
	}
	
	public class Portal_CCITotalAmtChanged : IPortal_CCITotalAmtChanged
	{
		readonly IApplicationDB appDB;
		
		public Portal_CCITotalAmtChanged(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int Portal_CCITotalAmtChangedSp(string CustNum,
		                                       string CardSystemId,
		                                       decimal? TotalAmt,
		                                       ref decimal? DomAmt,
		                                       ref decimal? ForAmt,
		                                       ref decimal? ExchRate,
		                                       ref decimal? PayExchRate,
		                                       ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CCICardSystemIDType _CardSystemId = CardSystemId;
			AmountType _TotalAmt = TotalAmt;
			AmountType _DomAmt = DomAmt;
			AmountType _ForAmt = ForAmt;
			ExchRateType _ExchRate = ExchRate;
			ExchRateType _PayExchRate = PayExchRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Portal_CCITotalAmtChangedSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalAmt", _TotalAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAmt", _DomAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForAmt", _ForAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayExchRate", _PayExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DomAmt = _DomAmt;
				ForAmt = _ForAmt;
				ExchRate = _ExchRate;
				PayExchRate = _PayExchRate;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
