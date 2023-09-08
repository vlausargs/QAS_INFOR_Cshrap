//PROJECT NAME: Logistics
//CLASS NAME: CalcProgBillAmtByPct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CalcProgBillAmtByPct : ICalcProgBillAmtByPct
	{
		readonly IApplicationDB appDB;
		
		
		public CalcProgBillAmtByPct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? BillAmount,
		decimal? CoitemPrice,
		string Infobar) CalcProgBillAmtByPctSp(string CoNum,
		int? CoLine,
		int? Percent,
		decimal? BillAmount,
		decimal? CoitemPrice,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			IntType _Percent = Percent;
			AmountType _BillAmount = BillAmount;
			AmountType _CoitemPrice = CoitemPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcProgBillAmtByPctSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Percent", _Percent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillAmount", _BillAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoitemPrice", _CoitemPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BillAmount = _BillAmount;
				CoitemPrice = _CoitemPrice;
				Infobar = _Infobar;
				
				return (Severity, BillAmount, CoitemPrice, Infobar);
			}
		}
	}
}
