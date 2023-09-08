//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateRMAReceiver.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateRMAReceiver : IRSQC_CreateRMAReceiver
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateRMAReceiver(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string TagStatus,
		string Messages,
		string Infobar) RSQC_CreateRMAReceiverSp(decimal? QtyReceived,
		string Whse,
		string RMANum,
		int? RMALine,
		string Loc,
		string Lot,
		string Item,
		string CustNum,
		DateTime? TransDate,
		int? AutoQCHold,
		string CallingFunction,
		string QCLot,
		string UserCode,
		string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string TagStatus,
		string Messages,
		string Infobar)
		{
			QtyUnitType _QtyReceived = QtyReceived;
			WhseType _Whse = Whse;
			RmaNumType _RMANum = RMANum;
			RmaLineType _RMALine = RMALine;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			DateType _TransDate = TransDate;
			ListYesNoType _AutoQCHold = AutoQCHold;
			DescriptionType _CallingFunction = CallingFunction;
			LotType _QCLot = QCLot;
			UserCodeType _UserCode = UserCode;
			QCDocNumType _RcvrNum = RcvrNum;
			ListYesNoType _PopUp = PopUp;
			ListYesNoType _PrintTag = PrintTag;
			QCCodeType _TagStatus = TagStatus;
			InfobarType _Messages = Messages;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateRMAReceiverSp";
				
				appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMANum", _RMANum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMALine", _RMALine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoQCHold", _AutoQCHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallingFunction", _CallingFunction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QCLot", _QCLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserCode", _UserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvrNum", _RcvrNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PopUp", _PopUp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintTag", _PrintTag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TagStatus", _TagStatus, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Messages", _Messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RcvrNum = _RcvrNum;
				PopUp = _PopUp;
				PrintTag = _PrintTag;
				TagStatus = _TagStatus;
				Messages = _Messages;
				Infobar = _Infobar;
				
				return (Severity, RcvrNum, PopUp, PrintTag, TagStatus, Messages, Infobar);
			}
		}
	}
}
