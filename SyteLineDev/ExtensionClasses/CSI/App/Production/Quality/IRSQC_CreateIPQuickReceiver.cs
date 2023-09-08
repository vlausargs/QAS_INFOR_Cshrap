//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateIPQuickReceiver.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateIPQuickReceiver
	{
		(int? ReturnCode, int? o_PopUp,
		int? o_PrintTag,
		string o_RcvrNums,
		string o_Messages,
		string Infobar) RSQC_CreateIPQuickReceiverSp(decimal? i_QtyReceived,
		string i_Whse,
		string i_Job,
		int? i_Suffix,
		int? i_OperNum,
		string i_PSNum,
		string i_CallingFunction,
		string i_UserCode,
		int? firstarticleonly,
		int? o_PopUp,
		int? o_PrintTag,
		string o_RcvrNums,
		string o_Messages,
		string Infobar);
	}
}

