//PROJECT NAME: Codes
//CLASS NAME: IValidateShift.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IValidateShift
	{
		(int? ReturnCode, string Infobar) ValidateShiftSp(string Shift,
		DateTime? PEffDate,
		string Infobar);
	}
}

