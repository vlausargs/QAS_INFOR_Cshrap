//PROJECT NAME: Data
//CLASS NAME: IEdiJulStmp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiJulStmp
	{
		string EdiJulStmpFn(
			DateTime? Date);
	}
}

