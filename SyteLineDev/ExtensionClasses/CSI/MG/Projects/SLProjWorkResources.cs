//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjWorkResources.cs

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
	[IDOExtensionClass("SLProjWorkResources")]
	public class SLProjWorkResources : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetWorkResourceListSourceSp(string ResourceType,
		ref string Ref_num_ido_source,
		ref string Ref_name_property_source,
		ref string Ref_num_property_source,
		ref string ref_num_ido_source_filter,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetWorkResourceListSourceExt = new SetWorkResourceListSourceFactory().Create(appDb);
				
				var result = iSetWorkResourceListSourceExt.SetWorkResourceListSourceSp(ResourceType,
				Ref_num_ido_source,
				Ref_name_property_source,
				Ref_num_property_source,
				ref_num_ido_source_filter,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Ref_num_ido_source = result.Ref_num_ido_source;
				Ref_name_property_source = result.Ref_name_property_source;
				Ref_num_property_source = result.Ref_num_property_source;
				ref_num_ido_source_filter = result.ref_num_ido_source_filter;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
