package md5a4734618bc4a81f5e454c130f97d4e57;


public class ListPlaceActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("FoodLocator.ListPlaceActivity, FoodLocator", ListPlaceActivity.class, __md_methods);
	}


	public ListPlaceActivity ()
	{
		super ();
		if (getClass () == ListPlaceActivity.class)
			mono.android.TypeManager.Activate ("FoodLocator.ListPlaceActivity, FoodLocator", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
