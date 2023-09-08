//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateSupplierReceiver.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateSupplierReceiver : IRSQC_CreateSupplierReceiver
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateSupplierReceiver(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string Messages,
		string Infobar) RSQC_CreateSupplierReceiverSp(decimal? QtyReceived,
		string Whse,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		string Loc,
		DateTime? DueDate,
		string Lot,
		string Item,
		string VendNum,
		DateTime? TransDate,
		int? AutoAccept,
		string CallingFunction,
		string QCLot,
		string UserCode,
		int? firstarticleonly,
		string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string Messages,
		string Infobar)
		{
			QtyUnitType _QtyReceived = QtyReceived;
			WhseType _Whse = Whse;
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			LocType _Loc = Loc;
			DateType _DueDate = DueDate;
			LotType _Lot = Lot;
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			DateType _TransDate = TransDate;
			ListYesNoType _AutoAccept = AutoAccept;
			DescriptionType _CallingFunction = CallingFunction;
			LotType _QCLot = QCLot;
			UserCodeType _UserCode = UserCode;
			ListYesNoType _firstarticleonly = firstarticleonly;
			QCDocNumType _RcvrNum = RcvrNum;
			ListYesNoType _PopUp = PopUp;
			ListYesNoType _PrintTag = PrintTag;
			InfobarType _Messages = Messages;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateSupplierReceiverSp";
				
				appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoAccept", _AutoAccept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallingFunction", _CallingFunction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QCLot", _QCLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserCode", _UserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "firstarticleonly", _firstarticleonly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvrNum", _RcvrNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PopUp", _PopUp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintTag", _PrintTag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Messages", _Messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RcvrNum = _RcvrNum;
				PopUp = _PopUp;
				PrintTag = _PrintTag;
				Messages = _Messages;
				Infobar = _Infobar;
				
				return (Severity, RcvrNum, PopUp, PrintTag, Messages, Infobar);
			}
		}
	}
}
