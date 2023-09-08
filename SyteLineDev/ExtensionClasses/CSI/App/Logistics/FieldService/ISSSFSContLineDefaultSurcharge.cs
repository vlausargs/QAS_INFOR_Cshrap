//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContLineDefaultSurcharge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContLineDefaultSurcharge
	{
		(int? ReturnCode,
			string InfoBar) SSSFSContLineDefaultSurchargeSp(
			string Contract,
			int? ContLine,
			string Item,
			string InfoBar);
	}
}

