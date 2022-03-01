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

        private void _mybutton_Click(object sender, EventArgs e)
        {
            if (passwordfill() && newpasswordfill() && otpfill())
            {
                Toast.MakeText(this, "Password changed Sucessfully", ToastLength.Short).Show();
                Finish();


            }
            else if (passwordfill() != newpasswordfill())
            {

                Toast.MakeText(this, "New Password doesn't match with current password", ToastLength.Short).Show();
            }
            else
            {

                Toast.MakeText(this, "Enter Details ", ToastLength.Short).Show();


            }
        }

        private bool otpfill()
        {
            if (_myOTPedts.Text.Length == 0)
            {

                _myOTPedts.Error = "Enter OTP";
                return false;
            }
            else if (_myOTPedts.Text.Length != 4)
            {

                _myOTPedts.Error = "Invalid OTP";
                return false;

            }
            return true;
        }

        private bool newpasswordfill()
        {
            if (_myFnewpassword.Text.Length == 0)
            {

                _myFnewpassword.Error = "Enter New Password";
                return false;
            }
            else if (_myFnewpassword.Text.Length < 8)
            {

                _myFnewpassword.Error = "Invalid Password";
                return false;

            }
            return true;
        }

        private bool passwordfill()
        {
            if (_myFpassword.Text.Length == 0)
            {

                _myFpassword.Error = "Enter Your current Password";
                return false;
            }
            else if (_myFpassword.Text.Length < 8)
            {

                _myFpassword.Error = "Invalid Password";
                return false;

            }
            return true;
        }


        private void _mytextOTP_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "OTP has been Sent to your email", ToastLength.Short).Show();
        }

        
        private void UIRefernece()
        {
            _myFpassword = FindViewById<EditText>(Resource.Id.passwordF);
            _myFnewpassword = FindViewById<EditText>(Resource.Id.newpasswordF);
            _myOTPedts = FindViewById<EditText>(Resource.Id.otpF);
            _mytextOTP = FindViewById<TextView>(Resource.Id.genrateOTPF);
            _mybutton = FindViewById<Button>(Resource.Id.confirmbF);

            //_myFpassword.Touch += _myFpassword_Touch;
        }

        /*private void _myFpassword_Touch(object sender, View.TouchEventArgs e)
        {
            
        }*/

       
    }
}