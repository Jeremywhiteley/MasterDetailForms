using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace MasterDetailExample.ViewModels
{
	public class DetailClickEndPageViewModel : BaseViewModel
	{
		private string _itemName;
		public string ItemName
		{
			get { return _itemName; }
			set { SetProperty(ref _itemName, value); }
		}

		public DetailClickEndPageViewModel(INavigationService navigationService) : base(navigationService)
		{
			Title = "DetailClickEndPageView";
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
