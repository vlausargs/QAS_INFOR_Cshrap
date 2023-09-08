//PROJECT NAME: Data
//CLASS NAME: IChkGrnLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChkGrnLine
	{
		(int? ReturnCode,
			decimal? QtyRec,
			decimal? QtyRej) ChkGrnLineSp(
			string VendNum,
			string GrnNum,
			decimal? QtyRec,
			decimal? QtyRej);
	}
}

