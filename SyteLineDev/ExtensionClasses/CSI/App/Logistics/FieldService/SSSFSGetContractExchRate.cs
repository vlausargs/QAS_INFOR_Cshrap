//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetContractExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetContractExchRate : ISSSFSGetContractExchRate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetContractExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PExchRate,
			decimal? Result,
			string Infobar) SSSFSGetContractExchRateSp(
			string InContractNum,
			string PCustCurrCode,
			int? PTransDom,
			int? PUseBuyRate,
			int? PUseRoundFactor,
			DateTime? PDate,
			decimal? PExchRate,
			decimal? Amount,
			decimal? Result,
			string Infobar)
		{
			FSContractType _InContractNum = InContractNum;
			CurrCodeType _PCustCurrCode = PCustCurrCode;
			FlagNyType _PTransDom = PTransDom;
			FlagNyType _PUseBuyRate = PUseBuyRate;
			FlagNyType _PUseRoundFactor = PUseRoundFactor;
			CurrentDateType _PDate = PDate;
			ExchRateType _PExchRate = PExchRate;
			AmountType _Amount = Amount;
			AmountType _Result = Result;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetContractExchRateSp";
				
				appDB.AddCommandParameter(cmd, "InContractNum", _InContractNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustCurrCode", _PCustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDom", _PTransDom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseBuyRate", _PUseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseRoundFactor", _PUseRoundFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result", _Result, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PExchRate = _PExchRate;
				Result = _Result;
				Infobar = _Infobar;
				
				return (Severity, PExchRate, Result, Infobar);
			}
		}
	}
}
