//PROJECT NAME: Data
//CLASS NAME: IJmatlBf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJmatlBf
	{
		(int? ReturnCode,
			string Job,
			int? Suffix) JmatlBfSp(
			string Whse,
			string Item,
			string Loc,
			string Job,
			int? Suffix);
	}
}

