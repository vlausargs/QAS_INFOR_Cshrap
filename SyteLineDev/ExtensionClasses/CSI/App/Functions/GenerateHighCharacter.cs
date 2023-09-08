//PROJECT NAME: Data
//CLASS NAME: GenerateHighCharacter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GenerateHighCharacter : IGenerateHighCharacter
	{
		readonly IApplicationDB appDB;
		
		public GenerateHighCharacter(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GenerateHighCharacterSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateHighCharacter";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
