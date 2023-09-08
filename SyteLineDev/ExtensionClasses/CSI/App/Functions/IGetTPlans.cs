//PROJECT NAME: Data
//CLASS NAME: IGetTPlans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetTPlans
	{
		(int? ReturnCode,
			string tplans) GetTPlansSp(
			string de_code,
			string tplans);
	}
}

