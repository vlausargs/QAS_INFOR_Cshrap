//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSValidEstimate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSValidEstimate
	{
		(int? ReturnCode,
			string Infobar) SSSFSValidEstimateSp(
			string iSroNum,
			int? iSroLine,
			int? iSroOper,
			string iCodeField,
			string iCodeFieldName,
			string Infobar);
	}
}

