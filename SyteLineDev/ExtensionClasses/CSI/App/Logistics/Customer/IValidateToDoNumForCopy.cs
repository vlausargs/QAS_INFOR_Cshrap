//PROJECT NAME: Logistics
//CLASS NAME: IValidateToDoNumForCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateToDoNumForCopy
	{
		(int? ReturnCode, string CopyLines,
		string CopyOption,
		string Infobar) ValidateToDoNumForCopySp(string FROMDoNum,
		string ToDoNum,
		string CopyLines,
		string CopyOption,
		string Infobar);
	}
}

