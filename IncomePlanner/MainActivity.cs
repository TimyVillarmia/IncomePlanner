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
using System.Runtime.Remoting.Contexts;
using static Android.Service.Voice.VoiceInteractionSession;
using static Android.Views.ViewGroup;
using static System.Net.Mime.MediaTypeNames;

namespace IncomePlanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextInputEditText editTextHourlyRate, editTextWorkedHours, editTextTaxRate, editTextSavingsRate;
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
            editTextHourlyRate = FindViewById<TextInputEditText>(Resource.Id.editTextHourlyRate);
            editTextWorkedHours = FindViewById<TextInputEditText>(Resource.Id.editTextWorkedHours);
            editTextTaxRate = FindViewById<TextInputEditText>(Resource.Id.editTextTaxRate);
            editTextSavingsRate = FindViewById<TextInputEditText>(Resource.Id.editTextSavingsRate);

            // Buttons
            btnCalculate = FindViewById<MaterialButton>(Resource.Id.btnCalculate);



            btnCalculate.Click += BtnCalculate_Click;




        }


        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (editTextHourlyRate.Text != string.Empty)
            {
                double taxRate = double.Parse(editTextTaxRate.Text) / 100;
                double savingsRate = double.Parse(editTextSavingsRate.Text) / 100;

                double annualIncome = 250 * (double.Parse(editTextHourlyRate.Text) * double.Parse(editTextWorkedHours.Text));
                double annualWorkedHour = 250 * double.Parse(editTextWorkedHours.Text);
                double annualTaxIncome = annualIncome * taxRate;
                double annualSavings = annualIncome * savingsRate;
                double SpendableIncome = annualIncome - annualTaxIncome - annualSavings;





                Intent i = new Intent(this, typeof(result));
                //Add PutExtra method data to intent.    
                i.PutExtra("Income", annualIncome.ToString("N0"));
                i.PutExtra("WorkSummary", annualWorkedHour.ToString("N0"));
                i.PutExtra("AnnualTax", annualTaxIncome.ToString("N0"));
                i.PutExtra("AnnualSavings", annualSavings.ToString("N0"));
                i.PutExtra("SpendableIncome", SpendableIncome.ToString("N0"));
                //StartActivity    
                StartActivity(i);
            }
            else
            {
                string toast = string.Format("Please complete all fields");
                Toast.MakeText(this, toast, ToastLength.Long).Show();

            }
  
        }




        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}