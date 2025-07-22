using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Repository.Constants
{
    public class DbConstants
    {
        #region "Establishment"

        #region "Stored Procedure Parameters"

        public const string P_ESTABLISHMENT_ID = "Establishment_Id";
        public const string P_ESTABLISHMENT_NAME = "Establishment_Name";
        public const string P_CONTACT_PERSON = "Contact_Person";
        public const string P_EMAIL_ID = "Email_Id";
        public const string P_MOBILE_NUMBER = "Mobile_Number";
        public const string P_DOOR_NUMBER = "Door_Number";
        public const string P_STREET = "Street";
        public const string P_STATE_ID = "State_Id";
        public const string P_STATE_CODE = "State_Code";
        public const string P_DISTRICT_ID = "District_Id";
        public const string P_DISTRICT_CODE = "District_Code";
        public const string P_CITY_ID = "City_Id";
        public const string P_CITY_CODE = "City_Code";
        public const string P_VILLAGE_AREA_ID = "Village_Area_Id";
        public const string P_VILLAGE_AREA_Code = "Village_Area_Code";
        public const string P_VILLAGE_AREA_NAME = "Village_Area_NAME";
        public const string P_PINCODE = "Pincode";
        public const string P_IS_PLAN_APPROVAL_ID = "Is_Plan_Approval_Id";
        public const string P_PLAN_APPROVAL_ID = "Plan_Approval_Id";
        public const string P_CATEGORY_ID = "Category_Id";
        public const string P_WORK_NATURE_ID = "Work_Nature_Id";
        public const string P_COMMENCEMENT_DATE = "Commencement_Date";
        public const string P_COMPLETION_DATE = "Completion_Date";
        public const string P_CONSTRUCTION_ESTIMATED_COST = "Construction_Estimated_Cost";
        public const string P_CONSTRUCTION_AREA = "Construction_Area";
        public const string P_BUILT_UP_AREA = "Built_Up_Area";
        public const string P_BASIC_ESTIMATED_COST = "Basic_Estimated_Cost";
        public const string P_NO_OF_MALE_WORKERS = "No_Of_Male_Workers";
        public const string P_NO_OF_FEMALE_WORKERS = "No_Of_Female_Workers";
        public const string P_IS_ACCEPTED_TERMS_CONDITIONS = "Is_Accepted_Terms_Conditions";



        #endregion

        #region "Stored Procedure Names"
        public const string USP_PERSIST_ESTABLISHMENT_DETAILS = "usp_Persist_Establishment_Details";
        public const string USP_GET_ALL_ESTABLISHMENT_DETAILS = "usp_Get_All_Establishment_Details";
        public const string USP_GET_ESTABLISHMENT_DETAILS = "usp_Get_Establishment_Details";
        public const string USP_GET_ESTABLISHMENT_LOGIN_DETAILS = "usp_Get_Establishment_Login_Details";
        public const string USP_GET_ESTABLISHMENT_CARD_DETAILS = "usp_Get_Establishment_Card_Details";

        
        #endregion

        #endregion

        #region "Worker"   

        #region "Stored Procedure Parameters"
        public const string P_WORKER_ID = "Worker_Id";
        public const string P_AADHAAR_CARD_NUMBER = "Aadhaar_Card_Number";
        public const string P_E_SHRAM_ID = "E_Shram_Id";
        public const string P_BOCW_ID = "BoCw_Id";
        public const string P_ACCESS_CARD_ID = "Access_Card_Id";

        public const string P_FIRST_NAME = "First_Name";
        public const string P_LAST_NAME = "Last_Name";
        public const string P_MIDDLE_NAME = "Middle_Name";
        public const string P_GENDER = "Gender";
        public const string P_MARITAL_STATUS = "Marital_Status";
        public const string P_DATE_OF_BIRTH = "Date_Of_Birth";

        public const string P_AGE = "Age";
        public const string P_CASTE = "Caste";
        public const string P_SUB_CASTE = "Sub_Caste";

        public const string P_RELATIVE_NAME = "Relative_Name";        

        public const string P_PER_DOOR_NUMBER = "Per_Door_Number";
        public const string P_PER_STREET = "Per_Street";
        public const string P_PER_STATE_ID = "Per_State_Id";
        public const string P_PER_DISTRICT_ID = "Per_District_Id";
        public const string P_PER_CITY_ID = "Per_City_Id";
        public const string P_PER_VILLAGE_AREA_ID = "Per_Village_Area_Id";
        public const string P_PER_VILLAGE_AREA_NAME = "Per_Village_Area_NAME";
        public const string P_PER_PINCODE = "Per_Pincode";

        public const string P_PRE_DOOR_NUMBER = "Pre_Door_Number";
        public const string P_PRE_STREET = "Pre_Street";
        public const string P_PRE_STATE_ID = "Pre_State_Id";
        public const string P_PRE_DISTRICT_ID = "Pre_District_Id";
        public const string P_PRE_CITY_ID = "Pre_City_Id";
        public const string P_PRE_VILLAGE_AREA_ID = "Pre_Village_Area_Id";
        public const string P_PRE_VILLAGE_AREA_NAME = "Pre_Village_Area_NAME";
        public const string P_PRE_PINCODE = "Pre_Pincode";


        public const string P_IS_NRES_MEMBER = "Is_NRES_Member";
        public const string P_IS_TRADE_UNION = "Is_Trade_Union";
        public const string P_TRADE_UNION_NUMBER = "Trade_Union_Number";

        #endregion

        #region "Stored Procedure Names"

        public const string USP_GET_ALL_WORKER_DETAILS = "usp_Get_All_Worker_Details";
        public const string USP_GET_WORKER_DETAILS_BY_ID = "usp_Get_Worker_Details_By_Id";
        public const string USP_GET_WORKER_DETAILS_BY_ESTABLISHMENT_ID = "usp_Get_Workers_By_Establishment_Id";
        public const string USP_PERSIST_WORKER_DETAILS = "usp_Persist_Worker_Details";
        public const string USP_GET_WORKER_LOGIN_DETAILS = "usp_Get_Worker_Login_Details";
        public const string USP_GET_ALL_AADHAAR_CARD_DETAILS = "usp_Get_All_Aadhaar_Card_Details";
        public const string USP_GET_WORKER_CARD_DETAILS = "usp_Get_Worker_Card_Details";

        #endregion

        #endregion

        #region "Department"

        #region "Stored Procedure Names"

        public const string USP_GET_DEPARTMENT_LOGIN_DETAILS = "usp_Get_Department_Login_Details";
        public const string USP_GET_DEPARTMENT_CARD_DETAILS = "usp_Get_Department_Card_Details";

        #endregion

        #endregion

        #region "Common Stored Procedure Parameters"

        public const string P_PASSWORD = "Password";
        public const string P_STATUS_CODE = "StatusCode";
        public const string P_MESSAGE = "Message";

        #endregion

        #region "Masters"

        #region "Stored Procedure Names"

        public const string GET_CITIES = "Get_Cities";
        public const string GET_DISTRICTS = "Get_Districts";
        public const string GET_VILLAGES_AREAS = "Get_Villages_Areas";

        #endregion

        #endregion
    }
}
