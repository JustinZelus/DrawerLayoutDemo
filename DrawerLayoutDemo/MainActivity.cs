using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;

namespace DrawerLayoutDemo
{
    [Activity(Label = "DrawerLayoutDemo", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {   
        private DrawerLayout mDrawerLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitle(Resource.String.toolbar_home);
            SetSupportActionBar(toolbar);

            Android.Support.V7.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetDisplayHomeAsUpEnabled(true);
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            int id = e.MenuItem.ItemId;
            switch (id)
            {
                case Resource.Id.nav_map:
                    System.Diagnostics.Debug.WriteLine("item map clicked");
                    break;
                case Resource.Id.nav_file:
                    System.Diagnostics.Debug.WriteLine("item file clicked");
                    break;
                case Resource.Id.nav_tutorial:
                    System.Diagnostics.Debug.WriteLine("item tutorial clicked");
                    break;
                case Resource.Id.nav_setting:
                    System.Diagnostics.Debug.WriteLine("item setting clicked");
                    break;
            }

            // set item as selected to persist highlight
            e.MenuItem.SetChecked(true);
            mDrawerLayout.CloseDrawer((int)GravityFlags.Left, true);
        }
    }
}

