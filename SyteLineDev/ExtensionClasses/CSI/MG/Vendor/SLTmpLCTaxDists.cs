//PROJECT NAME: VendorExt
//CLASS NAME: SLTmpLCTaxDists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLTmpLCTaxDists")]
	public class SLTmpLCTaxDists : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ClearTempLCTaxDistSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iClearTempLCTaxDistExt = new ClearTempLCTaxDistFactory().Create(appDb);
				
				var result = iClearTempLCTaxDistExt.ClearTempLCTaxDistSp();
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LcTaxDistributionCustUpdSp(int? TaxSystem,
		string TaxCode,
		string TaxCodeE,
		decimal? AmtTaxBasis,
		decimal? AmtTaxAmount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLcTaxDistributionCustUpdExt = new LcTaxDistributionCustUpdFactory().Create(appDb);
				
				var result = iLcTaxDistributionCustUpdExt.LcTaxDistributionCustUpdSp(TaxSystem,
				TaxCode,
				TaxCodeE,
				AmtTaxBasis,
				AmtTaxAmount);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GenerateLCTaxDistSp(string PVendNum,
		decimal? PFreight,
		decimal? PBrokerage,
		decimal? PDuty,
		decimal? PLocFreight,
		decimal? PInsurance,
		DateTime? PInvDate,
		int? GenerateTax,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GenerateLCTaxDistExt = new CLM_GenerateLCTaxDistFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GenerateLCTaxDistExt.CLM_GenerateLCTaxDistSp(PVendNum,
				PFreight,
				PBrokerage,
				PDuty,
				PLocFreight,
				PInsurance,
				PInvDate,
				GenerateTax,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
