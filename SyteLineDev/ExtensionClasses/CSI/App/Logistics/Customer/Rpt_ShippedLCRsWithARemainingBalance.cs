//PROJECT NAME: Logistics
//CLASS NAME: Rpt_ShippedLCRsWithARemainingBalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class Rpt_ShippedLCRsWithARemainingBalance : IRpt_ShippedLCRsWithARemainingBalance
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ShippedLCRsWithARemainingBalance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ShippedLCRsWithARemainingBalanceSp(string PCustomerStarting,
		string PCustomerEnding,
		string PLCRStarting,
		string PLCREnding,
		DateTime? PIssueDateStarting,
		DateTime? PIssueDateEnding,
		DateTime? PExpireDateStarting,
		DateTime? PExpireDateEnding,
		string PCurrency,
		string PSite = null)
		{
			CustNumType _PCustomerStarting = PCustomerStarting;
			CustNumType _PCustomerEnding = PCustomerEnding;
			LcrNumType _PLCRStarting = PLCRStarting;
			LcrNumType _PLCREnding = PLCREnding;
			DateType _PIssueDateStarting = PIssueDateStarting;
			DateType _PIssueDateEnding = PIssueDateEnding;
			DateType _PExpireDateStarting = PExpireDateStarting;
			DateType _PExpireDateEnding = PExpireDateEnding;
			CurrCodeType _PCurrency = PCurrency;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ShippedLCRsWithARemainingBalanceSp";
				
				appDB.AddCommandParameter(cmd, "PCustomerStarting", _PCustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustomerEnding", _PCustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLCRStarting", _PLCRStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLCREnding", _PLCREnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIssueDateStarting", _PIssueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIssueDateEnding", _PIssueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExpireDateStarting", _PExpireDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExpireDateEnding", _PExpireDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrency", _PCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
