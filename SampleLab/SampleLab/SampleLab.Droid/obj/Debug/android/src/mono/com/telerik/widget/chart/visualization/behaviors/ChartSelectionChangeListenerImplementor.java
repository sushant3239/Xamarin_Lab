package mono.com.telerik.widget.chart.visualization.behaviors;


public class ChartSelectionChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.telerik.widget.chart.visualization.behaviors.ChartSelectionChangeListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onSelectionChanged:(Lcom/telerik/widget/chart/visualization/behaviors/ChartSelectionContext;)V:GetOnSelectionChanged_Lcom_telerik_widget_chart_visualization_behaviors_ChartSelectionContext_Handler:Com.Telerik.Widget.Chart.Visualization.Behaviors.IChartSelectionChangeListenerInvoker, Telerik.Xamarin.Android.Chart\n" +
			"";
		mono.android.Runtime.register ("Com.Telerik.Widget.Chart.Visualization.Behaviors.IChartSelectionChangeListenerImplementor, Telerik.Xamarin.Android.Chart, Version=2015.3.1312.0, Culture=neutral, PublicKeyToken=null", ChartSelectionChangeListenerImplementor.class, __md_methods);
	}


	public ChartSelectionChangeListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ChartSelectionChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Telerik.Widget.Chart.Visualization.Behaviors.IChartSelectionChangeListenerImplementor, Telerik.Xamarin.Android.Chart, Version=2015.3.1312.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onSelectionChanged (com.telerik.widget.chart.visualization.behaviors.ChartSelectionContext p0)
	{
		n_onSelectionChanged (p0);
	}

	private native void n_onSelectionChanged (com.telerik.widget.chart.visualization.behaviors.ChartSelectionContext p0);

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
