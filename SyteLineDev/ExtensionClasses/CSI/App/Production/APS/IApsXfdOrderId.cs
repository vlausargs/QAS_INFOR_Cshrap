//PROJECT NAME: Production
//CLASS NAME: IApsXfdOrderId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsXfdOrderId
	{
		string ApsXfdOrderIdFn(
			string Site,
			string RefNum);
	}
}

