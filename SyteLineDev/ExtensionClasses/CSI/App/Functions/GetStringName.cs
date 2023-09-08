//PROJECT NAME: Data
//CLASS NAME: GetStringName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetStringName : IGetStringName
	{
		readonly IApplicationDB appDB;
		
		public GetStringName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetStringNameFn(
			string ObjectName,
			string MessageText,
			string Name,
			string String)
		{
			ObjectNameType _ObjectName = ObjectName;
			InfobarType _MessageText = MessageText;
			ObjectNameType _Name = Name;
			InfobarType _String = String;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetStringName](@ObjectName, @MessageText, @Name, @String)";
				
				appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageText", _MessageText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "String", _String, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
