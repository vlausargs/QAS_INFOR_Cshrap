//PROJECT NAME: Production
//CLASS NAME: IJobtClsLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtClsLogError
	{
		int? JobtClsLogErrorSp(decimal? PTransNum,
		string ErrorMsg);
	}
}

