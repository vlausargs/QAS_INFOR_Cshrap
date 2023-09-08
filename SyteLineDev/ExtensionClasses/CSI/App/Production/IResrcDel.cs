//PROJECT NAME: Production
//CLASS NAME: IResrcDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IResrcDel
	{
		(int? ReturnCode, string Infobar) ResrcDelSp(string Resid,
		int? AltNo,
		string Infobar);
	}
}

