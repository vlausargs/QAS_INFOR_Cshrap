//PROJECT NAME: Finance
//CLASS NAME: CalcBalBuildRateFile.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class CalcBalBuildRateFile : ICalcBalBuildRateFile
	{
		readonly IApplicationDB appDB;
		
		public CalcBalBuildRateFile(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CalcBalBuildRateFileSp(
			string TMethod,
			DateTime? SDate,
			DateTime? EDate,
			string PCurrCode,
			string PDomCurrCode,
			int? TUse,
			string Infobar,
			string pSite = null)
		{
			CurrTransMethodType _TMethod = TMethod;
			DateType _SDate = SDate;
			DateType _EDate = EDate;
			CurrCodeType _PCurrCode = PCurrCode;
			CurrCodeType _PDomCurrCode = PDomCurrCode;
			ListBuySellType _TUse = TUse;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcBalBuildRateFileSp";
				
				appDB.AddCommandParameter(cmd, "TMethod", _TMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDate", _SDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EDate", _EDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCurrCode", _PDomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUse", _TUse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
