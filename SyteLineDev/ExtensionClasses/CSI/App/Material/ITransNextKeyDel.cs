//PROJECT NAME: Material
//CLASS NAME: ITransNextKeyDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITransNextKeyDel
	{
		(int? ReturnCode, string Infobar) TransNextKeyDelSp(string TrnNum,
		string Infobar);
	}
}

