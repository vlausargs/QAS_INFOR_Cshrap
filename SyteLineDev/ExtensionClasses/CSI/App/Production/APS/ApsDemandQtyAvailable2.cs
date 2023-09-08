//PROJECT NAME: Production
//CLASS NAME: ApsDemandQtyAvailable2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDemandQtyAvailable2 : IApsDemandQtyAvailable2
	{
		readonly IApplicationDB appDB;
		
		public ApsDemandQtyAvailable2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsDemandQtyAvailable2Fn(
			string RefType,
			string RefNum)
		{
			RefTypeIJKMNOTType _RefType = RefType;
			RefType _RefNum = RefNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsDemandQtyAvailable2](@RefType, @RefNum)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
