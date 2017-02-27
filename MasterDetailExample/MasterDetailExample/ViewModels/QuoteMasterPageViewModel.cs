using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms;
using Prism.Events;
using MasterDetailExample.Model;
using System.Collections.ObjectModel;
using MasterDetailExample.Repository;

namespace MasterDetailExample.ViewModels
{
	public class QuoteMasterPageViewModel : BaseViewModel
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly QuotesRepository _quotesRepository;

		private ObservableCollection<Quote> _randomQuotes;
		public ObservableCollection<Quote> RandomQuotes
		{
			get { return _randomQuotes; }
			set { SetProperty(ref _randomQuotes, value); }
		}

		public DelegateCommand NavigateMenuPageView { get; set; }

		public DelegateCommand<Quote> ItemClicked { get; set; }

		public QuoteMasterPageViewModel(
			INavigationService navigationService, 
			IEventAggregator eventAggregator,
			QuotesRepository quotesRepository
			)
			:base(navigationService) 
		{
			_quotesRepository = quotesRepository;
			_eventAggregator = eventAggregator;

			Title = "Quotes";
			ItemClicked = new DelegateCommand<Quote>(DoItemClicked);
			NavigateMenuPageView = new DelegateCommand(NavigateToMenuPageView);
			GetRandomQuotes();
		}

		private void GetRandomQuotes()
		{
			RandomQuotes = new ObservableCollection<Quote>(_quotesRepository.GetRandomQuotes());
		}

		private async void DoItemClicked(Quote itemValue)
		{
			//if on tablet or desktop send message to the master/detail manager to switch view
			if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
			{
				var message = new DetailPageViewNavigationMessage { Id = itemValue.AuthorValue.Id };
				_eventAggregator.GetEvent<DetailPageViewNavigationEvent>().Publish(message);
			}
			else
			{
				var navParameters = new NavigationParameters($"id={itemValue.AuthorValue.Id}");
				await _navigationService.NavigateAsync("QuoteDetailPageView", navParameters);
			}
		}

		private async void NavigateToMenuPageView()
		{
			await _navigationService.NavigateAsync("MenuPageView");
		}
	}
}
