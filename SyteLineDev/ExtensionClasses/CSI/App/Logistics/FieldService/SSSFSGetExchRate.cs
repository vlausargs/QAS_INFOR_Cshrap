//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetExchRate : ISSSFSGetExchRate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PExchRate,
			decimal? Result,
			string Infobar) SSSFSGetExchRateSp(
			string InSRONum,
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
			FSSRONumType _InSRONum = InSRONum;
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
				cmd.CommandText = "SSSFSGetExchRateSp";
				
				appDB.AddCommandParameter(cmd, "InSRONum", _InSRONum, ParameterDirection.Input);
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
