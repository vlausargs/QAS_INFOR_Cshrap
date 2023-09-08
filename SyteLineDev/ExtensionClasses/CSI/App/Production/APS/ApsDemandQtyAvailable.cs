//PROJECT NAME: Production
//CLASS NAME: ApsDemandQtyAvailable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDemandQtyAvailable : IApsDemandQtyAvailable
	{
		readonly IApplicationDB appDB;
		
		public ApsDemandQtyAvailable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsDemandQtyAvailableFn(
			string PDemandID)
		{
			ApsOrderType _PDemandID = PDemandID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsDemandQtyAvailable](@PDemandID)";
				
				appDB.AddCommandParameter(cmd, "PDemandID", _PDemandID, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
