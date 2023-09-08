//PROJECT NAME: Logistics
//CLASS NAME: ShipmentSplitting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipmentSplitting : IShipmentSplitting
	{
		readonly IApplicationDB appDB;
		
		
		public ShipmentSplitting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? NewShipment,
		int? NewLine,
		string Infobar) ShipmentSplittingSp(int? Package = null,
		decimal? OldShipment = null,
		int? OldLine = null,
		int? OldSeq = null,
		int? CreateNewLine = null,
		decimal? NewShipment = null,
		int? NewLine = null,
		string Infobar = null)
		{
			PackageIDType _Package = Package;
			ShipmentIDType _OldShipment = OldShipment;
			ShipmentLineType _OldLine = OldLine;
			ShipmentSequenceType _OldSeq = OldSeq;
			ListYesNoType _CreateNewLine = CreateNewLine;
			ShipmentIDType _NewShipment = NewShipment;
			ShipmentLineType _NewLine = NewLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShipmentSplittingSp";
				
				appDB.AddCommandParameter(cmd, "Package", _Package, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldShipment", _OldShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldLine", _OldLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldSeq", _OldSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateNewLine", _CreateNewLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewShipment", _NewShipment, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewLine", _NewLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewShipment = _NewShipment;
				NewLine = _NewLine;
				Infobar = _Infobar;
				
				return (Severity, NewShipment, NewLine, Infobar);
			}
		}
	}
}
