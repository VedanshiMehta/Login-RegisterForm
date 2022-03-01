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
        private TextView _mylogin;
        private TextView _mydonthave;
        private TextView _mycreateacc;
        private EditText _myusernameedts;
        private EditText _mypassword;
        private Button _loginB;
        private TextView _forgetpassword;
        private ImageView _myfacebook;
        private ImageView _mygoogle;
        private Drawable errorIcon;
        private Regex username = new Regex("^[a-z-A-Z]*$");
     


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
            _mycreateacc.Click += _mycreateacc_Click;
            _loginB.Click += _mylogin_Click;
            _myfacebook.Click += _myfacebook_Click;
            _mygoogle.Click += _mygoogle_Click;
            _forgetpassword.Click += _forgetpassword_Click;
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

        private void _mylogin_Click(object sender, EventArgs e)
        {

           
             if (usernamefill() && passwordfill())
            {
                Toast.MakeText(this, "Loggedin Sucessfull", ToastLength.Short).Show();
            }
          
            
        }

      

        private bool passwordfill()
        {

           
            if (_mypassword.Text.Length == 0)
            {
                
                _mypassword.Error = "Enter Password";
                return false;
            }

            else if (_mypassword.Text.Length < 8)
            {

             
                _mypassword.Error = "Minimum length of  password should be 8";
                return false;
            }

            return true;

        }



        private bool usernamefill()
        {
            
            
            if (_myusernameedts.Text.Length == 0)
            {
               
                _myusernameedts.Error = "Enter Username";
                return false;
                
            }
            else if(!isValidateUsername(_myusernameedts.Text))

            {
                _myusernameedts.Error = "Numbers are not allowed";
                return false;
            }
            return true;

        }

        private bool isValidateUsername(string text)
        {
            if (string.IsNullOrEmpty(text))
            
                return false;
            

                return username.IsMatch(text);
            
        }

        private void _mycreateacc_Click(object sender, EventArgs e)
        {
            Intent register = new Intent(this, typeof(RegisterActivity));
            StartActivity(register);
        }

        private void UIReference()
        {
            _mylogin = FindViewById<TextView>(Resource.Id.textlogin);
            _mydonthave = FindViewById<TextView>(Resource.Id.txtView1);
            _mycreateacc = FindViewById<TextView>(Resource.Id.txtView2);
            _myusernameedts = FindViewById<EditText>(Resource.Id.editText1);
            _mypassword = FindViewById<EditText>(Resource.Id.editText2);
            _loginB = FindViewById<Button>(Resource.Id.loginbutton);
            _forgetpassword = FindViewById<TextView>(Resource.Id.forgotpass);
            _myfacebook = FindViewById<ImageView>(Resource.Id.facebookI);
            _mygoogle = FindViewById<ImageView>(Resource.Id.googleI);

            TextPaint paint = _mylogin.Paint;
            float width = paint.MeasureText(_mylogin.Text);

            int[] vs = new int[]{



                   
                    Color.ParseColor("#002aba"),
                    Color.ParseColor("#002aba"),
                    Color.ParseColor("#f23ce7"),


                    };
            Shader textShader = new LinearGradient(0, 150 , width, _mylogin.TextSize,
                    vs, null, Shader.TileMode.Clamp);
            _mylogin.Paint.SetShader(textShader);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}