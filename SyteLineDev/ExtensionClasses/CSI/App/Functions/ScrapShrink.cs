//PROJECT NAME: Data
//CLASS NAME: ScrapShrink.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ScrapShrink : IScrapShrink
	{
		readonly IApplicationDB appDB;
		
		public ScrapShrink(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ScrapShrinkFn(
			int? MrpParmShrinkFlag,
			string ApsParmApsMode,
			Guid? apsplanRowPointer)
		{
			IntType _MrpParmShrinkFlag = MrpParmShrinkFlag;
			StringType _ApsParmApsMode = ApsParmApsMode;
			GuidType _apsplanRowPointer = apsplanRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ScrapShrink](@MrpParmShrinkFlag, @ApsParmApsMode, @apsplanRowPointer)";
				
				appDB.AddCommandParameter(cmd, "MrpParmShrinkFlag", _MrpParmShrinkFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsParmApsMode", _ApsParmApsMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "apsplanRowPointer", _apsplanRowPointer, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
