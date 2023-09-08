//PROJECT NAME: Data
//CLASS NAME: GetReplIDOCollection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetReplIDOCollection : IGetReplIDOCollection
	{
		readonly IApplicationDB appDB;
		
		public GetReplIDOCollection(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetReplIDOCollectionFn(
			string Property,
			string Parsing)
		{
			LongListType _Property = Property;
			StringType _Parsing = Parsing;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetReplIDOCollection](@Property, @Parsing)";
				
				appDB.AddCommandParameter(cmd, "Property", _Property, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parsing", _Parsing, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
