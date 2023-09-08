//PROJECT NAME: Logistics
//CLASS NAME: CanConfigureItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CanConfigureItem : ICanConfigureItem
	{
		readonly IApplicationDB appDB;
		
		
		public CanConfigureItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? OplConfigureItem,
		int? OplConfigureDone) CanConfigureItemSp(string IpcItem,
		int? OplConfigureItem,
		int? OplConfigureDone)
		{
			ItemType _IpcItem = IpcItem;
			Flag _OplConfigureItem = OplConfigureItem;
			Flag _OplConfigureDone = OplConfigureDone;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CanConfigureItemSp";
				
				appDB.AddCommandParameter(cmd, "IpcItem", _IpcItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OplConfigureItem", _OplConfigureItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OplConfigureDone", _OplConfigureDone, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OplConfigureItem = _OplConfigureItem;
				OplConfigureDone = _OplConfigureDone;
				
				return (Severity, OplConfigureItem, OplConfigureDone);
			}
		}
	}
}
