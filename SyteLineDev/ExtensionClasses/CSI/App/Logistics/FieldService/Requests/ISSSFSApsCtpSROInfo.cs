//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSApsCtpSROInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSApsCtpSROInfo
	{
		(int? ReturnCode, string PApsOrderId,
		int? PCategory,
		int? PFlags,
		DateTime? PApsRequestDate,
		DateTime? PApsDueDate,
		string PApsItem,
		int? PExcludeFromATP,
		DateTime? PSroStartDate) SSSFSApsCtpSROInfoSp(string PSroNum,
		int? PSroLine,
		int? PSroOper,
		int? PTransNum,
		DateTime? PTransDate,
		string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		string PItem,
		string PApsOrderId,
		int? PCategory,
		int? PFlags,
		DateTime? PApsRequestDate,
		DateTime? PApsDueDate,
		string PApsItem,
		int? PExcludeFromATP,
		DateTime? PSroStartDate);
	}
}

