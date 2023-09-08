//PROJECT NAME: Production
//CLASS NAME: ProjMatlChng.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjMatlChng : IProjMatlChng
	{
		readonly IApplicationDB appDB;
		
		public ProjMatlChng(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ProjMatlChngSp(
			string PItem,
			decimal? PQty)
		{
			ItemType _PItem = PItem;
			QtyPerType _PQty = PQty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjMatlChngSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
