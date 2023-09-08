//PROJECT NAME: Data
//CLASS NAME: IGetProdcode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetProdcode
	{
		(int? ReturnCode,
			string PProdcode,
			string PPricecode,
			string PPricecodeDesc,
			decimal? PUnitCost,
			decimal? PCurUCost) GetProdcodeSp(
			string PItem,
			string PProdcode,
			string PPricecode,
			string PPricecodeDesc,
			decimal? PUnitCost,
			decimal? PCurUCost);
	}
}

