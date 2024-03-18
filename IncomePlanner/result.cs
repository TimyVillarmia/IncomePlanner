using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncomePlanner
{
    [Activity(Label = "Activity1")]
    public class result : Activity
    {
        TextView resultAnnualIncome, resultWorkSummary, resultAnnualTax, resultAnnualSavings, resultSpendableIncome;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.result);

            // TextView
            resultAnnualIncome = FindViewById<TextView>(Resource.Id.resultAnnualIncome);
            resultWorkSummary = FindViewById<TextView>(Resource.Id.resultWorkSummary);
            resultAnnualTax = FindViewById<TextView>(Resource.Id.resultAnnualTax);
            resultAnnualSavings = FindViewById<TextView>(Resource.Id.resultAnnualSavings);
            resultSpendableIncome = FindViewById<TextView>(Resource.Id.resultSpendableIncome);

            //Get txt_Result TextView control from the Main.xaml Layout.      
            //Retrieve the data using Intent.GetStringExtra method    
            string Income = Intent.GetStringExtra("Income");
            string WorkSummary = Intent.GetStringExtra("WorkSummary");
            string AnnualTax = Intent.GetStringExtra("AnnualTax");
            string AnnualSavings = Intent.GetStringExtra("AnnualSavings");
            string SpendableIncome = Intent.GetStringExtra("SpendableIncome");
            resultAnnualIncome.Text = $"{Income}";
            resultWorkSummary.Text = $"{WorkSummary}";
            resultAnnualTax.Text = $"{AnnualTax}";
            resultAnnualSavings.Text = $"{AnnualSavings}";
            resultSpendableIncome.Text = $"{SpendableIncome}";
        }
    }
}