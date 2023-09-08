//PROJECT NAME: Data
//CLASS NAME: IInitDuePeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInitDuePeriod
	{
		(int? ReturnCode,
			int? PDuePeriod) InitDuePeriodSp(
			string PItem,
			string PCustNum,
			string PSite,
			int? PDuePeriod,
			string CustItem);
	}
}

