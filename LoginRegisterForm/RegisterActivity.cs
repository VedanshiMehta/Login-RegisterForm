using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LoginRegisterForm
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RegisterActivity : Activity
    {
        private TextView _myRegisterText;
        private EditText _myUserEditText;
        private EditText _myEmailAddressEditText;
        private EditText _myUserNameEditText;
        private EditText _myPasswordEditText;
        private Button _myResgisterButton;
        private ImageView _myFacebookImage;
        private ImageView _myGoogleImage;
        private Regex username = new Regex("^[a-z-A-Z]*$");
        private Regex email = new Regex(@"^[a-z]([\w]*[\w\.]*(?!\.)@gmail.com)");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RegistrationForm);
            UIReference();
            UIClickevents();


        }

        private void UIClickevents()
        {
            _myResgisterButton.Click += _resgister_Click;
            _myFacebookImage.Click += _myRfacebook_Click;
            _myGoogleImage.Click += _myRgoogle_Click;
            
        }

        private void _resgister_Click(object sender, EventArgs e)
        {


            if (isValidateUserfill() && isValidateEmail() && isValidateUserNameRegister() && isValidatePasswordRegister())
            {
                Toast.MakeText(this, "Registeration Sucessfull", ToastLength.Short).Show();

                Finish();

            }
            else
            {

                Toast.MakeText(this, "Enter Details", ToastLength.Short).Show();

            }



        }
        private bool isValidateUserfill()
        {

            if (_myUserEditText.Text.Length == 0)
            {

                _myUserEditText.Error = "Enter User Name";

                return false;

            }
            else if (!isValidUser(_myUserEditText.Text))
            {
                _myUserEditText.Error = "Numbers are not allowed";

                return false;

            }
            return true;
        }

        private bool isValidUser(string text)
        {
            if (string.IsNullOrEmpty(text))

                return false;

            return username.IsMatch(text);
        }
        private bool isValidateEmail()
        {

            if (_myEmailAddressEditText.Text.Length == 0)
            {

                _myEmailAddressEditText.Error = "Enter Email Address";

                return false;

            }
            else if (!isValidEmail(_myEmailAddressEditText.Text))
            {
                _myEmailAddressEditText.Error = "Entered email address is not valid";

                return false;

            }
            return true;
        }

        private bool isValidEmail(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return email.IsMatch(text);
        }


        private bool isValidateUserNameRegister()
        {

            if (_myUserNameEditText.Text.Length == 0)
            {

                _myUserNameEditText.Error = "Enter Username";
                _myUserNameEditText.RequestFocus();

                return false;
            }
            else if (!isValidUser(_myUserNameEditText.Text))
            {

                _myUserNameEditText.Error = "Numbers and Special-Characters not allowed";
                _myUserNameEditText.RequestFocus();
                return false;
            }

            return true;
        }

        private bool isValidatePasswordRegister()
        {

            if (_myPasswordEditText.Text.Length == 0)
            {

                _myPasswordEditText.Error = "Enter Password";
                return false;


            }
            else if (_myPasswordEditText.Text.Length < 8)
            {


                _myPasswordEditText.Error = "Minimum length of  password should be 8";
                return false;
            }

            return true;
        }

       

   

       
     

        private void _myRfacebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Hey Facebook", ToastLength.Short).Show();
        }

        private void _myRgoogle_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Hey Google", ToastLength.Short).Show();
        }

       

        private void UIReference()
        {
            _myRegisterText = FindViewById<TextView>(Resource.Id.textRegister);
            _myUserEditText= FindViewById<EditText>(Resource.Id.editTextUser);
            _myEmailAddressEditText = FindViewById<EditText>(Resource.Id.editTextEmailAddress);
            _myUserNameEditText = FindViewById<EditText>(Resource.Id.editTextUserNameRegister);
            _myPasswordEditText = FindViewById<EditText>(Resource.Id.editTextPasswordRegister);
            _myResgisterButton = FindViewById<Button>(Resource.Id.buttonRegister);
            _myFacebookImage = FindViewById<ImageView>(Resource.Id.imageViewFacebookRegister);
            _myGoogleImage = FindViewById<ImageView>(Resource.Id.imageViewGoogleRegister);

            TextPaint paint = _myRegisterText.Paint;
            float width = paint.MeasureText(_myRegisterText.Text);
            int[] vs = new int[] {


                    Color.ParseColor("#002aba"),
                    Color.ParseColor("#002aba"),
                    Color.ParseColor("#f23ce7"),

            };

            Shader textshade = new LinearGradient(0, 150, width, _myRegisterText.TextSize, vs, null, Shader.TileMode.Clamp);
            _myRegisterText.Paint.SetShader(textshade);

        }
    }
}