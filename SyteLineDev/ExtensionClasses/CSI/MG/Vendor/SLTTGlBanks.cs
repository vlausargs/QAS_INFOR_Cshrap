//PROJECT NAME: VendorExt
//CLASS NAME: SLTTGlBanks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLTTGlBanks")]
	public class SLTTGlBanks : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TTGlBankLoadSp(string PBankCode,
		                                    int? PCheckNumStart,
		                                    int? PCheckNumEnd)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_TTGlBankLoadExt = new CLM_TTGlBankLoadFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCLM_TTGlBankLoadExt.CLM_TTGlBankLoadSp(PBankCode,
				                                                       PCheckNumStart,
				                                                       PCheckNumEnd);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTGlBankCommitSp(ref string PromptMsg,
		                            ref string PromptButtons,
		                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTGlBankCommitExt = new TTGlBankCommitFactory().Create(appDb);
				
				int Severity = iTTGlBankCommitExt.TTGlBankCommitSp(ref PromptMsg,
				                                                   ref PromptButtons,
				                                                   ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTGlBankDeleteSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTGlBankDeleteExt = new TTGlBankDeleteFactory().Create(appDb);
				
				var result = iTTGlBankDeleteExt.TTGlBankDeleteSp(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTGlBankUpdateSp(Guid? PRowPointer,
		int? PProcessFlag,
		int? POverrideDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTGlBankUpdateExt = new TTGlBankUpdateFactory().Create(appDb);
				
				var result = iTTGlBankUpdateExt.TTGlBankUpdateSp(PRowPointer,
				PProcessFlag,
				POverrideDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
