//PROJECT NAME: Logistics
//CLASS NAME: IPurgeEDIASN.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPurgeEDIASN
	{
		(int? ReturnCode, string Message) PurgeEDIASNSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		string ExOptprPostedEmp = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		string Message = null);
	}
}

