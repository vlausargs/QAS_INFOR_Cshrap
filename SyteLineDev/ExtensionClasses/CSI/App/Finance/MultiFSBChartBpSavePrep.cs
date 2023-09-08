//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBChartBpSavePrep.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBChartBpSavePrep
	{
		(int? ReturnCode, string Infobar) MultiFSBChartBpSavePrepSp(byte? PNewRecord,
		string pChartBpAcct,
		string pChartBpAcctUnit1,
		string pChartBpAcctUnit2,
		string pChartBpAcctUnit3,
		string pChartBpAcctUnit4,
		short? pChartBpFiscalYear,
		string Infobar,
		string FSBName = null);
	}
	
	public class MultiFSBChartBpSavePrep : IMultiFSBChartBpSavePrep
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBChartBpSavePrep(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MultiFSBChartBpSavePrepSp(byte? PNewRecord,
		string pChartBpAcct,
		string pChartBpAcctUnit1,
		string pChartBpAcctUnit2,
		string pChartBpAcctUnit3,
		string pChartBpAcctUnit4,
		short? pChartBpFiscalYear,
		string Infobar,
		string FSBName = null)
		{
			FlagNyType _PNewRecord = PNewRecord;
			AcctType _pChartBpAcct = pChartBpAcct;
			UnitCode1Type _pChartBpAcctUnit1 = pChartBpAcctUnit1;
			UnitCode2Type _pChartBpAcctUnit2 = pChartBpAcctUnit2;
			UnitCode3Type _pChartBpAcctUnit3 = pChartBpAcctUnit3;
			UnitCode4Type _pChartBpAcctUnit4 = pChartBpAcctUnit4;
			FiscalYearType _pChartBpFiscalYear = pChartBpFiscalYear;
			InfobarType _Infobar = Infobar;
			FSBNameType _FSBName = FSBName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBChartBpSavePrepSp";
				
				appDB.AddCommandParameter(cmd, "PNewRecord", _PNewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChartBpAcct", _pChartBpAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChartBpAcctUnit1", _pChartBpAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChartBpAcctUnit2", _pChartBpAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChartBpAcctUnit3", _pChartBpAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChartBpAcctUnit4", _pChartBpAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChartBpFiscalYear", _pChartBpFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
