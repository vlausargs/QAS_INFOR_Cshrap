using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;

namespace CSI.CRUD.Material.PlantMfgWhseValidityChecker
{
    public interface IPlantMfgWhseValidityCheckerCRUD
    {
        PlantType GetPlantByMfgWhse(WhseType MfgWhse);
        (ListYesNoType DedicatedInventory, ConsignmentTypeType ConsignmentType, ListYesNoType ControlledByExternalWMS) GetWhseSettings(WhseType Whse);
    }

    public class PlantMfgWhseValidityCheckerCRUD : IPlantMfgWhseValidityCheckerCRUD
    {
        private readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        private readonly IApplicationDB appDB;

        public PlantMfgWhseValidityCheckerCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadRequestFactory));
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
        }

        public PlantType GetPlantByMfgWhse(WhseType MfgWhse)
        {
            PlantType Plant = DBNull.Value;

            var request = collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {Plant, "plant" }
                },
                tableName: "plant",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause("WITH (READUNCOMMITTED)"),
                orderByClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("mfg_whse={0}" , MfgWhse),
                maximumRows: 1
                );

            appDB.Load(request);

            return Plant;
        }

        public (ListYesNoType DedicatedInventory,
                ConsignmentTypeType ConsignmentType,
                ListYesNoType ControlledByExternalWMS)
            GetWhseSettings(WhseType Whse)
        {
            ListYesNoType DedicatedInventory = DBNull.Value;
            ConsignmentTypeType ConsignmentType = DBNull.Value;
            ListYesNoType ControlledByExternalWMS = DBNull.Value;

            var request = collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {DedicatedInventory, "dedicated_inventory" },
                    {ConsignmentType, "consignment_type" },
                    {ControlledByExternalWMS, "controlled_by_external_wms" }
                },
                tableName: "whse",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause("WITh (READUNCOMMITTED)"),
                orderByClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("whse={0}", Whse),
                maximumRows: 1
                );

            appDB.Load(request);

            return (DedicatedInventory, ConsignmentType, ControlledByExternalWMS);

        }
    }
}
