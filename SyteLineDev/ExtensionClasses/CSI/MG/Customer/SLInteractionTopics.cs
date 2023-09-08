//PROJECT NAME: CustomerExt
//CLASS NAME: SLInteractionTopics.cs

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
	[IDOExtensionClass("SLInteractionTopics")]
	public class SLInteractionTopics : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertInteractionTopicSp(string InteractionType,
		                                    string Topic)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInsertInteractionTopicExt = new InsertInteractionTopicFactory().Create(appDb);
				
				int Severity = iInsertInteractionTopicExt.InsertInteractionTopicSp(InteractionType,
				                                                                   Topic);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InteractionTopicValidatorSp(string InteractionType,
		                                       string Topic,
		                                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInteractionTopicValidatorExt = new InteractionTopicValidatorFactory().Create(appDb);
				
				int Severity = iInteractionTopicValidatorExt.InteractionTopicValidatorSp(InteractionType,
				                                                                         Topic,
				                                                                         ref Infobar);
				
				return Severity;
			}
		}
	}
}
