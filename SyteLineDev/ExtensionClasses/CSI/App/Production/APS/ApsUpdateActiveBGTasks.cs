//PROJECT NAME: Production
//CLASS NAME: ApsUpdateActiveBGTasks.cs

using System;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public class ApsUpdateActiveBGTasks : IApsUpdateActiveBGTasks
	{
		readonly IApsUpdateActiveBGTasksCRUD iApsUpdateActiveBGTasksCRUD;

		public ApsUpdateActiveBGTasks(IApsUpdateActiveBGTasksCRUD iApsUpdateActiveBGTasksCRUD)
		{
			this.iApsUpdateActiveBGTasksCRUD = iApsUpdateActiveBGTasksCRUD;
		}

		public int? UpdateActiveBGTasks()
		{
			int? Severity = 0;
			SiteType site_ref;
			ListYesNoType alwayson;
			OSDomainLabelNameType listener;
			UsernameType login;
			EncryptedPasswordType pass;
			StringType dbname;
			StringType servername;

			var aps_parmLoadResponse = iApsUpdateActiveBGTasksCRUD.Aps_parm_Select();

			foreach (var item in aps_parmLoadResponse.Items)
            {
				site_ref = item.GetValue<SiteType>("site_ref");
				alwayson = item.GetValue<ListYesNoType>("alwayson");
				listener = item.GetValue<OSDomainLabelNameType>("listener");
				login = item.GetValue<UsernameType>("login");
				pass = item.GetValue<EncryptedPasswordType>("pass");
				dbname = item.GetValue<StringType>("dbname");
				servername = item.GetValue<StringType>("servername");

				if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(pass))
				{
					string sServer = ((alwayson == 1) && !string.IsNullOrEmpty(listener)) ? listener : servername;

					string sAlwaysOn = (alwayson == 1) ? "-alwayson" : "";

					string sReplace = $"~LIT~({sServer}) ~LIT~({dbname.Value}) ~LIT~({login.Value}) ~LIT~(\")~LIT~({pass.Value})~LIT~(\") -e {sAlwaysOn}";

					iApsUpdateActiveBGTasksCRUD.ActiveBGTasks_Update(site_ref.Value, sReplace);
				}
			}

			return Severity;
		}
	}
}
