//PROJECT NAME: Data
//CLASS NAME: IFTValidateSRO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTValidateSRO
	{
		int? FTValidateSROSp(
			string spEmpNum,
			DateTime? spreport_date = null,
			Guid? SessionID = null);
	}
}

