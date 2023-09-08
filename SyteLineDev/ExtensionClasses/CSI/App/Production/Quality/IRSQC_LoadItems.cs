//PROJECT NAME: Production
//CLASS NAME: IRSQC_LoadItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_LoadItems
	{
		int? RSQC_LoadItemsSp(
			string i_begitem,
			string i_enditem,
			int? i_supplier,
			int? i_ip,
			int? i_customer);
	}
}

