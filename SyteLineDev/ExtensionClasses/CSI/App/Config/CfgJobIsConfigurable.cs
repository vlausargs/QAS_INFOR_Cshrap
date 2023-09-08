//PROJECT NAME: Config
//CLASS NAME: CfgJobIsConfigurable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgJobIsConfigurable : ICfgJobIsConfigurable
	{
		readonly IApplicationDB appDB;
		
		public CfgJobIsConfigurable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CfgJobIsConfigurableFn(
			string CoitemCoNum,
			int? CoitemCoLine,
			int? CoitemCoRelease,
			string CoitemShipSite)
		{
			CoNumType _CoitemCoNum = CoitemCoNum;
			CoLineType _CoitemCoLine = CoitemCoLine;
			CoReleaseType _CoitemCoRelease = CoitemCoRelease;
			SiteType _CoitemShipSite = CoitemShipSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CfgJobIsConfigurable](@CoitemCoNum, @CoitemCoLine, @CoitemCoRelease, @CoitemShipSite)";
				
				appDB.AddCommandParameter(cmd, "CoitemCoNum", _CoitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemCoLine", _CoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemCoRelease", _CoitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemShipSite", _CoitemShipSite, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
