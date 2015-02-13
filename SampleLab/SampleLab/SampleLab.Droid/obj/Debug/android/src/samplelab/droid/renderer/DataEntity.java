package samplelab.droid.renderer;


public class DataEntity
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SampleLab.Droid.Renderer.DataEntity, SampleLab.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DataEntity.class, __md_methods);
	}


	public DataEntity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DataEntity.class)
			mono.android.TypeManager.Activate ("SampleLab.Droid.Renderer.DataEntity, SampleLab.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
