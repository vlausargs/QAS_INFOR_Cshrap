//PROJECT NAME: Data
//CLASS NAME: ILocalJournalId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILocalJournalId
	{
		string LocalJournalIdFn(
			string pJournalId);
	}
}

