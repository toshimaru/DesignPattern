using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// http://www.codeproject.com/Articles/470476/Understanding-and-Implementing-Builder-Pattern-in
namespace ConsoleApplication
{
    class MainApp
    {
        static void Main (string[] args)
        {
            var android = new AndroidBuilder ();
            var manifacture = new Manifacture ();
            manifacture.Construct (android);

            Console.Write (android.phone);
        }
    }

    public enum ScreenType
    {
        ScreenType_TOUCH,
        ScreenType_NON_TOUCH
    }

    public enum OperatingSystem
    {
        ANDROID,
        WINDOWS_PHONE,
        I_PHONE,
    }

    public enum Stylus
    {
        YES,
        NO
    }

    class MobilePhone
    {
        string phoneName;
        ScreenType phoneScreen;
        OperatingSystem os;
        Stylus stylus;

        public MobilePhone (string name)
        {
            this.phoneName = name;
        }

        public ScreenType PhoneScreen {
            get { return this.phoneScreen; }
            set { this.phoneScreen = value; }
        }

        public OperatingSystem OS {
            get { return this.os; }
            set { this.os = value; }
        }

        public Stylus Stylus {
            get { return this.stylus; }
            set { this.stylus = value; }
        }

        public string PhoneName {
            get { return this.phoneName; }
        }

        public override string ToString ()
        {
            return string.Format ("[MobilePhone: PhoneScreen={0}, OS={1}, Stylus={2}, PhoneName={3}]", PhoneScreen, OS, Stylus, PhoneName);
        }
    }

    interface IPhoneBuilder
    {
        void BuildScreen ();

        void BuildOS ();

        void BuildStylus ();
    }

    class AndroidBuilder : IPhoneBuilder
    {
        public MobilePhone phone { get; set; }

        public AndroidBuilder ()
        {
            this.phone = new MobilePhone ("Android");
        }

        public void BuildScreen ()
        {
            phone.PhoneScreen = ScreenType.ScreenType_TOUCH;
        }

        public void BuildOS ()
        {
            phone.OS = OperatingSystem.ANDROID;
        }

        public void BuildStylus ()
        {
            phone.Stylus = Stylus.NO;
        }
    }

    //  class WindowsPhoneBuilder : IPhoneBuilder
    //  {
    //
    //  }

    class Manifacture
    {
        public void Construct (IPhoneBuilder phoneBuilder)
        {
            phoneBuilder.BuildOS ();
            phoneBuilder.BuildScreen ();
            phoneBuilder.BuildStylus ();
        }
    }
}
