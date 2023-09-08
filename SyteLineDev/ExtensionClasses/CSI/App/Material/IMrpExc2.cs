//PROJECT NAME: Material
//CLASS NAME: IMrpExc2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpExc2
	{
		(int? ReturnCode,
			string Infobar) MrpExc2Sp(
			string OrderNum,
			string OrderType,
			string Item,
			DateTime? DateReq,
			int? ExceptCode,
			decimal? Qty,
			int? OrdLineSuf,
			int? OrderRel,
			string Infobar,
			int? BufferExcMesg = 0,
			Guid? ProcessId = null);
	}
}

