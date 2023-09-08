//PROJECT NAME: Data
//CLASS NAME: IInternationalDateToNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInternationalDateToNumber
	{
		string InternationalDateToNumberFn(
			DateTime? DateValue);
	}
}

