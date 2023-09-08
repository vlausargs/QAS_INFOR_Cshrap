//PROJECT NAME: Production
//CLASS NAME: IProdConfFeatureMaterial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IProdConfFeatureMaterial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProdConfFeatureMaterialSp(string ParentItem,
		string Feature,
		string CoNum,
		int? CoLine,
		string Site = null);
	}
}

