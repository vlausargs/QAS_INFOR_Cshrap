//PROJECT NAME: Finance
//CLASS NAME: FRCLM_FecExport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FRCLM_FecExport : IFRCLM_FecExport
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public FRCLM_FecExport(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) FRCLM_FecExportSp(int? PYear,
		int? PPeriod,
		string PSAcct,
		string PEAcct)
		{
			FiscalYearType _PYear = PYear;
			FinPeriodType _PPeriod = PPeriod;
			AcctType _PSAcct = PSAcct;
			AcctType _PEAcct = PEAcct;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FRCLM_FecExportSp";
				
				appDB.AddCommandParameter(cmd, "PYear", _PYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPeriod", _PPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcct", _PSAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcct", _PEAcct, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
