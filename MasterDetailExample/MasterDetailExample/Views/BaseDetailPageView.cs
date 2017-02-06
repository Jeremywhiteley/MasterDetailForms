using System;
using MasterDetailExample.ViewModels;
using Prism.Navigation;
using Xamarin.Forms;

namespace MasterDetailExample.Views
{
	public class BaseDetailPageView : ContentPage
	{

		public BaseDetailPageView()
		{
			SetToolbarItems();		
		}

		private void SetToolbarItems()
		{
			var menuToolBarItem = new ToolbarItem("Menu", string.Empty, NavigateMenuPage, ToolbarItemOrder.Default, 0);
			this.ToolbarItems.Add(menuToolBarItem);
		}

		private void NavigateMenuPage()
		{
			var vm = this.BindingContext as BaseDetailPageViewModel;
			if (vm != null)
			{
				vm.NavigateMenuPageView.Execute();
			}
		}
	}
}

