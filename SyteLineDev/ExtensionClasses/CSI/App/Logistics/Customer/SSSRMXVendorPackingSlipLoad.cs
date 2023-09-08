//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXVendorPackingSlipLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXVendorPackingSlipLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRMXVendorPackingSlipLoadSp(string TPckCall,
		                                                                              string RefType,
		                                                                              string VendNum,
		                                                                              string RefNum,
		                                                                              string Whse);
	}
	
	public class SSSRMXVendorPackingSlipLoad : ISSSRMXVendorPackingSlipLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRMXVendorPackingSlipLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSRMXVendorPackingSlipLoadSp(string TPckCall,
		                                                                                     string RefType,
		                                                                                     string VendNum,
		                                                                                     string RefNum,
		                                                                                     string Whse)
		{
			StringType _TPckCall = TPckCall;
			RMXRefTypeType _RefType = RefType;
			VendNumType _VendNum = VendNum;
			RMXRefNumType _RefNum = RefNum;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXVendorPackingSlipLoadSp";
				
				appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
