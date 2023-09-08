//PROJECT NAME: Codes
//CLASS NAME: IGetParmsTimeZone.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetParmsTimeZone
	{
		(int? ReturnCode, string ParmsTimeZone) GetParmsTimeZoneSP(string ParmsTimeZone);
	}
}

