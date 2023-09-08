//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateJITReceiver.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class RSQC_CreateJITReceiver : IRSQC_CreateJITReceiver
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateJITReceiver(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_PopUp,
		int? o_PrintTag,
		string o_RcvrNums,
		string o_Messages,
		string Infobar) RSQC_CreateJITReceiverSp(decimal? i_QtyReceived,
		string i_Whse,
		string i_Item,
		string i_CallingFunction,
		int? o_PopUp,
		int? o_PrintTag,
		string o_RcvrNums,
		string o_Messages,
		string Infobar)
		{
			QtyUnitType _i_QtyReceived = i_QtyReceived;
			WhseType _i_Whse = i_Whse;
			ItemType _i_Item = i_Item;
			DescriptionType _i_CallingFunction = i_CallingFunction;
			ListYesNoType _o_PopUp = o_PopUp;
			ListYesNoType _o_PrintTag = o_PrintTag;
			InfobarType _o_RcvrNums = o_RcvrNums;
			InfobarType _o_Messages = o_Messages;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateJITReceiverSp";
				
				appDB.AddCommandParameter(cmd, "i_QtyReceived", _i_QtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Whse", _i_Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Item", _i_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_CallingFunction", _i_CallingFunction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_PopUp", _o_PopUp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_PrintTag", _o_PrintTag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_RcvrNums", _o_RcvrNums, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_Messages", _o_Messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_PopUp = _o_PopUp;
				o_PrintTag = _o_PrintTag;
				o_RcvrNums = _o_RcvrNums;
				o_Messages = _o_Messages;
				Infobar = _Infobar;
				
				return (Severity, o_PopUp, o_PrintTag, o_RcvrNums, o_Messages, Infobar);
			}
		}
	}
}
