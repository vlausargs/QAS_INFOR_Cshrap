//PROJECT NAME: Reporting
//CLASS NAME: LedgerConsolCtaAdj.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class LedgerConsolCtaAdj : ILedgerConsolCtaAdj
	{
		readonly IApplicationDB appDB;
		
		public LedgerConsolCtaAdj(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LedgerConsolCtaAdjSp(
			DateTime? pCurrentDate,
			DateTime? pFiscalYearEnd,
			string pFromSite,
			string ParmsSite,
			string pHierarchy,
			string CurrparmsCurrCode,
			Guid? SessionID,
			string Infobar,
			string CTARef,
			int? HierarchyConnected)
		{
			DateType _pCurrentDate = pCurrentDate;
			DateType _pFiscalYearEnd = pFiscalYearEnd;
			SiteType _pFromSite = pFromSite;
			SiteType _ParmsSite = ParmsSite;
			HierarchyType _pHierarchy = pHierarchy;
			CurrCodeType _CurrparmsCurrCode = CurrparmsCurrCode;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			ReferenceType _CTARef = CTARef;
			ListYesNoType _HierarchyConnected = HierarchyConnected;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LedgerConsolCtaAdjSp";
				
				appDB.AddCommandParameter(cmd, "pCurrentDate", _pCurrentDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFiscalYearEnd", _pFiscalYearEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromSite", _pFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHierarchy", _pHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrparmsCurrCode", _CurrparmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CTARef", _CTARef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HierarchyConnected", _HierarchyConnected, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
