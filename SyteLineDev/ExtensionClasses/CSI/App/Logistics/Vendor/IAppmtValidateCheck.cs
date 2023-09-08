//PROJECT NAME: Logistics
//CLASS NAME: IAppmtValidateCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtValidateCheck
	{
		(int? ReturnCode, string Infobar) AppmtValidateCheckSp(int? PNewRecord,
		string PBankCode,
		int? PCheckNum,
		string PPayType,
		int? PReapplication,
		string Infobar);
	}
}

