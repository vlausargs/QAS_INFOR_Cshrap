//PROJECT NAME: Data
//CLASS NAME: GetFrozenOps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetFrozenOps : IGetFrozenOps
	{
		readonly IApplicationDB appDB;
		
		public GetFrozenOps(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetFrozenOpsSp(
			int? AltNo)
		{
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFrozenOpsSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
