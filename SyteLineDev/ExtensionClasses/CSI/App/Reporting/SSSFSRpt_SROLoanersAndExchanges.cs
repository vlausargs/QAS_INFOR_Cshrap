//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROLoanersAndExchanges.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROLoanersAndExchanges : ISSSFSRpt_SROLoanersAndExchanges
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROLoanersAndExchanges(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROLoanersAndExchangesSp(string Mode = "LS",
		string BegSroNum = null,
		string EndSroNum = null,
		string BegCustNum = null,
		string EndCustNum = null,
		int? BegSroLine = null,
		int? EndSroLine = null,
		int? BegSroOper = null,
		int? EndSroOper = null,
		string BegItem = null,
		string EndItem = null,
		string BegUnit = null,
		string EndUnit = null,
		string BegBillMgr = null,
		string EndBillMgr = null,
		DateTime? BegStartDate = null,
		DateTime? EndStartDate = null,
		DateTime? BegEndDate = null,
		DateTime? EndEndDate = null,
		DateTime? BegOpenDate = null,
		DateTime? EndOpenDate = null,
		DateTime? BegDueDate = null,
		DateTime? EndDueDate = null,
		string pSite = null)
		{
			StringType _Mode = Mode;
			FSSRONumType _BegSroNum = BegSroNum;
			FSSRONumType _EndSroNum = EndSroNum;
			CustNumType _BegCustNum = BegCustNum;
			CustNumType _EndCustNum = EndCustNum;
			FSSROLineType _BegSroLine = BegSroLine;
			FSSROLineType _EndSroLine = EndSroLine;
			FSSROOperType _BegSroOper = BegSroOper;
			FSSROOperType _EndSroOper = EndSroOper;
			ItemType _BegItem = BegItem;
			ItemType _EndItem = EndItem;
			SerNumType _BegUnit = BegUnit;
			SerNumType _EndUnit = EndUnit;
			FSPartnerType _BegBillMgr = BegBillMgr;
			FSPartnerType _EndBillMgr = EndBillMgr;
			DateType _BegStartDate = BegStartDate;
			DateType _EndStartDate = EndStartDate;
			DateType _BegEndDate = BegEndDate;
			DateType _EndEndDate = EndEndDate;
			DateType _BegOpenDate = BegOpenDate;
			DateType _EndOpenDate = EndOpenDate;
			DateType _BegDueDate = BegDueDate;
			DateType _EndDueDate = EndDueDate;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROLoanersAndExchangesSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegSroNum", _BegSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroNum", _EndSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCustNum", _BegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegSroLine", _BegSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroLine", _EndSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegSroOper", _BegSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroOper", _EndSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegUnit", _BegUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUnit", _EndUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegBillMgr", _BegBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndBillMgr", _EndBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegStartDate", _BegStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndStartDate", _EndStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegEndDate", _BegEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndEndDate", _EndEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegOpenDate", _BegOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOpenDate", _EndOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegDueDate", _BegDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
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
