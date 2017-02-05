using Prism.Unity;
using MasterDetailExample.Views;
using MasterDetailExample.ViewModels;
using Xamarin.Forms;

namespace MasterDetailExample
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		async protected override void OnInitialized()
		{
			InitializeComponent();

			if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
			{
				await NavigationService.NavigateAsync("MasterDetailPageView/BaseNavigationPageView/DetailPageNoContentView");
			}
			else
			{
				await NavigationService.NavigateAsync("BaseNavigationPageView/MasterPageView");
			}
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MasterPageView, MasterPageViewModel>();
			Container.RegisterTypeForNavigation<MasterDetailPageView, MasterDetailPageViewModel>();
			Container.RegisterTypeForNavigation<DetailPageNoContentView, DetailPageNoContentViewModel>(); 
			Container.RegisterTypeForNavigation<DetailPageView, DetailPageViewModel>();
			Container.RegisterTypeForNavigation<DetailClickPageView, DetailClickPageViewModel>();
			Container.RegisterTypeForNavigation<DetailClickEndPageView, DetailClickEndPageViewModel>();
			Container.RegisterTypeForNavigation<BaseNavigationPageView, BaseNavigationPageViewModel>();

		}
	}
}

