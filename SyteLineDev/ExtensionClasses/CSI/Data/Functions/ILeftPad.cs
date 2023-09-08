//PROJECT NAME: Data
//CLASS NAME: ILeftPad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
	public interface ILeftPad
	{
		string LeftPadFn(string String,
		string Char,
		int? Size);
	}
}

