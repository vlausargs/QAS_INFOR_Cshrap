//PROJECT NAME: Production
//CLASS NAME: IProjMatlChng.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjMatlChng
	{
		int? ProjMatlChngSp(
			string PItem,
			decimal? PQty);
	}
}

