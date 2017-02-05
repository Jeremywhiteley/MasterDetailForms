using System;

using Xamarin.Forms;

namespace MasterDetailExample.Views
{
	public class BaseDetailPageView : ContentPage
	{
		public BaseDetailPageView()
		{
			this.ToolbarItems.Add(new ToolbarItem("Menu", string.Empty, DisplayMenu, ToolbarItemOrder.Default, 0));
		}

		private void DisplayMenu()
		{

		}
	}
}

