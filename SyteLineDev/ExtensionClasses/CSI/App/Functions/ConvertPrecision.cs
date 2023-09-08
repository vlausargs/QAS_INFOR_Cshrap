//PROJECT NAME: Data
//CLASS NAME: ConvertPrecision.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertPrecision : IConvertPrecision
	{
		readonly IApplicationDB appDB;
		
		public ConvertPrecision(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ConvertPrecisionFn(
			string ProgressFormat,
			int? IsCharacter,
			int? Decimals)
		{
			StringType _ProgressFormat = ProgressFormat;
			IntType _IsCharacter = IsCharacter;
			ShortType _Decimals = Decimals;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvertPrecision](@ProgressFormat, @IsCharacter, @Decimals)";
				
				appDB.AddCommandParameter(cmd, "ProgressFormat", _ProgressFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsCharacter", _IsCharacter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decimals", _Decimals, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
