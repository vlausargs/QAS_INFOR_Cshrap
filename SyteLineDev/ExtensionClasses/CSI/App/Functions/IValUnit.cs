//PROJECT NAME: Data
//CLASS NAME: IValUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValUnit
	{
		(int? ReturnCode,
			string Infobar) ValUnitSp(
			Guid? PItemlocRowPointer,
			Guid? PProdcodeRowPointer,
			string Infobar,
			string Site = null);
	}
}

