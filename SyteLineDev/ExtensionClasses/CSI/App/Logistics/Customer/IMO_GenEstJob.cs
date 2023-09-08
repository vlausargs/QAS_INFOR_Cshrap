//PROJECT NAME: Logistics
//CLASS NAME: IMO_GenEstJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IMO_GenEstJob
	{
		(int? ReturnCode, string Infobar) MO_GenEstJobSp(string CoNum,
		int? CoLine,
		string Item,
		decimal? QtyOrdered,
		int? ProductCycle,
		decimal? QtyPerCycle,
		DateTime? DueDate,
		string Whse,
		string BOMType,
		string CoProductMix,
		string AlternateID,
		string Resource,
		string Infobar);
	}
}

