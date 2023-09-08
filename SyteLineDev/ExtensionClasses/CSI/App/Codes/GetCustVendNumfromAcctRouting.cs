//PROJECT NAME: Codes
//CLASS NAME: GetCustVendNumfromAcctRouting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Codes
{
	public class GetCustVendNumfromAcctRouting : IGetCustVendNumfromAcctRouting
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;


		public GetCustVendNumfromAcctRouting(IApplicationDB appDB,
			IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
			IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) GetCustVendNumfromAcctRoutingSp(string Account,
		string RoutingNumber,
		string InfoBar)
		{
			BankAccountType _Account = Account;
			BankTransitNumType _RoutingNumber = RoutingNumber;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCustVendNumfromAcctRoutingSp";
				
				appDB.AddCommandParameter(cmd, "Account", _Account, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoutingNumber", _RoutingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, InfoBar);
			}
		}

        public ICollectionLoadResponse GetCustVendNumfromAcctRoutingFn(string BankAccount)
        {
			BankAccountType _BankAccount = BankAccount;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select * from dbo.[GetCustVendNumfromAcctRouting](@bankAccount)";

				appDB.AddCommandParameter(cmd, "bankAccount", _BankAccount, ParameterDirection.Input);

				DataTable dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetCustVendNumfromAcctRouting";
				this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
    }
}
