using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace MasterDetailExample.ViewModels
{
	public class DetailPageNoContentViewModel : BaseViewModel
	{
		public DetailPageNoContentViewModel(INavigationService navigationService):base(navigationService)
		{
			Title = "DetailPageNoContentView";
		}
	}
}
