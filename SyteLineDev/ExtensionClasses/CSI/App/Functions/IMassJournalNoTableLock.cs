//PROJECT NAME: Data
//CLASS NAME: IMassJournalNoTableLock.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMassJournalNoTableLock
	{
		int? MassJournalNoTableLockSp(
			string Site);
	}
}

