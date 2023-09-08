//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAutoSRODateCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAutoSRODateCalc
	{
		(int? ReturnCode,
			DateTime? _oStartDate,
			string Infobar) SSSFSAutoSRODateCalcSp(
			DateTime? _iDate,
			int? _iFrequency,
			int? _iFreqUnits,
			int? _iDirection,
			DateTime? _oStartDate,
			string Infobar);
	}
}

