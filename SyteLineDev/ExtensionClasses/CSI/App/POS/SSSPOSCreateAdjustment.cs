//PROJECT NAME: POS
//CLASS NAME: SSSPOSCreateAdjustment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSCreateAdjustment : ISSSPOSCreateAdjustment
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSCreateAdjustment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPOSCreateAdjustmentSp(
			decimal? AdjAmt,
			string PosPayTypeBankCode,
			DateTime? AdjustmentPostingDate,
			string CashDrawer,
			string CurrCode,
			string Infobar)
		{
			AmountType _AdjAmt = AdjAmt;
			BankCodeType _PosPayTypeBankCode = PosPayTypeBankCode;
			DateType _AdjustmentPostingDate = AdjustmentPostingDate;
			POSMDrawerType _CashDrawer = CashDrawer;
			CurrCodeType _CurrCode = CurrCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSCreateAdjustmentSp";
				
				appDB.AddCommandParameter(cmd, "AdjAmt", _AdjAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PosPayTypeBankCode", _PosPayTypeBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjustmentPostingDate", _AdjustmentPostingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CashDrawer", _CashDrawer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
