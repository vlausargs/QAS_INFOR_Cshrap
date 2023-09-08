//PROJECT NAME: Data
//CLASS NAME: IFormatAddressShort.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatAddressShort
	{
		string FormatAddressShortFn(
			string CustNum,
			int? CustSeq);
	}
}

