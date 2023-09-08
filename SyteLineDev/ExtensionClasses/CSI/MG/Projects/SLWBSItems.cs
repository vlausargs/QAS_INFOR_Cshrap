//PROJECT NAME: ProjectsExt
//CLASS NAME: SLWBSItems.cs

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
	[IDOExtensionClass("SLWBSItems")]
	public class SLWBSItems : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int WBSItemDeleteCheckMilestonesSp(string ProjNum,
		string WbsNum,
		string WbsItemRefType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iWBSItemDeleteCheckMilestonesExt = new WBSItemDeleteCheckMilestonesFactory().Create(appDb);
				
				var result = iWBSItemDeleteCheckMilestonesExt.WBSItemDeleteCheckMilestonesSp(ProjNum,
				WbsNum,
				WbsItemRefType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
