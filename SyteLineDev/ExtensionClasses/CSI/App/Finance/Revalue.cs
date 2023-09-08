//PROJECT NAME: Finance
//CLASS NAME: Revalue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class Revalue : IRevalue
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Revalue(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RevalueSp(int? PPostTransactions,
		string BBankCode,
		string EBankCode,
		decimal? PUserID,
		string UseType = null,
		int? UseCheckNum = null,
		decimal? UseExchangeRate = null)
		{
			ListYesNoType _PPostTransactions = PPostTransactions;
			BankCodeType _BBankCode = BBankCode;
			BankCodeType _EBankCode = EBankCode;
			TokenType _PUserID = PUserID;
			GlbankTypeType _UseType = UseType;
			GlCheckNumType _UseCheckNum = UseCheckNum;
			ExchRateType _UseExchangeRate = UseExchangeRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RevalueSp";
				
				appDB.AddCommandParameter(cmd, "PPostTransactions", _PPostTransactions, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BBankCode", _BBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EBankCode", _EBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUserID", _PUserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseType", _UseType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseCheckNum", _UseCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExchangeRate", _UseExchangeRate, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
