//PROJECT NAME: DataCollection
//CLASS NAME: IDcwcLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcwcLogError
	{
		int? DcwcLogErrorSp(int? PTransNum,
		string ErrorMsg);
	}
}

