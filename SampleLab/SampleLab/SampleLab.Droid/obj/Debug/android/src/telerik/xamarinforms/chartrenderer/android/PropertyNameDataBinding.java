package telerik.xamarinforms.chartrenderer.android;


public class PropertyNameDataBinding
	extends com.telerik.widget.chart.engine.databinding.DataPointBinding
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_getValue:(Ljava/lang/Object;)Ljava/lang/Object;:GetGetValue_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.ChartRenderer.Android.PropertyNameDataBinding, Telerik.XamarinForms.ChartRenderer.Android, Version=2014.3.1315.130, Culture=neutral, PublicKeyToken=null", PropertyNameDataBinding.class, __md_methods);
	}


	public PropertyNameDataBinding () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PropertyNameDataBinding.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.PropertyNameDataBinding, Telerik.XamarinForms.ChartRenderer.Android, Version=2014.3.1315.130, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object getValue (java.lang.Object p0)
	{
		return n_getValue (p0);
	}

	private native java.lang.Object n_getValue (java.lang.Object p0);

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
