//PROJECT NAME: Logistics
//CLASS NAME: CoitemMargin.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemMargin : ICoitemMargin
	{
		readonly IApplicationDB appDB;
		
		public CoitemMargin(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CoitemMarginFn(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			int? PercentOrValue)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			ListYesNoType _PercentOrValue = PercentOrValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CoitemMargin](@CoNum, @CoLine, @CoRelease, @PercentOrValue)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PercentOrValue", _PercentOrValue, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
