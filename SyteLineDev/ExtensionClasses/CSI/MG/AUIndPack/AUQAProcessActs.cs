//PROJECT NAME: AUIndPackExt
//CLASS NAME: AUQAProcessActs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Automotive;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.AUIndPack
{
    [IDOExtensionClass("AUQAProcessActs")]
    public class AUQAProcessActs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AU_QAProcessPhaseActivityResequenceSp(string QAProcess,
                                                         decimal? Sequence)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAU_QAProcessPhaseActivityResequenceExt = new AU_QAProcessPhaseActivityResequenceFactory().Create(appDb);

                int Severity = iAU_QAProcessPhaseActivityResequenceExt.AU_QAProcessPhaseActivityResequenceSp(QAProcess,
                                                                                                             Sequence);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_CLM_QAProcessRefGetValueSp([Optional] string RefType,
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
