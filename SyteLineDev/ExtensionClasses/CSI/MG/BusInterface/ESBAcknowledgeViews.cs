//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBAcknowledgeViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBAcknowledgeViews")]
	public class ESBAcknowledgeViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBAcknowledgeSp(string BODID,
		                                string DocumentIDID,
		                                string ResponseExpression,
		                                ref string Infobar,
		                                string AlternateDocumentIDID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBAcknowledgeExt = new LoadESBAcknowledgeFactory().Create(appDb);
				
				int Severity = iLoadESBAcknowledgeExt.LoadESBAcknowledgeSp(BODID,
				                                                           DocumentIDID,
				                                                           ResponseExpression,
				                                                           ref Infobar,
				                                                           AlternateDocumentIDID);
				
				return Severity;
			}
		}
	}
}
