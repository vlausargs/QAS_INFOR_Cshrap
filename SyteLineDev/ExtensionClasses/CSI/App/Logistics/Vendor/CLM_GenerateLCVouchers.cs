//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_GenerateLCVouchers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_GenerateLCVouchers
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateLCVouchersSp(string VendNum,
		string VendCurrCode,
		DateTime? BeginReceiveDate,
		DateTime? EndReceiveDate,
		string SelectionMethod,
		string LandedCostSelect,
		string FilterString = null);
	}
	
	public class CLM_GenerateLCVouchers : ICLM_GenerateLCVouchers
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GenerateLCVouchers(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateLCVouchersSp(string VendNum,
		string VendCurrCode,
		DateTime? BeginReceiveDate,
		DateTime? EndReceiveDate,
		string SelectionMethod,
		string LandedCostSelect,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				VendNumType _VendNum = VendNum;
				CurrCodeType _VendCurrCode = VendCurrCode;
				DateType _BeginReceiveDate = BeginReceiveDate;
				DateType _EndReceiveDate = EndReceiveDate;
				StringType _SelectionMethod = SelectionMethod;
				StringType _LandedCostSelect = LandedCostSelect;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_GenerateLCVouchersSp";
					
					appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "VendCurrCode", _VendCurrCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BeginReceiveDate", _BeginReceiveDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndReceiveDate", _EndReceiveDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SelectionMethod", _SelectionMethod, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "LandedCostSelect", _LandedCostSelect, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
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
