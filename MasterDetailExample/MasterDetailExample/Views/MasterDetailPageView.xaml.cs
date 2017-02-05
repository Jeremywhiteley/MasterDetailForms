using Prism.Navigation;
using Xamarin.Forms;

namespace MasterDetailExample.Views
{
	public partial class MasterDetailPageView : MasterDetailPage, IMasterDetailPageOptions
	{
		public MasterDetailPageView()
		{
			InitializeComponent();
		}

		public bool IsPresentedAfterNavigation
		{
			get
			{
				if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
					return true;
				return false;
			}
		}
	}
}

