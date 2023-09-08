//PROJECT NAME: Reporting
//CLASS NAME: IRPT_RSQC_QcGageCalibration.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_RSQC_QcGageCalibration
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_QcGageCalibrationSp(
			string pSortBy = null,
			string pStartGage = null,
			string pEndGage = null,
			DateTime? pStartLastCalDate = null,
			DateTime? pEndLastCalDate = null,
			DateTime? pStartNextCalDate = null,
			DateTime? pEndNextCalDate = null,
			string pStartLocation = null,
			string pEndLocation = null,
			string pStartGageType = null,
			string pEndGageType = null,
			int? DisplayHeader = null);
	}
}

