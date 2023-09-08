//PROJECT NAME: CSIVendor
//CLASS NAME: PostRemPopulateTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPostRemPopulateTT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PostRemPopulateTTSP(Guid? PSessionID,
		string PBankCode,
		string PStartingVendNum,
		string PEndingVendNum,
		int? PStartingDraftNum,
		int? PEndingDraftNum,
		DateTime? PStartingDueDate,
		DateTime? PEndingDueDate,
		string PRemittanceOption = null);
	}
	
	public class PostRemPopulateTT : IPostRemPopulateTT
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PostRemPopulateTT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) PostRemPopulateTTSP(Guid? PSessionID,
		string PBankCode,
		string PStartingVendNum,
		string PEndingVendNum,
		int? PStartingDraftNum,
		int? PEndingDraftNum,
		DateTime? PStartingDueDate,
		DateTime? PEndingDueDate,
		string PRemittanceOption = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				RowPointer _PSessionID = PSessionID;
				BankCodeType _PBankCode = PBankCode;
				VendNumType _PStartingVendNum = PStartingVendNum;
				VendNumType _PEndingVendNum = PEndingVendNum;
				DraftNumType _PStartingDraftNum = PStartingDraftNum;
				DraftNumType _PEndingDraftNum = PEndingDraftNum;
				DateType _PStartingDueDate = PStartingDueDate;
				DateType _PEndingDueDate = PEndingDueDate;
				ApdrafttStatusType _PRemittanceOption = PRemittanceOption;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "PostRemPopulateTTSP";
					
					appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingDraftNum", _PStartingDraftNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingDraftNum", _PEndingDraftNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingDueDate", _PStartingDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingDueDate", _PEndingDueDate, ParameterDirection.Input);
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
