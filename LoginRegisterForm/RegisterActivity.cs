using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace LoginRegisterForm
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RegisterActivity : Activity
    {
        private TextView _myregister;
        private TextView _myRdonthave;
        private TextView _myRcreateacc;
        private TextView _myRusername;
        private TextView _myRemailaddress;
        private EditText _myRusernameedts;
        private EditText _myRpassword;
        private Button _resgister;
        private ImageView _myRfacebook;
        private ImageView _myRgoogle;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegistrationForm);
            UIReference();
            UIClickevents();
        }

        private void UIClickevents()
        {
            _resgister.Click += _resgister_Click;
            _myRgoogle.Click += _myRgoogle_Click;
            _myRfacebook.Click += _myRfacebook_Click;
        }

        private void _myRfacebook_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Hey Facebook", ToastLength.Short).Show();
        }

        private void _myRgoogle_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Hey Google", ToastLength.Short).Show();
        }

        private void _resgister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_myRusername.Text) || string.IsNullOrEmpty(_myRemailaddress.Text) || string.IsNullOrEmpty(_myRusernameedts.Text) || string.IsNullOrEmpty(_myRpassword.Text))
            {
                Toast.MakeText(this, "Enter details", ToastLength.Short).Show();
             
            }

            else
            {

                Toast.MakeText(this, "Registeration Sucessfull", ToastLength.Short).Show();
               
                Finish();
            }
           
        }

        private void UIReference()
        {
            _myregister = FindViewById<TextView>(Resource.Id.texRegister);
            _myRdonthave = FindViewById<TextView>(Resource.Id.txtViewR1);
            _myRcreateacc = FindViewById<TextView>(Resource.Id.txtViewR2);
            _myRusername = FindViewById<EditText>(Resource.Id.editTextR1);
            _myRemailaddress = FindViewById<EditText>(Resource.Id.editTextR2);
            _myRusernameedts = FindViewById<EditText>(Resource.Id.editTextR3);
            _myRpassword = FindViewById<EditText>(Resource.Id.editTextR4);
            _resgister = FindViewById<Button>(Resource.Id.registerbutton);
            _myRfacebook = FindViewById<ImageView>(Resource.Id.facebookRI);
            _myRgoogle = FindViewById<ImageView>(Resource.Id.googleRI);

            TextPaint paint = _myregister.Paint;
            float width = paint.MeasureText(_myregister.Text);

      


            int[] vs = new int[] {



                    Color.ParseColor("#000060"),
                    Color.ParseColor("#000060"),
                    Color.ParseColor("#209FF1"),



            };

            Shader textshade = new LinearGradient(0, 150, width, _myregister.TextSize, vs, null, Shader.TileMode.Clamp);
            _myregister.Paint.SetShader(textshade);

        }
    }
}