//PROJECT NAME: Data
//CLASS NAME: IsUsePlanOutputSched.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsUsePlanOutputSched : IIsUsePlanOutputSched
	{
		readonly IApplicationDB appDB;
		
		public IsUsePlanOutputSched(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsUsePlanOutputSchedFn(
			int? AltNo)
		{
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsUsePlanOutputSched](@AltNo)";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
