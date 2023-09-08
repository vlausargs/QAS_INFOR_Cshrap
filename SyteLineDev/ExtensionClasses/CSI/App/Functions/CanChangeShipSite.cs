//PROJECT NAME: Data
//CLASS NAME: CanChangeShipSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CanChangeShipSite : ICanChangeShipSite
	{
		readonly IApplicationDB appDB;
		
		public CanChangeShipSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CanChangeShipSiteFn(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string ShipSite)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			SiteType _ShipSite = ShipSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CanChangeShipSite](@CoNum, @CoLine, @CoRelease, @ShipSite)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
