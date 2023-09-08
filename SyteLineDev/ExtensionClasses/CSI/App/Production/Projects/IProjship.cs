//PROJECT NAME: Production
//CLASS NAME: IProjship.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjship
	{
		(int? ReturnCode, string Infobar) ProjshipSp(string PProjNum,
		int? PTaskNum,
		int? PSeq,
		decimal? PQtyToShip,
		DateTime? PShipDate,
		string PEcCode,
		int? PConsNum,
		string Infobar,
		string PExportDocId);
	}
}

