//PROJECT NAME: Production
//CLASS NAME: IProdConfList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IProdConfList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProdConfListSp(string FeatStr,
		string Item,
		string CoNum,
		int? CoLine,
		int? Level,
		string Site = null,
		string FilterString = null);
	}
}

