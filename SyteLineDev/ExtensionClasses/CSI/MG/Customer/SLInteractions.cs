//PROJECT NAME: CustomerExt
//CLASS NAME: SLInteractions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using CSI.POS;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLInteractions")]
	public class SLInteractions : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FormatContactAddressSp(string ContactId,
		                                  ref string ContactAddress,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFormatContactAddressExt = new FormatContactAddressFactory().Create(appDb);
				
				int Severity = iFormatContactAddressExt.FormatContactAddressSp(ContactId,
				                                                               ref ContactAddress,
				                                                               ref Infobar);
				
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetInteractionRefRowPointerSp(string InteractionRefType,
		                                         string RefNum,
		                                         ref Guid? RefRowPointer,
		                                         ref string Description,
		                                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetInteractionRefRowPointerExt = new GetInteractionRefRowPointerFactory().Create(appDb);
				
				int Severity = iGetInteractionRefRowPointerExt.GetInteractionRefRowPointerSp(InteractionRefType,
				                                                                             RefNum,
				                                                                             ref RefRowPointer,
				                                                                             ref Description,
				                                                                             ref Infobar);
				
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FormatProspectAddressSp(string ProspectId,
		                                   ref string ProAddress,
		                                   ref string Infobar,
		                                   [Optional] ref string DerCurrCode,
		                                   [Optional] ref string TaxCode1,
		                                   [Optional] ref string TaxCode2)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFormatProspectAddressExt = new FormatProspectAddressFactory().Create(appDb);
				
				var result = iFormatProspectAddressExt.FormatProspectAddressSp(ProspectId,
				                                                               ProAddress,
				                                                               Infobar,
				                                                               DerCurrCode,
				                                                               TaxCode1,
				                                                               TaxCode2);
				
				int Severity = result.ReturnCode.Value;
				ProAddress = result.ProAddress;
				Infobar = result.Infobar;
				DerCurrCode = result.DerCurrCode;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetInteractionCountSp(string RefNumId,
		                                 string InteractionType,
		                                 ref int? InteractionCount,
		                                 [Optional] ref string Infobar,
		                                 [Optional] string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetInteractionCountExt = new GetInteractionCountFactory().Create(appDb);
				
				var result = iGetInteractionCountExt.GetInteractionCountSp(RefNumId,
				                                                           InteractionType,
				                                                           InteractionCount,
				                                                           Infobar,
				                                                           SiteRef);
				
				int Severity = result.ReturnCode.Value;
				InteractionCount = result.InteractionCount;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetLastInteractionIDSp(string RefNumId,
		                                  string InteractionType,
		                                  string SiteGroup,
		                                  ref decimal? InteractionId,
		                                  ref string Site,
		                                  [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetLastInteractionIDExt = new GetLastInteractionIDFactory().Create(appDb);
				
				var result = iGetLastInteractionIDExt.GetLastInteractionIDSp(RefNumId,
				                                                             InteractionType,
				                                                             SiteGroup,
				                                                             InteractionId,
				                                                             Site,
				                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				InteractionId = result.InteractionId;
				Site = result.Site;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InteractionsDelSp(string StartingVendNum,
		                             string EndingVendNum,
		                             DateTime? StartingInteractionDate,
		                             DateTime? EndingInteractionDate,
		                             DateTime? StartingFollowDate,
		                             DateTime? EndingFollowDate,
		                             string StartingTopic,
		                             string EndingTopic,
		                             ref int? InteractionsDeleted,
		                             ref string Infobar,
		                             [Optional] short? StartingInteractionDateOffset,
		                             [Optional] short? EndingInteractionDateOffset,
		                             [Optional] short? StartingFollowDateOffset,
		                             [Optional] short? EndingFollowDateOffset,
		                             string InteractionType,
		                             decimal? StartingInteractionId,
		                             decimal? EndingInteractionId,
		                             string StartingSlsman,
		                             string EndingSlsman)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInteractionsDelExt = new InteractionsDelFactory().Create(appDb);
				
				var result = iInteractionsDelExt.InteractionsDelSp(StartingVendNum,
				                                                   EndingVendNum,
				                                                   StartingInteractionDate,
				                                                   EndingInteractionDate,
				                                                   StartingFollowDate,
				                                                   EndingFollowDate,
				                                                   StartingTopic,
				                                                   EndingTopic,
				                                                   InteractionsDeleted,
				                                                   Infobar,
				                                                   StartingInteractionDateOffset,
				                                                   EndingInteractionDateOffset,
				                                                   StartingFollowDateOffset,
				                                                   EndingFollowDateOffset,
				                                                   InteractionType,
				                                                   StartingInteractionId,
				                                                   EndingInteractionId,
				                                                   StartingSlsman,
				                                                   EndingSlsman);
				
				int Severity = result.ReturnCode.Value;
				InteractionsDeleted = result.InteractionsDeleted;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_InteractionRefNumIDSp(string InteractionRefType,
		string VendNum,
		int? FromPortal)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_InteractionRefNumIDExt = new CLM_InteractionRefNumIDFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_InteractionRefNumIDExt.CLM_InteractionRefNumIDSp(InteractionRefType,
				VendNum,
				FromPortal);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FormatAddressSp(string CustNum,
		int? CustSeq,
		ref string BillToAddress,
		ref string ShipToAddress,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFormatAddressExt = new FormatAddressFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFormatAddressExt.FormatAddressSp(CustNum,
				CustSeq,
				BillToAddress,
				ShipToAddress,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				BillToAddress = result.BillToAddress;
				ShipToAddress = result.ShipToAddress;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
