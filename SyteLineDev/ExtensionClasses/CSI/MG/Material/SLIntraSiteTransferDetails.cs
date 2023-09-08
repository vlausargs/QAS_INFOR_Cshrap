//PROJECT NAME: MaterialExt
//CLASS NAME: SLIntraSiteTransferDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLIntraSiteTransferDetails")]
    public class SLIntraSiteTransferDetails : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetApsIDFromPLNSp(Guid? PApsPlanRowPtr,
                                     ref string PApsOrderID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetApsIDFromPLNExt = new GetApsIDFromPLNFactory().Create(appDb);

                ApsOrderType oPApsOrderID = PApsOrderID;

                int Severity = iGetApsIDFromPLNExt.GetApsIDFromPLNSp(PApsPlanRowPtr,
                                                                     ref oPApsOrderID);

                PApsOrderID = oPApsOrderID;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MrpDPreFirmPlanSp(string PItem,
                                     ref string PRefType,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMrpDPreFirmPlanExt = new MrpDPreFirmPlanFactory().Create(appDb);

                JobTypeType oPRefType = PRefType;
                InfobarType oInfobar = Infobar;

                int Severity = iMrpDPreFirmPlanExt.MrpDPreFirmPlanSp(PItem,
                                                                     ref oPRefType,
                                                                     ref oInfobar);

                PRefType = oPRefType;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MrpInitTransferOrderSp(string Item,
                                          ref string FromSite,
                                          ref string FromWhse,
                                          ref string ToSite,
                                          ref string ToWhse)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMrpInitTransferOrderExt = new MrpInitTransferOrderFactory().Create(appDb);

                SiteType oFromSite = FromSite;
                WhseType oFromWhse = FromWhse;
                SiteType oToSite = ToSite;
                WhseType oToWhse = ToWhse;

                int Severity = iMrpInitTransferOrderExt.MrpInitTransferOrderSp(Item,
                                                                               ref oFromSite,
                                                                               ref oFromWhse,
                                                                               ref oToSite,
                                                                               ref oToWhse);

                FromSite = oFromSite;
                FromWhse = oFromWhse;
                ToSite = oToSite;
                ToWhse = oToWhse;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IntraSiteFirmTransferSp(string Item,
		                                   string RefNum,
		                                   ref string TrnNum,
		                                   string FromSite,
		                                   string FromWhse,
		                                   string ToSite,
		                                   string ToWhse,
		                                   [Optional, DefaultParameterValue((byte)0)] byte? FromWorkbench,
		[Optional] DateTime? DueDate,
		[Optional, DefaultParameterValue(0)] decimal? ReqdQty,
		[Optional] string RefType,
		[Optional] short? RefLineSuf,
		[Optional] short? RefRelease,
		[Optional] int? RefSeq,
		ref string Infobar,
		[Optional] ref byte? CheckInsertPermission,
		string TrnLoc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iIntraSiteFirmTransferExt = new IntraSiteFirmTransferFactory().Create(appDb);
				
				var result = iIntraSiteFirmTransferExt.IntraSiteFirmTransferSp(Item,
				                                                               RefNum,
				                                                               TrnNum,
				                                                               FromSite,
				                                                               FromWhse,
				                                                               ToSite,
				                                                               ToWhse,
				                                                               FromWorkbench,
				                                                               DueDate,
				                                                               ReqdQty,
				                                                               RefType,
				                                                               RefLineSuf,
				                                                               RefRelease,
				                                                               RefSeq,
				                                                               Infobar,
				                                                               CheckInsertPermission,
				                                                               TrnLoc);
				
				int Severity = result.ReturnCode.Value;
				TrnNum = result.TrnNum;
				Infobar = result.Infobar;
				CheckInsertPermission = result.CheckInsertPermission;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExpandKyByTypeSp(string DataType,
		string Key,
		[Optional, DefaultParameterValue(null)] string Site,
		ref string Result)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iExpandKyByTypeExt = new ExpandKyByTypeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iExpandKyByTypeExt.ExpandKyByTypeSp(DataType,
				Key,
				Site,
				Result);
				
				int Severity = result.ReturnCode.Value;
				Result = result.Result;
				return Severity;
			}
		}
    }
}
