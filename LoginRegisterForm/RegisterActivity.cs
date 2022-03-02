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
        private TextView _myregister;
        private TextView _myRusername;
        private TextView _myRemailaddress;
        private EditText _myRusernameedts;
        private EditText _myRpassword;
        private Button _myresgisterB;
        private ImageView _myRfacebook;
        private ImageView _myRgoogle;
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
            _myresgisterB.Click += _resgister_Click;
            _myRgoogle.Click += _myRgoogle_Click;
            _myRfacebook.Click += _myRfacebook_Click;
        }

        private void _resgister_Click(object sender, EventArgs e)
        {


            if (myuserfill() && myemailfill() && myusernamefill() && mypasswordfill())
            {
                Toast.MakeText(this, "Registeration Sucessfull", ToastLength.Short).Show();

                Finish();

            }
            else
            {

                Toast.MakeText(this, "Enter Details", ToastLength.Short).Show();

            }



        }

        private bool mypasswordfill()
        {

            if (_myRpassword.Text.Length == 0)
            {

                _myRpassword.Error = "Enter Password";
                return false;


            }
            else if (_myRpassword.Text.Length < 8)
            {


                _myRpassword.Error = "Minimum length of  password should be 8";
                return false;
            }

            return true;
        }

        private bool myusernamefill()
        {

            if (_myRusernameedts.Text.Length == 0)
            {

                _myRusernameedts.Error = "Enter Username";
                _myRusernameedts.RequestFocus();

                return false;
            }
            else if (!isValiduser(_myRusernameedts.Text))
            {

                _myRusernameedts.Error = "Numbers and Special-Characters not allowed";
                _myRusernameedts.RequestFocus();
                return false;
            }

            return true;
        }

        private bool myemailfill()
        {

            if (_myRemailaddress.Text.Length == 0)
            {

                _myRemailaddress.Error = "Enter Email Address";

                return false;

            }
            else if (!isValidemail(_myRemailaddress.Text))
            {
                _myRemailaddress.Error = "Entered email address is not valid";

                return false;

            }
            return true;
        }

        private bool isValidemail(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return email.IsMatch(text);
        }

        private bool myuserfill()
        {

            if (_myRusername.Text.Length == 0)
            {

                _myRusername.Error = "Enter User Name";

                return false;

            }
            else if (!isValiduser(_myRusername.Text))
            {
                _myRusername.Error = "Numbers are not allowed";

                return false;

            }
            return true;
        }

        private bool isValiduser(string text)
        {
            if (string.IsNullOrEmpty(text))

                return false;

            return username.IsMatch(text);
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
            _myregister = FindViewById<TextView>(Resource.Id.texRegister);
            _myRusername = FindViewById<EditText>(Resource.Id.edittextuserR);
            _myRemailaddress = FindViewById<EditText>(Resource.Id.edittextemailaddressR);
            _myRusernameedts = FindViewById<EditText>(Resource.Id.edittextusernameR);
            _myRpassword = FindViewById<EditText>(Resource.Id.edittextpasswordR);
            _myresgisterB = FindViewById<Button>(Resource.Id.buttonregisterR);
            _myRfacebook = FindViewById<ImageView>(Resource.Id.imageviewfacebookR);
            _myRgoogle = FindViewById<ImageView>(Resource.Id.imageviewgoogleR);

            TextPaint paint = _myregister.Paint;
            float width = paint.MeasureText(_myregister.Text);
            int[] vs = new int[] {


                    Color.ParseColor("#002aba"),
                    Color.ParseColor("#002aba"),
                    Color.ParseColor("#f23ce7"),

            };

            Shader textshade = new LinearGradient(0, 150, width, _myregister.TextSize, vs, null, Shader.TileMode.Clamp);
            _myregister.Paint.SetShader(textshade);

        }
    }
}