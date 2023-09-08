//PROJECT NAME: Logistics
//CLASS NAME: ISSSOPMOperReceive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSOPMOperReceive
	{
		(int? ReturnCode,
			string Infobar) SSSOPMOperReceiveSp(
			string job,
			int? suffix,
			int? oper_num,
			decimal? qty_moved,
			string Infobar,
			int? ThisSequenceOnly = null);
	}
}

