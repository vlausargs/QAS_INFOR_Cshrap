//PROJECT NAME: Production
//CLASS NAME: ApsPlannerCompleted.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPlannerCompleted : IApsPlannerCompleted
	{
		readonly IApplicationDB appDB;
		
		public ApsPlannerCompleted(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsPlannerCompletedSp(
			int? AltNo,
			int? Scope,
			string Item)
		{
			ShortType _AltNo = AltNo;
			ShortType _Scope = Scope;
			ApsMaxIDType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsPlannerCompletedSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Scope", _Scope, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
