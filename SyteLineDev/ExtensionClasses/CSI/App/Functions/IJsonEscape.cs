//PROJECT NAME: Data
//CLASS NAME: IJsonEscape.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJsonEscape
	{
		string JsonEscapeFn(
			string value);
	}
}

