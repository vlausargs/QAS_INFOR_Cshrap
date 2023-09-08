//PROJECT NAME: Data
//CLASS NAME: IDisplayEmployeeAddressWithPhoneSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayEmployeeAddressWithPhone
	{
		string DisplayEmployeeAddressWithPhoneSp(
			string EmpNum);
	}
}

