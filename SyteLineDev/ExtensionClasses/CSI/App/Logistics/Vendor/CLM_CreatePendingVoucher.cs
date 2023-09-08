//PROJECT NAME: Logistics
//CLASS NAME: CLM_CreatePendingVoucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_CreatePendingVoucher : ICLM_CreatePendingVoucher
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_CreatePendingVoucher(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_CreatePendingVoucherSp(Guid? PProcessID,
		string PVendNum,
		string PVoucherType,
		string PSite,
		int? PVoucher,
		string FilterString = null,
		string PoCurrCode = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				RowPointerType _PProcessID = PProcessID;
				VendNumType _PVendNum = PVendNum;
				AptrxpTypeType _PVoucherType = PVoucherType;
				SiteType _PSite = PSite;
				VoucherType _PVoucher = PVoucher;
				LongListType _FilterString = FilterString;
				CurrCodeType _PoCurrCode = PoCurrCode;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_CreatePendingVoucherSp";
					
					appDB.AddCommandParameter(cmd, "PProcessID", _PProcessID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PVoucherType", _PVoucherType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PoCurrCode", _PoCurrCode, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
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
