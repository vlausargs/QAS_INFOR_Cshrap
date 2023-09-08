//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetCharacter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetCharacter : ISSSFSGetCharacter
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetCharacter(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSGetCharacterFn(
			int? CharValue)
		{
			GenericIntType _CharValue = CharValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetCharacter](@CharValue)";
				
				appDB.AddCommandParameter(cmd, "CharValue", _CharValue, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
