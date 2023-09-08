//PROJECT NAME: Data
//CLASS NAME: GetReplProperty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetReplProperty : IGetReplProperty
	{
		readonly IApplicationDB appDB;
		
		public GetReplProperty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetReplPropertyFn(
			string Property,
			string Parsing)
		{
			LongListType _Property = Property;
			StringType _Parsing = Parsing;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetReplProperty](@Property, @Parsing)";
				
				appDB.AddCommandParameter(cmd, "Property", _Property, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parsing", _Parsing, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
