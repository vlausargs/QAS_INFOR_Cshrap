//PROJECT NAME: Data
//CLASS NAME: ILastJobtran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILastJobtran
	{
		(int? ReturnCode,
			string OutPayRate,
			int? OutStartTime,
			int? OutEndTime,
			int? OutOperNum) LastJobtranSp(
			decimal? InTransNum,
			string OutPayRate,
			int? OutStartTime,
			int? OutEndTime,
			int? OutOperNum);
	}
}

