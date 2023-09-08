//PROJECT NAME: Logistics
//CLASS NAME: IValidateFromDoNumForCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateFromDoNumForCopy
	{
		(int? ReturnCode, string CopyLines,
		int? StartLineNum,
		int? EndLineNum,
		string Infobar) ValidateFromDoNumForCopySp(string FROMDoNum,
		string CopyLines,
		int? StartLineNum,
		int? EndLineNum,
		string Infobar);
	}
}

