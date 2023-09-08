//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateTesthEsig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateTesthEsig
	{
		int? RSQC_CreateTesthEsigSp(Guid? TesteRowpointer,
		string UserName,
		string ReasonCode,
		Guid? EsigRowpointer);
	}
}

