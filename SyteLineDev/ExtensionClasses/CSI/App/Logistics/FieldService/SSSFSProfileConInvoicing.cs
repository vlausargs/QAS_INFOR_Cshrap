//PROJECT NAME: Logistics
//CLASS NAME: SSSFSProfileConInvoicing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSProfileConInvoicing : ISSSFSProfileConInvoicing
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSProfileConInvoicing(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSProfileConInvoicingSp(string StartInvNum = null,
		string EndInvNum = null,
		string StartContNum = null,
		string EndContNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartCustNum = null,
		string EndCustNum = null)
		{
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			FSContractType _StartContNum = StartContNum;
			FSContractType _EndContNum = EndContNum;
			DateType _StartInvDate = StartInvDate;
			DateType _EndInvDate = EndInvDate;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSProfileConInvoicingSp";
				
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartContNum", _StartContNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndContNum", _EndContNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
