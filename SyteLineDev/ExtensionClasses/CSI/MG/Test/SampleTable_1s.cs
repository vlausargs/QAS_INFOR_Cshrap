//PROJECT NAME: TestExt
//CLASS NAME: SampleTable_1s.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Test;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Test
{
	[IDOExtensionClass("SampleTable_1s")]
	public class SampleTable_1s : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SAMPErrorOrPromptValidationSp(int? CodeNum,
		                                         string Desc,
		                                         byte? WarnOnDuplicate,
		                                         ref byte? DuplicateExists,
		                                         ref string PromptMsg,
		                                         ref string PromptButtons,
		                                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSAMPErrorOrPromptValidationExt = new SAMPErrorOrPromptValidationFactory().Create(appDb);
				
				int Severity = iSAMPErrorOrPromptValidationExt.SAMPErrorOrPromptValidationSp(CodeNum,
				                                                                             Desc,
				                                                                             WarnOnDuplicate,
				                                                                             ref DuplicateExists,
				                                                                             ref PromptMsg,
				                                                                             ref PromptButtons,
				                                                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SAMPProcessErrorOrPromptSp(byte? WarnOnDuplicate,
		                                      ref string PromptMsg,
		                                      ref string PromptButtons,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSAMPProcessErrorOrPromptExt = new SAMPProcessErrorOrPromptFactory().Create(appDb);
				
				int Severity = iSAMPProcessErrorOrPromptExt.SAMPProcessErrorOrPromptSp(WarnOnDuplicate,
				                                                                       ref PromptMsg,
				                                                                       ref PromptButtons,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}
	}
}
