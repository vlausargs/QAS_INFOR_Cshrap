//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjMsGroups.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLProjMsGroups")]
	public class SLProjMsGroups : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RecalculateObligationsSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRecalculateObligationsExt = new RecalculateObligationsFactory().Create(appDb);
				
				var result = iRecalculateObligationsExt.RecalculateObligationsSp(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
