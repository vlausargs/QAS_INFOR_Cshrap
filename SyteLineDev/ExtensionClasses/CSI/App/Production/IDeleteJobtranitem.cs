//PROJECT NAME: Production
//CLASS NAME: IDeleteJobtranitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IDeleteJobtranitem
	{
		int? DeleteJobtranitemSp(decimal? TransNum);
	}
}

