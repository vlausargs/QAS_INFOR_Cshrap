//PROJECT NAME: Production
//CLASS NAME: ApsPlannerStart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPlannerStart : IApsPlannerStart
	{
		readonly IApplicationDB appDB;
		
		public ApsPlannerStart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsPlannerStartSp(
			int? AltNo,
			int? Scope,
			string Item,
			int? ProcessID)
		{
			ShortType _AltNo = AltNo;
			ShortType _Scope = Scope;
			ApsMaxIDType _Item = Item;
			GenericNoType _ProcessID = ProcessID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsPlannerStartSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Scope", _Scope, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
