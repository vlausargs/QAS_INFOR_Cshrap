//PROJECT NAME: Data
//CLASS NAME: FormatDateStr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatDateStr : IFormatDateStr
	{
		readonly IApplicationDB appDB;
		
		public FormatDateStr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FormatDateStrFn(
			string InputDateStr,
			string DateFormat)
		{
			StringType _InputDateStr = InputDateStr;
			StringType _DateFormat = DateFormat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatDateStr](@InputDateStr, @DateFormat)";
				
				appDB.AddCommandParameter(cmd, "InputDateStr", _InputDateStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateFormat", _DateFormat, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
