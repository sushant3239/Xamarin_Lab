package mono.com.telerik.widget.chart.visualization.behaviors;


public class TooltipContextNeededListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.telerik.widget.chart.visualization.behaviors.TooltipContextNeededListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onContextNeeded:(Lcom/telerik/widget/chart/visualization/behaviors/TooltipContextNeededEventArgs;)V:GetOnContextNeeded_Lcom_telerik_widget_chart_visualization_behaviors_TooltipContextNeededEventArgs_Handler:Com.Telerik.Widget.Chart.Visualization.Behaviors.ITooltipContextNeededListenerInvoker, Telerik.Xamarin.Android.Chart\n" +
			"";
		mono.android.Runtime.register ("Com.Telerik.Widget.Chart.Visualization.Behaviors.ITooltipContextNeededListenerImplementor, Telerik.Xamarin.Android.Chart, Version=2015.3.1312.0, Culture=neutral, PublicKeyToken=null", TooltipContextNeededListenerImplementor.class, __md_methods);
	}


	public TooltipContextNeededListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TooltipContextNeededListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Telerik.Widget.Chart.Visualization.Behaviors.ITooltipContextNeededListenerImplementor, Telerik.Xamarin.Android.Chart, Version=2015.3.1312.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onContextNeeded (com.telerik.widget.chart.visualization.behaviors.TooltipContextNeededEventArgs p0)
	{
		n_onContextNeeded (p0);
	}

	private native void n_onContextNeeded (com.telerik.widget.chart.visualization.behaviors.TooltipContextNeededEventArgs p0);

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
