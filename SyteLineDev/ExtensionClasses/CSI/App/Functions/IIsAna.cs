//PROJECT NAME: Data
//CLASS NAME: IIsAna.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsAna
	{
		int? IsAnaFn(
			string pJournalId);
	}
}

