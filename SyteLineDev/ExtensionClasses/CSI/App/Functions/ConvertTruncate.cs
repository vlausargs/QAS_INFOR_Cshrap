//PROJECT NAME: Data
//CLASS NAME: ConvertTruncate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertTruncate : IConvertTruncate
	{
		readonly IApplicationDB appDB;
		
		public ConvertTruncate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ConvertTruncateFn(
			string Value,
			int? MaxLength,
			int? Truncate)
		{
			LongListType _Value = Value;
			ShortType _MaxLength = MaxLength;
			IntType _Truncate = Truncate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvertTruncate](@Value, @MaxLength, @Truncate)";
				
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxLength", _MaxLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Truncate", _Truncate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
