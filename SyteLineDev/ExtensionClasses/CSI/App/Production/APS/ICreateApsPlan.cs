//PROJECT NAME: Production
//CLASS NAME: ICreateApsPlan.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICreateApsPlan
	{
		int? CreateApsPlanSp(
			string OrderId);
	}
}

