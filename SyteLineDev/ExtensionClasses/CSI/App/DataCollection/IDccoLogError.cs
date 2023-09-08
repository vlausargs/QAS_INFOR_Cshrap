//PROJECT NAME: DataCollection
//CLASS NAME: IDccoLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccoLogError
	{
		int? DccoLogErrorSp(int? PTransNum,
		string ErrorMsg);
	}
}

