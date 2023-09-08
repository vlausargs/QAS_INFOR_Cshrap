//PROJECT NAME: Logistics
//CLASS NAME: POReceivingProjShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POReceivingProjShip : IPOReceivingProjShip
	{
		readonly IApplicationDB appDB;
		
		
		public POReceivingProjShip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) POReceivingProjShipSp(string WorkKey,
		string Infobar)
		{
			RefStrType _WorkKey = WorkKey;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POReceivingProjShipSp";
				
				appDB.AddCommandParameter(cmd, "WorkKey", _WorkKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
