//PROJECT NAME: Data
//CLASS NAME: GetSplitWhitespace.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetSplitWhitespace : IGetSplitWhitespace
	{
		readonly IApplicationDB appDB;
		
		public GetSplitWhitespace(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetSplitWhitespaceFn(
			string Desc,
			int? SplitNum)
		{
			DescriptionType _Desc = Desc;
			IntType _SplitNum = SplitNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetSplitWhitespace](@Desc, @SplitNum)";
				
				appDB.AddCommandParameter(cmd, "Desc", _Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SplitNum", _SplitNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
