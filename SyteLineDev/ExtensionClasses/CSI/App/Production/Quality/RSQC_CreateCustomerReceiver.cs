//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateCustomerReceiver.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateCustomerReceiver : IRSQC_CreateCustomerReceiver
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateCustomerReceiver(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string Messages,
		string Infobar) RSQC_CreateCustomerReceiverSp(decimal? QtyReceived,
		string Whse,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Loc,
		DateTime? DueDate,
		string Lot,
		string Item,
		string CustNum,
		DateTime? HoldDate,
		int? AutoAccept,
		string CallingFunction,
		string QCLot,
		int? firstarticleonly,
		string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string Messages,
		string Infobar)
		{
			QtyUnitType _QtyReceived = QtyReceived;
			WhseType _Whse = Whse;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			LocType _Loc = Loc;
			DateType _DueDate = DueDate;
			LotType _Lot = Lot;
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			DateType _HoldDate = HoldDate;
			ListYesNoType _AutoAccept = AutoAccept;
			DescriptionType _CallingFunction = CallingFunction;
			QCDocNumType _QCLot = QCLot;
			ListYesNoType _firstarticleonly = firstarticleonly;
			QCDocNumType _RcvrNum = RcvrNum;
			ListYesNoType _PopUp = PopUp;
			ListYesNoType _PrintTag = PrintTag;
			InfobarType _Messages = Messages;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateCustomerReceiverSp";
				
				appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HoldDate", _HoldDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoAccept", _AutoAccept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallingFunction", _CallingFunction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QCLot", _QCLot, ParameterDirection.Input);
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
