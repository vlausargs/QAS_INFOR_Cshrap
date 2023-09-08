//PROJECT NAME: Finance
//CLASS NAME: IGlPostDeleteTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGlPostDeleteTT
	{
		int? GlPostDeleteTTSp(Guid? PSessionID);
	}
}

