using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Events;

namespace MasterDetailExample.ViewModels
{
	public class DetailClickPageViewModel : BaseDetailPageViewModel
	{
		private string _itemName;
		public string ItemName
		{
			get { return _itemName; }
			set { SetProperty(ref _itemName, value); }
		}

		public new DelegateCommand NavigateCommand { get; set; }

		public DetailClickPageViewModel(INavigationService navigationService,
		                             	IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
		{ 
			this.Title = "DetailClickPageView"; 
			NavigateCommand = new DelegateCommand(NavigateToClickEndPageView);
		}

		public async void NavigateToClickEndPageView()
		{
			var parameter = new NavigationParameters($"id={ItemName}");
			await _navigationService.NavigateAsync("DetailClickEndPageView", parameter);
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
