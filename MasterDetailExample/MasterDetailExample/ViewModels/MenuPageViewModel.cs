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
	public class MenuPageViewModel : BaseViewModel
	{
		public MenuPageViewModel(INavigationService navigationService): base(navigationService)
		{
			Title = "MenuPageView";
		}
	}
}
