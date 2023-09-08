//PROJECT NAME: Data
//CLASS NAME: IFTValidateProject.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTValidateProject
	{
		int? FTValidateProjectSp(
			string spEmpNum,
			DateTime? spreport_date = null,
			Guid? SessionID = null);
	}
}

