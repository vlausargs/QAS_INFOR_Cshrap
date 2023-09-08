//PROJECT NAME: Material
//CLASS NAME: IProdConfFeatureGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IProdConfFeatureGroup
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProdConfFeatureGroupSp(string ParentItem,
		string CoitemFeatStr = null,
		string Site = null);
	}
}

