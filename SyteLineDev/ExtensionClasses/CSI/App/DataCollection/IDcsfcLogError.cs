//PROJECT NAME: DataCollection
//CLASS NAME: IDcsfcLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcsfcLogError
	{
		int? DcsfcLogErrorSp(int? PTransNum,
		int? PCanOverride,
		string ErrorMsg);
	}
}

