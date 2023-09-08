//PROJECT NAME: Data
//CLASS NAME: IMsDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMsDate
	{
		(int? ReturnCode,
			DateTime? ODate) MsDateSp(
			string IProjNum,
			string IMsNum,
			DateTime? ODate);
	}
}

