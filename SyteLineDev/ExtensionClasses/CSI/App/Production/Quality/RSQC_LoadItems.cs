//PROJECT NAME: Production
//CLASS NAME: RSQC_LoadItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_LoadItems : IRSQC_LoadItems
	{
		readonly IApplicationDB appDB;
		
		public RSQC_LoadItems(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RSQC_LoadItemsSp(
			string i_begitem,
			string i_enditem,
			int? i_supplier,
			int? i_ip,
			int? i_customer)
		{
			ItemType _i_begitem = i_begitem;
			ItemType _i_enditem = i_enditem;
			IntType _i_supplier = i_supplier;
			IntType _i_ip = i_ip;
			IntType _i_customer = i_customer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_LoadItemsSp";
				
				appDB.AddCommandParameter(cmd, "i_begitem", _i_begitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_enditem", _i_enditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_supplier", _i_supplier, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ip", _i_ip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_customer", _i_customer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
