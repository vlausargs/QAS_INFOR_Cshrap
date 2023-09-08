//PROJECT NAME: DataCollection
//CLASS NAME: IDcitemLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcitemLogError
	{
		int? DcitemLogErrorSp(int? PTransNum,
		int? PCanOverride,
		string ErrorMsg);
	}
}

