//PROJECT NAME: Data
//CLASS NAME: IChgRemoteCoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChgRemoteCoitem
	{
		int? ChgRemoteCoitemSp(
			string coitemNum,
			int? coitemLine,
			int? coitemRelease,
			string cotype,
			decimal? qty_ordered,
			decimal? qty_shipped,
			string item,
			string cust_num,
			string whse);
	}
}

