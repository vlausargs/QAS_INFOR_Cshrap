//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_ItemWhereUsedReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_ItemWhereUsedReport : ISSSFSRpt_ItemWhereUsedReport
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_ItemWhereUsedReport(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_ItemWhereUsedReportSp(string pItem,
		string pSerNum,
		string pRevision,
		string pMfgNum,
		string pCustomerConsumer,
		string pSite = null)
		{
			ItemType _pItem = pItem;
			SerNumType _pSerNum = pSerNum;
			RevisionType _pRevision = pRevision;
			FSUnitMfgType _pMfgNum = pMfgNum;
			StringType _pCustomerConsumer = pCustomerConsumer;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_ItemWhereUsedReportSp";
				
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSerNum", _pSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRevision", _pRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMfgNum", _pMfgNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustomerConsumer", _pCustomerConsumer, ParameterDirection.Input);
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
