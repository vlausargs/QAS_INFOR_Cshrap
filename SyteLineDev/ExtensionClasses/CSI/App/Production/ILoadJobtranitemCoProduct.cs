//PROJECT NAME: Production
//CLASS NAME: ILoadJobtranitemCoProduct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ILoadJobtranitemCoProduct
	{
		(ICollectionLoadResponse Data, int? ReturnCode) LoadJobtranitemCoProductSp(decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		string FilterString = null);
	}
}

