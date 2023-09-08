//PROJECT NAME: CSIDataCollection
//CLASS NAME: DCLotValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDCLotValid
	{
		int DCLotValidSP(string pItem,
		                 string pLot,
		                 ref string Infobar);
	}
	
	public class DCLotValid : IDCLotValid
	{
		readonly IApplicationDB appDB;
		
		public DCLotValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DCLotValidSP(string pItem,
		                        string pLot,
		                        ref string Infobar)
		{
			ItemType _pItem = pItem;
			LotType _pLot = pLot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DCLotValidSp";
				
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLot", _pLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
