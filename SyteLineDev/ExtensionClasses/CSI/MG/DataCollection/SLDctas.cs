//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDctas.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.DataCollection;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.DataCollection
{
    [IDOExtensionClass("SLDctas")]
    public class SLDctas : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SecondsPastMidnightSp(DateTime? PostTime,
                                         ref int? PSecondsPastMidnight)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSecondsPastMidnightExt = new SecondsPastMidnightFactory().Create(appDb);

                IntType oPSecondsPastMidnight = PSecondsPastMidnight;

                int Severity = iSecondsPastMidnightExt.SecondsPastMidnightSp(PostTime,
                                                                             ref oPSecondsPastMidnight);

                PSecondsPastMidnight = oPSecondsPastMidnight;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DctaPSp(ref DateTime? PPostDate,
                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDctaPExt = new DctaPFactory().Create(appDb);

                CurrentDateType oPPostDate = PPostDate;
                InfobarType oInfobar = Infobar;

                int Severity = iDctaPExt.DctaPSp(ref oPPostDate,
                                                 ref oInfobar);

                PPostDate = oPPostDate;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DctaAddValidateSp(Guid? PRowPointer,
                                     ref string PTransType,
                                     ref int? PTransTime,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDctaAddValidateExt = new DctaAddValidateFactory().Create(appDb);

                DcTransTypeType oPTransType = PTransType;
                TimeSecondsType oPTransTime = PTransTime;
                InfobarType oInfobar = Infobar;

                int Severity = iDctaAddValidateExt.DctaAddValidateSp(PRowPointer,
                                                                     ref oPTransType,
                                                                     ref oPTransTime,
                                                                     ref oInfobar);

                PTransType = oPTransType;
                PTransTime = oPTransTime;
                Infobar = oInfobar;


                return Severity;
            }
        }




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DctaDSp(string Status,
		                   string TransType,
		                   string FromEmpNum,
		                   string ToEmpNum,
		                   decimal? FromTransNum,
		                   decimal? ToTransNum,
		                   DateTime? FromTransDate,
		                   DateTime? ToTransDate,
		                   DateTime? FromPostDate,
		                   DateTime? ToPostDate,
		                   ref string Infobar,
		                   [Optional] short? StartingTransDateOffset,
		                   [Optional] short? EndingTransDateOffset,
		                   [Optional] short? StartingPostDateOffset,
		                   [Optional] short? EndingPostDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDctaDExt = new DctaDFactory().Create(appDb);
				
				var result = iDctaDExt.DctaDSp(Status,
				                               TransType,
				                               FromEmpNum,
				                               ToEmpNum,
				                               FromTransNum,
				                               ToTransNum,
				                               FromTransDate,
				                               ToTransDate,
				                               FromPostDate,
				                               ToPostDate,
				                               Infobar,
				                               StartingTransDateOffset,
				                               EndingTransDateOffset,
				                               StartingPostDateOffset,
				                               EndingPostDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable TAMonitorSp([Optional] string Shift)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iTAMonitorExt = new TAMonitorFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iTAMonitorExt.TAMonitorSp(Shift);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AutoLunchCheckSp(string PEmpNum,
		string PShift,
		DateTime? PTransDate,
		int? PTransTime,
		string PTransType,
		int? PTransNum,
		string PTermid,
		string PIndCode,
		string PJob,
		int? PSuffix,
		int? POperNum,
		string PWc,
		string PWhse,
		string PDcModule,
		ref string PError)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAutoLunchCheckExt = new AutoLunchCheckFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAutoLunchCheckExt.AutoLunchCheckSp(PEmpNum,
				PShift,
				PTransDate,
				PTransTime,
				PTransType,
				PTransNum,
				PTermid,
				PIndCode,
				PJob,
				PSuffix,
				POperNum,
				PWc,
				PWhse,
				PDcModule,
				PError);
				
				int Severity = result.ReturnCode.Value;
				PError = result.PError;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AutoLunchSp(string PEmpNum,
		DateTime? PTransDate,
		int? PTransTime,
		string PTransType,
		int? PTransNum,
		string PTermid,
		string PIndCode,
		string PJob,
		int? PSuffix,
		int? POperNum,
		string PWc,
		string PWhse,
		string PDcModule,
		ref string PError)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAutoLunchExt = new AutoLunchFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAutoLunchExt.AutoLunchSp(PEmpNum,
				PTransDate,
				PTransTime,
				PTransType,
				PTransNum,
				PTermid,
				PIndCode,
				PJob,
				PSuffix,
				POperNum,
				PWc,
				PWhse,
				PDcModule,
				PError);
				
				int Severity = result.ReturnCode.Value;
				PError = result.PError;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcATimeatISp(string TTermId,
		int? TTransType,
		string TEmpNum,
		DateTime? TDate,
		int? TTime,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDcATimeatIExt = new DcATimeatIFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDcATimeatIExt.DcATimeatISp(TTermId,
				TTransType,
				TEmpNum,
				TDate,
				TTime,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcATimeatSp(string TTermId,
		int? TTransType,
		string TEmpNum,
		DateTime? TDate,
		int? TTime,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDcATimeatExt = new DcATimeatFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDcATimeatExt.DcATimeatSp(TTermId,
				TTransType,
				TEmpNum,
				TDate,
				TTime,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}