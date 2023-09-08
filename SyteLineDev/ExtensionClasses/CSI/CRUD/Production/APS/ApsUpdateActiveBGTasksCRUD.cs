//PROJECT NAME: Production
//CLASS NAME: ApsUpdateActiveBGTasksCRUD.cs

using System.Collections.Generic;
using CSI.MG;
using CSI.Data.CRUD;

namespace CSI.Production.APS
{
	public class ApsUpdateActiveBGTasksCRUD : IApsUpdateActiveBGTasksCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		
		public ApsUpdateActiveBGTasksCRUD(IApplicationDB appDB,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory)
		{
			this.appDB = appDB;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
		}
		
		public ICollectionLoadResponse Aps_parm_Select()
        {
			var aps_parmLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
				    { "site_ref",   "site_ref"                                            },
					{ "alwayson",   "ISNULL(sql_server_alwayson, 0)"                      },
				    { "listener",   "ISNULL(sql_server_availability_group_listener, N'')" },
				    { "login",      "ISNULL(sql_server_login, N'')"                       },
					{ "pass",       "ISNULL(sql_server_password, N'')"                    },
					{ "dbname",     "DB_NAME()"                                           },
					{ "servername", "dbo.GetServerName()"                                 }
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "aps_parm_mst",
				fromClause: collectionLoadRequestFactory.Clause("WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("aps_parm_key = 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			return appDB.Load(aps_parmLoadRequest);
		}

		public void ActiveBGTasks_Update(string site_ref, string sReplace)
		{
			var ActiveBGTasksLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "TaskParm",   "TaskParm"   },
					{ "TaskParms1", "TaskParms1" }
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName: "ActiveBGTasks_mst",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause($"SiteRef = N'{site_ref}' AND TaskName in (N'Planning', N'Scheduling') AND TaskStatusCode = N'WAITING'"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var ActiveBGTasksLoadResponse = appDB.Load(ActiveBGTasksLoadRequest);

			foreach (var item in ActiveBGTasksLoadResponse.Items)
			{
				string sTaskParm = item.GetValue<string>("TaskParm");
				string sTaskParm_Replace = sTaskParm;
				if (!string.IsNullOrEmpty(sTaskParm))
				{
					int index = sTaskParm.IndexOf(" -s ");
					if (index > 0)
					{
						sTaskParm_Replace = sReplace + sTaskParm.Substring(index);
					}
				}
				item.SetValue<string>("TaskParm", sTaskParm_Replace);

				string sTaskParms1 = item.GetValue<string>("TaskParms1");
				string sTaskParms1_Replace = sTaskParms1;
				if (!string.IsNullOrEmpty(sTaskParms1))
				{
					int index = sTaskParms1.IndexOf(" -s ");
					if (index > 0)
					{
						sTaskParms1_Replace = sReplace + sTaskParms1.Substring(index);
					}
				}
				item.SetValue<string>("TaskParms1", sTaskParms1_Replace);
			};
			
			var ActiveBGTasksRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "ActiveBGTasks_mst",
				items: ActiveBGTasksLoadResponse.Items);
			
			appDB.Update(ActiveBGTasksRequestUpdate);
		}
	}
}
