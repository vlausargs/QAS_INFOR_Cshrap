//PROJECT NAME: Data
//CLASS NAME: IItemLocCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemLocCheck
	{
		(int? ReturnCode,
			string Infobar,
			Guid? ItemlocRowPointer) ItemLocCheckSp(
			string PItem,
			string PWhse,
			string PSite = null,
			string PLoc = null,
			int? PForTransitLoc = null,
			int? PIlocCanAdd = null,
			string PIlocTrnFunct = null,
			int? POutgoing = null,
			string Infobar = null,
			int? CreateIfMissing = 0,
			Guid? ItemlocRowPointer = null);
	}
}

