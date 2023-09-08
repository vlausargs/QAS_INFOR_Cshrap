//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRPT_ContractRenewalListing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRPT_ContractRenewalListing : ISSSFSRPT_ContractRenewalListing
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRPT_ContractRenewalListing(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRPT_ContractRenewalListingSp(string StartingContract,
		string EndingContract,
		string StartingCustomer,
		string EndingCustomer,
		string StartingItem,
		string EndingItem,
		int? t_Period,
		int? t_Year,
		string pSite = null,
		string BillingFrequencies = null,
		int? DaysLookAhead = 0)
		{
			FSContractType _StartingContract = StartingContract;
			FSContractType _EndingContract = EndingContract;
			CustNumType _StartingCustomer = StartingCustomer;
			CustNumType _EndingCustomer = EndingCustomer;
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			ShortType _t_Period = t_Period;
			ShortType _t_Year = t_Year;
			SiteType _pSite = pSite;
			StringType _BillingFrequencies = BillingFrequencies;
			IntType _DaysLookAhead = DaysLookAhead;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRPT_ContractRenewalListingSp";
				
				appDB.AddCommandParameter(cmd, "StartingContract", _StartingContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingContract", _EndingContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCustomer", _StartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustomer", _EndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_Period", _t_Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_Year", _t_Year, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillingFrequencies", _BillingFrequencies, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysLookAhead", _DaysLookAhead, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
