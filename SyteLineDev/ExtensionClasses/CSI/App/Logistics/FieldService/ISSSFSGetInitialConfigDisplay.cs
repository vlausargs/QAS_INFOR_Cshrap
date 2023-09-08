//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetInitialConfigDisplay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetInitialConfigDisplay
	{
			(int? ReturnCode,
		int? InitialConfigDisplay) SSSFSGetInitialConfigDisplaySp(
			int? InitialConfigDisplay);
	}
}

