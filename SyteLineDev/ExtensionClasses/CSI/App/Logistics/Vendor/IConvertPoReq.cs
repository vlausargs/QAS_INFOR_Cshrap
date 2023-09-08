//PROJECT NAME: Logistics
//CLASS NAME: IConvertPoReq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IConvertPoReq
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ConvertPoReqSp(string ProcSel,
		string PreqNum,
		int? PreqFromLine,
		int? PreqToLine,
		int? CopyText,
		string PoType,
		string PoNum,
		int? PoChangeFlag,
		string Infobar,
		string CostCode = null);
	}
}

