//PROJECT NAME: Logistics
//CLASS NAME: GetDefaultTaxAdjust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetDefaultTaxAdjust : IGetDefaultTaxAdjust
	{
		readonly IApplicationDB appDB;
		
		
		public GetDefaultTaxAdjust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? DfltTax1Val,
		decimal? DfltTax1Var,
		decimal? DfltTax2Val,
		decimal? DfltTax2Var) GetDefaultTaxAdjustSp(string InvoiceNumber,
		decimal? DisAmt,
		decimal? AllowAmt,
		decimal? DfltTax1Val,
		decimal? DfltTax1Var,
		decimal? DfltTax2Val,
		decimal? DfltTax2Var)
		{
			InvNumType _InvoiceNumber = InvoiceNumber;
			AmountType _DisAmt = DisAmt;
			AmountType _AllowAmt = AllowAmt;
			AmountType _DfltTax1Val = DfltTax1Val;
			AmountType _DfltTax1Var = DfltTax1Var;
			AmountType _DfltTax2Val = DfltTax2Val;
			AmountType _DfltTax2Var = DfltTax2Var;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDefaultTaxAdjustSp";
				
				appDB.AddCommandParameter(cmd, "InvoiceNumber", _InvoiceNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisAmt", _DisAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowAmt", _AllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DfltTax1Val", _DfltTax1Val, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DfltTax1Var", _DfltTax1Var, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DfltTax2Val", _DfltTax2Val, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DfltTax2Var", _DfltTax2Var, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DfltTax1Val = _DfltTax1Val;
				DfltTax1Var = _DfltTax1Var;
				DfltTax2Val = _DfltTax2Val;
				DfltTax2Var = _DfltTax2Var;
				
				return (Severity, DfltTax1Val, DfltTax1Var, DfltTax2Val, DfltTax2Var);
			}
		}
	}
}
