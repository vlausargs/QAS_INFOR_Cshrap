//PROJECT NAME: ProductExt
//CLASS NAME: SLResschd000s.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLResschd000s")]
    public class SLResschd000s : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsSetSequenceDatesSp(string RESID,
                                         string EndDateInterval)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsSetSequenceDatesExt = new ApsSetSequenceDatesFactory().Create(appDb);

                int Severity = iApsSetSequenceDatesExt.ApsSetSequenceDatesSp(RESID,
                                                                             EndDateInterval);

                return Severity;
            }
        }



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LoadResourceSequenceSp(string RESID,
		                                            string EndDateInterval,
		                                            [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_LoadResourceSequenceExt = new CLM_LoadResourceSequenceFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_LoadResourceSequenceExt.CLM_LoadResourceSequenceSp(RESID,
				                                                                     EndDateInterval,
				                                                                     FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateResourceSchedSp(int? SequenceNum,
		int? JobTag,
		string GroupID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateResourceSchedExt = new UpdateResourceSchedFactory().Create(appDb);
				
				var result = iUpdateResourceSchedExt.UpdateResourceSchedSp(SequenceNum,
				JobTag,
				GroupID);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ResequenceOperDateSp(string Job,
		int? Suffix,
		int? OperNum,
		DateTime? NewStartDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iResequenceOperDateExt = new ResequenceOperDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iResequenceOperDateExt.ResequenceOperDateSp(Job,
				Suffix,
				OperNum,
				NewStartDate);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
