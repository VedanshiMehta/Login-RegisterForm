using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

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
            if (string.IsNullOrEmpty(_myusernameedts.Text) || string.IsNullOrEmpty(_mypassword.Text))
            {
                Toast.MakeText(this, "Enter details", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Loggedin Sucessfull", ToastLength.Short).Show();

                
            }
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

            int[] vs = new int[] {



                    Color.ParseColor("#000060"),
                    Color.ParseColor("#000060"),
                    Color.ParseColor("#209FF1"),



            };

            Shader textshade = new LinearGradient(0 , 150, width, _mylogin.TextSize, vs, null, Shader.TileMode.Clamp);
            _mylogin.Paint.SetShader(textshade);
            

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}