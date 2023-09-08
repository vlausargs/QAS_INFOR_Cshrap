//PROJECT NAME: Data
//CLASS NAME: IParseSerialPrefix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IParseSerialPrefix
	{
		string ParseSerialPrefixFn(
			string ItemPrefix,
			DateTime? Date,
			string RefType,
			string Site);
	}
}

