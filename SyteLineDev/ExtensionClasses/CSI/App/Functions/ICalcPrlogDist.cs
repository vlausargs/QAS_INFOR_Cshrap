//PROJECT NAME: Data
//CLASS NAME: ICalcPrlogDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcPrlogDist
	{
		decimal? CalcPrlogDistFn(
			string pEmpNum,
			int? pSeq);
	}
}

