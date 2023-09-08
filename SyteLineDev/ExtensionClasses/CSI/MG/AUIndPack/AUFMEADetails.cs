//PROJECT NAME: MG
//CLASS NAME: AUFMEADetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Automotive;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.AUIndPack
{
	[IDOExtensionClass("AUFMEADetails")]
	public class AUFMEADetails : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_CLM_ResponsibilityRefGetValueSp([Optional] string RefType,
		                                                    [Optional] string RefNum,
		                                                    [Optional] string RefName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iAU_CLM_QAProcessRefGetValueExt = new AU_CLM_QAProcessRefGetValueFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iAU_CLM_QAProcessRefGetValueExt.AU_CLM_QAProcessRefGetValueSp(RefType,
				                                                                           RefNum,
				                                                                           RefName);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
