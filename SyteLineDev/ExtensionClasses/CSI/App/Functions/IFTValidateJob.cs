//PROJECT NAME: Data
//CLASS NAME: IFTValidatejob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTValidatejob
	{
		int? FTValidatejobSp(
			string spEmpNum,
			DateTime? spreport_date = null,
			int? hdr_processed = null,
			Guid? SessionID = null);
	}
}

