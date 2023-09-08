//PROJECT NAME: APSExt
//CLASS NAME: SLContentionDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLContentionDetails")]
    public class SLContentionDetails : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GetContentionBucketsSp(string Group,
		DateTime? StartDate,
		DateTime? EndDate,
		int? AltNo,
		string DisplayType,
		int? RecordCap,
		int? Interval,
		string Period,
		string GroupType,
		int? ExcludeInfinite,
		string WildCardChar)
		{
			var iCLM_GetContentionDetailsByTypeExt = new CLM_GetContentionDetailsByTypeFactory().Create(this, true);
			
			var result = iCLM_GetContentionDetailsByTypeExt.CLM_GetContentionDetailsByTypeSp(Group,
			StartDate,
			EndDate,
			AltNo,
			DisplayType,
			RecordCap,
			Interval,
			Period,
			GroupType,
			ExcludeInfinite,
			WildCardChar);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GetContentionDetailsSp(string Group,
		DateTime? StartDate,
		DateTime? EndDate,
		int? AltNo,
		string DisplayType,
		int? RecordCap,
		int? Interval,
		string Period,
		string GroupType,
		int? ExcludeInfinite,
		string WildCardChar)
		{
			var iCLM_GetContentionDetailsByTypeExt = new CLM_GetContentionDetailsByTypeFactory().Create(this, true);
			
			var result = iCLM_GetContentionDetailsByTypeExt.CLM_GetContentionDetailsByTypeSp(Group,
			StartDate,
			EndDate,
			AltNo,
			DisplayType,
			RecordCap,
			Interval,
			Period,
			GroupType,
			ExcludeInfinite,
			WildCardChar);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GetContentionSummarySp(string Group,
		DateTime? StartDate,
		DateTime? EndDate,
		int? AltNo,
		string DisplayType,
		int? RecordCap,
		int? Interval,
		string Period,
		string GroupType,
		int? ExcludeInfinite,
		string WildCardChar)
		{
			var iCLM_GetContentionDetailsByTypeExt = new CLM_GetContentionDetailsByTypeFactory().Create(this, true);
			
			var result = iCLM_GetContentionDetailsByTypeExt.CLM_GetContentionDetailsByTypeSp(Group,
			StartDate,
			EndDate,
			AltNo,
			DisplayType,
			RecordCap,
			Interval,
			Period,
			GroupType,
			ExcludeInfinite,
			WildCardChar);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

    }
}
