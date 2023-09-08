//PROJECT NAME: Data
//CLASS NAME: IPojob3I.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPojob3I
	{
		(int? ReturnCode,
			string TToLot,
			int? TGetLot,
			string PromptMsg,
			string PromptButtons,
			string Infobar) Pojob3ISp(
			int? ItemLotTracked,
			string JobItem,
			decimal? TMove,
			string TToLot,
			int? TGetLot,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

