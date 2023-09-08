//PROJECT NAME: Data
//CLASS NAME: IWarningPochangeStatChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IWarningPochangeStatChange
	{
		(int? ReturnCode,
			string Infobar) WarningPochangeStatChangeSp(
			string PPoNum,
			string PNewStat,
			string Infobar);
	}
}

