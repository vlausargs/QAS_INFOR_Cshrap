//PROJECT NAME: MaterialExt
//CLASS NAME: SLProdMixes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Reporting;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLProdMixes")]
    public class SLProdMixes : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ProdMixCompareRoutingSp(string OldLeadItem,
                                                   string NewLeadItem,
                                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iProdMixCompareRoutingExt = new ProdMixCompareRoutingFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iProdMixCompareRoutingExt.ProdMixCompareRoutingSp(OldLeadItem,
                                                                       NewLeadItem,
                                                                       ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ProdMixProductCodeSp(string LeadItem,
                                                string ChildItem,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iProdMixProductCodeExt = new ProdMixProductCodeFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iProdMixProductCodeExt.ProdMixProductCodeSp(LeadItem,
                                                                    ChildItem,
                                                                    ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemGenMixSp(string PProdMix,
		                        [Optional, DefaultParameterValue(0)] int? PNetChange,
		                        [Optional, DefaultParameterValue(1)] int? PPrintOperText,
		                        [Optional, DefaultParameterValue(0)] int? PPageBtwOper,
		                        [Optional, DefaultParameterValue(1)] int? PPrintMatlText,
		                        [Optional, DefaultParameterValue(0)] int? PDisRefFields,
		                        [Optional, DefaultParameterValue(0)] int? PDisEffDate,
		                        [Optional] DateTime? PEffectDate,
		                        [Optional, DefaultParameterValue(0)] int? ShowInternal,
		                        [Optional, DefaultParameterValue(0)] int? ShowExternal,
		                        [Optional, DefaultParameterValue(0)] int? DisplayHeader,
		                        ref string Infobar,
		                        [Optional] string BGSessionId,
		                        [Optional] string pSite,
		                        [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iRpt_ItemGenMixExt = new Rpt_ItemGenMixFactory().Create(appDb,
					bunchedLoadCollection,
					mgInvoker,
					new CSI.Data.SQL.SQLParameterProvider(),
					true);

				var result = iRpt_ItemGenMixExt.Rpt_ItemGenMixSp(PProdMix,
				                                                 PNetChange,
				                                                 PPrintOperText,
				                                                 PPageBtwOper,
				                                                 PPrintMatlText,
				                                                 PDisRefFields,
				                                                 PDisEffDate,
				                                                 PEffectDate,
				                                                 ShowInternal,
				                                                 ShowExternal,
				                                                 DisplayHeader,
				                                                 Infobar,
				                                                 BGSessionId,
				                                                 pSite,
				                                                 BGUser);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemValMixSp([Optional] string PProdMix,
		                        [Optional, DefaultParameterValue(1)] int? PPrintOperText,
		                        [Optional, DefaultParameterValue(0)] int? PPageBtwOper,
		                        [Optional, DefaultParameterValue(1)] int? PPrintMatlText,
		                        [Optional, DefaultParameterValue(0)] int? PDisRefFields,
		                        [Optional, DefaultParameterValue(0)] int? PDisEffDate,
		                        [Optional] DateTime? PEffectDate,
		                        [Optional, DefaultParameterValue(0)] int? ShowInternal,
		                        [Optional, DefaultParameterValue(0)] int? ShowExternal,
		                        [Optional, DefaultParameterValue(0)] int? DisplayHeader,
		                        string Infobar,
		                        [Optional] string BGSessionId,
		                        [Optional] string pSite,
		                        [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

                var iRpt_ItemValMixExt = new Rpt_ItemValMixFactory().Create(appDb,
					bunchedLoadCollection,
					mgInvoker,
					new CSI.Data.SQL.SQLParameterProvider(),
					true);

                var result = iRpt_ItemValMixExt.Rpt_ItemValMixSp(PProdMix,
				                                                 PPrintOperText,
				                                                 PPageBtwOper,
				                                                 PPrintMatlText,
				                                                 PDisRefFields,
				                                                 PDisEffDate,
				                                                 PEffectDate,
				                                                 ShowInternal,
				                                                 ShowExternal,
				                                                 DisplayHeader,
				                                                 Infobar,
				                                                 BGSessionId,
				                                                 pSite,
				                                                 BGUser);
				
				
				return result.ReturnCode.Value;
			}
		}
    }
}
