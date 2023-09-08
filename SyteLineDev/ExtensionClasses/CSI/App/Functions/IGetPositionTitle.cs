//PROJECT NAME: Data
//CLASS NAME: IGetPositionTitle.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPositionTitle
	{
		string GetPositionTitleFn(
			string EmpNum,
			DateTime? Jobdate);
	}
}

