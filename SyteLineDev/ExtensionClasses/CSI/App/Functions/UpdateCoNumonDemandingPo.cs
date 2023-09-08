//PROJECT NAME: Data
//CLASS NAME: UpdateCoNumonDemandingPo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdateCoNumonDemandingPo : IUpdateCoNumonDemandingPo
	{
		readonly IApplicationDB appDB;
		
		public UpdateCoNumonDemandingPo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateCoNumonDemandingPoSp(
			string PoNum,
			string PoSourceSiteCoNum)
		{
			PoNumType _PoNum = PoNum;
			CoNumType _PoSourceSiteCoNum = PoSourceSiteCoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateCoNumonDemandingPoSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoSourceSiteCoNum", _PoSourceSiteCoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
