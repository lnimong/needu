package md57925cc97df324ad50a50de7102d3c85a;


public class Splash
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Need_U.Droid.Splash, Need_U.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Splash.class, __md_methods);
	}


	public Splash () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Splash.class)
			mono.android.TypeManager.Activate ("Need_U.Droid.Splash, Need_U.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
