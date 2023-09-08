//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_RentalContractAgreement.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_RentalContractAgreement : ISSSFSRpt_RentalContractAgreement
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_RentalContractAgreement(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_RentalContractAgreementSp(string ContractStarting = null,
		string ContractEnding = null,
		string CustNumStarting = null,
		string CustNumEnding = null,
		int? DispContractNotes = 1,
		int? DispLineNotes = 1,
		int? ShowInternal = 0,
		int? ShowExternal = 1,
		int? DispLineDetail = 1,
		int? DispLineSurcharge = 1,
		int? DispContractWaiver = 1,
		int? DispContractPricing = 0,
		string pSite = null)
		{
			FSContractType _ContractStarting = ContractStarting;
			FSContractType _ContractEnding = ContractEnding;
			CustNumType _CustNumStarting = CustNumStarting;
			CustNumType _CustNumEnding = CustNumEnding;
			FlagNyType _DispContractNotes = DispContractNotes;
			FlagNyType _DispLineNotes = DispLineNotes;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _DispLineDetail = DispLineDetail;
			FlagNyType _DispLineSurcharge = DispLineSurcharge;
			FlagNyType _DispContractWaiver = DispContractWaiver;
			FlagNyType _DispContractPricing = DispContractPricing;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_RentalContractAgreementSp";
				
				appDB.AddCommandParameter(cmd, "ContractStarting", _ContractStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContractEnding", _ContractEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumStarting", _CustNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumEnding", _CustNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispContractNotes", _DispContractNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispLineNotes", _DispLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispLineDetail", _DispLineDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispLineSurcharge", _DispLineSurcharge, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispContractWaiver", _DispContractWaiver, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispContractPricing", _DispContractPricing, ParameterDirection.Input);
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
