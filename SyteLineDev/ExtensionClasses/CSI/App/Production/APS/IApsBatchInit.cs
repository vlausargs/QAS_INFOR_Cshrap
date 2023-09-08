//PROJECT NAME: Production
//CLASS NAME: IApsBatchInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBatchInit
	{
		int? ApsBatchInitSp(
			int? AltNo);
	}
}

