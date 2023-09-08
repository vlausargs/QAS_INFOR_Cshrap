//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_ContractProfitAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_ContractProfitAnalysis : ISSSFSRpt_ContractProfitAnalysis
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_ContractProfitAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_ContractProfitAnalysisSp(string BegContract = null,
		string EndContract = null,
		string BegCustNum = null,
		string EndCustNum = null,
		DateTime? BegInvoiceDate = null,
		DateTime? EndInvoiceDate = null,
		int? ShowSro = 1,
		string pSite = null)
		{
			FSContractType _BegContract = BegContract;
			FSContractType _EndContract = EndContract;
			CustNumType _BegCustNum = BegCustNum;
			CustNumType _EndCustNum = EndCustNum;
			DateType _BegInvoiceDate = BegInvoiceDate;
			DateType _EndInvoiceDate = EndInvoiceDate;
			ListYesNoType _ShowSro = ShowSro;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_ContractProfitAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "BegContract", _BegContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndContract", _EndContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCustNum", _BegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegInvoiceDate", _BegInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvoiceDate", _EndInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowSro", _ShowSro, ParameterDirection.Input);
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
