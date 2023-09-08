//PROJECT NAME: Logistics
//CLASS NAME: ICCreateOrUpdateBlanketPo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class ICCreateOrUpdateBlanketPo : IICCreateOrUpdateBlanketPo
	{
		readonly IApplicationDB appDB;
		
		
		public ICCreateOrUpdateBlanketPo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PPoNum,
		int? PPoLine,
		int? PPoLineRelease,
		string Infobar) ICCreateOrUpdateBlanketPoSp(string PPoNum,
		int? PPoLine,
		int? PPoLineRelease,
		string PVendNum,
		string PItem,
		decimal? PQty,
		string Infobar)
		{
			PoNumType _PPoNum = PPoNum;
			PoLineType _PPoLine = PPoLine;
			PoReleaseType _PPoLineRelease = PPoLineRelease;
			VendNumType _PVendNum = PVendNum;
			ItemType _PItem = PItem;
			QtyUnitNoNegType _PQty = PQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ICCreateOrUpdateBlanketPoSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPoLineRelease", _PPoLineRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPoNum = _PPoNum;
				PPoLine = _PPoLine;
				PPoLineRelease = _PPoLineRelease;
				Infobar = _Infobar;
				
				return (Severity, PPoNum, PPoLine, PPoLineRelease, Infobar);
			}
		}
	}
}
