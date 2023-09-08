//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetDefMatlTransType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetDefMatlTransType
	{
		(int? ReturnCode,
		string MatlTransType) SSSFSGetDefMatlTransTypeSp(
			string MatlTransType);
	}
}

