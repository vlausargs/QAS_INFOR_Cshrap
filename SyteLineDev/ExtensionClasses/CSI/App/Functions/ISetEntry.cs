//PROJECT NAME: Data
//CLASS NAME: ISetEntry.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetEntry
	{
		string SetEntryFn(
			int? Entry,
			string List,
			string Item,
			string Delim = ",");
	}
}

