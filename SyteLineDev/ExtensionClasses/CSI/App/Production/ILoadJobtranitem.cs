//PROJECT NAME: Production
//CLASS NAME: ILoadJobtranitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ILoadJobtranitem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) LoadJobtranitemSp(decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		string FilterString = null);
	}
}

