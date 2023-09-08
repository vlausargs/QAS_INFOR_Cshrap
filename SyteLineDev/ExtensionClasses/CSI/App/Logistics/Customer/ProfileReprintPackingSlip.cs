//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileReprintPackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IProfileReprintPackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileReprintPackingSlipSp(int? PStartSlipNum = null,
		int? PEndSlipNum = null);
	}
	
	public class ProfileReprintPackingSlip : IProfileReprintPackingSlip
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileReprintPackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileReprintPackingSlipSp(int? PStartSlipNum = null,
		int? PEndSlipNum = null)
		{
			PackNumType _PStartSlipNum = PStartSlipNum;
			PackNumType _PEndSlipNum = PEndSlipNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileReprintPackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "PStartSlipNum", _PStartSlipNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndSlipNum", _PEndSlipNum, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
