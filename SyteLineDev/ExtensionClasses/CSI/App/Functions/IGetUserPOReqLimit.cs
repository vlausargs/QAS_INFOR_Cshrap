//PROJECT NAME: Data
//CLASS NAME: IGetUserPOReqLimit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetUserPOReqLimit
	{
		(int? ReturnCode,
			decimal? PreqLimit,
			decimal? PreqItemLimit,
			string Infobar) GetUserPOReqLimitSp(
			string UserName,
			decimal? PreqLimit,
			decimal? PreqItemLimit,
			string Infobar);
	}
}

