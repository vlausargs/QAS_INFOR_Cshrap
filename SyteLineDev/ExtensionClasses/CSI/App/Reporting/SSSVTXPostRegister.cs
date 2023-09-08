//PROJECT NAME: Reporting
//CLASS NAME: SSSVTXPostRegister.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSVTXPostRegister : ISSSVTXPostRegister
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSVTXPostRegister(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSVTXPostRegisterSp(string FormCaption,
		int? BGTaskID,
		DateTime? StartingInvDate,
		DateTime? EndingInvDate,
		int? StartINV_dateOffSET = null,
		int? ENDINV_dateOffSET = null,
		string pSite = null)
		{
			LongListType _FormCaption = FormCaption;
			GenericNoType _BGTaskID = BGTaskID;
			DateType _StartingInvDate = StartingInvDate;
			DateType _EndingInvDate = EndingInvDate;
			DateOffsetType _StartINV_dateOffSET = StartINV_dateOffSET;
			DateOffsetType _ENDINV_dateOffSET = ENDINV_dateOffSET;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXPostRegisterSp";
				
				appDB.AddCommandParameter(cmd, "FormCaption", _FormCaption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGTaskID", _BGTaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvDate", _StartingInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvDate", _EndingInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartINV_dateOffSET", _StartINV_dateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ENDINV_dateOffSET", _ENDINV_dateOffSET, ParameterDirection.Input);
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
