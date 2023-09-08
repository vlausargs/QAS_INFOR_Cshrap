//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipLine_ShipOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROPackSlipLine_ShipOne
	{
		(int? ReturnCode, string Infobar) SSSFSSROPackSlipLine_ShipOneSp(Guid? RowPointer,
		string Mode,
		decimal? QtyToShipConv,
		string Loc,
		string Lot,
		DateTime? TransDate,
		string Infobar);
	}
	
	public class SSSFSSROPackSlipLine_ShipOne : ISSSFSSROPackSlipLine_ShipOne
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROPackSlipLine_ShipOne(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSROPackSlipLine_ShipOneSp(Guid? RowPointer,
		string Mode,
		decimal? QtyToShipConv,
		string Loc,
		string Lot,
		DateTime? TransDate,
		string Infobar)
		{
			RowPointerType _RowPointer = RowPointer;
			StringType _Mode = Mode;
			QtyUnitType _QtyToShipConv = QtyToShipConv;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			DateType _TransDate = TransDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROPackSlipLine_ShipOneSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToShipConv", _QtyToShipConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
