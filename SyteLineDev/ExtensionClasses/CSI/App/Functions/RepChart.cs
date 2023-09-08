//PROJECT NAME: Data
//CLASS NAME: RepChart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepChart : IRepChart
	{
		readonly IApplicationDB appDB;
		
		public RepChart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RepChartSp(
			string pDestSite,
			string pAcct,
			int? pOverwriteExistingRecords = 0,
			int? pCopyReportsToAcct = 0,
			int? pCopyNotes = 0,
			string pDescription = null,
			string pType = null,
			DateTime? pEffDate = null,
			DateTime? pObsDate = null,
			string pAccessUnit1 = null,
			string pAccessUnit2 = null,
			string pAccessUnit3 = null,
			string pAccessUnit4 = null,
			string pTransMethod = null,
			int? pUseBuyRate = null,
			string pReportsToAcct = null,
			string pAcctClass = null,
			string Infobar = null,
			int? pIsControl = 0)
		{
			SiteType _pDestSite = pDestSite;
			AcctType _pAcct = pAcct;
			Flag _pOverwriteExistingRecords = pOverwriteExistingRecords;
			Flag _pCopyReportsToAcct = pCopyReportsToAcct;
			Flag _pCopyNotes = pCopyNotes;
			DescriptionType _pDescription = pDescription;
			ChartTypeType _pType = pType;
			DateType _pEffDate = pEffDate;
			DateType _pObsDate = pObsDate;
			UnitCodeAccessType _pAccessUnit1 = pAccessUnit1;
			UnitCodeAccessType _pAccessUnit2 = pAccessUnit2;
			UnitCodeAccessType _pAccessUnit3 = pAccessUnit3;
			UnitCodeAccessType _pAccessUnit4 = pAccessUnit4;
			CurrTransMethodType _pTransMethod = pTransMethod;
			ListBuySellType _pUseBuyRate = pUseBuyRate;
			AcctType _pReportsToAcct = pReportsToAcct;
			AcctClassType _pAcctClass = pAcctClass;
			InfobarType _Infobar = Infobar;
			ListYesNoType _pIsControl = pIsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepChartSp";
				
				appDB.AddCommandParameter(cmd, "pDestSite", _pDestSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcct", _pAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOverwriteExistingRecords", _pOverwriteExistingRecords, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCopyReportsToAcct", _pCopyReportsToAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCopyNotes", _pCopyNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDescription", _pDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pType", _pType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEffDate", _pEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pObsDate", _pObsDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAccessUnit1", _pAccessUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAccessUnit2", _pAccessUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAccessUnit3", _pAccessUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAccessUnit4", _pAccessUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransMethod", _pTransMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseBuyRate", _pUseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReportsToAcct", _pReportsToAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctClass", _pAcctClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pIsControl", _pIsControl, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
