using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

using Xamarin.Forms;

using MasterDetailExample.Repository;
using MasterDetailExample.Model;
using System.Collections.ObjectModel;

namespace MasterDetailExample.ViewModels
{
	public class QuoteDetailPageViewModel : BaseDetailPageViewModel
	{
		private readonly QuotesRepository _quotesRepository;

		private Author _selectedAuthor; 
		public Author SelectedAuthor
		{
			get { return _selectedAuthor; }
			set { SetProperty(ref _selectedAuthor, value); }
		}

		private ObservableCollection<Quote> _authorQuotes;
		public ObservableCollection<Quote> AuthorQuotes
		{
			get { return _authorQuotes; }
			set { SetProperty(ref _authorQuotes, value); }
		}

		public new DelegateCommand NavigateCommand { get; set; }

		public QuoteDetailPageViewModel(INavigationService navigationService, 
		                           IEventAggregator eventAggregator,
		                           QuotesRepository quotesRepository 
		                          ):base(navigationService, eventAggregator)
		{
			_quotesRepository = quotesRepository;
			Title = "Author Quotes";

			NavigateCommand = new DelegateCommand(NavigateToClickPageView);
		}

		public async void NavigateToClickPageView()
		{
			var parameter = new NavigationParameters($"id={_selectedAuthor.Id}");
			await _navigationService.NavigateAsync("DetailClickPageView", parameter);
		}

		public override void OnNavigatingTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				int id = -1;
				var didParse = int.TryParse(parameters["id"].ToString(), out id);
				if (didParse && id > -1)
				{
					LoadAuthorQuotes(id);
				}
			}	
		}

		private void LoadAuthorQuotes(int authorId )
		{
			SelectedAuthor = _quotesRepository.GetAuthorById(authorId);
			if (_selectedAuthor != null)
			{
				if (IsTablet)
				{
					Title = $"{SelectedAuthor.FullName} Quotes";
				}
				AuthorQuotes = new ObservableCollection<Quote>(_quotesRepository.GetQuotesByAuthor(authorId));
			}
		}
	}
}
