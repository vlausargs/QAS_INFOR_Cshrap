//PROJECT NAME: PPIndPackExt
//CLASS NAME: PPJobrouteMatlUsages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.PrintingPackaging;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PPIndPack
{
	[IDOExtensionClass("PPJobrouteMatlUsages")]
	public class PPJobrouteMatlUsages : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PP_InsertMaterialUsageSp([Optional] string Job,
		[Optional] int? Suffix,
		[Optional] int? Oper_num,
		[Optional] int? Sequence,
		[Optional] string Item,
		[Optional] decimal? Length,
		[Optional] decimal? Width,
		[Optional] decimal? Height,
		[Optional] int? Number_of_joints,
		[Optional] int? Use_for_matching_criteria)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPP_InsertMaterialUsageExt = new PP_InsertMaterialUsageFactory().Create(appDb);
				
				var result = iPP_InsertMaterialUsageExt.PP_InsertMaterialUsageSp(Job,
				Suffix,
				Oper_num,
				Sequence,
				Item,
				Length,
				Width,
				Height,
				Number_of_joints,
				Use_for_matching_criteria);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
