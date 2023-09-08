//PROJECT NAME: Data
//CLASS NAME: IValidateJobOrdersXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateJobOrdersXref
	{
		(int? ReturnCode,
			string Infobar) ValidateJobOrdersXrefSp(
			string POrdType,
			string POrdNum,
			int? POrdLine,
			int? POrdRelease,
			string Infobar);
	}
}

