//PROJECT NAME: DataCollection
//CLASS NAME: IDcpoLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcpoLogError
	{
		int? DcpoLogErrorSp(int? PTransNum,
		string ErrorMsg);
	}
}

