//PROJECT NAME: Data
//CLASS NAME: ISyncline.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISyncline
	{
		(int? ReturnCode,
			string Infobar) SynclineSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string CoOrigSite,
			string ShipSite,
			string Infobar);
	}
}

