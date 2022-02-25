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

namespace LoginRegisterForm
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class ForgotPassword : Activity
    {
        private EditText _myFpassword;
        private EditText _myFnewpassword;
        private TextView _mytextOTP;
        private EditText _myOTPedts;
        private Button _mybutton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.forgotpass);
            UIRefernece();
            UIClick();

          
        }

        private void UIClick()
        {
            _mybutton.Click += _mybutton_Click;
            _mytextOTP.Click += _mytextOTP_Click;
        }

        private void _mytextOTP_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "OTP has been Sent to your email", ToastLength.Short).Show();
        }

        private void _mybutton_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(_myFpassword.Text) || string.IsNullOrEmpty(_myFnewpassword.Text) || string.IsNullOrEmpty(_myOTPedts.Text))
            {
                Toast.MakeText(this, "Enter Details", ToastLength.Short).Show();
                

            }
           else
            {

                Toast.MakeText(this, "Password Changed Sucessfully", ToastLength.Short).Show();

            }
        }

        private void UIRefernece()
        {
            _myFpassword = FindViewById<EditText>(Resource.Id.editTextF1);
            _myFnewpassword = FindViewById<EditText>(Resource.Id.editTextF2);
            _myOTPedts = FindViewById<EditText>(Resource.Id.editTextF3);
            _mytextOTP = FindViewById<TextView>(Resource.Id.genrateOTP);
            _mybutton = FindViewById<Button>(Resource.Id.confirmbutton);
        }
    }
}