//PROJECT NAME: MOIndPackExt
//CLASS NAME: MOResourceMaints.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.MOIndPack;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.MOIndPack
{
	[IDOExtensionClass("MOResourceMaints")]
	public class MOResourceMaints : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CloseResMantSp(string MOMaintenanceID,
		                          short? AltNo,
		                          byte? DelAssSchMaint,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCloseResMantExt = new CloseResMantFactory().Create(appDb);
				
				int Severity = iCloseResMantExt.CloseResMantSp(MOMaintenanceID,
				                                               AltNo,
				                                               DelAssSchMaint,
				                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_ResourceMaintenanceStatusChangeSp(string FromMaintenanceId,
		                                                string ToMaintenanceId,
		                                                string FromMaintenanceType,
		                                                string ToMaintenanceType,
		                                                string FromResourceType,
		                                                string ToResourceType,
		                                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMO_ResourceMaintenanceStatusChangeExt = new MO_ResourceMaintenanceStatusChangeFactory().Create(appDb);
				
				int Severity = iMO_ResourceMaintenanceStatusChangeExt.MO_ResourceMaintenanceStatusChangeSp(FromMaintenanceId,
				                                                                                           ToMaintenanceId,
				                                                                                           FromMaintenanceType,
				                                                                                           ToMaintenanceType,
				                                                                                           FromResourceType,
				                                                                                           ToResourceType,
				                                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int OpenResMantSp(string MOMaintenanceID,
		                         short? AltNo,
		                         ref string Infobar,
		                         [Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iOpenResMantExt = new OpenResMantFactory().Create(appDb);
				
				var result = iOpenResMantExt.OpenResMantSp(MOMaintenanceID,
				                                           AltNo,
				                                           Infobar,
				                                           Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
