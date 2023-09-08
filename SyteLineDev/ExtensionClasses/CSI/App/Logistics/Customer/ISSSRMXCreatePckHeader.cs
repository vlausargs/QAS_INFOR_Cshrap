//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXCreatePckHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXCreatePckHeader
	{
		(int? ReturnCode,
			string Infobar) SSSRMXCreatePckHeaderSp(
			string TPckCall,
			string RefNum,
			string VendNum,
			string ShipCode,
			int? QtyPackages,
			decimal? Weight,
			DateTime? PackDate,
			string Whse,
			string ProcessId,
			int? PackNum,
			string Infobar);
	}
}

