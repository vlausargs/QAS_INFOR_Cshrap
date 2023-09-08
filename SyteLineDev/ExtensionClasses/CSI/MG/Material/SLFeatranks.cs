//PROJECT NAME: MaterialExt
//CLASS NAME: SLFeatranks.cs

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
    [IDOExtensionClass("SLFeatranks")]
    public class SLFeatranks : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GenerateFeatrankSp(string PItem,
                                      int? POperNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGenerateFeatrankExt = new GenerateFeatrankFactory().Create(appDb);

                int Severity = iGenerateFeatrankExt.GenerateFeatrankSp(PItem,
                                                                  POperNum);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int UpdateFeatRankSp(string Item,
                                            int? OperNum,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iUpdateFeatRankExt = new UpdateFeatRankFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iUpdateFeatRankExt.UpdateFeatRankSp(Item,
                                                                OperNum,
                                                                ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProdConfExcludeOptCodeSp(string Feature,
		                                    string FeatStr,
		                                    string Item,
		                                    int? OperNum,
		                                    ref string ExcludeOptCode,
		                                    [Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProdConfExcludeOptCodeExt = new ProdConfExcludeOptCodeFactory().Create(appDb);
				
				var result = iProdConfExcludeOptCodeExt.ProdConfExcludeOptCodeSp(Feature,
				                                                                 FeatStr,
				                                                                 Item,
				                                                                 OperNum,
				                                                                 ExcludeOptCode,
				                                                                 Site);
				
				int Severity = result.ReturnCode.Value;
				ExcludeOptCode = result.ExcludeOptCode;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FeatStrValidateSp(string FeatStr,
		string Item,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFeatStrValidateExt = new FeatStrValidateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFeatStrValidateExt.FeatStrValidateSp(FeatStr,
				Item,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvparmsFbomBlankSp(ref string InvparmsFbomBlank)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInvparmsFbomBlankExt = new InvparmsFbomBlankFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInvparmsFbomBlankExt.InvparmsFbomBlankSp(InvparmsFbomBlank);
				
				int Severity = result.ReturnCode.Value;
				InvparmsFbomBlank = result.InvparmsFbomBlank;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProdConfFeatureGroupSp(string ParentItem,
		[Optional] string CoitemFeatStr,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProdConfFeatureGroupExt = new ProdConfFeatureGroupFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProdConfFeatureGroupExt.ProdConfFeatureGroupSp(ParentItem,
				CoitemFeatStr,
				Site);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
