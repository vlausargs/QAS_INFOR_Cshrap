//PROJECT NAME: FSPlusExt
//CLASS NAME: SLPortalFSUnitRegs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlus
{
	[IDOExtensionClass("SLPortalFSUnitRegs")]
	public class SLPortalFSUnitRegs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalCreateUnitRegSp(string SerNum,
		                                      string Item,
		                                      string Name,
		                                      string Addr1,
		                                      string Addr2,
		                                      string Addr3,
		                                      string Addr4,
		                                      string City,
		                                      string State,
		                                      string Zip,
		                                      string Country,
		                                      string Phone,
		                                      string Email,
		                                      string RegNotes,
		                                      [Optional, DefaultParameterValue((byte)0)] byte? Validate,
		ref string TransNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalCreateUnitRegExt = new SSSFSPortalCreateUnitRegFactory().Create(appDb);
				
				var result = iSSSFSPortalCreateUnitRegExt.SSSFSPortalCreateUnitRegSp(SerNum,
				                                                                     Item,
				                                                                     Name,
				                                                                     Addr1,
				                                                                     Addr2,
				                                                                     Addr3,
				                                                                     Addr4,
				                                                                     City,
				                                                                     State,
				                                                                     Zip,
				                                                                     Country,
				                                                                     Phone,
				                                                                     Email,
				                                                                     RegNotes,
				                                                                     Validate,
				                                                                     TransNum,
				                                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				TransNum = result.TransNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
