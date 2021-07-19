using System;
using SolidWorks.Interop.swpublished;
using SolidWorks.Interop.sldworks;
using System.Runtime.InteropServices;
using System.IO;


namespace MyFirstAddin
{
    [Guid("54a1e284-091e-4c10-9e81-47f91ea0d770"), ComVisible(true)]
    public class Main : ISwAddin
    {
        private int mSwCookie;
        private TaskpaneView mTaskpaneView;
        private TaskpaneHostUI mTaskpaneHost;
        private SldWorks mSolidWorksApplication;
        public const string SWTASKPANE_PROGID = "SolidWorks.NewAddin";
        internal static SldWorks App { get; private set; }

        public bool ConnectToSW(object ThisSW, int cookie)
        {
            App = (SldWorks)ThisSW;
            mSolidWorksApplication = (SldWorks)ThisSW;
            App.SendMsgToUser("Hello!");
            mSwCookie = cookie;

            var ok = mSolidWorksApplication.SetAddinCallbackInfo2(0, this, mSwCookie);
            LoadUI();

            return true;
        }

        public bool DisconnectFromSW()
        {
            App.SendMsgToUser("Goodbye!");
            UnloadUI();
            Marshal.ReleaseComObject(App);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return true;
        }

        private void LoadUI()
        {
            var imagePath = Path.Combine(Path.GetDirectoryName(typeof(Main).Assembly.CodeBase).Replace(@"file:\", string.Empty), "Webp.net-resizeimage.bmp");
            
            mTaskpaneView = mSolidWorksApplication.CreateTaskpaneView2(imagePath, "Addin used to compare dxf files");

            mTaskpaneHost = (TaskpaneHostUI)mTaskpaneView.AddControl(Main.SWTASKPANE_PROGID, string.Empty);
        }
        private void UnloadUI()
        {
            //mTaskpaneHost = null;

            mTaskpaneView.DeleteView();
            Marshal.ReleaseComObject(mTaskpaneView);

            //mTaskpaneView = null;
        }

        static internal void ImportFile(string filePath)
        {
            ModelDoc2 model = default(ModelDoc2);
            string fileName = filePath;
            string argString = null;
            int Err = 0;
            ImportDxfDwgData importData = default(ImportDxfDwgData);
            model = (ModelDoc2)App.LoadFile4(fileName, argString, importData, ref Err);
        }
    
        [ComRegisterFunction()]
        private static void RegisterFunction(Type t)
        {
            Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey hkcu = Microsoft.Win32.Registry.CurrentUser;
            string keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
            Microsoft.Win32.RegistryKey addinkey = hklm.CreateSubKey(keyname);
            addinkey.SetValue(null, 1);
            addinkey.SetValue("Description", "This is my first addin");
            addinkey.SetValue("Title", "MyFirstAddin");
            keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
            addinkey = hkcu.CreateSubKey(keyname);
            addinkey.SetValue(null, 1);
        }

        [ComUnregisterFunction]
        private static void UnregisterFunction(Type t)
        {
            Microsoft.Win32.RegistryKey hkcu = Microsoft.Win32.Registry.CurrentUser;
            string keyname = "SOFTWARE\\SolidWorks\\AddinsStartup\\{" + t.GUID.ToString() + "}";
            hkcu.DeleteSubKey(keyname);
            Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
            keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
            hklm.DeleteSubKey(keyname);
        }
    }
}
