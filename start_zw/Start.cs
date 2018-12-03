using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using zzr = ZwSoft.ZwCAD.Runtime;
using zza = ZwSoft.ZwCAD.ApplicationServices;
using zze = ZwSoft.ZwCAD.EditorInput;

namespace start_zw
{
    public class Start : zzr.IExtensionApplication
    {
        string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        int zlicz = 0;
        public static zza.Document doc = zza.Application.DocumentManager.MdiActiveDocument;
        zze.Editor ed = doc.Editor;

        public void Initialize()
        {
            Zaladuj("skala_zw.dll");

            if (zlicz == 0)
            {               
                ed.WriteMessage("\nPI 2019 MIT Edition załadowano poprawnie. Niektóre moduły PI korzystają z silnika bazy danych SQLite - www.sqlite.org.");
            }
            else
            {                
                ed.WriteMessage("\nPI 2019 MIT Edition załadowano z błędami. Informacje o błędach mogą się znajdować we wcześniejszych komunikatach");
            }
        }
        public void Terminate()
        {
            
        }

        public void Zaladuj(string nazwadll)
        {            
            string sciezka = path + "\\" + nazwadll;            
            try
            {
                Assembly.LoadFrom(sciezka);
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
                zlicz = 1;
            }
        }
    }
}

