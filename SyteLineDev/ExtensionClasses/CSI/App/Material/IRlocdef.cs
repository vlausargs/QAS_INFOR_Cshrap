//PROJECT NAME: Material
//CLASS NAME: IRlocdef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRlocdef
	{
		(int? ReturnCode, string Loc,
		string Infobar) RlocdefSp(string Site = null,
		string Whse = null,
		string Item = null,
		string Loc = null,
		string Infobar = null);
	}
}

