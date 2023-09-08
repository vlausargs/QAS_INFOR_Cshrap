//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHPVuchers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.ChineseFinancials
{
    [IDOExtensionClass("CHPVuchers")]
    public class CHPVuchers : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSCLM_LoadPostedVouchersSp([Optional] short? fiscal_year,
		                                             [Optional] byte? period,
		                                             [Optional] string CrntNmbrStart,
		                                             [Optional] string CrntNmbrEnd,
		                                             [Optional] string TypeCode,
		                                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSCLM_LoadPostedVouchersExt = new CHSCLM_LoadPostedVouchersFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSCLM_LoadPostedVouchersExt.CHSCLM_LoadPostedVouchersSp(fiscal_year,
				                                                                       period,
				                                                                       CrntNmbrStart,
				                                                                       CrntNmbrEnd,
				                                                                       TypeCode,
				                                                                       Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}
