//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigParentUnit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigParentUnit : ISSSFSConfigParentUnit
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConfigParentUnit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSConfigParentUnitFn(
			string Type,
			int? CompId)
		{
			AnyRefTypeType _Type = Type;
			FSCompIdType _CompId = CompId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSConfigParentUnit](@Type, @CompId)";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompId", _CompId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
