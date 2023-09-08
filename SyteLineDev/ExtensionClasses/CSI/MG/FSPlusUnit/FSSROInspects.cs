//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSSROInspects.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusUnit
{
	[IDOExtensionClass("FSSROInspects")]
	public class FSSROInspects : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROInspectFailCountSp(string SroNum,
		                                      int? SroLine,
		                                      string InspectType,
		                                      string SectionCode,
		                                      int? CompId,
		                                      ref int? IntialFailCnt,
		                                      ref int? AdjustFailCnt,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROInspectFailCountExt = new SSSFSSROInspectFailCountFactory().Create(appDb);
				
				int Severity = iSSSFSSROInspectFailCountExt.SSSFSSROInspectFailCountSp(SroNum,
				                                                                       SroLine,
				                                                                       InspectType,
				                                                                       SectionCode,
				                                                                       CompId,
				                                                                       ref IntialFailCnt,
				                                                                       ref AdjustFailCnt,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSNoOpSaveSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSNoOpSaveExt = new SSSFSNoOpSaveFactory().Create(appDb);
				
				int Severity = iSSSFSNoOpSaveExt.SSSFSNoOpSaveSp();
				
				return Severity;
			}
		}
	}
}
