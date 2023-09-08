//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBCaptureDocumentViews.cs

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
	[IDOExtensionClass("ESBCaptureDocumentViews")]
	public class ESBCaptureDocumentViews : ExtensionClassBase
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBCaptureDocumentPostSp(string DocumentID,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBCaptureDocumentPostExt = new LoadESBCaptureDocumentPostFactory().Create(appDb);
				
				int Severity = iLoadESBCaptureDocumentPostExt.LoadESBCaptureDocumentPostSp(DocumentID,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBCaptureDocumentSp(string DerBODID,
		                                    string ActionExpression,
		                                    string AlternateID,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBCaptureDocumentExt = new LoadESBCaptureDocumentFactory().Create(appDb);
				
				int Severity = iLoadESBCaptureDocumentExt.LoadESBCaptureDocumentSp(DerBODID,
				                                                                   ActionExpression,
				                                                                   AlternateID,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}
	}
}
