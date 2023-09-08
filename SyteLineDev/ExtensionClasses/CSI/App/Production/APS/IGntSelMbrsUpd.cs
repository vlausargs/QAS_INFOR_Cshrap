//PROJECT NAME: Production
//CLASS NAME: IGntSelMbrsUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IGntSelMbrsUpd
	{
		(int? ReturnCode, string Infobar) GntSelMbrsUpdSp(Guid? Rowp,
		string Selid,
		int? Seqnum,
		string Resid,
		string Infobar);
	}
}

