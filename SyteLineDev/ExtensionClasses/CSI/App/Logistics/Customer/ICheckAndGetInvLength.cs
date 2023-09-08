//PROJECT NAME: Logistics
//CLASS NAME: ICheckAndGetInvLength.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckAndGetInvLength
	{
		(int? ReturnCode,
		int? Result,
		int? KeyLength,
		int? PromptTaxDisc,
		string Infobar) CheckAndGetInvLength(
			string KeyName,
			int? Result,
			int? KeyLength,
			int? PromptTaxDisc,
			string Infobar);
	}
}

