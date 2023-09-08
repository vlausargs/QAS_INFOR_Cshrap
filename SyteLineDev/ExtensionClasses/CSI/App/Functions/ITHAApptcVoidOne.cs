//PROJECT NAME: Data
//CLASS NAME: ITHAApptcVoidOne.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcVoidOne
	{
		(int? ReturnCode,
			string Infobar) THAApptcVoidOneSp(
			Guid? PSessionID,
			Guid? PAppmtRowPointer,
			string PPayType = null,
			string Infobar = null);
	}
}

