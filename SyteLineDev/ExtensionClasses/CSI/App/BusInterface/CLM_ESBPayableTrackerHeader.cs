//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPayableTrackerHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CLM_ESBPayableTrackerHeader : ICLM_ESBPayableTrackerHeader
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ESBPayableTrackerHeader(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPayableTrackerHeaderSp(string SupplierPartyID,
		int? Voucher,
		int? Sequence)
		{
			VendNumType _SupplierPartyID = SupplierPartyID;
			VoucherType _Voucher = Voucher;
			VouchSeqType _Sequence = Sequence;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ESBPayableTrackerHeaderSp";
				
				appDB.AddCommandParameter(cmd, "SupplierPartyID", _SupplierPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
