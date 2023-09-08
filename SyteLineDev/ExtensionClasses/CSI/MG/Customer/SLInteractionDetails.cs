//PROJECT NAME: CustomerExt
//CLASS NAME: SLInteractionDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using OfficeIntegration = CSI.ExternalContracts.OfficeIntegration.Outlook;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLInteractionDetails")]
	public class SLInteractionDetails : ExtensionClassBase, OfficeIntegration.ISLInteractionDetails, ISLInteractionDetails
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetMaxInteractionDetailsSequenceSp(decimal? InteractionId,
		                                              ref decimal? MaxSequence,
		                                              ref string InfobarType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetMaxInteractionDetailsSequenceExt = new GetMaxInteractionDetailsSequenceFactory().Create(appDb);
				
				int Severity = iGetMaxInteractionDetailsSequenceExt.GetMaxInteractionDetailsSequenceSp(InteractionId,
				                                                                                       ref MaxSequence,
				                                                                                       ref InfobarType);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AddToPortalInteractionSp(ref decimal? InteractionId,
		                                    string Note,
		                                    string InteractionType,
		                                    string Description,
		                                    string Topic,
		                                    string RefType,
		                                    Guid? RefRowPointer,
		                                    [Optional, DefaultParameterValue(0)] int? CustSeq,
		[Optional] ref string IntHeaderText,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAddToPortalInteractionExt = new AddToPortalInteractionFactory().Create(appDb);
				
				var result = iAddToPortalInteractionExt.AddToPortalInteractionSp(InteractionId,
				                                                                 Note,
				                                                                 InteractionType,
				                                                                 Description,
				                                                                 Topic,
				                                                                 RefType,
				                                                                 RefRowPointer,
				                                                                 CustSeq,
				                                                                 IntHeaderText,
				                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				InteractionId = result.InteractionId;
				IntHeaderText = result.IntHeaderText;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetInteractionEmailSentSp(int? PEmailSent,
		string PInteractionType,
		Guid? PInteractionRP,
		string PUserName,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetInteractionEmailSentExt = new SetInteractionEmailSentFactory().Create(appDb);
				
				var result = iSetInteractionEmailSentExt.SetInteractionEmailSentSp(PEmailSent,
				PInteractionType,
				PInteractionRP,
				PUserName,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
