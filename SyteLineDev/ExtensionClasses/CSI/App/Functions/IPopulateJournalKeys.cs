//PROJECT NAME: Data
//CLASS NAME: IPopulateJournalKeys.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPopulateJournalKeys
	{
		int? PopulateJournalKeysSp();
	}
}

