using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

using Prism.Navigation;
using Prism.Events;

namespace MasterDetailExample.ViewModels
{
	public class QuoteDetailPageNoContentViewModel : BaseDetailPageViewModel
	{
		private string _message;
		public string Message
		{
			get { return _message; }
			set { SetProperty(ref _message, value); }
		}

		public QuoteDetailPageNoContentViewModel(INavigationService navigationService,
		                                	IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
		{
			Title = "Author";
			Message = "No Author Quote selected.  Please select an Author quote.";
		}
	}
}
