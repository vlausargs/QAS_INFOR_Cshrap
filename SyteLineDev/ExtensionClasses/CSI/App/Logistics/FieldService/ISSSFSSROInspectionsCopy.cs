//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInspectionsCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInspectionsCopy
	{
		(int? ReturnCode,
			string Infobar) SSSFSSROInspectionsCopySp(
			string SroNum,
			int? SroLine,
			string Infobar);
	}
}

