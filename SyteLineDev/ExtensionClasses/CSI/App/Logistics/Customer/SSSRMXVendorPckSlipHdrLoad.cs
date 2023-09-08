//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXVendorPckSlipHdrLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXVendorPckSlipHdrLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRMXVendorPckSlipHdrLoadSp(string TPckCall,
		byte? RefTypeM,
		byte? RefTypeP,
		string BeginVendNum,
		string EndVendNum,
		string BeginRefNum,
		string EndRefNum,
		string Whse,
		string FilterString = null);
	}
	
	public class SSSRMXVendorPckSlipHdrLoad : ISSSRMXVendorPckSlipHdrLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRMXVendorPckSlipHdrLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSRMXVendorPckSlipHdrLoadSp(string TPckCall,
		byte? RefTypeM,
		byte? RefTypeP,
		string BeginVendNum,
		string EndVendNum,
		string BeginRefNum,
		string EndRefNum,
		string Whse,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _TPckCall = TPckCall;
				ListYesNoType _RefTypeM = RefTypeM;
				ListYesNoType _RefTypeP = RefTypeP;
				VendNumType _BeginVendNum = BeginVendNum;
				VendNumType _EndVendNum = EndVendNum;
				RMXRefNumType _BeginRefNum = BeginRefNum;
				RMXRefNumType _EndRefNum = EndRefNum;
				WhseType _Whse = Whse;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSRMXVendorPckSlipHdrLoadSp";
					
					appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefTypeM", _RefTypeM, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefTypeP", _RefTypeP, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BeginVendNum", _BeginVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BeginRefNum", _BeginRefNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndRefNum", _EndRefNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
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
