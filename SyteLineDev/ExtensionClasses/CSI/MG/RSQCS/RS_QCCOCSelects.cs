//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCCOCSelects.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.RSQCS
{
    [IDOExtensionClass("RS_QCCOCSelects")]
    public class RS_QCCOCSelects : ExtensionClassBase, IExtFTRS_QCCOCSelects
    {	
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CheckCOCSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Item,
		ref int? QCItem,
		ref int? COCItem,
		ref decimal? QtyCOC,
		ref decimal? QtyCOCPrinted,
		ref Guid? SessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CheckCOCExt = new RSQC_CheckCOCFactory().Create(appDb);
				
				var result = iRSQC_CheckCOCExt.RSQC_CheckCOCSp(CoNum,
				CoLine,
				CoRelease,
				Item,
				QCItem,
				COCItem,
				QtyCOC,
				QtyCOCPrinted,
				SessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				QCItem = result.QCItem;
				COCItem = result.COCItem;
				QtyCOC = result.QtyCOC;
				QtyCOCPrinted = result.QtyCOCPrinted;
				SessionID = result.SessionID;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CheckCOCTOSp(string ToNum,
		int? ToLine,
		int? ToRelease,
		string Item,
		ref int? QCItem,
		ref int? COCItem,
		ref decimal? QtyCOC,
		ref decimal? QtyCOCPrinted,
		ref Guid? SessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CheckCOCTOExt = new RSQC_CheckCOCTOFactory().Create(appDb);
				
				var result = iRSQC_CheckCOCTOExt.RSQC_CheckCOCTOSp(ToNum,
				ToLine,
				ToRelease,
				Item,
				QCItem,
				COCItem,
				QtyCOC,
				QtyCOCPrinted,
				SessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				QCItem = result.QCItem;
				COCItem = result.COCItem;
				QtyCOC = result.QtyCOC;
				QtyCOCPrinted = result.QtyCOCPrinted;
				SessionID = result.SessionID;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ShipCleanupCOCSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ShipCleanupCOCExt = new RSQC_ShipCleanupCOCFactory().Create(appDb);
				
				var result = iRSQC_ShipCleanupCOCExt.RSQC_ShipCleanupCOCSp(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ShipUpdateCOCSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ShipUpdateCOCExt = new RSQC_ShipUpdateCOCFactory().Create(appDb);
				
				var result = iRSQC_ShipUpdateCOCExt.RSQC_ShipUpdateCOCSp(CoNum,
				CoLine,
				CoRelease,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
