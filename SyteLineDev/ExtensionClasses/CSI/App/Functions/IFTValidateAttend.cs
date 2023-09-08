//PROJECT NAME: Data
//CLASS NAME: IFTValidateAttend.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTValidateAttend
	{
		int? FTValidateAttendSp(
			Guid? SessionID);
	}
}

