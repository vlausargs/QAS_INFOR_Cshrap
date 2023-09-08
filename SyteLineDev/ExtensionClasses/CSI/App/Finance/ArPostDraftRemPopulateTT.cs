//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostDraftRemPopulateTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IArPostDraftRemPopulateTT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ArPostDraftRemPopulateTTSP(Guid? PSessionID,
		string PStartingBankCode,
		string PEndingBankCode,
		int? PStartDraftNum,
		int? PEndDraftNum,
		string PRemittanceOption = null);
	}
	
	public class ArPostDraftRemPopulateTT : IArPostDraftRemPopulateTT
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ArPostDraftRemPopulateTT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ArPostDraftRemPopulateTTSP(Guid? PSessionID,
		string PStartingBankCode,
		string PEndingBankCode,
		int? PStartDraftNum,
		int? PEndDraftNum,
		string PRemittanceOption = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				RowPointerType _PSessionID = PSessionID;
				BankCodeType _PStartingBankCode = PStartingBankCode;
				BankCodeType _PEndingBankCode = PEndingBankCode;
				DraftNumType _PStartDraftNum = PStartDraftNum;
				DraftNumType _PEndDraftNum = PEndDraftNum;
				CustdrftStatusType _PRemittanceOption = PRemittanceOption;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ArPostDraftRemPopulateTTSP";
					
					appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingBankCode", _PStartingBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingBankCode", _PEndingBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartDraftNum", _PStartDraftNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndDraftNum", _PEndDraftNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PRemittanceOption", _PRemittanceOption, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
