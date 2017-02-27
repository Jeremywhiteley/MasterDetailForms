using Prism.Unity;
using MasterDetailExample.Views;
using MasterDetailExample.ViewModels;
using Xamarin.Forms;

namespace MasterDetailExample
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected async override void OnInitialized()
		{
			InitializeComponent();

			if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
			{
				await NavigationService.NavigateAsync("QuoteMasterDetailPageView/BaseNavigationPageView/QuoteDetailPageNoContentView");
			}
			else
			{
				await NavigationService.NavigateAsync("BaseNavigationPageView/QuoteMasterPageView");
			}
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MenuPageView, MenuPageViewModel>();
			Container.RegisterTypeForNavigation<QuoteMasterPageView, QuoteMasterPageViewModel>();
			Container.RegisterTypeForNavigation<QuoteMasterDetailPageView, QuoteMasterDetailPageViewModel>();
			Container.RegisterTypeForNavigation<QuoteDetailPageNoContentView, QuoteDetailPageNoContentViewModel>(); 
			Container.RegisterTypeForNavigation<QuoteDetailPageView, QuoteDetailPageViewModel>();
			Container.RegisterTypeForNavigation<BaseNavigationPageView, BaseNavigationPageViewModel>();

		}
	}
}

