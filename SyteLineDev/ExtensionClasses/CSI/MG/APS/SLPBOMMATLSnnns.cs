//PROJECT NAME: APSExt
//CLASS NAME: SLPBOMMATLSnnns.cs

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
    [IDOExtensionClass("SLPBOMMATLSnnns")]
    public class SLPBOMMATLSnnns : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsPBOMMATLSDelSp(int? AltNo, Guid? RowPointer)
        {
            var iApsPBOMMATLSDelExt = new ApsPBOMMATLSDelFactory().Create(this, true);

            var result = iApsPBOMMATLSDelExt.ApsPBOMMATLSDelSp(AltNo, RowPointer);

            return result ?? 0;
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsPBOMMATLSAltSaveSp(int? InsertFlag,
		int? AltNo,
		string BOMID,
		int? ALTID,
		int? SEQNO,
		string MATERIALID,
		int? NEWSEQNO)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsPBOMMATLSAltSaveExt = new ApsPBOMMATLSAltSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsPBOMMATLSAltSaveExt.ApsPBOMMATLSAltSaveSp(InsertFlag,
				AltNo,
				BOMID,
				ALTID,
				SEQNO,
				MATERIALID,
				NEWSEQNO);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsPBOMMATLSSaveSp(int? InsertFlag,
		int? AltNo,
		string BOMID,
		string MATERIALID,
		int? SEQNO,
		int? BOMFLAGS,
		decimal? QUANTITY,
		int? MERGETO,
		decimal? SHRINK,
		int? ALTID,
		string REFORDERID,
		DateTime? EFFDATE,
		DateTime? OBSDATE)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsPBOMMATLSSaveExt = new ApsPBOMMATLSSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsPBOMMATLSSaveExt.ApsPBOMMATLSSaveSp(InsertFlag,
				AltNo,
				BOMID,
				MATERIALID,
				SEQNO,
				BOMFLAGS,
				QUANTITY,
				MERGETO,
				SHRINK,
				ALTID,
				REFORDERID,
				EFFDATE,
				OBSDATE);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetPBOMMATLSSp(int? AltNo,
		string BOMID,
		int? ALTID,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetPBOMMATLSExt = new CLM_ApsGetPBOMMATLSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetPBOMMATLSExt.CLM_ApsGetPBOMMATLSSp(AltNo,
				BOMID,
				ALTID,
				FilterString);
				 
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
