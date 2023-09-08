//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetIQCDerAgeInd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetIQCDerAgeInd
	{
		string SSSFSGetIQCDerAgeIndFn(
			DateTime? AsOfDate,
			string IncNum);
	}
}

