//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXGetQtyDisp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXGetQtyDisp
	{
			(int? ReturnCode,
			decimal? RmxQtyDisp,
			string Infobar) 
		SSSRMXGetQtyDispSp(
			string RmaNum,
			int? RmaLine,
			decimal? RmxQtyDisp,
			string Infobar);
	}
}

