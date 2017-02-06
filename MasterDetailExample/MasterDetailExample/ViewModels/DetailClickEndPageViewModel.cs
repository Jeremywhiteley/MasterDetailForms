using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Events;

namespace MasterDetailExample.ViewModels
{
	public class DetailClickEndPageViewModel : BaseDetailPageViewModel
	{
		private string _itemName;
		public string ItemName
		{
			get { return _itemName; }
			set { SetProperty(ref _itemName, value); }
		}

		public DetailClickEndPageViewModel(INavigationService navigationService,
		                                 	IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
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
