//PROJECT NAME: APSExt
//CLASS NAME: SLInventoryLevels.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using CSI.Data.RecordSets;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLInventoryLevels")]
    public class SLInventoryLevels : ExtensionClassBase, ISLInventoryLevels
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetInvSumStartEndDates(ref DateTime? PStartDate,
		                                  ref DateTime? PEndDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetInvSumStartEndDatExt = new GetInvSumStartEndDatFactory().Create(appDb);
				
				int Severity = iGetInvSumStartEndDatExt.GetInvSumStartEndDates(ref PStartDate,
				                                                               ref PEndDate);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsInventoryLevelSp(string PItem,
		                                         DateTime? PStartDate,
		                                         DateTime? PEndDate,
		                                         [Optional, DefaultParameterValue((byte)0)] byte? PExcludePLNs,
		[Optional] string FilterString,
        [Optional] string Infobar
            )
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsInventoryLevelExt = new CLM_ApsInventoryLevelFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsInventoryLevelExt.CLM_ApsInventoryLevelSp(PItem,
				                                                               PStartDate,
				                                                               PEndDate,
				                                                               PExcludePLNs,
				                                                               FilterString,
                                                                               Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
			}
		}
    }
}
