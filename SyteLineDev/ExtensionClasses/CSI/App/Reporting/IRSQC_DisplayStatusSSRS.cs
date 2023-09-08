//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_DisplayStatusSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_DisplayStatusSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_DisplayStatusSSRSSp(string i_whse,
		string i_item,
		string psite);
	}
}

