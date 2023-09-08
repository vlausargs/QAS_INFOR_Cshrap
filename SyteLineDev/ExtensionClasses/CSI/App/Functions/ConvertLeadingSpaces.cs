//PROJECT NAME: Data
//CLASS NAME: ConvertLeadingSpaces.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertLeadingSpaces : IConvertLeadingSpaces
	{
		readonly IApplicationDB appDB;
		
		public ConvertLeadingSpaces(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ConvertLeadingSpacesFn(
			string Value,
			int? MaxSubstitutions,
			string BlankSubstitute)
		{
			LongListType _Value = Value;
			ShortType _MaxSubstitutions = MaxSubstitutions;
			StringType _BlankSubstitute = BlankSubstitute;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvertLeadingSpaces](@Value, @MaxSubstitutions, @BlankSubstitute)";
				
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxSubstitutions", _MaxSubstitutions, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlankSubstitute", _BlankSubstitute, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
