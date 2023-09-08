//PROJECT NAME: Production
//CLASS NAME: IWhatIfExpectedReceiptsItemChg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IWhatIfExpectedReceiptsItemChg
	{
		(int? ReturnCode, string Description) WhatIfExpectedReceiptsItemChgSp(int? AltNo,
		string Item,
		string Description);
	}
}

