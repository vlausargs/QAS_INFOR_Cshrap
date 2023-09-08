//PROJECT NAME: Finance
//CLASS NAME: IArPostRemUpdTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArPostRemUpdTT
	{
		(int? ReturnCode,
			string Infobar) ArPostRemUpdTTSp(
			Guid? PSessionID,
			int? PPrintedFlag = null,
			int? PPostedFlag = null,
			string Infobar = null);
	}
}

