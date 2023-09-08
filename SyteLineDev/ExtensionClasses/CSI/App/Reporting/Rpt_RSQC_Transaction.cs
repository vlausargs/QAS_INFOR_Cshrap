//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_Transaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_Transaction : IRpt_RSQC_Transaction
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_Transaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_TransactionSp(
			DateTime? begtdate = null,
			DateTime? endtdate = null,
			string begdcode = null,
			string enddcode = null,
			string begitem = null,
			string enditem = null,
			string beginsp = null,
			string endinsp = null,
			string beguser = null,
			string enduser = null,
			string reftype = null,
			string status = null,
			int? openonly = null,
			string begentity = null,
			string endentity = null,
			int? displayheader = null)
		{
			DateType _begtdate = begtdate;
			DateType _endtdate = endtdate;
			QCCodeType _begdcode = begdcode;
			QCCodeType _enddcode = enddcode;
			ItemType _begitem = begitem;
			ItemType _enditem = enditem;
			EmpNumType _beginsp = beginsp;
			EmpNumType _endinsp = endinsp;
			UserCodeType _beguser = beguser;
			UserCodeType _enduser = enduser;
			StringType _reftype = reftype;
			StringType _status = status;
			ListYesNoType _openonly = openonly;
			QCDocNumType _begentity = begentity;
			QCDocNumType _endentity = endentity;
			ListYesNoType _displayheader = displayheader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_TransactionSp";
				
				appDB.AddCommandParameter(cmd, "begtdate", _begtdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endtdate", _endtdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begdcode", _begdcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "enddcode", _enddcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begitem", _begitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "enditem", _enditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beginsp", _beginsp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endinsp", _endinsp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beguser", _beguser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "enduser", _enduser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "reftype", _reftype, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "status", _status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "openonly", _openonly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begentity", _begentity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endentity", _endentity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "displayheader", _displayheader, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
