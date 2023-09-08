//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXDispScrapPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispScrapPre
	{
		(int? ReturnCode,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSRMXDispScrapPreSp(
			Guid? DispRowPointer,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

