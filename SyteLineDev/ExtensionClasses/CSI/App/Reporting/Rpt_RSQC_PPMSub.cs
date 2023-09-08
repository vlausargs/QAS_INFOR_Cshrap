//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_PPMSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_PPMSub : IRpt_RSQC_PPMSub
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_PPMSub(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_PPMSubSp(
			string sortby,
			string begitem,
			string enditem,
			string begvend,
			string endvend,
			DateTime? firstbegdate,
			DateTime? lastenddate,
			DateTime? rptbegdate,
			DateTime? rptenddate)
		{
			StringType _sortby = sortby;
			ItemType _begitem = begitem;
			ItemType _enditem = enditem;
			VendNumType _begvend = begvend;
			VendNumType _endvend = endvend;
			DateType _firstbegdate = firstbegdate;
			DateType _lastenddate = lastenddate;
			DateType _rptbegdate = rptbegdate;
			DateType _rptenddate = rptenddate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_PPMSubSp";
				
				appDB.AddCommandParameter(cmd, "sortby", _sortby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begitem", _begitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "enditem", _enditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begvend", _begvend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endvend", _endvend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "firstbegdate", _firstbegdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "lastenddate", _lastenddate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rptbegdate", _rptbegdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rptenddate", _rptenddate, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
