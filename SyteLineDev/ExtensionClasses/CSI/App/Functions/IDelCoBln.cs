//PROJECT NAME: Data
//CLASS NAME: IDelCoBln.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDelCoBln
	{
		(int? ReturnCode,
			string Infobar) DelCoBlnSp(
			string CoNum,
			int? CoLine,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null);
	}
}

