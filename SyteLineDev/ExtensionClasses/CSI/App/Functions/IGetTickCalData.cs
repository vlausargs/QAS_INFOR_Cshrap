//PROJECT NAME: Data
//CLASS NAME: IGetTickCalData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetTickCalData
	{
		(int? ReturnCode,
			decimal? PSTicks,
			int? PTickOffset,
			int? PMDays,
			int? PSLength) GetTickCalDataSp(
			int? Index,
			string Calendar,
			decimal? PRTick,
			decimal? PSTicks,
			int? PTickOffset,
			int? PMDays,
			int? PSLength);
	}
}

