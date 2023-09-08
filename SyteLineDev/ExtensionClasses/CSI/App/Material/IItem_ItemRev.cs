//PROJECT NAME: Material
//CLASS NAME: IItem_ItemRev.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItem_ItemRev
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Item_ItemRevSp(string sTreeFilter,
		string sStartingRevision,
		string sEndingRevision,
		int? sAlternateFilter = null);
	}
}

