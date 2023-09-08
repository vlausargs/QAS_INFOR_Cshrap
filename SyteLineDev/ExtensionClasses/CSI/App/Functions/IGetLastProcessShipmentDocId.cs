//PROJECT NAME: Data
//CLASS NAME: IGetLastProcessShipmentDocId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetLastProcessShipmentDocId
	{
		(int? ReturnCode,
			string LastProcessShipmentDocId,
			string Infobar) GetLastProcessShipmentDocIdSp(
			string CoNum,
			string TrnNum,
			string Whse,
			string ShipSite,
			DateTime? DueDate,
			Guid? Rowpointer,
			string LastProcessShipmentDocId,
			string Infobar);
	}
}

