//PROJECT NAME: Logistics
//CLASS NAME: IPurgeEDIPurchaseOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPurgeEDIPurchaseOrders
	{
		(int? ReturnCode, string Message) PurgeEDIPurchaseOrdersSp(string ExOptBegVend_Num = null,
		string ExOptEndVend_Num = null,
		string ExOptBegPo = null,
		string ExOptEndPo = null,
		DateTime? ExOptBegPost_Date = null,
		DateTime? ExOptEndPost_Date = null,
		DateTime? ExOptBegorder_Date = null,
		DateTime? ExOptEndorder_Date = null,
		string ExOptprPostedEmp = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		string Message = null);
	}
}

