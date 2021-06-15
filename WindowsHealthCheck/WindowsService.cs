using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DobsonUtilities
{
    class WindowsService
    {
        public WindowsService()
        {
        }

        public static void Set(string servicename)
        {
            using (System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController())
            {
                service.ServiceName = servicename;
            }
        }

        public static string Status(string servicename)
        {
            using (System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(servicename))
            {
                return service.Status.ToString();
            }
        }

        public static bool Start(string servicename)
        {
            using (System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(servicename))
            {
                try
                {
                    service.Start();
                    service.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }

        public static bool Stop(string servicename)
        {
            using (System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(servicename))
            {
                try
                {
                    service.Stop();
                    service.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }
    }
}
