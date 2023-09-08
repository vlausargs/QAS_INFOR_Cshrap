//PROJECT NAME: Production
//CLASS NAME: IRSQC_DisplayStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_DisplayStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_DisplayStatusSp(
			string i_whse,
			string i_item);
	}
}

