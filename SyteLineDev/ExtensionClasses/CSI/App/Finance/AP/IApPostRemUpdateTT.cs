//PROJECT NAME: Finance
//CLASS NAME: IApPostRemUpdateTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IApPostRemUpdateTT
	{
		(int? ReturnCode,
			string Infobar) ApPostRemUpdateTTSp(
			Guid? PSessionID,
			int? PPrintedFlag = null,
			int? PPostedFlag = null,
			string Infobar = null);
	}
}

