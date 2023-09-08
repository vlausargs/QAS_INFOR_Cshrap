//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchaseOrder0.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PurchaseOrder0
	{
		(int? ReturnCode,
			string Infobar) Rpt_PurchaseOrder0Sp(
			string pPoType = null,
			string pPoStat = null,
			string pPoitemStat = null,
			string pStartPoNum = null,
			string pEndPoNum = null,
			int? pStartPoLine = null,
			int? pEndPoLine = null,
			int? pStartPoRElease = null,
			int? pEndPoRelease = null,
			DateTime? pStartDueDate = null,
			DateTime? pEndDueDate = null,
			string pStartvendor = null,
			string pEndVendor = null,
			DateTime? pStartorderDate = null,
			DateTime? pEndOrderDate = null,
			string SessionId = null,
			string Infobar = null);
	}
}

