//PROJECT NAME: Data
//CLASS NAME: SplitString2parts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SplitString2parts : ISplitString2parts
	{
		readonly IApplicationDB appDB;
		
		public SplitString2parts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SplitString2partsFn(
			string Delimiter,
			string List,
			int? PartNumber)
		{
			StringType _Delimiter = Delimiter;
			InfobarType _List = List;
			IntType _PartNumber = PartNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SplitString2parts](@Delimiter, @List, @PartNumber)";
				
				appDB.AddCommandParameter(cmd, "Delimiter", _Delimiter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "List", _List, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartNumber", _PartNumber, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
