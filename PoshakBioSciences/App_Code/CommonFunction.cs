using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PoshakBioSciences.App_Code
{
    public class CommonFunction
    {
        public static bool CheckUserAuthentication()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            HttpContext.Current.Response.Cache.SetNoStore();
            if (HttpContext.Current.Session["PrCode"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckUserAccessAuthorization(string ControllerActionName, int RoleID, string ControllerName)
        {
            //string Result = string.Empty;
            //try
            //{
            //    DDC_DatabaseEntities1 ObjDbContext = new DDC_DatabaseEntities1();
            //    M_ActionMappingWithRole m_MasterTable = (from MasterTable in ObjDbContext.M_ActionMappingWithRole.Where(x => x.RoleID == RoleID) select MasterTable).FirstOrDefault();
            //    M_ControllerMappingWithActionMappingMaster HasControllerAccess = (from MasterTable in ObjDbContext.M_ControllerMappingWithActionMappingMaster.Where(x => x.ActionMappingID == m_MasterTable.ActionMappingID && x.ControllerName == ControllerName) select MasterTable).FirstOrDefault();
            //    if (HasControllerAccess != null)
            //    {
            //        if (ControllerActionName == "Edit")
            //        {
            //            if (m_MasterTable.AccessEdit)
            //            {
            //                return true;
            //            }
            //            return false;
            //        }
            //        if (ControllerActionName == "View")
            //        {
            //            if (m_MasterTable.AccessView)
            //            {
            //                return true;
            //            }
            //            return false;
            //        }
            //        if (ControllerActionName == "Create")
            //        {
            //            if (m_MasterTable.AccessCreate)
            //            {
            //                return true;
            //            }
            //            return false;
            //        }
            //        if (ControllerActionName == "Delete")
            //        {
            //            if (m_MasterTable.AccessDelete)
            //            {
            //                return true;
            //            }
            //            return false;
            //        }
            //        if (ControllerActionName == "Report")
            //        {
            //            if (m_MasterTable.AccessReport)
            //            {
            //                return true;
            //            }
            //            return false;
            //        }
            //        if (ControllerActionName == "Search")
            //        {
            //            if (m_MasterTable.AccessSearch)
            //            {
            //                return true;
            //            }
            //            return false;
            //        }
            //        if (ControllerActionName == "Role")
            //        {
            //            if (m_MasterTable.AccessSearch)
            //            {
            //                return true;
            //            }
            //            return false;
            //        }
            //    }
            //    return false;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            return true;
        }

        public static bool IsFolderExist(string FolderPathFromResource)
        {
            try
            {
                if (!Directory.Exists(Path.GetFullPath(FolderPathFromResource)))
                {
                    Directory.CreateDirectory(Path.GetFullPath(FolderPathFromResource));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool IsFileExist(string NewFileName)
        {
            try
            {
                if (!File.Exists(Path.GetFullPath(NewFileName)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}