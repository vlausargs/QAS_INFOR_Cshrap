//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBCaptureDocumentRowColumnViews.cs

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
	[IDOExtensionClass("ESBCaptureDocumentRowColumnViews")]
	public class ESBCaptureDocumentRowColumnViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBCaptureDocumentRowColumnSp(string DerBODID,
		                                             string ActionExpression,
		                                             int? RowID,
		                                             string ColumnName,
		                                             string ColumnValue,
		                                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBCaptureDocumentRowColumnExt = new LoadESBCaptureDocumentRowColumnFactory().Create(appDb);
				
				int Severity = iLoadESBCaptureDocumentRowColumnExt.LoadESBCaptureDocumentRowColumnSp(DerBODID,
				                                                                                     ActionExpression,
				                                                                                     RowID,
				                                                                                     ColumnName,
				                                                                                     ColumnValue,
				                                                                                     ref Infobar);
				
				return Severity;
			}
		}
	}
}
