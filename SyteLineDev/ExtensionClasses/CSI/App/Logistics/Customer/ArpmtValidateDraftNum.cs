//PROJECT NAME: Logistics
//CLASS NAME: ArpmtValidateDraftNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtValidateDraftNum : IArpmtValidateDraftNum
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtValidateDraftNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PCheckAmt,
		decimal? PExchRate,
		DateTime? PDueDate,
		string Infobar) ArpmtValidateDraftNumSp(int? PDraftNum,
		string PCustNum,
		decimal? PCheckAmt,
		decimal? PExchRate,
		DateTime? PDueDate,
		string Infobar)
		{
			ArCheckNumType _PDraftNum = PDraftNum;
			CustNumType _PCustNum = PCustNum;
			AmountType _PCheckAmt = PCheckAmt;
			ExchRateType _PExchRate = PExchRate;
			DateType _PDueDate = PDueDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtValidateDraftNumSp";
				
				appDB.AddCommandParameter(cmd, "PDraftNum", _PDraftNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckAmt", _PCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCheckAmt = _PCheckAmt;
				PExchRate = _PExchRate;
				PDueDate = _PDueDate;
				Infobar = _Infobar;
				
				return (Severity, PCheckAmt, PExchRate, PDueDate, Infobar);
			}
		}
	}
}
