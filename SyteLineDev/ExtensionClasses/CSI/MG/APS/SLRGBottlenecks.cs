//PROJECT NAME: APSExt
//CLASS NAME: SLRGBottlenecks.cs

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
	[IDOExtensionClass("SLRGBottlenecks")]
	public class SLRGBottlenecks : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetRGBottlenecksSp(string Group,
		string GroupType,
		byte? ExcludeInfinite,
		DateTime? StartDate,
		DateTime? EndDate,
		short? AltNo,
		string WildCardChar,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetRGBottlenecksExt = new CLM_ApsGetRGBottlenecksFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetRGBottlenecksExt.CLM_ApsGetRGBottlenecksSp(Group,
				GroupType,
				ExcludeInfinite,
				StartDate,
				EndDate,
				AltNo,
				WildCardChar,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
