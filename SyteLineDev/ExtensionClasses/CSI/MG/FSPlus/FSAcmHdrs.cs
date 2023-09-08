//PROJECT NAME: FSPlusExt
//CLASS NAME: FSAcmHdrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlus
{
    [IDOExtensionClass("FSAcmHdrs")]
    public class FSAcmHdrs : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSAcmInitSp(ref string Id,
            ref int? TotalPeriods,
            ref string Infobar)
        {
            var iSSSFSAcmInitExt = new SSSFSAcmInitFactory().Create(this, true);

            var result = iSSSFSAcmInitExt.SSSFSAcmInitSp(Id,
                TotalPeriods,
                Infobar);

            Id = result.Id;
            TotalPeriods = result.TotalPeriods;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSAcmGenerateSchedSp(ref string AcmNum,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSAcmGenerateSchedExt = new SSSFSAcmGenerateSchedFactory().Create(appDb);
				
				int Severity = iSSSFSAcmGenerateSchedExt.SSSFSAcmGenerateSchedSp(ref AcmNum,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSAcmPostUtilSp(byte? Commit,
		                                    string StartCustNum,
		                                    string EndCustNum,
		                                    string StartRefNum,
		                                    string EndRefNum,
		                                    string StartInvNum,
		                                    string EndInvNum,
		                                    string StartAmortAcct,
		                                    string EndAmortAcct,
		                                    string StartOffsetAcct,
		                                    string EndOffsetAcct,
		                                    byte? Period,
		                                    short? FiscalYear,
		                                    DateTime? PostDate,
		                                    byte? UpdateStatus,
		                                    [Optional, DefaultParameterValue((byte)0)] byte? PostAllPeriods,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSFSAcmPostUtilExt = new SSSFSAcmPostUtilFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSFSAcmPostUtilExt.SSSFSAcmPostUtilSp(Commit,
				                                                     StartCustNum,
				                                                     EndCustNum,
				                                                     StartRefNum,
				                                                     EndRefNum,
				                                                     StartInvNum,
				                                                     EndInvNum,
				                                                     StartAmortAcct,
				                                                     EndAmortAcct,
				                                                     StartOffsetAcct,
				                                                     EndOffsetAcct,
				                                                     Period,
				                                                     FiscalYear,
				                                                     PostDate,
				                                                     UpdateStatus,
				                                                     PostAllPeriods,
				                                                     FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSAcmDeleteAllSp(ref string AcmNum,
            ref string Infobar)
        {
            var iSSSFSAcmDeleteAllExt = new SSSFSAcmDeleteAllFactory().Create(this, true);

            var result = iSSSFSAcmDeleteAllExt.SSSFSAcmDeleteAllSp(AcmNum,
                Infobar);

            AcmNum = result.AcmNum;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSAcmPostSchedSp(string AcmNum,
		int? AcmSeq,
		DateTime? PostDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSAcmPostSchedExt = new SSSFSAcmPostSchedFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSAcmPostSchedExt.SSSFSAcmPostSchedSp(AcmNum,
				AcmSeq,
				PostDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
