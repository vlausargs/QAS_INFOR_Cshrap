//PROJECT NAME: DataCollection
//CLASS NAME: IDcpsLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcpsLogError
	{
		int? DcpsLogErrorSp(int? PTransNum,
		string ErrorMsg);
	}
}

