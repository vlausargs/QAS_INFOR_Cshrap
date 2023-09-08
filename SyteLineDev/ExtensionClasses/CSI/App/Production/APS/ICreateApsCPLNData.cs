//PROJECT NAME: Production
//CLASS NAME: ICreateApsCPLNData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICreateApsCPLNData
	{
		int? CreateApsCPLNDataSp(
			string OrderId);
	}
}

