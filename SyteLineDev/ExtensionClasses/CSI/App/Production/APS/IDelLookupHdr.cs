//PROJECT NAME: Production
//CLASS NAME: IDelLookupHdr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IDelLookupHdr
	{
		(int? ReturnCode, string Infobar) DelLookupHdrSp(string Tabid,
		string Infobar);
	}
}

