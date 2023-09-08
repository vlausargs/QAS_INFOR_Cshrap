//PROJECT NAME: Data
//CLASS NAME: IConvDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvDate
	{
		string ConvDateFn(
			DateTime? pInputDate,
			string pFormat);
	}
}

