//PROJECT NAME: Logistics
//CLASS NAME: PmtpckSetForDomAmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PmtpckSetForDomAmts : IPmtpckSetForDomAmts
	{
		readonly IApplicationDB appDB;
		
		
		public PmtpckSetForDomAmts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PDomAmt,
		decimal? PForAmt,
		string Infobar) PmtpckSetForDomAmtsSp(string PTransactionCurrCode,
		decimal? PAmt,
		int? PFixedRate,
		decimal? PExchRate,
		DateTime? PRecptDate,
		decimal? PDomAmt,
		decimal? PForAmt,
		string Infobar,
		int? PDomPmt)
		{
			CurrCodeType _PTransactionCurrCode = PTransactionCurrCode;
			AmountType _PAmt = PAmt;
			FlagNyType _PFixedRate = PFixedRate;
			ExchRateType _PExchRate = PExchRate;
			DateType _PRecptDate = PRecptDate;
			AmountType _PDomAmt = PDomAmt;
			AmountType _PForAmt = PForAmt;
			Infobar _Infobar = Infobar;
			ListYesNoType _PDomPmt = PDomPmt;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmtpckSetForDomAmtsSp";
				
				appDB.AddCommandParameter(cmd, "PTransactionCurrCode", _PTransactionCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmt", _PAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFixedRate", _PFixedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmt", _PDomAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForAmt", _PForAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomPmt", _PDomPmt, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDomAmt = _PDomAmt;
				PForAmt = _PForAmt;
				Infobar = _Infobar;
				
				return (Severity, PDomAmt, PForAmt, Infobar);
			}
		}
	}
}
