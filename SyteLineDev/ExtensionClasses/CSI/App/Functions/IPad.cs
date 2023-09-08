//PROJECT NAME: Data
//CLASS NAME: IPad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPad
	{
		string PadFn(
			int? l,
			string s);
	}
}

