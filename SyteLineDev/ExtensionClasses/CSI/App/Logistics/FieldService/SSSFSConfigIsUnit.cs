//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigIsUnit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigIsUnit : ISSSFSConfigIsUnit
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConfigIsUnit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConfigIsUnitFn(
			int? iCompID)
		{
			FSCompIdType _iCompID = iCompID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSConfigIsUnit](@iCompID)";
				
				appDB.AddCommandParameter(cmd, "iCompID", _iCompID, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
