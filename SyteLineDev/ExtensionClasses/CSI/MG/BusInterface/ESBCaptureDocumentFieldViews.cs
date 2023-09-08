//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBCaptureDocumentFieldViews.cs

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
	[IDOExtensionClass("ESBCaptureDocumentFieldViews")]
	public class ESBCaptureDocumentFieldViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBCaptureDocumentFieldSp(string DerBODID,
		                                         string ActionExpression,
		                                         string FieldName,
		                                         string FieldValue,
		                                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBCaptureDocumentFieldExt = new LoadESBCaptureDocumentFieldFactory().Create(appDb);
				
				int Severity = iLoadESBCaptureDocumentFieldExt.LoadESBCaptureDocumentFieldSp(DerBODID,
				                                                                             ActionExpression,
				                                                                             FieldName,
				                                                                             FieldValue,
				                                                                             ref Infobar);
				
				return Severity;
			}
		}
	}
}
