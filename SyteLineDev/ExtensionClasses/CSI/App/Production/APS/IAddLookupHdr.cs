//PROJECT NAME: Production
//CLASS NAME: IAddLookupHdr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IAddLookupHdr
	{
		(int? ReturnCode, string Infobar) AddLookupHdrSp(string Tabid,
		string MatrixType,
		string Infobar);
	}
}

