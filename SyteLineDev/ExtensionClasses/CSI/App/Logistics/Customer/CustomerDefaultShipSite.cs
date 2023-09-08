//PROJECT NAME: Logistics
//CLASS NAME: CustomerDefaultShipSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustomerDefaultShipSite : ICustomerDefaultShipSite
	{
		readonly IApplicationDB appDB;
		
		
		public CustomerDefaultShipSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CustomerDefaultShipSiteSp(string Co_Num = null,
		string Co_Type = null,
		int? Co_Line = null)
		{
			CoNumType _Co_Num = Co_Num;
			CoTypeType _Co_Type = Co_Type;
			CoLineType _Co_Line = Co_Line;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerDefaultShipSiteSp";
				
				appDB.AddCommandParameter(cmd, "Co_Num", _Co_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Co_Type", _Co_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Co_Line", _Co_Line, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
