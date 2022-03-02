using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Text.RegularExpressions;

namespace LoginRegisterForm
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        private TextView _myLoginText;
        private TextView _myCreateAccountText;
        private EditText _myUserNameEditText;
        private EditText _myPasswordEditText;
        private Button _myLoginButton;
        private TextView _myForgetPasswordText;
        private ImageView _myFacebookImage;
        private ImageView _myGoogleImage;
        private Regex userName = new Regex("^[a-z-A-Z]*$");
     
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReference();
            UIClickEvent();

           
        }


        private void UIClickEvent()
        {
            _myCreateAccountText.Click += _mycreateacc_Click;
            _myLoginButton.Click += _mylogin_Click;
            _myFacebookImage.Click += _myfacebook_Click;
            _myGoogleImage.Click += _mygoogle_Click;
            _myForgetPasswordText.Click += _forgetpassword_Click;
        }

        private void _mycreateacc_Click(object sender, EventArgs e)
        {
            Intent register = new Intent(this, typeof(RegisterActivity));
            StartActivity(register);
        }


        private void _mylogin_Click(object sender, EventArgs e)
        {


            if (isValidateUserName() && isValidatePassword())
            {
                Toast.MakeText(this, "Login Sucessfull", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Enter Detail", ToastLength.Short).Show();

            }


        }

        private void _forgetpassword_Click(object sender, EventArgs e)
        {
            Intent fp = new Intent(this, typeof(ForgotPassword));
            StartActivity(fp);
           
        }

        private void _mygoogle_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Hey Google", ToastLength.Short).Show();
        }

        private void _myfacebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Hey Facebook", ToastLength.Short).Show();
        }



        private bool isValidateUserName()
        {


            if (_myUserNameEditText.Text.Length == 0)
            {

                _myUserNameEditText.Error = "Enter Username";
                return false;

            }
            else if (!isValidUsername(_myUserNameEditText.Text))

            {
                _myUserNameEditText.Error = "Numbers and Special-Characters not allowed";
                return false;
            }
            return true;



        }

        private bool isValidUsername(string text)
        {
            if (string.IsNullOrEmpty(text))

                return false;


            return userName.IsMatch(text);

        }

        private bool isValidatePassword()
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


        private void UIReference()
        {
            _myLoginText = FindViewById<TextView>(Resource.Id.textViewLogin);
            _myCreateAccountText= FindViewById<TextView>(Resource.Id.textViewCreateAccount);
            _myUserNameEditText = FindViewById<EditText>(Resource.Id.editTextUserName);
            _myPasswordEditText = FindViewById<EditText>(Resource.Id.editTextPassword);
            _myLoginButton= FindViewById<Button>(Resource.Id.buttonLogin);
            _myForgetPasswordText = FindViewById<TextView>(Resource.Id.textViewForgotPassword);
            _myFacebookImage= FindViewById<ImageView>(Resource.Id.imageViewfacebook);
            _myGoogleImage = FindViewById<ImageView>(Resource.Id.imageViewGoogle);

            TextPaint paint = _myLoginText.Paint;
            float width = paint.MeasureText(_myLoginText.Text);

            int[] vs = new int[]{
                
                    Color.ParseColor("#002aba"),
                    Color.ParseColor("#002aba"),
                    Color.ParseColor("#f23ce7"),


                    };
            Shader textShader = new LinearGradient(0, 150 , width, _myLoginText.TextSize,
                    vs, null, Shader.TileMode.Clamp);
            _myLoginText.Paint.SetShader(textShader);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}