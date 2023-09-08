//PROJECT NAME: Material
//CLASS NAME: IWhseValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IWhseValid
	{
		(int? ReturnCode, string Infobar) WhseValidSp(string Whse,
		string Infobar);
	}
}

