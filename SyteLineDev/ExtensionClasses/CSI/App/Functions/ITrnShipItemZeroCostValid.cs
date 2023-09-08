//PROJECT NAME: Data
//CLASS NAME: ITrnShipItemZeroCostValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrnShipItemZeroCostValid
	{
		(int? ReturnCode,
			string Infobar) TrnShipItemZeroCostValidSp(
			string PTrnNum,
			int? PTrnLine,
			string PFromSite,
			string PFromWhse,
			int? MoveZeroCostItem = 0,
			string Infobar = null);
	}
}

