//PROJECT NAME: PmfExt
//CLASS NAME: PmfParmsBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PMF
{
	[IDOExtensionClass("PmfParmsBase")]
	public class PmfParmsBase : CSIExtensionClassBase
	{
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PmfDataInit([Optional] ref string Infobar)
        {
            var iPmfDataInitExt = new PmfDataInitFactory().Create(this, true);

            var result = iPmfDataInitExt.PmfDataInitSp(Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfGetRowPointerFromColValuesSp(string TableName,
			string IdColumn1,
			string Value1,
			[Optional] string IdColumn2,
			[Optional] string Value2,
			[Optional] string IdColumn3,
			[Optional] string Value3,
			[Optional] ref Guid? RowPointer,
			[Optional] ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfGetRowPointerFromColValuesExt = new PmfGetRowPointerFromColValuesFactory().Create(appDb);
				
				var result = iPmfGetRowPointerFromColValuesExt.PmfGetRowPointerFromColValuesSp(TableName,
					IdColumn1,
					Value1,
					IdColumn2,
					Value2,
					IdColumn3,
					Value3,
					RowPointer,
					InfoBar);
				
				int Severity = result.ReturnCode.Value;
				RowPointer = result.RowPointer;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfGetSystemDefaultsSp([Optional] ref string InfoBar,
		[Optional] string Whse,
		[Optional] ref string BaseWtUm,
		[Optional] ref string BaseVolUm,
		[Optional] ref string DensityDesc,
		[Optional] ref string DefStagingLoc,
		[Optional] ref string DefWipItem,
		[Optional] ref Guid? SessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfGetSystemDefaultsExt = new PmfGetSystemDefaultsFactory().Create(appDb);
				
				var result = iPmfGetSystemDefaultsExt.PmfGetSystemDefaultsSp(InfoBar,
				Whse,
				BaseWtUm,
				BaseVolUm,
				DensityDesc,
				DefStagingLoc,
				DefWipItem,
				SessionId);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				BaseWtUm = result.BaseWtUm;
				BaseVolUm = result.BaseVolUm;
				DensityDesc = result.DensityDesc;
				DefStagingLoc = result.DefStagingLoc;
				DefWipItem = result.DefWipItem;
				SessionId = result.SessionId;
				return Severity;
			}
		}
	}
}
