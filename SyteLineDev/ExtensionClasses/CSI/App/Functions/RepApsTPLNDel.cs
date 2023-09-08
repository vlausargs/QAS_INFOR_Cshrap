//PROJECT NAME: Data
//CLASS NAME: RepApsTPLNDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepApsTPLNDel : IRepApsTPLNDel
	{
		readonly IApplicationDB appDB;
		
		public RepApsTPLNDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RepApsTPLNDelSp(
			string Item,
			string tpln_OrderID,
			string ReceivingSite,
			int? FirmingPLN,
			string Infobar)
		{
			ItemType _Item = Item;
			ApsOrderType _tpln_OrderID = tpln_OrderID;
			SiteType _ReceivingSite = ReceivingSite;
			ListYesNoType _FirmingPLN = FirmingPLN;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepApsTPLNDelSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tpln_OrderID", _tpln_OrderID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceivingSite", _ReceivingSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirmingPLN", _FirmingPLN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
