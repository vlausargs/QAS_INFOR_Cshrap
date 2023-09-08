//PROJECT NAME: Production
//CLASS NAME: IPsitemSetGloVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPsitemSetGloVar
	{
		int? PsitemSetGloVarSp(string JobWhse = null,
		string JobRevision = null);
	}
}

