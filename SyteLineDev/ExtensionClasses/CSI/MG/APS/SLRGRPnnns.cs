//PROJECT NAME: APSExt
//CLASS NAME: SLRGRPnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Production;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLRGRPnnns")]
    public class SLRGRPnnns : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetRGRPSp(int? AltNo,
			[Optional] string Filter)
		{
			var iCLM_ApsGetRGRPExt = this.GetService<ICLM_ApsGetRGRP>();
			
			var result = iCLM_ApsGetRGRPExt.CLM_ApsGetRGRPSp(AltNo,
				Filter);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RgrpDelSp(string Rgid,
		int? AltNo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRgrpDelExt = new RgrpDelFactory().Create(appDb);
				
				var result = iRgrpDelExt.RgrpDelSp(Rgid,
				AltNo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsRGRPDelSp(int? AltNo,
		string RgID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsRGRPDelExt = new ApsRGRPDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsRGRPDelExt.ApsRGRPDelSp(AltNo,
				RgID);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsRGRPSaveSp(int? InsertFlag,
		int? AltNo,
		string RGID,
		string DESCR,
		string SLTYPE,
		decimal? BUFFERIN,
		decimal? BUFFEROUT,
		decimal? INFCAP,
		int? ALLOCRL,
		string INFINITEFG,
		string REALLOCFG,
		string LOADFG,
		                         string SUMFG,
                                 string plant,
                                 string RGID_alias)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsRGRPSaveExt = new ApsRGRPSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsRGRPSaveExt.ApsRGRPSaveSp(InsertFlag,
				AltNo,
				RGID,
				DESCR,
				SLTYPE,
				BUFFERIN,
				BUFFEROUT,
				INFCAP,
				ALLOCRL,
				INFINITEFG,
				REALLOCFG,
				LOADFG,
				                                             SUMFG,
                                                             plant,
                                                             RGID_alias);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
