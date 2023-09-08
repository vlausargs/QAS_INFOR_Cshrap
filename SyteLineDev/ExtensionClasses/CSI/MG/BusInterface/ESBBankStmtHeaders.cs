//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBBankStmtHeaders.cs

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
	[IDOExtensionClass("ESBBankStmtHeaders")]
	public class ESBBankStmtHeaders : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBankStmProcessedSp(string DocumentID,
		                                     byte? Processed,
		                                     ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBankStmProcessedExt = new LoadESBBankStmProcessedFactory().Create(appDb);
				
				int Severity = iLoadESBBankStmProcessedExt.LoadESBBankStmProcessedSp(DocumentID,
				                                                                     Processed,
				                                                                     ref InfoBar);
				
				return Severity;
			}
		}
	}
}
