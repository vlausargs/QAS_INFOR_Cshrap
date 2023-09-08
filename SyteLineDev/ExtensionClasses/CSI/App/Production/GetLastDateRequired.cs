//PROJECT NAME: CSIProduct
//CLASS NAME: GetLastDateRequired.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IGetLastDateRequired
	{
		int GetLastDateRequiredSp(ref DateTime? LastDateRequired);
	}
	
	public class GetLastDateRequired : IGetLastDateRequired
	{
		readonly IApplicationDB appDB;
		
		public GetLastDateRequired(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetLastDateRequiredSp(ref DateTime? LastDateRequired)
		{
			DateType _LastDateRequired = LastDateRequired;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetLastDateRequiredSp";
				
				appDB.AddCommandParameter(cmd, "LastDateRequired", _LastDateRequired, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LastDateRequired = _LastDateRequired;
				
				return Severity;
			}
		}
	}
}
