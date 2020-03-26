using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Foundation;
using RealSimpleCircle.iOS;
using UIKit;
using Xamarin.Forms;

namespace IOTMobileApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("SwipeView_Experimental");
            //Forms.SetFlags("SwipeView_Experimental");

            ServicePointManager
                .ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(223,27, 61); //bar background
            UINavigationBar.Appearance.TintColor = UIColor.White; //Tint color of button items
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                Font = UIFont.FromName("HelveticaNeue-Light", (nfloat)20f),
                TextColor = UIColor.White
            });
            UINavigationBar.Appearance.BackgroundColor = UIColor.FromRGB(223, 27, 61);

            global::Xamarin.Forms.Forms.Init(); 
            CircleRenderer.Init();

            var dbName = "homeKit.sqlite";
            var folderName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"..", "Library");
            var fullPath = Path.Combine(folderName, dbName);
            LoadApplication(new App(fullPath));
            return base.FinishedLaunching(app, options);
        }
    }
}
