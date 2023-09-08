//PROJECT NAME: DataCollection
//CLASS NAME: IDcjitLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjitLogError
	{
		int? DcjitLogErrorSp(int? PTransNum,
		int? PCanOverride,
		string ErrorMsg);
	}
}

