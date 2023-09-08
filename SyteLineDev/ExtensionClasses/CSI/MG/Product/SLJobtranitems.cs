//PROJECT NAME: ProductExt
//CLASS NAME: SLJobtranitems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLJobtranitems")]
    public class SLJobtranitems : ExtensionClassBase, IExtFTSLJobtranitems
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SWcmachISp(string PWorkCenter,
                              decimal? PTotalHours,
                              int? PStartTime,
                              int? PEndTime,
                              string PShift,
                              DateTime? PTransDate,
                              string PEmpNum,
                              string PUserID,
                              Guid? SessionID,
                              ref byte? TCoby,
                              ref decimal? JobtranTransNum,
                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSWcmachIExt = new SWcmachIFactory().Create(appDb);

                ListYesNoType oTCoby = TCoby;
                HugeTransNumType oJobtranTransNum = JobtranTransNum;
                InfobarType oInfobar = Infobar;

                int Severity = iSWcmachIExt.SWcmachISp(PWorkCenter,
                                                       PTotalHours,
                                                       PStartTime,
                                                       PEndTime,
                                                       PShift,
                                                       PTransDate,
                                                       PEmpNum,
                                                       PUserID,
                                                       SessionID,
                                                       ref oTCoby,
                                                       ref oJobtranTransNum,
                                                       ref oInfobar);

                TCoby = oTCoby;
                JobtranTransNum = oJobtranTransNum;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SaveJobtranitemSp(decimal? TransNum,
                                     string Item,
                                     decimal? QtyComplete,
                                     decimal? QtyMoved,
                                     decimal? QtyScrapped,
                                     string Reason,
                                     int? NextOper,
                                     string Loc,
                                     string Lot)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSaveJobtranitemExt = new SaveJobtranitemFactory().Create(appDb);

                int Severity = iSaveJobtranitemExt.SaveJobtranitemSp(TransNum,
                                                                     Item,
                                                                     QtyComplete,
                                                                     QtyMoved,
                                                                     QtyScrapped,
                                                                     Reason,
                                                                     NextOper,
                                                                     Loc,
                                                                     Lot);

                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JobtranitemQtyCompleteValidSp(string Job,
		int? Suffix,
		int? OperNum,
		string JobtranitemItem,
		decimal? QtyComplete,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJobtranitemQtyCompleteValidExt = new JobtranitemQtyCompleteValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJobtranitemQtyCompleteValidExt.JobtranitemQtyCompleteValidSp(Job,
				Suffix,
				OperNum,
				JobtranitemItem,
				QtyComplete,
				PromptMsg,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable LoadJobtranitemCoProductSp(decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadJobtranitemCoProductExt = new LoadJobtranitemCoProductFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadJobtranitemCoProductExt.LoadJobtranitemCoProductSp(TransNum,
				Job,
				Suffix,
				OperNum,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable LoadJobtranitemSp(decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadJobtranitemExt = new LoadJobtranitemFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadJobtranitemExt.LoadJobtranitemSp(TransNum,
				Job,
				Suffix,
				OperNum,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable MO_LoadCoJobtranitemSp(decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMO_LoadCoJobtranitemExt = new MO_LoadCoJobtranitemFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMO_LoadCoJobtranitemExt.MO_LoadCoJobtranitemSp(TransNum,
				Job,
				Suffix,
				OperNum,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
