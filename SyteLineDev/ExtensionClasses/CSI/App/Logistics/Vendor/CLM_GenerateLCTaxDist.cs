//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateLCTaxDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_GenerateLCTaxDist : ICLM_GenerateLCTaxDist
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GenerateLCTaxDist(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateLCTaxDistSp(string PVendNum,
		decimal? PFreight,
		decimal? PBrokerage,
		decimal? PDuty,
		decimal? PLocFreight,
		decimal? PInsurance,
		DateTime? PInvDate,
		int? GenerateTax,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				VendNumType _PVendNum = PVendNum;
				AmountType _PFreight = PFreight;
				AmountType _PBrokerage = PBrokerage;
				AmountType _PDuty = PDuty;
				AmountType _PLocFreight = PLocFreight;
				AmountType _PInsurance = PInsurance;
				GenericDateType _PInvDate = PInvDate;
				ListYesNoType _GenerateTax = GenerateTax;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_GenerateLCTaxDistSp";
					
					appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PBrokerage", _PBrokerage, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PDuty", _PDuty, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PLocFreight", _PLocFreight, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PInsurance", _PInsurance, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "GenerateTax", _GenerateTax, ParameterDirection.Input);
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
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
