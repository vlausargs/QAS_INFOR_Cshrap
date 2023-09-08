//PROJECT NAME: Data
//CLASS NAME: AvgRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class AvgRate : IAvgRate
	{
		readonly IApplicationDB appDB;
		
		public AvgRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PAvgRate,
			string Infobar) AvgRateSp(
			string pSite,
			string PCurrCode,
			string PDomCurrCode,
			int? PUseBuyRate,
			DateTime? PStartDate,
			DateTime? PEndDate,
			decimal? PAvgRate,
			string Infobar)
		{
			SiteType _pSite = pSite;
			CurrCodeType _PCurrCode = PCurrCode;
			CurrCodeType _PDomCurrCode = PDomCurrCode;
			ListBuySellType _PUseBuyRate = PUseBuyRate;
			CurrentDateType _PStartDate = PStartDate;
			CurrentDateType _PEndDate = PEndDate;
			ExchRateType _PAvgRate = PAvgRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AvgRateSp";
				
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCurrCode", _PDomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseBuyRate", _PUseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAvgRate", _PAvgRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAvgRate = _PAvgRate;
				Infobar = _Infobar;
				
				return (Severity, PAvgRate, Infobar);
			}
		}
	}
}
