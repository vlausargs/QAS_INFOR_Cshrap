//PROJECT NAME: Data
//CLASS NAME: ITHAApptcOne.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcOne
	{
		(int? ReturnCode,
			string Infobar) THAApptcOneSp(
			Guid? PSessionID,
			Guid? PAppmtRowPointer,
			string PPayType = null,
			string Infobar = null);
	}
}

