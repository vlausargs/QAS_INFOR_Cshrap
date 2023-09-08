//PROJECT NAME: Data
//CLASS NAME: THAptcpost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAptcpost : ITHAptcpost
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THAptcpost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THAptcpostSp(
			string PSessionID = null,
			string PSBankCode = null,
			string PEBankCode = null,
			string PStartingVendNum = null,
			string PEndingVendNum = null,
			int? PStartingCheckNum = null,
			int? PEndingCheckNum = null,
			DateTime? PStartingCheckDate = null,
			DateTime? PEndingCheckDate = null)
		{
			StringType _PSessionID = PSessionID;
			BankCodeType _PSBankCode = PSBankCode;
			BankCodeType _PEBankCode = PEBankCode;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			ApCheckNumType _PStartingCheckNum = PStartingCheckNum;
			ApCheckNumType _PEndingCheckNum = PEndingCheckNum;
			DateType _PStartingCheckDate = PStartingCheckDate;
			DateType _PEndingCheckDate = PEndingCheckDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAptcpostSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSBankCode", _PSBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEBankCode", _PEBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCheckNum", _PStartingCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCheckNum", _PEndingCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCheckDate", _PStartingCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCheckDate", _PEndingCheckDate, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
