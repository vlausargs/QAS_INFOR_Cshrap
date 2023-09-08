//PROJECT NAME: Logistics
//CLASS NAME: IValidatorRefPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidatorRefPickList
	{
		(int? ReturnCode, string Infobar) ValidatorRefPickListSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Infobar);
	}
}

