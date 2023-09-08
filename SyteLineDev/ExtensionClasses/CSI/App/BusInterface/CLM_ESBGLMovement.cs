//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBGLMovement.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CLM_ESBGLMovement : ICLM_ESBGLMovement
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ESBGLMovement(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBGLMovementSp(string GLNomAcctName,
		string ChartType,
		int? FiscalYear,
		int? Period,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		int? Actual,
		string ActionCode)
		{
			DescriptionType _GLNomAcctName = GLNomAcctName;
			ChartTypeType _ChartType = ChartType;
			FiscalYearType _FiscalYear = FiscalYear;
			IntType _Period = Period;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			IntType _Actual = Actual;
			StringType _ActionCode = ActionCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ESBGLMovementSp";
				
				appDB.AddCommandParameter(cmd, "GLNomAcctName", _GLNomAcctName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartType", _ChartType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Actual", _Actual, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionCode", _ActionCode, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
