//PROJECT NAME: Data
//CLASS NAME: IProdConfFeatureGroupR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProdConfFeatureGroupR
	{
		int? ProdConfFeatureGroupRSp(
			string ParentItem,
			string CoitemFeatStr,
			string DisplaySequence,
			string Site);
	}
}

