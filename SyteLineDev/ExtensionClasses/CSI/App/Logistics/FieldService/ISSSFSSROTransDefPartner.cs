//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransDefPartner.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROTransDefPartner
	{
		(int? ReturnCode,
			string PartnerID,
			string Name,
			string Infobar) SSSFSSROTransDefPartnerSp(
			string SRONum,
			int? SROLine,
			int? SROOper,
			string PartnerID,
			string Name,
			string Infobar);
	}
}

