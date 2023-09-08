//PROJECT NAME: MOIndPackExt
//CLASS NAME: MOResourceJobs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.MOIndPack;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.MOIndPack
{
	[IDOExtensionClass("MOResourceJobs")]
	public class MOResourceJobs : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_ResourceJobSaveDeleteSp(string RESID,
		                                      string Item,
		                                      string Job,
		                                      short? Suffix,
		                                      decimal? QtyPerCycle)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMO_ResourceJobSaveDeleteExt = new MO_ResourceJobSaveDeleteFactory().Create(appDb);
				
				int Severity = iMO_ResourceJobSaveDeleteExt.MO_ResourceJobSaveDeleteSp(RESID,
				                                                                       Item,
				                                                                       Job,
				                                                                       Suffix,
				                                                                       QtyPerCycle);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_ResourceJobSaveSp(string RESID,
		                                string Item,
		                                string Job,
		                                short? Suffix,
		                                decimal? QtyPerCycle)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMO_ResourceJobSaveExt = new MO_ResourceJobSaveFactory().Create(appDb);
				
				int Severity = iMO_ResourceJobSaveExt.MO_ResourceJobSaveSp(RESID,
				                                                           Item,
				                                                           Job,
				                                                           Suffix,
				                                                           QtyPerCycle);
				
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_ResourceJobDeleteSp(int? DeleteFlag,
		string RESID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMO_ResourceJobDeleteExt = new MO_ResourceJobDeleteFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMO_ResourceJobDeleteExt.MO_ResourceJobDeleteSp(DeleteFlag,
				RESID);
				
				int Severity = result.Value;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable MO_CLM_ResourceJobSp(string BOMType,
		string CoJob,
		string ProdMix,
		string RESID,
		int? DeleteFlag,
		[Optional] string FilterString)
		{
			var iMO_CLM_ResourceJobExt = new MO_CLM_ResourceJobFactory().Create(this, true);
			
			var result = iMO_CLM_ResourceJobExt.MO_CLM_ResourceJobSp(BOMType,
			CoJob,
			ProdMix,
			RESID,
			DeleteFlag,
			FilterString);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

	}
}
