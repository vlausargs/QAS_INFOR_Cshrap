//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSSDLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CLM_ESBSSDLine : ICLM_ESBSSDLine
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ESBSSDLine(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSSDLineSp(string TransIndicator,
		string RefType,
		DateTime? StartPeriod,
		DateTime? EndPeriod,
		string StartCust,
		string EndCust,
		string StartVend,
		string EndVend,
		string StartWhse,
		string EndWhse)
		{
			InfobarType _TransIndicator = TransIndicator;
			InfobarType _RefType = RefType;
			DateType _StartPeriod = StartPeriod;
			DateType _EndPeriod = EndPeriod;
			VendNumType _StartCust = StartCust;
			VendNumType _EndCust = EndCust;
			VendNumType _StartVend = StartVend;
			VendNumType _EndVend = EndVend;
			VendNumType _StartWhse = StartWhse;
			VendNumType _EndWhse = EndWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ESBSSDLineSp";
				
				appDB.AddCommandParameter(cmd, "TransIndicator", _TransIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPeriod", _StartPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCust", _StartCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCust", _EndCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVend", _StartVend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVend", _EndVend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartWhse", _StartWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndWhse", _EndWhse, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
