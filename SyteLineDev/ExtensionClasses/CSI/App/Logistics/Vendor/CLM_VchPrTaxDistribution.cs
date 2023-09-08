//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_VchPrTaxDistribution.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_VchPrTaxDistribution
	{
		DataTable CLM_VchPrTaxDistributionSp(int? PPreRegister);
	}
	
	public class CLM_VchPrTaxDistribution : ICLM_VchPrTaxDistribution
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_VchPrTaxDistribution(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_VchPrTaxDistributionSp(int? PPreRegister)
		{
			PreRegisterType _PPreRegister = PPreRegister;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_VchPrTaxDistributionSp";
				
				appDB.AddCommandParameter(cmd, "PPreRegister", _PPreRegister, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
