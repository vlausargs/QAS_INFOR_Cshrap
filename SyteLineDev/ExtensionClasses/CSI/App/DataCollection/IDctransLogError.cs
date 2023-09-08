//PROJECT NAME: DataCollection
//CLASS NAME: IDctransLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDctransLogError
	{
		int? DctransLogErrorSp(int? PTransNum,
		string ErrorMsg);
	}
}

