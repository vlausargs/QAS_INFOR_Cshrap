//PROJECT NAME: Logistics
//CLASS NAME: CLM_ChangeVendorContractPriceStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_ChangeVendorContractPriceStatus : ICLM_ChangeVendorContractPriceStatus
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ChangeVendorContractPriceStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ChangeVendorContractPriceStatusSp(string Process,
		string StartingVendor,
		string EndingVendor,
		string StartingItem,
		string EndingItem,
		DateTime? StartingDate,
		DateTime? EndingDate,
		int? StartingEffectDateOffset = null,
		int? EndingEffectDateOffset = null,
		string Infobar = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				LongListType _Process = Process;
				VendNumType _StartingVendor = StartingVendor;
				VendNumType _EndingVendor = EndingVendor;
				ItemType _StartingItem = StartingItem;
				ItemType _EndingItem = EndingItem;
				DateType _StartingDate = StartingDate;
				DateType _EndingDate = EndingDate;
				DateOffsetType _StartingEffectDateOffset = StartingEffectDateOffset;
				DateOffsetType _EndingEffectDateOffset = EndingEffectDateOffset;
				InfobarType _Infobar = Infobar;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ChangeVendorContractPriceStatusSp";
					
					appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingDate", _StartingDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingDate", _EndingDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingEffectDateOffset", _StartingEffectDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingEffectDateOffset", _EndingEffectDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
