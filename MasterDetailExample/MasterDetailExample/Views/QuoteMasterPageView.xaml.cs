using Xamarin.Forms;
using Prism.Mvvm;
using MasterDetailExample.ViewModels;
using MasterDetailExample.Model;

namespace MasterDetailExample.Views
{
	public partial class QuoteMasterPageView : ContentPage
	{
		public QuoteMasterPageViewModel ViewModel
		{
			get { return BindingContext as QuoteMasterPageViewModel; }
		}

		public QuoteMasterPageView()
		{
			InitializeComponent();
			SetToolbarItems();

			lvQuotes.ItemSelected += (o, e) =>
			{
				if (e.SelectedItem is Quote)
				{
					var quote = e.SelectedItem as Quote;
					if (quote != null)
					{
						ViewModel.ItemClicked.Execute(quote);
					}
				}
			};
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
			var vm = this.BindingContext as QuoteMasterPageViewModel;
			if (vm != null)
			{
				vm.NavigateMenuPageView.Execute();
			}
		}

	}
}

