//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPCostOfQuality.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPCostOfQuality : IRpt_RSQC_IPCostOfQuality
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_IPCostOfQuality(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPCostOfQualitySp(
			string begitem = null,
			string enditem = null,
			DateTime? begddate = null,
			DateTime? endddate = null,
			string begmrr = null,
			string endmrr = null,
			string begcar = null,
			string endcar = null,
			int? displayheader = 0)
		{
			ItemType _begitem = begitem;
			ItemType _enditem = enditem;
			DateType _begddate = begddate;
			DateType _endddate = endddate;
			QCDocNumType _begmrr = begmrr;
			QCDocNumType _endmrr = endmrr;
			QCDocNumType _begcar = begcar;
			QCDocNumType _endcar = endcar;
			ListYesNoType _displayheader = displayheader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_IPCostOfQualitySp";
				
				appDB.AddCommandParameter(cmd, "begitem", _begitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "enditem", _enditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begddate", _begddate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endddate", _endddate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begmrr", _begmrr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endmrr", _endmrr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begcar", _begcar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endcar", _endcar, ParameterDirection.Input);
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
