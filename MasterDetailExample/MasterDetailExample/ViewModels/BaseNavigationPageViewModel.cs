using Prism.Navigation;

namespace MasterDetailExample.ViewModels
{
	public class BaseNavigationPageViewModel : BaseViewModel
	{
		public BaseNavigationPageViewModel(INavigationService navigationService):base(navigationService) { Title = "BaseNavigationPage"; }

		public override void OnNavigatedFrom(NavigationParameters parameters)
		{
			base.OnNavigatedFrom(parameters);
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
		}
	}
}
