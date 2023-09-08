//PROJECT NAME: Data
//CLASS NAME: RepApsTPLNBulkDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepApsTPLNBulkDel : IRepApsTPLNBulkDel
	{
		readonly IApplicationDB appDB;
		
		public RepApsTPLNBulkDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RepApsTPLNBulkDelSp(
			string Item,
			string ReceivingSite,
			string Infobar)
		{
			ItemType _Item = Item;
			SiteType _ReceivingSite = ReceivingSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepApsTPLNBulkDelSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceivingSite", _ReceivingSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
