//PROJECT NAME: Data
//CLASS NAME: ICalcObjChecksum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcObjChecksum
	{
		int? CalcObjChecksumFn(
			string ObjectName);
	}
}

