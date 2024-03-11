using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;
using System;
using static Android.Views.ViewGroup;

namespace IncomePlanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextInputEditText editTextPeso, editTextWorkedHours, editTextTaxRate, editTextSavingsRate;
        MaterialButton btnCalculate, btnClear;
        TextView textViewAnnualIncome, textViewAnnualWork, textViewSSS, textViewPhilHealth, textViewPagIbig, textViewIncomeTax, textViewTotalDeductions, textViewSavings, textViewNetPay;
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
            editTxtBasicPay = FindViewById<TextInputEditText>(Resource.Id.editTextBasicPay);
            editTextDays = FindViewById<TextInputEditText>(Resource.Id.editTextDays);
            editTextTaxRate = FindViewById<TextInputEditText>(Resource.Id.editTextTaxRate);
            editTextSavingsRate = FindViewById<TextInputEditText>(Resource.Id.editTextSavingsRate);

            // Buttons
            btnCalculate = FindViewById<MaterialButton>(Resource.Id.btnCalculate);
            btnClear = FindViewById<MaterialButton>(Resource.Id.btnClear);

            // TextView
            textViewBasicPay = FindViewById<TextView>(Resource.Id.editTextBasicPay);
            textViewSSS = FindViewById<TextView>(Resource.Id.textViewSSS);
            textViewPhilHealth = FindViewById<TextView>(Resource.Id.textViewPhilHealth);
            textViewPagIbig = FindViewById<TextView>(Resource.Id.textViewPagIbig);
            textViewIncomeTax = FindViewById<TextView>(Resource.Id.textViewIncomeTax);
            textViewTotalDeductions = FindViewById<TextView>(Resource.Id.textViewTotalDeductions);
            textViewSavings = FindViewById<TextView>(Resource.Id.textViewSavings);
            textViewNetPay = FindViewById<TextView>(Resource.Id.textViewNetPay);


            btnCalculate.Click += BtnCalculate_Click;
            btnCalculate.Click += BtnClear_Click;




        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            editTxtBasicPay.Text = "";
            editTextDays.Text = "";
            editTextTaxRate.Text = "";
            editTextSavingsRate.Text = "";
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            
        }




        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}