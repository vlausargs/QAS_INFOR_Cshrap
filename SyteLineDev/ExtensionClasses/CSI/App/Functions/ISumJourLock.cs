//PROJECT NAME: Data
//CLASS NAME: ISUMJourLock.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISUMJourLock
	{
		(int? ReturnCode,
			string Infobar) SUMJourLockSp(
			string Id,
			string Infobar);
	}
}

