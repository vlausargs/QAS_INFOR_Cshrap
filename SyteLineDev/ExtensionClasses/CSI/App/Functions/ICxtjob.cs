//PROJECT NAME: Data
//CLASS NAME: ICxtjob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICxtjob
	{
		(int? ReturnCode,
			string Infobar) CxtjobSp(
			string CustNum,
			string Infobar);
	}
}

