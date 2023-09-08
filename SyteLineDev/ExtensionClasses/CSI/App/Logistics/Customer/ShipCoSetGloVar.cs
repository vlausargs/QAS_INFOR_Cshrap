//PROJECT NAME: Logistics
//CLASS NAME: ShipCoSetGloVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipCoSetGloVar : IShipCoSetGloVar
	{
		readonly IApplicationDB appDB;
		
		
		public ShipCoSetGloVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ShipCoSetGloVarSp(int? PLcrOkFlag)
		{
			ListYesNoType _PLcrOkFlag = PLcrOkFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShipCoSetGloVarSp";
				
				appDB.AddCommandParameter(cmd, "PLcrOkFlag", _PLcrOkFlag, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
