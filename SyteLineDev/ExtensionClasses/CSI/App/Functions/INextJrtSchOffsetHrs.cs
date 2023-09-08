//PROJECT NAME: Data
//CLASS NAME: INextJrtSchOffsetHrs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextJrtSchOffsetHrs
	{
		decimal? NextJrtSchOffsetHrsFn(
			string PJob,
			int? PSuffix,
			int? POperNum);
	}
}

