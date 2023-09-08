//PROJECT NAME: Data
//CLASS NAME: ITaxFreeCreateLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITaxFreeCreateLot
	{
		(int? ReturnCode,
			string Infobar) TaxFreeCreateLotSp(
			string pItem,
			string pRevision = null,
			string Infobar = null);
	}
}

