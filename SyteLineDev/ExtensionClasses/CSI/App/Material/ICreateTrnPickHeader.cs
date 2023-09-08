//PROJECT NAME: Material
//CLASS NAME: ICreateTrnPickHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICreateTrnPickHeader
	{
		(int? ReturnCode, int? PackNum,
		string Infobar) CreateTrnPickHeaderSp(string PTrnNum,
		string PToSite,
		string PFromWhse,
		string PToWhse,
		string PTransStatT,
		string PTransStatC,
		decimal? PWeight,
		int? PQtyPackages,
		string PShipCode,
		DateTime? PPackDate,
		string PLineStatT,
		string PLineStatC,
		int? PBegTrnLine,
		int? PEndTrnLine,
		DateTime? PBegDueDate,
		DateTime? PEndDueDate,
		int? DoLines,
		int? PackNum,
		string Infobar);
	}
}

