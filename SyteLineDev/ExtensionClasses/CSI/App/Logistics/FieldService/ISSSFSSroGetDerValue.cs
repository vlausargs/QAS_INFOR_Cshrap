//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroGetDerValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroGetDerValue
	{
		decimal? SSSFSSroGetDerValueFn(
			string SroNum,
			string InParm);
	}
}

