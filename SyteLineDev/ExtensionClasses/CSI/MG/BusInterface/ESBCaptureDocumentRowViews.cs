//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBCaptureDocumentRowViews.cs

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
	[IDOExtensionClass("ESBCaptureDocumentRowViews")]
	public class ESBCaptureDocumentRowViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBCaptureDocumentRowSp(string DerBODID,
		                                       string ActionExpression,
		                                       int? RowID,
		                                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBCaptureDocumentRowExt = new LoadESBCaptureDocumentRowFactory().Create(appDb);
				
				int Severity = iLoadESBCaptureDocumentRowExt.LoadESBCaptureDocumentRowSp(DerBODID,
				                                                                         ActionExpression,
				                                                                         RowID,
				                                                                         ref Infobar);
				
				return Severity;
			}
		}
	}
}
