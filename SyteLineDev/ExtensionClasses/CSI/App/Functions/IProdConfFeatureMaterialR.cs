//PROJECT NAME: Data
//CLASS NAME: IProdConfFeatureMaterialR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProdConfFeatureMaterialR
	{
		int? ProdConfFeatureMaterialRSp(
			string ParentItem,
			string Feature,
			string CoNum,
			int? CoLine,
			string Site);
	}
}

