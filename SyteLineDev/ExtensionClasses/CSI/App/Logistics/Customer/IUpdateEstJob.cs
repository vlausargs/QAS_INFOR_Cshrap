//PROJECT NAME: Logistics
//CLASS NAME: IUpdateEstJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUpdateEstJob
	{
		(int? ReturnCode, string Infobar) UpdateEstJobSp(string EstNum,
		int? EstLine,
		string RefNum,
		int? RefLineSuf,
		int? ProductCycle,
		decimal? QtyCycle,
		string Item,
		string BOMType,
		string CoProductMix,
		string AlternateID,
		string Infobar);
	}
}

