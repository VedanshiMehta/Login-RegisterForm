using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginRegisterForm
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class ForgotPassword : Activity 
    {
        private EditText _myNewPasswordEditText;
        private EditText _myConfirmPasswordEditText;
        private EditText _myOtpEditText;
        private TextView _myOtpText;
        private Button _myConfirmButton;
    

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.forgotpass);
            UIRefernece();
            UIClick();

          
        }

        private void UIClick()
        {
            _myConfirmButton.Click += _mybutton_Click;
            _myOtpText.Click += _mytextOTP_Click;
        }

        private void _mybutton_Click(object sender, EventArgs e)
        {
            if (isValidateNewPassword() && isValidateConfirmPassword() && isValidateOtp())
            {
                Toast.MakeText(this, "Password changed Sucessfully", ToastLength.Short).Show();
                Finish();


            }
            else
            {

                Toast.MakeText(this, "Enter Details ", ToastLength.Short).Show();


            }
        }


        private bool isValidateNewPassword()
        {
            if (_myNewPasswordEditText.Text.Length == 0)
            {

                _myNewPasswordEditText.Error = "Enter New Password";
                return false;
            }
            else if (_myNewPasswordEditText.Text.Length < 8)
            {

                _myNewPasswordEditText.Error = "Invalid Password";
                return false;

            }
            return true;
        }

        private bool isValidateConfirmPassword()
        {
            if (_myConfirmPasswordEditText.Text.Length == 0)
            {

                _myConfirmPasswordEditText.Error = "Enter Password";
                return false;
            }
            else if (_myConfirmPasswordEditText.Text.Length < 8)
            {

                _myConfirmPasswordEditText.Error = "Invalid Password";
                return false;

            }
            else if (_myConfirmPasswordEditText.Text != _myNewPasswordEditText.Text)
            {

                _myConfirmPasswordEditText.Error = "Both password doesn't match";
                return false;

            }

            return true;
        }
        private bool isValidateOtp()
        {
            if (_myOtpEditText.Text.Length == 0)
            {

                _myOtpEditText.Error = "Enter OTP";
                return false;
            }
            else if (_myOtpEditText.Text.Length != 4)
            {

                _myOtpEditText.Error = "Invalid OTP";
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
            _myNewPasswordEditText = FindViewById<EditText>(Resource.Id.editTextNewPassword);
            _myConfirmPasswordEditText= FindViewById<EditText>(Resource.Id.editTextConfirmPassword);
            _myOtpEditText = FindViewById<EditText>(Resource.Id.editTextOtp);
            _myOtpText= FindViewById<TextView>(Resource.Id.textViewGenerateOtp);
            _myConfirmButton = FindViewById<Button>(Resource.Id.buttonConfirm);
        
            
        }

       

       
    }
}