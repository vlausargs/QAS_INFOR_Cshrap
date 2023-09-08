//PROJECT NAME: Production
//CLASS NAME: IRgrpDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IRgrpDel
	{
		(int? ReturnCode, string Infobar) RgrpDelSp(string Rgid,
		int? AltNo,
		string Infobar);
	}
}

