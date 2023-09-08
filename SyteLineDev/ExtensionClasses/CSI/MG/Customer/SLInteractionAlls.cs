//PROJECT NAME: CustomerExt
//CLASS NAME: SLInteractionAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLInteractionAlls")]
	public class SLInteractionAlls : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetInteractionBySiteSp(string InteractionType,
		                                  decimal? InteractionId,
		                                  ref string SiteRef,
		                                  ref string Description,
		                                  ref string Topic,
		                                  ref string CustNum,
		                                  ref int? CustSeq,
		                                  ref string CustName,
		                                  ref string Status,
		                                  ref DateTime? InteractionDate,
		                                  ref DateTime? FollowDate,
		                                  ref string Slsman,
		                                  [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetInteractionBySiteExt = new GetInteractionBySiteFactory().Create(appDb);
				
				var result = iGetInteractionBySiteExt.GetInteractionBySiteSp(InteractionType,
				                                                             InteractionId,
				                                                             SiteRef,
				                                                             Description,
				                                                             Topic,
				                                                             CustNum,
				                                                             CustSeq,
				                                                             CustName,
				                                                             Status,
				                                                             InteractionDate,
				                                                             FollowDate,
				                                                             Slsman,
				                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				SiteRef = result.SiteRef;
				Description = result.Description;
				Topic = result.Topic;
				CustNum = result.CustNum;
				CustSeq = result.CustSeq;
				CustName = result.CustName;
				Status = result.Status;
				InteractionDate = result.InteractionDate;
				FollowDate = result.FollowDate;
				Slsman = result.Slsman;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetProspectsInteractionCountSp(string ProspectId,
		                                          string Slsman,
		                                          ref int? InteractionCount,
		                                          string SiteRef,
		                                          [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetProspectsInteractionCountExt = new GetProspectsInteractionCountFactory().Create(appDb);
				
				var result = iGetProspectsInteractionCountExt.GetProspectsInteractionCountSp(ProspectId,
				                                                                             Slsman,
				                                                                             InteractionCount,
				                                                                             SiteRef,
				                                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				InteractionCount = result.InteractionCount;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
