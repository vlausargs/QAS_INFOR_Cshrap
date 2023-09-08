//PROJECT NAME: Production
//CLASS NAME: IMO_LoadCoJobtranitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IMO_LoadCoJobtranitem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MO_LoadCoJobtranitemSp(decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		string FilterString);
	}
}

