//PROJECT NAME: Logistics
//CLASS NAME: AppmtCalcCheckAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtCalcCheckAmount : IAppmtCalcCheckAmount
	{
		readonly IApplicationDB appDB;
		
		
		public AppmtCalcCheckAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? POutCheckAmt,
		string Infobar) AppmtCalcCheckAmountSp(decimal? PExchRate,
		decimal? PInCheckAmt,
		string PVendCurr,
		DateTime? PCheckDate,
		int? PToVendor,
		decimal? POutCheckAmt,
		string Infobar)
		{
			ExchRateType _PExchRate = PExchRate;
			AmountType _PInCheckAmt = PInCheckAmt;
			CurrCodeType _PVendCurr = PVendCurr;
			DateType _PCheckDate = PCheckDate;
			FlagNyType _PToVendor = PToVendor;
			AmountType _POutCheckAmt = POutCheckAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtCalcCheckAmountSp";
				
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInCheckAmt", _PInCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendCurr", _PVendCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToVendor", _PToVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POutCheckAmt", _POutCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POutCheckAmt = _POutCheckAmt;
				Infobar = _Infobar;
				
				return (Severity, POutCheckAmt, Infobar);
			}
		}
	}
}
