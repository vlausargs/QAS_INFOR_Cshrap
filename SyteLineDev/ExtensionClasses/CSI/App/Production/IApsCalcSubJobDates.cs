//PROJECT NAME: Production
//CLASS NAME: IApsCalcSubJobDates.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IApsCalcSubJobDates
	{
		(int? ReturnCode, int? ApsCalcSubJobDates) ApsCalcSubJobDatesSp(int? ApsCalcSubJobDates);

		int? ApsCalcSubJobDatesFn();
	}
}

