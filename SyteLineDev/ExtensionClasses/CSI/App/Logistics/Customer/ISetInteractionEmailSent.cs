//PROJECT NAME: Logistics
//CLASS NAME: ISetInteractionEmailSent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISetInteractionEmailSent
	{
		(int? ReturnCode, string Infobar) SetInteractionEmailSentSp(int? PEmailSent,
		string PInteractionType,
		Guid? PInteractionRP,
		string PUserName,
		string Infobar);
	}
}

