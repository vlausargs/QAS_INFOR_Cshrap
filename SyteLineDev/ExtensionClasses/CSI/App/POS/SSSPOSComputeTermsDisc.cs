//PROJECT NAME: POS
//CLASS NAME: SSSPOSComputeTermsDisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSComputeTermsDisc : ISSSPOSComputeTermsDisc
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSComputeTermsDisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? DiscAmt,
			string Infobar) SSSPOSComputeTermsDiscSp(
			string POSMNum,
			decimal? Amount,
			int? CurrencyPlaces,
			decimal? DiscAmt,
			string Infobar)
		{
			POSMNumType _POSMNum = POSMNum;
			AmountType _Amount = Amount;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			AmountType _DiscAmt = DiscAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSComputeTermsDiscSp";
				
				appDB.AddCommandParameter(cmd, "POSMNum", _POSMNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAmt", _DiscAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DiscAmt = _DiscAmt;
				Infobar = _Infobar;
				
				return (Severity, DiscAmt, Infobar);
			}
		}
	}
}
