//PROJECT NAME: Admin
//CLASS NAME: IDeleteGDPRData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IDeleteGDPRData
	{
		int? DeleteGDPRDataSP(Guid? ProcessId);
	}
}

