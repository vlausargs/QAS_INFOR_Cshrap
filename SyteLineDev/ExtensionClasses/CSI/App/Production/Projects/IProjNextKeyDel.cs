//PROJECT NAME: Production
//CLASS NAME: IProjNextKeyDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjNextKeyDel
	{
		(int? ReturnCode, string Infobar) ProjNextKeyDelSp(string ProjNum,
		string Infobar);
	}
}

