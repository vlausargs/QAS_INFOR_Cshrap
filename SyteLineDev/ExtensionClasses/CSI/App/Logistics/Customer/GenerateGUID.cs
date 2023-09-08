//PROJECT NAME: Logistics
//CLASS NAME: GenerateGUID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateGUID : IGenerateGUID
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateGUID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? GUID) GenerateGUIDSp(Guid? GUID)
		{
			GuidType _GUID = GUID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateGUIDSp";
				
				appDB.AddCommandParameter(cmd, "GUID", _GUID, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				GUID = _GUID;
				
				return (Severity, GUID);
			}
		}
	}
}
