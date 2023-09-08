//PROJECT NAME: Data
//CLASS NAME: FormatFeatStr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatFeatStr : IFormatFeatStr
	{
		readonly IApplicationDB appDB;
		
		public FormatFeatStr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FormatFeatStrFn(
			string pFeatStr,
			string pFeatTempl)
		{
			FeatStrType _pFeatStr = pFeatStr;
			FeatTemplateType _pFeatTempl = pFeatTempl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatFeatStr](@pFeatStr, @pFeatTempl)";
				
				appDB.AddCommandParameter(cmd, "pFeatStr", _pFeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFeatTempl", _pFeatTempl, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
