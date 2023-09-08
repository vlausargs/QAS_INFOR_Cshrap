//PROJECT NAME: Production
//CLASS NAME: ApsXfdOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsXfdOrderId : IApsXfdOrderId
	{
		readonly IApplicationDB appDB;
		
		public ApsXfdOrderId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsXfdOrderIdFn(
			string Site,
			string RefNum)
		{
			SiteType _Site = Site;
			MrpOrderType _RefNum = RefNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsXfdOrderId](@Site, @RefNum)";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
