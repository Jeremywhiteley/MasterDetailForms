using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Navigation;
using Prism.Events;

using MasterDetailExample.Events;
using Xamarin.Forms;

namespace MasterDetailExample.ViewModels
{
	public class BaseDetailPageViewModel : BaseViewModel
	{
		private IEventAggregator _eventAggregator;

		public DelegateCommand NavigateMenuPageView { get; set; }

		public BaseDetailPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator):base(navigationService)
		{
			_eventAggregator = eventAggregator;
			NavigateMenuPageView = new DelegateCommand(NavigateToMenuPageView);
		}

		private async void NavigateToMenuPageView()
		{
			if (Device.Idiom == TargetIdiom.Phone)
			{
				await _navigationService.NavigateAsync("MenuPageView");
			}
			else
			{
				_eventAggregator.GetEvent<MenuPageViewNavigationEvent>().Publish();
			}
		}
	}
}
