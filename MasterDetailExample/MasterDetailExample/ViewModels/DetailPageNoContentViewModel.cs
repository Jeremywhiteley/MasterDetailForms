using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

using Prism.Navigation;
using Prism.Events;

namespace MasterDetailExample.ViewModels
{
	public class DetailPageNoContentViewModel : BaseDetailPageViewModel
	{
		public DetailPageNoContentViewModel(INavigationService navigationService,
		                                	IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
		{
			Title = "DetailPageNoContentView";
		}
	}
}
