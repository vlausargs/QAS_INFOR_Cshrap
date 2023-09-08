//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSConfigValidateLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigValidateLot
	{
		int SSSFSConfigValidateLotSp(string Item,
		                             string Lot,
		                             ref string Infobar);
	}
	
	public class SSSFSConfigValidateLot : ISSSFSConfigValidateLot
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConfigValidateLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSConfigValidateLotSp(string Item,
		                                    string Lot,
		                                    ref string Infobar)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConfigValidateLotSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
