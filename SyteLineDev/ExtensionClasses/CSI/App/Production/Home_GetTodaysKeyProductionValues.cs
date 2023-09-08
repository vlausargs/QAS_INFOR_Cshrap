//PROJECT NAME: Production
//CLASS NAME: Home_GetTodaysKeyProductionValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Home_GetTodaysKeyProductionValues : IHome_GetTodaysKeyProductionValues
	{
		readonly IApplicationDB appDB;
		
		
		public Home_GetTodaysKeyProductionValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CompleteQty,
		int? PastDueQty) Home_GetTodaysKeyProductionValuesSp(int? CompleteQty,
		int? PastDueQty)
		{
			IntType _CompleteQty = CompleteQty;
			IntType _PastDueQty = PastDueQty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_GetTodaysKeyProductionValuesSp";
				
				appDB.AddCommandParameter(cmd, "CompleteQty", _CompleteQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueQty", _PastDueQty, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CompleteQty = _CompleteQty;
				PastDueQty = _PastDueQty;
				
				return (Severity, CompleteQty, PastDueQty);
			}
		}
	}
}
