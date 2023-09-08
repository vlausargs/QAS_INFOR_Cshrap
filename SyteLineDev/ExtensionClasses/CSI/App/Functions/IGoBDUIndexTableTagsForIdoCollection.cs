//PROJECT NAME: Data
//CLASS NAME: IGoBDUIndexTableTagsForIdoCollection.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGoBDUIndexTableTagsForIdoCollection
	{
		string GoBDUIndexTableTagsForIdoCollectionFn(
			DateTime? TransDateBeg,
			DateTime? TransDateEnd,
			string CollectionName);
	}
}

