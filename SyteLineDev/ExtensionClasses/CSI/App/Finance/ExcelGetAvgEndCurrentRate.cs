//PROJECT NAME: Finance
//CLASS NAME: ExcelGetAvgEndCurrentRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IExcelGetAvgEndCurrentRate
	{
		(int? ReturnCode, decimal? PAvgRate,
		decimal? PEndRate,
		decimal? PCurrentRate,
		string Infobar) ExcelGetAvgEndCurrentRateSp(string PSite,
		string PFromCurrCode,
		string PToCurrCode = null,
		byte? PUseBuyRate = (byte)1,
		DateTime? PStartDate = null,
		DateTime? PEndDate = null,
		decimal? PAvgRate = null,
		decimal? PEndRate = null,
		decimal? PCurrentRate = null,
		string Infobar = null);
	}
	
	public class ExcelGetAvgEndCurrentRate : IExcelGetAvgEndCurrentRate
	{
		readonly IApplicationDB appDB;
		
		public ExcelGetAvgEndCurrentRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PAvgRate,
		decimal? PEndRate,
		decimal? PCurrentRate,
		string Infobar) ExcelGetAvgEndCurrentRateSp(string PSite,
		string PFromCurrCode,
		string PToCurrCode = null,
		byte? PUseBuyRate = (byte)1,
		DateTime? PStartDate = null,
		DateTime? PEndDate = null,
		decimal? PAvgRate = null,
		decimal? PEndRate = null,
		decimal? PCurrentRate = null,
		string Infobar = null)
		{
			SiteType _PSite = PSite;
			CurrCodeType _PFromCurrCode = PFromCurrCode;
			CurrCodeType _PToCurrCode = PToCurrCode;
			ListBuySellType _PUseBuyRate = PUseBuyRate;
			CurrentDateType _PStartDate = PStartDate;
			CurrentDateType _PEndDate = PEndDate;
			ExchRateType _PAvgRate = PAvgRate;
			ExchRateType _PEndRate = PEndRate;
			ExchRateType _PCurrentRate = PCurrentRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExcelGetAvgEndCurrentRateSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCurrCode", _PFromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCurrCode", _PToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseBuyRate", _PUseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAvgRate", _PAvgRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate", _PEndRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurrentRate", _PCurrentRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAvgRate = _PAvgRate;
				PEndRate = _PEndRate;
				PCurrentRate = _PCurrentRate;
				Infobar = _Infobar;
				
				return (Severity, PAvgRate, PEndRate, PCurrentRate, Infobar);
			}
		}
	}
}
