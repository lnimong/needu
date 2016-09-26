package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (!initialized) {
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new java.io.File (
							android.os.Environment.getExternalStorageDirectory (),
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath (),
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				initialized = true;
			}
		}
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		"Need_U.Droid.dll",
		"Acr.Support.Android.dll",
		"Acr.UserDialogs.dll",
		"Acr.UserDialogs.Interface.dll",
		"AndHUD.dll",
		"ExifLib.dll",
		"FFImageLoading.dll",
		"FFImageLoading.Droid.dll",
		"FFImageLoading.Forms.dll",
		"FFImageLoading.Forms.Droid.dll",
		"FFImageLoading.Transformations.dll",
		"FormsViewGroup.dll",
		"GeoCoordinatePortable.dll",
		"mcpNetwork.HorizontalScrollLayout.dll",
		"ModernHttpClient.dll",
		"Need_U.dll",
		"Newtonsoft.Json.dll",
		"OkHttp.dll",
		"PCLStorage.Abstractions.dll",
		"PCLStorage.dll",
		"Plugin.CurrentActivity.dll",
		"Plugin.ExternalMaps.Abstractions.dll",
		"Plugin.ExternalMaps.dll",
		"Plugin.Geolocator.Abstractions.dll",
		"Plugin.Geolocator.dll",
		"Plugin.Media.Abstractions.dll",
		"Plugin.Media.dll",
		"Plugin.Permissions.Abstractions.dll",
		"Plugin.Permissions.dll",
		"Splat.dll",
		"SQLite-net.dll",
		"SQLitePCL.raw.dll",
		"System.Net.Http.Extensions.dll",
		"System.Net.Http.Primitives.dll",
		"TK.CustomMap.Android.dll",
		"TK.CustomMap.dll",
		"Xamarin.Android.Support.Design.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Android.Support.v7.AppCompat.dll",
		"Xamarin.Android.Support.v7.CardView.dll",
		"Xamarin.Android.Support.v7.MediaRouter.dll",
		"Xamarin.Auth.Android.dll",
		"Xamarin.Bolts.dll",
		"Xamarin.Facebook.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.Maps.Android.dll",
		"Xamarin.Forms.Maps.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Platform.dll",
		"Xamarin.Forms.Xaml.dll",
		"Xamarin.GooglePlayServices.Base.dll",
		"Xamarin.GooglePlayServices.Location.dll",
		"Xamarin.GooglePlayServices.Maps.dll",
		"XLabs.Core.dll",
		"XLabs.Forms.dll",
		"XLabs.Forms.Droid.dll",
		"XLabs.Ioc.dll",
		"XLabs.Platform.dll",
		"XLabs.Platform.Droid.dll",
		"XLabs.Serialization.dll",
		"System.Diagnostics.Tracing.dll",
		"System.Reflection.Emit.dll",
		"System.Reflection.Emit.ILGeneration.dll",
		"System.Reflection.Emit.Lightweight.dll",
		"System.ServiceModel.Security.dll",
		"System.Threading.Timer.dll",
		"System.ServiceModel.Internals.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_23";
}
