//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCVendors.cs

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
	[IDOExtensionClass("RS_QCVendors")]
	public class RS_QCVendors : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetVendorDataSp(string i_vendor,
		string o_stat,
		string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetVendorDataExt = new RSQC_GetVendorDataFactory().Create(appDb);
				
				var result = iRSQC_GetVendorDataExt.RSQC_GetVendorDataSp(i_vendor,
				o_stat,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
