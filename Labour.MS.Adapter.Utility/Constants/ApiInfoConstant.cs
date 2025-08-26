using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Utility.Constants
{
    public class ApiInfoConstant
    {
        public const string Name = "labourms";
        public const string Version = "v1";
        public const string SubBasePath = "services";
        public const string Adapter = "adapter";

        #region "Establishment routes"

        public const string EstablishmentRegister = "establishment/register";
        public const string EstablishmentDetails = "establishment/details";
        public const string EstablishmentAllDetails = "establishment/alldetails";
        public const string EstablishmentLogin = "establishment/login";
        public const string WorkerAvailableAadhaarCardDetails = "establishment/availableaadhaarcarddetails";
        public const string EstablishmentDashboardCardDetails = "establishment/dashboard/carddetails";
        public const string PersistWorkerDetailsByEstablishment = "establishment/persistworkerdetailsbyestablishment";
        public const string WorkerDetailsByEstablishmentId = "establishment/workerdetails";


        #endregion

        #region "Worker routes"

        public const string WorkerRegister = "worker/register";
        public const string WorkerDetailsById = "worker/detailsbyid";
        public const string WorkerAllDetails = "worker/alldetails";
        public const string WorkerLogin = "worker/login";
        public const string WorkerDashboardCardDetails = "worker/dashboard/carddetails";
        public const string WorkerCheckinOrOut = "worker/checkinorout";
        public const string WorkerRecentAttendance = "worker/recent/attendance";

        #endregion

        #region "Department routes"

        public const string DepartmentLogin = "department/login";
        public const string DepartmentDashboardCardDetails = "department/dashboard/carddetails";

        #endregion

        #region "Master routes"

        public const string VillagesAreasAllDetails = "villagesareas/details";
        public const string VillageAreaDetailsById = "villagesareas/detailsbyId";
        public const string VillagesAreasDetailsByCityId = "villagesareas/villagesareasdetailsbycityid";

        public const string CitiesAllDetails = "cities/details";
        public const string CityDetailsById = "cities/detailsbyId";
        public const string CitiesDetailsByDistrictId = "cities/citiesdetailsbydistrictid";

        public const string DistrictsAllDetails = "districts/details";
        public const string DistrictDetailsById = "districts/detailsbyId";
        public const string DistrictsDetailsByStateId = "districts/districtsdetailsbystateid";

        public const string EstablishmentCategoryDetails = "establishmentcategory/details";
        public const string EstablishmentWorkNatureDetails = "establishmentworknature/details";

        #endregion


        #region "Application Connection String Name/Key"

        public const string NameOfConnectionString = "AppConnectionString";

        #endregion
    }
}
