//PROJECT NAME: Logistics
//CLASS NAME: SSSFSProfileSROPrePackSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSProfileSROPrePackSlip : ISSSFSProfileSROPrePackSlip
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSProfileSROPrePackSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSProfileSROPrePackSlipSp(string StartSRONum = null,
		string EndSRONum = null,
		string StartCustNum = null,
		string EndCustNum = null,
		DateTime? StartOpenDate = null,
		DateTime? EndOpenDate = null,
		DateTime? StartTransDate = null,
		DateTime? EndTransDate = null,
		string OrdStat = "OIC")
		{
			FSSRONumType _StartSRONum = StartSRONum;
			FSSRONumType _EndSRONum = EndSRONum;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			DateType _StartOpenDate = StartOpenDate;
			DateType _EndOpenDate = EndOpenDate;
			DateType _StartTransDate = StartTransDate;
			DateType _EndTransDate = EndTransDate;
			GenericCodeType _OrdStat = OrdStat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSProfileSROPrePackSlipSp";
				
				appDB.AddCommandParameter(cmd, "StartSRONum", _StartSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSRONum", _EndSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOpenDate", _StartOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOpenDate", _EndOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTransDate", _StartTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdStat", _OrdStat, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
