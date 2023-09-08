//PROJECT NAME: Logistics
//CLASS NAME: APVchPostPopulateTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class APVchPostPopulateTT : IAPVchPostPopulateTT
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public APVchPostPopulateTT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) APVchPostPopulateTTSP(Guid? PSessionID,
		string PStartingVendNum,
		string PEndingVendNum,
		int? PStartingVoucherNum,
		int? PEndingVoucherNum,
		DateTime? PStartingDueDate,
		DateTime? PEndingDueDate,
		DateTime? PStartingDistDate,
		DateTime? PEndingDistDate,
		string PAuthStatus,
		string PSortVchVend,
		int? CalledFromBackground = 0)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				RowPointer _PSessionID = PSessionID;
				VendNumType _PStartingVendNum = PStartingVendNum;
				VendNumType _PEndingVendNum = PEndingVendNum;
				VoucherType _PStartingVoucherNum = PStartingVoucherNum;
				VoucherType _PEndingVoucherNum = PEndingVoucherNum;
				DateType _PStartingDueDate = PStartingDueDate;
				DateType _PEndingDueDate = PEndingDueDate;
				DateType _PStartingDistDate = PStartingDistDate;
				DateType _PEndingDistDate = PEndingDistDate;
				StringType _PAuthStatus = PAuthStatus;
				StringType _PSortVchVend = PSortVchVend;
				ListYesNoType _CalledFromBackground = CalledFromBackground;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "APVchPostPopulateTTSP";
					
					appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingVoucherNum", _PStartingVoucherNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingVoucherNum", _PEndingVoucherNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingDueDate", _PStartingDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingDueDate", _PEndingDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingDistDate", _PStartingDistDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingDistDate", _PEndingDistDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PAuthStatus", _PAuthStatus, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PSortVchVend", _PSortVchVend, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CalledFromBackground", _CalledFromBackground, ParameterDirection.Input);
					
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
