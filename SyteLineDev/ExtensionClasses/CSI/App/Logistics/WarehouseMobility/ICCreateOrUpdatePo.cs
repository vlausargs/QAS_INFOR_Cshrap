//PROJECT NAME: Logistics
//CLASS NAME: ICCreateOrUpdatePo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class ICCreateOrUpdatePo : IICCreateOrUpdatePo
	{
		IApplicationDB appDB;
		
		
		public ICCreateOrUpdatePo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PPoNum,
		int? PPoLine,
		string Infobar) ICCreateOrUpdatePoSp(string PPoNum,
		int? PPoLine,
		string PVendNum,
		string PItem,
		decimal? PQty,
		string Infobar)
		{
			PoNumType _PPoNum = PPoNum;
			PoLineType _PPoLine = PPoLine;
			VendNumType _PVendNum = PVendNum;
			ItemType _PItem = PItem;
			QtyUnitNoNegType _PQty = PQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ICCreateOrUpdatePoSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPoNum = _PPoNum;
				PPoLine = _PPoLine;
				Infobar = _Infobar;
				
				return (Severity, PPoNum, PPoLine, Infobar);
			}
		}
	}
}
