//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetDefConfigRemovalReason.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetDefConfigRemovalReason
	{
		(int? ReturnCode,
		string ConfigReason) SSSFSGetDefConfigRemovalReasonSp(
			string ConfigReason);
	}
}

