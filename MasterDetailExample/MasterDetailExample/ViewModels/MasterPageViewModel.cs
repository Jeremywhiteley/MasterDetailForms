using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms;
using Prism.Events;

namespace MasterDetailExample.ViewModels
{
	public class MasterPageViewModel : BaseViewModel
	{
		private IEventAggregator _eventAggregator;

		public DelegateCommand NavigateMenuPageView { get; set; }

		public DelegateCommand<string> ItemClicked { get; set; }

		public MasterPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator):base(navigationService) 
		{
			_eventAggregator = eventAggregator;
			Title = "MasterPageView";
			ItemClicked = new DelegateCommand<string>(DoItemClicked);
			NavigateMenuPageView = new DelegateCommand(NavigateToMenuPageView);
		}

		private async void DoItemClicked(string itemValue)
		{
			var navParameters = new NavigationParameters($"id={itemValue}");
			//if on tablet or desktop send message to the master/detail manager to switch view
			if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
			{
				var message = new DetailPageViewNavigationMessage { Id = itemValue };
				_eventAggregator.GetEvent<DetailPageViewNavigationEvent>().Publish(message);
			}
			else
			{
				await _navigationService.NavigateAsync("DetailPageView", navParameters);
			}
		}

		private async void NavigateToMenuPageView()
		{
			await _navigationService.NavigateAsync("MenuPageView");
		}
	}
}
