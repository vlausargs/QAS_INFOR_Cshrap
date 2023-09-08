//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateJITReceiver.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IRSQC_CreateJITReceiver
	{
		(int? ReturnCode, int? o_PopUp,
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
		string Infobar);
	}
}

