//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateTaxDistribution.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_GenerateTaxDistribution
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateTaxDistributionSp(string PVendNum,
		DateTime? PInvDate,
		decimal? PFreight,
		decimal? PMisc,
		byte? IncludeTaxInCost);
	}
	
	public class CLM_GenerateTaxDistribution : ICLM_GenerateTaxDistribution
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GenerateTaxDistribution(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateTaxDistributionSp(string PVendNum,
		DateTime? PInvDate,
		decimal? PFreight,
		decimal? PMisc,
		byte? IncludeTaxInCost)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				VendNumType _PVendNum = PVendNum;
				GenericDateType _PInvDate = PInvDate;
				AmountType _PFreight = PFreight;
				AmountType _PMisc = PMisc;
				ListYesNoType _IncludeTaxInCost = IncludeTaxInCost;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_GenerateTaxDistributionSp";
					
					appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PMisc", _PMisc, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IncludeTaxInCost", _IncludeTaxInCost, ParameterDirection.Input);
					
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
