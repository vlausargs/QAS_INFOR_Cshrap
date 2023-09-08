//PROJECT NAME: Codes
//CLASS NAME: IGLAttributesUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGLAttributesUpdate
	{
		(int? ReturnCode, string Infobar) GLAttributesUpdateSp(int? UpdateAnalysisAttributes,
		int? OverwriteExsiting,
		DateTime? TransDateStarting,
		DateTime? TransDateEnding,
		string AccountStarting,
		string AccountEnding,
		string DimensionStarting,
		string DimensionEnding,
		string Infobar,
        int? commitSize,
        int? Debug,
        int? TaskID,
        int? ChartCount);
	}
}

