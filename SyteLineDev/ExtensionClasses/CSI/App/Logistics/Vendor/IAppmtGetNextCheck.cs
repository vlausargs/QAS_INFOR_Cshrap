//PROJECT NAME: Logistics
//CLASS NAME: IAppmtGetNextCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtGetNextCheck
	{
		(int? ReturnCode, int? PNextCheck) AppmtGetNextCheckSp(string PBankCode,
		string PPayType,
		int? PNextCheck);
	}
}

