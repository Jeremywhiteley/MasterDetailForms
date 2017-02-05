using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using Xamarin.Forms;

namespace MasterDetailExample.ViewModels
{
	public class DetailPageViewModel : BaseViewModel
	{
		private string _itemName;
		public string ItemName
		{
			get { return _itemName; }
			set { SetProperty(ref _itemName, value); }
		}

		public new DelegateCommand NavigateCommand { get; set; }

		public DetailPageViewModel(INavigationService navigationService):base(navigationService)
		{ 
			Title = "DetailPageView";
			NavigateCommand = new DelegateCommand(NavigateToClickPageView);
		}

		public async void NavigateToClickPageView()
		{
			var parameter = new NavigationParameters($"id={ItemName}");
			await _navigationService.NavigateAsync("DetailClickPageView", parameter);
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				var id = parameters["id"] as string;
				ItemName = id;
			}
		}
	}
}
