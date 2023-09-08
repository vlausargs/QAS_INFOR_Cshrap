//PROJECT NAME: Data
//CLASS NAME: AutoShipCoFromPo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class AutoShipCoFromPo : IAutoShipCoFromPo
	{
		readonly IApplicationDB appDB;
		
		public AutoShipCoFromPo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) AutoShipCoFromPoSp(
			string DemandingPO,
			int? PoLine,
			int? PoRelease,
			string Loc,
			string Lot,
			decimal? Qty,
			decimal? QtyConv,
			string Infobar,
			DateTime? TransDate)
		{
			PoNumType _DemandingPO = DemandingPO;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyUnitType _Qty = Qty;
			QtyUnitType _QtyConv = QtyConv;
			InfobarType _Infobar = Infobar;
			DateType _TransDate = TransDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AutoShipCoFromPoSp";
				
				appDB.AddCommandParameter(cmd, "DemandingPO", _DemandingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
