//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXDispRTIPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispRTIPre
	{
		(int? ReturnCode,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSRMXDispRTIPreSp(
			Guid? DispRowPointer,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

