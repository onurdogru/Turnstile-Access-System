// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.Ayarlar
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\PROJELER\2-) Gömülü Sistem Projeleri\(1707482-537)_Fabrika Girişi İçin Temassız Sıcaklık Ölçüm İstasyonu\SOFTWARE\GUI\esd-rar\ESD\Release\EsdTurnikesi.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO.Ports;
using System.Runtime.CompilerServices;


namespace EsdTurnikesi
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed class Ayarlar : ApplicationSettingsBase
    {
        private static Ayarlar defaultInstance = (Ayarlar)SettingsBase.Synchronized((SettingsBase)new Ayarlar());

        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
        }

        public static Ayarlar Default
        {
            get
            {
                return Ayarlar.defaultInstance;
            }
        }
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("COM5")]
        public string mifareCom3
        {
            get
            {
                return (string)this[nameof(mifareCom3)];
            }
            set
            {
                this[nameof(mifareCom3)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("COM1")]
        public string mifareCom
        {
            get
            {
                return (string)this[nameof(mifareCom)];
            }
            set
            {
                this[nameof(mifareCom)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("9600")]
        public int mifareBaud
        {
            get
            {
                return (int)this[nameof(mifareBaud)];
            }
            set
            {
                this[nameof(mifareBaud)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("8")]
        public int mifaredataBits
        {
            get
            {
                return (int)this[nameof(mifaredataBits)];
            }
            set
            {
                this[nameof(mifaredataBits)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("One")]
        public StopBits mifarestopBit
        {
            get
            {
                return (StopBits)this[nameof(mifarestopBit)];
            }
            set
            {
                this[nameof(mifarestopBit)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("None")]
        public Parity mifareParity
        {
            get
            {
                return (Parity)this[nameof(mifareParity)];
            }
            set
            {
                this[nameof(mifareParity)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("COM2")]
        public string esdCom
        {
            get
            {
                return (string)this[nameof(esdCom)];
            }
            set
            {
                this[nameof(esdCom)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("9600")]
        public int esdBaud
        {
            get
            {
                return (int)this[nameof(esdBaud)];
            }
            set
            {
                this[nameof(esdBaud)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("8")]
        public int esddataBits
        {
            get
            {
                return (int)this[nameof(esddataBits)];
            }
            set
            {
                this[nameof(esddataBits)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("One")]
        public StopBits esdstopBit
        {
            get
            {
                return (StopBits)this[nameof(esdstopBit)];
            }
            set
            {
                this[nameof(esdstopBit)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("None")]
        public Parity esdParity
        {
            get
            {
                return (Parity)this[nameof(esdParity)];
            }
            set
            {
                this[nameof(esdParity)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(@"192.168.0.8\MEYER")]
        public string ServerName
        {
            get
            {
                return (string)this[nameof(ServerName)];
            }
            set
            {
                this[nameof(ServerName)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("ALPPLAS14336_Meyer")]
        public string DatabaseName
        {
            get
            {
                return (string)this[nameof(DatabaseName)];
            }
            set
            {
                this[nameof(DatabaseName)] = (object)value;
            }
        }
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("atesolcer")]
        public string UserName
        {
            get
            {
                return (string)this[nameof(UserName)];
            }
            set
            {
                this[nameof(UserName)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("AtsOlC*54AtsOlC*54")]
        public string Password
        {
            get
            {
                return (string)this[nameof(Password)];
            }
            set
            {
                this[nameof(Password)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Kitaplıklar\\Belgeler\\IDList.accdb")]
        public string IDdosyayolu
        {
            get
            {
                return (string)this[nameof(IDdosyayolu)];
            }
            set
            {
                this[nameof(IDdosyayolu)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Kitaplıklar\\Belgeler\\log.accdb")]
        public string Logdosyayolu
        {
            get
            {
                return (string)this[nameof(Logdosyayolu)];
            }
            set
            {
                this[nameof(Logdosyayolu)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("COM3")]
        public string plcCom
        {
            get
            {
                return (string)this[nameof(plcCom)];
            }
            set
            {
                this[nameof(plcCom)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("9600")]
        public int plcBaud
        {
            get
            {
                return (int)this[nameof(plcBaud)];
            }
            set
            {
                this[nameof(plcBaud)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("7")]
        public int plcdataBits
        {
            get
            {
                return (int)this[nameof(plcdataBits)];
            }
            set
            {
                this[nameof(plcdataBits)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("One")]
        public StopBits plcstopBit
        {
            get
            {
                return (StopBits)this[nameof(plcstopBit)];
            }
            set
            {
                this[nameof(plcstopBit)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Even")]
        public Parity plcParity
        {
            get
            {
                return (Parity)this[nameof(plcParity)];
            }
            set
            {
                this[nameof(plcParity)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("500")]
        public int timerModbus
        {
            get
            {
                return (int)this[nameof(timerModbus)];
            }
            set
            {
                this[nameof(timerModbus)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("3000")]
        public int timerBekleme
        {
            get
            {
                return (int)this[nameof(timerBekleme)];
            }
            set
            {
                this[nameof(timerBekleme)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("500")]
        public int timerCikis
        {
            get
            {
                return (int)this[nameof(timerCikis)];
            }
            set
            {
                this[nameof(timerCikis)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool checkAyak
        {
            get
            {
                return (bool)this[nameof(checkAyak)];
            }
            set
            {
                this[nameof(checkAyak)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool checkBileklik
        {
            get
            {
                return (bool)this[nameof(checkBileklik)];
            }
            set
            {
                this[nameof(checkBileklik)] = (object)value;
            }
        }
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool checkVardiye1
        {
            get
            {
                return (bool)this[nameof(checkVardiye1)];
            }
            set
            {
                this[nameof(checkVardiye1)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool checkVardiye2
        {
            get
            {
                return (bool)this[nameof(checkVardiye2)];
            }
            set
            {
                this[nameof(checkVardiye2)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool checkVardiye3
        {
            get
            {
                return (bool)this[nameof(checkVardiye3)];
            }
            set
            {
                this[nameof(checkVardiye3)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Arge1@alpplas.com")]
        public string mailAdress
        {
            get
            {
                return (string)this[nameof(mailAdress)];
            }
            set
            {
                this[nameof(mailAdress)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1299")]
        public string adminSifre
        {
            get
            {
                return (string)this[nameof(adminSifre)];
            }
            set
            {
                this[nameof(adminSifre)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Babil4444**")]
        public string mailSifre
        {
            get
            {
                return (string)this[nameof(mailSifre)];
            }
            set
            {
                this[nameof(mailSifre)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1000")]
        public int timerESD
        {
            get
            {
                return (int)this[nameof(timerESD)];
            }
            set
            {
                this[nameof(timerESD)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("3000")]
        public int timerAdmin
        {
            get
            {
                return (int)this[nameof(timerAdmin)];
            }
            set
            {
                this[nameof(timerAdmin)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1000")]
        public int timerMifare
        {
            get
            {
                return (int)this[nameof(timerMifare)];
            }
            set
            {
                this[nameof(timerMifare)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("750")]
        public int timerTurnike
        {
            get
            {
                return (int)this[nameof(timerTurnike)];
            }
            set
            {
                this[nameof(timerTurnike)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("COM4")]
        public string mifareCom2
        {
            get
            {
                return (string)this[nameof(mifareCom2)];
            }
            set
            {
                this[nameof(mifareCom2)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("9600")]
        public int mifareBaud2
        {
            get
            {
                return (int)this[nameof(mifareBaud2)];
            }
            set
            {
                this[nameof(mifareBaud2)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("8")]
        public int mifaredataBits2
        {
            get
            {
                return (int)this[nameof(mifaredataBits2)];
            }
            set
            {
                this[nameof(mifaredataBits2)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("One")]
        public StopBits mifarestopBits2
        {
            get
            {
                return (StopBits)this[nameof(mifarestopBits2)];
            }
            set
            {
                this[nameof(mifarestopBits2)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("None")]
        public Parity mifareParity2
        {
            get
            {
                return (Parity)this[nameof(mifareParity2)];
            }
            set
            {
                this[nameof(mifareParity2)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1000")]
        public int timerMifare2
        {
            get
            {
                return (int)this[nameof(timerMifare2)];
            }
            set
            {
                this[nameof(timerMifare2)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("07:00:00")]
        public string vardiyeSaat1
        {
            get
            {
                return (string)this[nameof(vardiyeSaat1)];
            }
            set
            {
                this[nameof(vardiyeSaat1)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("15:00:00")]
        public string vardiyeSaat2
        {
            get
            {
                return (string)this[nameof(vardiyeSaat2)];
            }
            set
            {
                this[nameof(vardiyeSaat2)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("15:00:00")]
        public string vardiyeSaat3
        {
            get
            {
                return (string)this[nameof(vardiyeSaat3)];
            }
            set
            {
                this[nameof(vardiyeSaat3)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("23:00:00")]
        public string vardiyeSaat4
        {
            get
            {
                return (string)this[nameof(vardiyeSaat4)];
            }
            set
            {
                this[nameof(vardiyeSaat4)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("23:00:00")]
        public string vardiyeSaat5
        {
            get
            {
                return (string)this[nameof(vardiyeSaat5)];
            }
            set
            {
                this[nameof(vardiyeSaat5)] = (object)value;
            }
        }
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("15:00:00")]
        public string vardiyeSaat6
        {
            get
            {
                return (string)this[nameof(vardiyeSaat6)];
            }
            set
            {
                this[nameof(vardiyeSaat6)] = (object)value;
            }
        }
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public BindingList<int> departmentListIndex
        {
            get
            {
                return (BindingList<int>)this[nameof(departmentListIndex)];
            }
            set
            {
                this[nameof(BindingList<int>)] = (object)value;
            }
        }
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public BindingList<int> departmentList
        {
            get
            {
                return (BindingList<int>)this[nameof(departmentList)];
            }
            set
            {
                this[nameof(BindingList<int>)] = (object)value;
            }
        }
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public BindingList<int> mailDepartmentListIndex
        {
            get
            {
                return (BindingList<int>)this[nameof(mailDepartmentListIndex)];
            }
            set
            {
                this[nameof(BindingList<int>)] = (object)value;
            }
        }
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public BindingList<int> mailDepartmentList
        {
            get
            {
                return (BindingList<int>)this[nameof(mailDepartmentList)];
            }
            set
            {
                this[nameof(BindingList<int>)] = (object)value;
            }
        }
    }
}
