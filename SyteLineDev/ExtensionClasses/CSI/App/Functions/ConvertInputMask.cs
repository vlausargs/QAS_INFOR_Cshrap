//PROJECT NAME: Data
//CLASS NAME: ConvertInputMask.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertInputMask : IConvertInputMask
	{
		readonly IApplicationDB appDB;
		
		public ConvertInputMask(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ConvertInputMaskFn(
			string ProgressFormat)
		{
			StringType _ProgressFormat = ProgressFormat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvertInputMask](@ProgressFormat)";
				
				appDB.AddCommandParameter(cmd, "ProgressFormat", _ProgressFormat, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
