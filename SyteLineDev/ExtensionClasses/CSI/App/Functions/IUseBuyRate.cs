//PROJECT NAME: Data
//CLASS NAME: IUseBuyRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUseBuyRate
	{
		int? UseBuyRateFn(
			string Type,
			string RefType,
			string BankCode);
	}
}

