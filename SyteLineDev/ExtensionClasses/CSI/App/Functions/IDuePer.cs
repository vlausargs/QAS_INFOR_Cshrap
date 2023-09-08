//PROJECT NAME: Data
//CLASS NAME: IDuePer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDuePer
	{
		(int? ReturnCode,
			int? DuePeriod) DuePerSp(
			string Item,
			string CustNum,
			int? DuePeriod,
			string CustItem);
	}
}

