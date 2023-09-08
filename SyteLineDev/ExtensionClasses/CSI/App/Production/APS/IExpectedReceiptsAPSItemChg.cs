//PROJECT NAME: Production
//CLASS NAME: IExpectedReceiptsAPSItemChg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IExpectedReceiptsAPSItemChg
	{
		(int? ReturnCode,
		string Description) ExpectedReceiptsAPSItemChgSp(
			string Item,
			string Description);
	}
}

