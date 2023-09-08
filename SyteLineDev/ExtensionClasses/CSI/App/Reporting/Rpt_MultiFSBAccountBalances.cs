//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBAccountBalances.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBAccountBalances : IRpt_MultiFSBAccountBalances
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MultiFSBAccountBalances(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBAccountBalancesSp(DateTime? ExOptacAsOfDate = null,
		string ExStartingAccount = null,
		string ExEndingAccount = null,
		int? PUnitCode1 = 0,
		int? PUnitCode2 = 0,
		int? PUnitCode3 = 0,
		int? PUnitCode4 = 0,
		string UnitCode1Starting = null,
		string UnitCode1Ending = null,
		string UnitCode2Starting = null,
		string UnitCode2Ending = null,
		string UnitCode3Starting = null,
		string UnitCode3Ending = null,
		string UnitCode4Starting = null,
		string UnitCode4Ending = null,
		string ExOptacChartType = null,
		int? DateOffset = null,
		int? DisplayHeader = null,
		string FSBName = null,
		string pSite = null)
		{
			DateType _ExOptacAsOfDate = ExOptacAsOfDate;
			AcctType _ExStartingAccount = ExStartingAccount;
			AcctType _ExEndingAccount = ExEndingAccount;
			ListYesNoType _PUnitCode1 = PUnitCode1;
			ListYesNoType _PUnitCode2 = PUnitCode2;
			ListYesNoType _PUnitCode3 = PUnitCode3;
			ListYesNoType _PUnitCode4 = PUnitCode4;
			UnitCode1Type _UnitCode1Starting = UnitCode1Starting;
			UnitCode1Type _UnitCode1Ending = UnitCode1Ending;
			UnitCode2Type _UnitCode2Starting = UnitCode2Starting;
			UnitCode2Type _UnitCode2Ending = UnitCode2Ending;
			UnitCode3Type _UnitCode3Starting = UnitCode3Starting;
			UnitCode3Type _UnitCode3Ending = UnitCode3Ending;
			UnitCode4Type _UnitCode4Starting = UnitCode4Starting;
			UnitCode4Type _UnitCode4Ending = UnitCode4Ending;
			InfobarType _ExOptacChartType = ExOptacChartType;
			DateOffsetType _DateOffset = DateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			FSBNameType _FSBName = FSBName;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MultiFSBAccountBalancesSp";
				
				appDB.AddCommandParameter(cmd, "ExOptacAsOfDate", _ExOptacAsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExStartingAccount", _ExStartingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndingAccount", _ExEndingAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode1", _PUnitCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode2", _PUnitCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode3", _PUnitCode3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCode4", _PUnitCode4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode1Starting", _UnitCode1Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode1Ending", _UnitCode1Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode2Starting", _UnitCode2Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode2Ending", _UnitCode2Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode3Starting", _UnitCode3Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode3Ending", _UnitCode3Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode4Starting", _UnitCode4Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode4Ending", _UnitCode4Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacChartType", _ExOptacChartType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateOffset", _DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
