//PROJECT NAME: Data
//CLASS NAME: IChkCurrPer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChkCurrPer
	{
		(int? ReturnCode,
			string WarmMsg) ChkCurrPerSp(
			DateTime? Date,
			string WarmMsg);
	}
}

