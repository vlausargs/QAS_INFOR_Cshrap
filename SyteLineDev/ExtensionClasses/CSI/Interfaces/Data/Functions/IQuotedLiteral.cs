//PROJECT NAME: Data
//CLASS NAME: IQuotedLiteral.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
	public interface IQuotedLiteral
	{
		string QuotedLiteralFn(string Value);
	}
}

