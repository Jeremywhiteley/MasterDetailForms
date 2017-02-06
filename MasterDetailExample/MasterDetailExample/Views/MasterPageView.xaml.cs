using Xamarin.Forms;
using Prism.Mvvm;
using MasterDetailExample.ViewModels;

namespace MasterDetailExample.Views
{
	public partial class MasterPageView : ContentPage
	{
		public MasterPageView()
		{
			InitializeComponent();
			SetToolbarItems();
		}

		private void SetToolbarItems()
		{
			if (Device.Idiom == TargetIdiom.Phone)
			{
				var menuToolBarItem = new ToolbarItem("Menu", string.Empty, NavigateMenuPage, ToolbarItemOrder.Default, 0);
				this.ToolbarItems.Add(menuToolBarItem);
			}
		}

		private void NavigateMenuPage()
		{
			var vm = this.BindingContext as MasterPageViewModel;
			if (vm != null)
			{
				vm.NavigateMenuPageView.Execute();
			}
		}

	}
}

