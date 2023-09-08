//PROJECT NAME: Production
//CLASS NAME: IRgrpMbrsUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IRgrpMbrsUpd
	{
		(int? ReturnCode, string Infobar) RgrpMbrsUpdSp(Guid? Rowp,
		int? Seqno,
		string Rgid,
		string Resid,
		int? AltNo,
		string Infobar);
	}
}

