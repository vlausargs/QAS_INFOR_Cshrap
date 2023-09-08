//PROJECT NAME: Logistics
//CLASS NAME: IValidateInvSequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateInvSequence
	{
		(int? ReturnCode, string PStartingInvNum,
		string PEndingInvNum,
		DateTime? PStartingInvDate,
		DateTime? PEndingInvDate,
		string Infobar) ValidateInvSequenceSp(string PArtranType,
		string PInvCategory,
		string PStartingInvNum,
		string PEndingInvNum,
		DateTime? PStartingInvDate,
		DateTime? PEndingInvDate,
		string Infobar);
	}
}

