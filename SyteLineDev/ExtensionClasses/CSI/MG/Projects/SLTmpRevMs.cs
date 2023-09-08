//PROJECT NAME: ProjectsExt
//CLASS NAME: SLTmpRevMs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLTmpRevMs")]
	public class SLTmpRevMs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProcessProjectMilestonesSp(Guid? ProcessID,
		                                      string Process,
		                                      string FromProjNum,
		                                      string ToProjNum,
		                                      DateTime? TransDate,
		                                      string FromProductCode,
		                                      string ToProductCode,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProcessProjectMilestonesExt = new ProcessProjectMilestonesFactory().Create(appDb);
				
				int Severity = iProcessProjectMilestonesExt.ProcessProjectMilestonesSp(ProcessID,
				                                                                       Process,
				                                                                       FromProjNum,
				                                                                       ToProjNum,
				                                                                       TransDate,
				                                                                       FromProductCode,
				                                                                       ToProductCode,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}
	}
}
