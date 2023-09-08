//PROJECT NAME: DataCollection
//CLASS NAME: IDcjmLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjmLogError
	{
		int? DcjmLogErrorSp(int? PTransNum,
		int? pCanOverride,
		string ErrorMsg);
	}
}

