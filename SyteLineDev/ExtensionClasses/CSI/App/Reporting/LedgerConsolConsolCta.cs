//PROJECT NAME: Reporting
//CLASS NAME: LedgerConsolConsolCta.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class LedgerConsolConsolCta : ILedgerConsolConsolCta
	{
		readonly IApplicationDB appDB;
		
		public LedgerConsolConsolCta(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LedgerConsolConsolCtaSp(
			DateTime? pCurrentDate,
			DateTime? pFiscalYearStart,
			DateTime? pFiscalYearEnd,
			decimal? pAmount,
			string pFromSite,
			string pSiteName,
			string pHierarchy,
			string Infobar,
			DateTime? pYearStart)
		{
			DateType _pCurrentDate = pCurrentDate;
			DateType _pFiscalYearStart = pFiscalYearStart;
			DateType _pFiscalYearEnd = pFiscalYearEnd;
			AmountType _pAmount = pAmount;
			SiteType _pFromSite = pFromSite;
			NameType _pSiteName = pSiteName;
			HierarchyType _pHierarchy = pHierarchy;
			InfobarType _Infobar = Infobar;
			DateType _pYearStart = pYearStart;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LedgerConsolConsolCtaSp";
				
				appDB.AddCommandParameter(cmd, "pCurrentDate", _pCurrentDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFiscalYearStart", _pFiscalYearStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFiscalYearEnd", _pFiscalYearEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAmount", _pAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromSite", _pFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSiteName", _pSiteName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHierarchy", _pHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pYearStart", _pYearStart, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
