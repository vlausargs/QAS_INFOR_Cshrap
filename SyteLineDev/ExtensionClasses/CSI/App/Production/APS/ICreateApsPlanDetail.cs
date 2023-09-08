//PROJECT NAME: Production
//CLASS NAME: ICreateApsPlanDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICreateApsPlanDetail
	{
		int? CreateApsPlanDetailSp(
			string OrderId);
	}
}

