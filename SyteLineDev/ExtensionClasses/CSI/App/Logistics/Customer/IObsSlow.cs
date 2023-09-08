//PROJECT NAME: Logistics
//CLASS NAME: IObsSlow.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IObsSlow
	{
		(int? ReturnCode,
			string Infobar,
			string Prompt,
			string PromptButtons) ObsSlowSp(
			string Item,
			int? WarnIfSlowMoving = 1,
			int? ErrorIfSlowMoving = 0,
			int? WarnIfObsolete = 0,
			int? ErrorIfObsolete = 1,
			string Infobar = null,
			string Prompt = null,
			string PromptButtons = null,
			string Site = null);
	}
}

