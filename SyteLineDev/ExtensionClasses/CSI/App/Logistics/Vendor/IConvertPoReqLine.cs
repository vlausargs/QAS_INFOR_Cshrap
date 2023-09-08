//PROJECT NAME: Logistics
//CLASS NAME: IConvertPoReqLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IConvertPoReqLine
	{
		(int? ReturnCode,
			string PErrors,
			string Infobar) ConvertPoReqLineSp(
			string PItem,
			string PPoNum,
			string PReqNum,
			int? PReqLine,
			int? PCopyText,
			int? PPoChangeOrd,
			string PErrors,
			string Infobar,
			string CostCode = null,
			int? PCreatePo = null);
	}
}

