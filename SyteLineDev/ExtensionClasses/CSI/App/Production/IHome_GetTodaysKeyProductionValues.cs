//PROJECT NAME: Production
//CLASS NAME: IHome_GetTodaysKeyProductionValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IHome_GetTodaysKeyProductionValues
	{
		(int? ReturnCode, int? CompleteQty,
		int? PastDueQty) Home_GetTodaysKeyProductionValuesSp(int? CompleteQty,
		int? PastDueQty);
	}
}

