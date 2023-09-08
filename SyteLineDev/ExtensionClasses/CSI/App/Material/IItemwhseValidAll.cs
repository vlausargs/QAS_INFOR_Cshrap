//PROJECT NAME: Material
//CLASS NAME: IItemwhseValidAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemwhseValidAll
	{
		(int? ReturnCode, string Infobar) ItemwhseValidAllSp(string Item,
		string Whse,
		string Site,
		string Infobar);
	}
}

