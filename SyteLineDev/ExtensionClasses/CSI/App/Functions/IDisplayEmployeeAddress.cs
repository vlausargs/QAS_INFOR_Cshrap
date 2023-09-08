//PROJECT NAME: Data
//CLASS NAME: IDisplayEmployeeAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayEmployeeAddress
	{
		string DisplayEmployeeAddressSp(
			string EmpNum);
	}
}

