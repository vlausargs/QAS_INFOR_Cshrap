//PROJECT NAME: Finance
//CLASS NAME: IApPostRemClearTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IApPostRemClearTT
	{
		(int? ReturnCode,
			string Infobar) ApPostRemClearTTSp(
			Guid? PSessionID,
			int? PPrintedFlag = null,
			int? PPostedFlag = null,
			string Infobar = null);
	}
}

