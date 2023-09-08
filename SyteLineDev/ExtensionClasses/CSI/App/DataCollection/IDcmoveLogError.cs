//PROJECT NAME: DataCollection
//CLASS NAME: IDcmoveLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmoveLogError
	{
		int? DcmoveLogErrorSp(int? PTransNum,
		int? PCanOverride,
		string ErrorMsg);
	}
}

