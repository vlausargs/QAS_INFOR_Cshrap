//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetInspectionResponses.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetInspectionResponses
	{
		string SSSFSGetInspectionResponsesFn(
			string MeasType);
	}
}

