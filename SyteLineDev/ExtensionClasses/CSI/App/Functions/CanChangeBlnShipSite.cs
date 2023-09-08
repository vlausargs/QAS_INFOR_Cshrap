//PROJECT NAME: Data
//CLASS NAME: CanChangeBlnShipSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CanChangeBlnShipSite : ICanChangeBlnShipSite
	{
		readonly IApplicationDB appDB;
		
		public CanChangeBlnShipSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CanChangeBlnShipSiteFn(
			string CoNum,
			int? CoLine,
			string ShipSite)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			SiteType _ShipSite = ShipSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CanChangeBlnShipSite](@CoNum, @CoLine, @ShipSite)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
