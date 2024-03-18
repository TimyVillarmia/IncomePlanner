using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;
using System;
using static Android.Service.Voice.VoiceInteractionSession;
using static Android.Views.ViewGroup;

namespace IncomePlanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextInputEditText editTextPeso, editTextWorkedHours, editTextTaxRate, editTextSavingsRate;
        MaterialButton btnCalculate, btnClear;
        string SelectedPeriod;


        double PhilHealth = 0.05;
        double PagIbig = 150;
        double SSS = 0.045;
        double SavingRate;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // EditText
            editTextPeso = FindViewById<TextInputEditText>(Resource.Id.editTextPeso);
            editTextWorkedHours = FindViewById<TextInputEditText>(Resource.Id.editTextWorkedHours);
            editTextTaxRate = FindViewById<TextInputEditText>(Resource.Id.editTextTaxRate);
            editTextSavingsRate = FindViewById<TextInputEditText>(Resource.Id.editTextSavingsRate);

            // Buttons
            btnCalculate = FindViewById<MaterialButton>(Resource.Id.btnCalculate);
            btnClear = FindViewById<MaterialButton>(Resource.Id.btnClear);



            btnCalculate.Click += BtnCalculate_Click;
            btnCalculate.Click += BtnClear_Click;




        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            editTextPeso.Text = "";
            editTextWorkedHours.Text = "";
            editTextTaxRate.Text = "";
            editTextSavingsRate.Text = "";
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Activity1));
            //Add PutExtra method data to intent.    
            i.PutExtra("Income", editTextPeso.Text.ToString());
            //StartActivity    
            StartActivity(i);
        }




        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}