//PROJECT NAME: Admin
//CLASS NAME: IBI_SSSFSWarrAct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IBI_SSSFSWarrAct
	{
		int? BI_SSSFSWarrActFn(
			string iCompID,
			string iWarrCode = null,
			DateTime? iDate = null,
			int? iMeter = null,
			string site = null);
	}
}

