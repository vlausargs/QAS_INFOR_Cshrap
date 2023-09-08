//PROJECT NAME: Logistics
//CLASS NAME: THAGetTaxData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class THAGetTaxData : ITHAGetTaxData
	{
		readonly IApplicationDB appDB;
		
		
		public THAGetTaxData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TaxAmount,
		string Infobar) THAGetTaxDataSp(string TaxCode,
		decimal? ForAmtPaid,
		string CurrCode,
		decimal? TaxAmount,
		string Infobar)
		{
			TaxCodeType _TaxCode = TaxCode;
			AmountType _ForAmtPaid = ForAmtPaid;
			CurrCodeType _CurrCode = CurrCode;
			AmountType _TaxAmount = TaxAmount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAGetTaxDataSp";
				
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmtPaid", _ForAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxAmount", _TaxAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxAmount = _TaxAmount;
				Infobar = _Infobar;
				
				return (Severity, TaxAmount, Infobar);
			}
		}
	}
}
