//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCMrrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCMrrs")]
	public class RS_QCMrrs : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateCarSp(string i_mrr,
		string i_crcvr,
		string i_trcvr,
		string i_car,
		ref string o_car,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CreateCarExt = new RSQC_CreateCarFactory().Create(appDb);
				
				var result = iRSQC_CreateCarExt.RSQC_CreateCarSp(i_mrr,
				i_crcvr,
				i_trcvr,
				i_car,
				o_car,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_car = result.o_car;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateVrmaSp(string i_mrr,
		decimal? i_qty,
		string i_vend,
		string i_reason,
		ref int? o_vrma,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CreateVrmaExt = new RSQC_CreateVrmaFactory().Create(appDb);
				
				var result = iRSQC_CreateVrmaExt.RSQC_CreateVrmaSp(i_mrr,
				i_qty,
				i_vend,
				i_reason,
				o_vrma,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_vrma = result.o_vrma;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RSQC_CLM_MRR_CostSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CLM_MRR_CostExt = new RSQC_CLM_MRR_CostFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CLM_MRR_CostExt.RSQC_CLM_MRR_CostSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
