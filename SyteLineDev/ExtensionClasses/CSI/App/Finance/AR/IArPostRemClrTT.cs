//PROJECT NAME: Finance
//CLASS NAME: IArPostRemClrTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArPostRemClrTT
	{
		(int? ReturnCode,
			string Infobar) ArPostRemClrTTSp(
			Guid? PSessionID,
			int? PPrintedFlag = null,
			int? PPostedFlag = null,
			string Infobar = null);
	}
}

