//PROJECT NAME: Data
//CLASS NAME: ApplyFeatTempl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ApplyFeatTempl : IApplyFeatTempl
	{
		readonly IApplicationDB appDB;
		
		public ApplyFeatTempl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApplyFeatTemplSp(
			string FeatStr,
			string FeatTempl)
		{
			FeatStrType _FeatStr = FeatStr;
			FeatTemplateType _FeatTempl = FeatTempl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApplyFeatTemplSp](@FeatStr, @FeatTempl)";
				
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatTempl", _FeatTempl, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
