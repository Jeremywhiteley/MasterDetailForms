using Prism.Navigation;
using Xamarin.Forms;

namespace MasterDetailExample.Views
{
	public partial class QuoteMasterDetailPageView : MasterDetailPage, IMasterDetailPageOptions
	{
		public QuoteMasterDetailPageView()
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

