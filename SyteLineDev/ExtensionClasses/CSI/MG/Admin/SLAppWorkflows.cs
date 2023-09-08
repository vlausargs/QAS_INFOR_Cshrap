//PROJECT NAME: AdminExt
//CLASS NAME: SLAppWorkflows.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
	[IDOExtensionClass("SLAppWorkflows")]
	public class SLAppWorkflows : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AppWorkflowParmUpdateSp(string Name1,
		string Value1,
		string Name2,
		string Value2,
		string Name3,
		string Value3)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAppWorkflowParmUpdateExt = new AppWorkflowParmUpdateFactory().Create(appDb);
				
				var result = iAppWorkflowParmUpdateExt.AppWorkflowParmUpdateSp(Name1,
				Value1,
				Name2,
				Value2,
				Name3,
				Value3);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AppWorkflowUpdateSp(Guid? EventHandlerRP,
		int? Active,
		string AppName,
		int? CreateTrigger)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAppWorkflowUpdateExt = new AppWorkflowUpdateFactory().Create(appDb);
				
				var result = iAppWorkflowUpdateExt.AppWorkflowUpdateSp(EventHandlerRP,
				Active,
				AppName,
				CreateTrigger);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
